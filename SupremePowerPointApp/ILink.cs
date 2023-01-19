using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupremePowerPointApp
{
    internal interface ILink
    {
        public int pos_x { get; set; }
        public int pos_y { get; set; }
        public string text { get; set; }
        public int diaVerwijzing { get; set; }
    }
}
