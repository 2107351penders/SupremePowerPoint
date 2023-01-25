using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SupremePowerPointApp
{
    internal class Layout_Images : ILayout
    {
        public int layoutNumber { get; set; } = 3;
        public ImagesAfbeelding linker_afbeelding;
        public ImagesAfbeelding rechter_afbeelding;
        
        public Layout_Images(string afbeeldingsBestandLinks, string afbeeldingBestandRechts)
        {
            linker_afbeelding = new ImagesAfbeelding(0, 300, afbeeldingsBestandLinks);
            rechter_afbeelding = new ImagesAfbeelding(600, 0, afbeeldingBestandRechts);
        }

        public string getTextElement()
        {
            throw new NotImplementedException();
        }

        public BitmapImage getAfbeeldingElement()
        {
            return new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + linker_afbeelding.afbeeldingBestand, UriKind.Absolute));
        }
    }

    internal class ImagesAfbeelding : IAfbeelding
    {
        public int pos_x { get; set; }
        public int pos_y { get; set; }
        public string afbeeldingBestand { get; set; }

        public ImagesAfbeelding(int pos_x, int pos_y, string afbeeldingBestand)
        {
            this.pos_x = pos_x;
            this.pos_y = pos_y;
            this.afbeeldingBestand = afbeeldingBestand;
        }
    }
}
