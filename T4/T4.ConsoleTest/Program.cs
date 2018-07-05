using Microsoft.VisualStudio.TextTemplating;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MyTextTemplatingEngineHost host = new MyTextTemplatingEngineHost();
            Engine engine = new Engine();
            host.TemplateFileValue = AppDomain.CurrentDomain.BaseDirectory + "Entity.tt";
            //Read the text template.  
            string input = File.ReadAllText(host.TemplateFileValue);
            //Transform the text template.  
            string output = engine.ProcessTemplate(input, host);
            string outputFileName = Path.GetFileNameWithoutExtension(host.TemplateFileValue);
            outputFileName = Path.Combine(Path.GetDirectoryName(host.TemplateFileValue), outputFileName);
            outputFileName = outputFileName + "1" + host.FileExtension;
            File.WriteAllText(outputFileName, output, host.FileEncoding);
        }
    }
}
