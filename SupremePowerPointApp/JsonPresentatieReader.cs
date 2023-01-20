using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public int diaLayout { get; set; }
        public string achtergrondKleur { get; set; }

    }

    internal class JsonPresentatieReader : IPresentatieReader
    {
        public string PresentatieFileInhoud { get; private set; } = "";

        public ILayout getLayout(int layout_number)
        {
            ILayout? layout = null;
            
            if (layout_number == 1)
            {
                layout = new Layout_Intro("test", "test");
            } else if (layout_number == 2) {
                layout = new Layout_TextImage("test", "test");
            } else if (layout_number == 3) {
                layout = new Layout_Images("test", "test");
            } else if (layout_number == 4) {
                layout = new Layout_Outro("test");
            }
            return layout;
        }

        public IEnumerator GetEnumerator()
        {
            var myDeserializedClass = JsonConvert.DeserializeObject<Rootobject>(PresentatieFileInhoud);
            foreach (DiaObject diaObject in myDeserializedClass.Presentatie.Dia)
            {
                Dia dia = new Dia(diaObject.diaNummer, getLayout(diaObject.diaLayout), Color.FromName(diaObject.achtergrondKleur));
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
