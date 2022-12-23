using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SupremePowerPointApp
{
    public class Rootobject
    {
        public PresentatieObject Presentatie { get; set; }
    }

    public class PresentatieObject
    {
        public DiaObject[] Dia { get; set; }
    }

    public class DiaObject
    {
        public int diaNummer { get; set; }
        public string achtergrondKleur { get; set; }
    }

    internal class JsonPresentatieReader : IPresentatieReader
    {
        public string PresentatieFileInhoud { get; private set; } = "";
        public IEnumerator GetEnumerator()
        {
            var myDeserializedClass = JsonConvert.DeserializeObject<Rootobject>(PresentatieFileInhoud);
            foreach (DiaObject diaObject in myDeserializedClass.Presentatie.Dia)
            {
                Dia dia = new Dia(diaObject.diaNummer);
                yield return dia;
            }
        }

        public bool openPresentatie(string presentatieBestand)
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(presentatieBestand))
                {
                    PresentatieFileInhoud = streamReader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                return true;
            }
            return false;
        }
    }
}
