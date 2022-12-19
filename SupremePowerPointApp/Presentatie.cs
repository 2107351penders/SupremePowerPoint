using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupremePowerPointApp
{
    internal class Presentatie
    {
        private List<Dia> diaLijst = new List<Dia>();
        public int zichtbareDia { get; private set; } = 0;

        public bool displayDia(int diaNummer)
        {
            zichtbareDia= diaNummer;
            // Display dia. Return true wanneer dit lukt
            return true;
        }

        public void addDia(Dia dia)
        {
            diaLijst.Add(dia);
        }
    }
}
