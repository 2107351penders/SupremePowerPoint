using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupremePowerPointApp
{
    internal class Dia
    {
        public int diaNummer { get; private set; }
        public Layout diaLayout { get; private set; }
        public Color achtergrondKleur { get; private set; }
        public Dia(int diaNummer)
        {
            this.diaNummer = diaNummer;
        }
    }
}
