using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SupremePowerPointApp
{
    internal interface ILayout
    {
        public int layoutNumber { get; set; }

        public string getTextElement();

        public BitmapImage getAfbeeldingElement();
    }
}
