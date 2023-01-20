﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupremePowerPointApp
{
    internal class Layout_TextImage : ILayout
    {
        public int layoutNumber = 2;
        public TextImageText linker_tekstvak;
        public TextImageAfbeelding rechter_afbeelding;
        
        public Layout_TextImage(string tekst, string afbeeldingBestand)
        {
            linker_tekstvak = new TextImageText(0, 300, tekst);
            rechter_afbeelding = new TextImageAfbeelding(600, 0, afbeeldingBestand);
        }
    }

    internal class TextImageText : IText
    {
        public int pos_x { get; set; }
        public int pos_y { get; set; }
        public string text { get; set; }

        public TextImageText(int pos_x, int pos_y, string text)
        {
            this.pos_x = pos_x;
            this.pos_y = pos_y;
            this.text = text;
        }
    }

    internal class TextImageAfbeelding : IAfbeelding
    {
        public int pos_x { get; set; }
        public int pos_y { get; set; }
        public string afbeeldingBestand { get; set; }

        public TextImageAfbeelding(int pos_x, int pos_y, string afbeeldingBestand)
        {
            this.pos_x = pos_x;
            this.pos_y = pos_y;
            this.afbeeldingBestand = afbeeldingBestand;
        }
    }
}