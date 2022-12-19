using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SupremePowerPointApp
{
    internal class PresentatieBouwer
    {
        private Presentatie? presentatie = new Presentatie();
        private IPresentatieReader presentatieReader;

        public PresentatieBouwer(IPresentatieReader presentatieReader, String presentatieBestand)
        {
            this.presentatieReader = presentatieReader;
            
            if (!presentatieReader.openPresentatie(presentatieBestand))
            { // Kan presentatiebestand niet openen
                presentatie = null;
                return;
            }

            foreach (Dia dia in presentatieReader)
            {
                presentatie.addDia(dia);
            }
        }

        public Presentatie? getPresentatie()
        {
            return presentatie;
        }
    }
}
