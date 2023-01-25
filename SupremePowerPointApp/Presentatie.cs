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
        public int zichtbareDia { get; private set; } = 1;

        public int getDiaCount()
        {
            return diaLijst.Count;
        }

        public Dia? displayDia(int diaNummer)
        {
            foreach (Dia dia in this.diaLijst)
            {
                if (dia.diaNummer == diaNummer)
                {
                    zichtbareDia = diaNummer;
                    return dia;
                }
            }
            return null;
        }

        public void addDia(Dia dia)
        {
            diaLijst.Add(dia);
        }
    }
}
