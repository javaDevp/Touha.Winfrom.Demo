using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace cn.touha.tools.lib.codedom
{
    public class CodeGenHelper
    {
        public static string GenCSharpFromXml(string xml)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(xml);

            XmlElement root = xdoc.DocumentElement;
            CodeTypeDeclaration type = new CodeTypeDeclaration(root.Name);
            StringBuilder sb = new StringBuilder();

            foreach (XmlNode childNode in root.ChildNodes)
            {
                AddProperty(sb, type, childNode);
            }
            sb.Append(GenCodeFromType(type));
            return sb.ToString();
        }

        private static void AddProperty(StringBuilder sb, CodeTypeDeclaration type, XmlNode childNode)
        {
            bool IsCon = false;
            if (childNode.HasChildNodes)
            {
                IsCon = false;
                CodeTypeDeclaration childType = new CodeTypeDeclaration(childNode.Name);
                foreach (XmlNode gransonNode in childNode.ChildNodes)
                {
                    if (gransonNode.NodeType != XmlNodeType.Text)
                    {
                        IsCon = true;
                        AddProperty(sb, childType, gransonNode);
                    }
                }
                if (IsCon)
                    sb.Append(GenCodeFromType(childType));
            }
            CodeMemberField field = new CodeMemberField();
            field.Name = "_" + childNode.Name;
            field.Type = IsCon ? new CodeTypeReference(childNode.Name) : new CodeTypeReference(typeof(string));
            field.Attributes = MemberAttributes.Private | MemberAttributes.Final;
            type.Members.Add(field);
            CodeMemberProperty property = new CodeMemberProperty();
            property.Name = childNode.Name;
            property.HasSet = true;
            property.HasGet = true;
            property.Type = IsCon ? new CodeTypeReference(childNode.Name) : new CodeTypeReference(typeof(string));
            property.GetStatements.Add(new CodeMethodReturnStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "_" + childNode.Name)));
            property.SetStatements.Add(new CodeAssignStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "_" + childNode.Name), new CodePropertySetValueReferenceExpression()));
            property.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            type.Members.Add(property);
            
        }

        private static string GenCodeFromType(CodeTypeDeclaration type)
        {
            StringBuilder sb = new StringBuilder();
            using (System.IO.StringWriter sw = new System.IO.StringWriter(sb))
            {
                CodeGeneratorOptions geneOptions = new CodeGeneratorOptions();
                geneOptions.BlankLinesBetweenMembers = true;
                geneOptions.BracingStyle = "C";
                geneOptions.IndentString = "    ";
                CodeDomProvider.CreateProvider("CSharp").GenerateCodeFromType(type, sw, geneOptions);
            }
            return sb.ToString();
        }
    }
}
