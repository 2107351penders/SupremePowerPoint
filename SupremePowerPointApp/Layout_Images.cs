using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupremePowerPointApp
{
    internal class Layout_Images : ILayout
    {
        public int layoutNumber = 3;
        public ImagesAfbeelding linker_afbeelding;
        public ImagesAfbeelding rechter_afbeelding;
        
        public Layout_Images(string afbeeldingsBestandLinks, string afbeeldingBestandRechts)
        {
            linker_afbeelding = new ImagesAfbeelding(0, 300, afbeeldingsBestandLinks);
            rechter_afbeelding = new ImagesAfbeelding(600, 0, afbeeldingBestandRechts);
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
