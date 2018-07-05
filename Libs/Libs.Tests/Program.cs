using Baidu.Lib;
using Baidu.Lib.Request;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            CoordsConvert();
            IPConvert();


        }


        private static void CoordsConvert()
        {
            CoordsConvertRequest req = new CoordsConvertRequest();
            req.Coords = new Baidu.Lib.Entity.Coords { Value = new List<Baidu.Lib.Entity.Coord> { new Baidu.Lib.Entity.Coord { X = 114.21892734521f, Y = 114.21892734521f } } };
            req.From = 1;
            req.To = 5;
            req.Ak = ConfigurationManager.AppSettings["AK"];
            CoordsConvertService service = new CoordsConvertService();
            var response = service.Execute(req);
        }

        private static void IPConvert()
        {
            IPConvertRequest req = new IPConvertRequest();
            req.Ak = ConfigurationManager.AppSettings["AK"];
            IPConvertService service = new IPConvertService();
            var response = service.Execute(req);
        }
    }
}
