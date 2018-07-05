using Baidu.Lib.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baidu.Lib.Response
{
    public class CoordsConvertResponse
    {
        public int Status { get; set; }

        public Coord[] Result { get; set; }
    }
}
