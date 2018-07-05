using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baidu.Lib.Entity
{
    public class Coord
    {
        public float X { get; set; }

        public float Y { get; set; }

        public override string ToString()
        {
            return X + "," + Y;
        }
    }

    public class Coords
    {
        public List<Coord> Value { get; set; }

        public override string ToString()
        {
            var str = string.Empty;
            foreach(Coord coord in Value)
            {
                str += coord.ToString() + ";";
            }
            return str.Substring(0, str.Length - 1);
        }
    }
}
