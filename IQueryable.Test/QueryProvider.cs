using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyQueryable.Test
{
    public class QueryProvider : IQueryProvider
    {
        public QueryProvider()
        {

        }

        public IQueryable CreateQuery(Expression expression)
        {
            Type elementType = TypeSystem.GetElementType(expression.Type);
            try
            {
                return (IQueryable)Activator.CreateInstance(typeof(Queryable<>).MakeGenericType(elementType), new object[] { this, expression });
            }
            catch (TargetInvocationException tie)
            {
                throw tie.InnerException;
            }
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            AnalysisExpression(expression);
            return new Queryable<TElement>(this, expression);
        }

        object IQueryProvider.Execute(Expression expression)
        {
            return this.Execute(expression);
        }

        TResult IQueryProvider.Execute<TResult>(Expression expression)
        {
            return (TResult)this.Execute(expression);
        }


        public string GetQueryText(Expression expression)
        {
            return "";
        }

        public object Execute(Expression expression)
        {
            return "123";
        }

        public void AnalysisExpression(Expression exp)
        {
            switch (exp.NodeType)
            {
                case ExpressionType.Call:
                    {
                        MethodCallExpression mce = exp as MethodCallExpression;
                        Console.WriteLine("The Method Is {0}", mce.Method.Name);
                        for (int i = 0; i < mce.Arguments.Count; i++)
                        {
                            AnalysisExpression(mce.Arguments[i]);
                        }
                    }
                    break;
                case ExpressionType.Quote:
                    {
                        UnaryExpression ue = exp as UnaryExpression;
                        AnalysisExpression(ue.Operand);
                    }
                    break;
                case ExpressionType.Lambda:
                    {
                        LambdaExpression le = exp as LambdaExpression;
                        AnalysisExpression(le.Body);
                    }
                    break;
                case ExpressionType.Equal:
                    {
                        BinaryExpression be = exp as BinaryExpression;
                        Console.WriteLine("The Method Is {0}", exp.NodeType.ToString());
                        AnalysisExpression(be.Left);
                        AnalysisExpression(be.Right);
                    }
                    break;
                case ExpressionType.Constant:
                    {
                        ConstantExpression ce = exp as ConstantExpression;
                        Console.WriteLine("The Value Type Is {0}", ce.Value.ToString());
                    }
                    break;
                case ExpressionType.Parameter:
                    {
                        ParameterExpression pe = exp as ParameterExpression;
                        Console.WriteLine("The Parameter Is {0}", pe.Name);
                    }
                    break;
                default:
                    {
                        Console.Write("UnKnow");
                    }
                    break;
            }
        }
    }
}
