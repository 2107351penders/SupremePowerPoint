using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SupremePowerPointApp
{
    internal class Layout_Outro : ILayout
    {
        public int layoutNumber { get; set; } = 4;
        public OutroText outro_tekst;

        public Layout_Outro(string tekst, string? element2 = null)
        {
            outro_tekst = new OutroText(0, 400, tekst);
        }

        public string getTextElement()
        {
            return outro_tekst.text;
        }

        public BitmapImage getAfbeeldingElement()
        {
            throw new NotImplementedException();
        }
    }

    internal class OutroText : IText
    {
        public int pos_x { get; set; }
        public int pos_y { get; set; }
        public string text { get; set; }

        public OutroText(int pos_x, int pos_y, string text)
        {
            this.pos_x = pos_x;
            this.pos_y = pos_y;
            this.text = text;
        }
    }
}

