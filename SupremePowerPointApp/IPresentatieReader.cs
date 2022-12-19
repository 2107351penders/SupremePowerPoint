using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupremePowerPointApp
{
    /* Een IPresentatieReader moet een bestand met een presentatie erin kunnen openen.
     * De dia's van deze presentatie worden dan als een IEnumerable beschikbaar gemaakt
     * zodat we er met foreach over heen kunnen lopen in de PresentatieBouwer
     */
    internal interface IPresentatieReader : IEnumerable
    {
        public bool openPresentatie(String presentatieBestand);
    }
}
