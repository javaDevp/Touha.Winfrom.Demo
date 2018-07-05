using Baidu.Lib.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baidu.Lib.Response
{
    public class IPConvertResponse
    {
        public string Address { get; set; }

        public int Status { get; set; }

        public Content Content { get; set; }
    }
}
