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

        public LayoutObject diaLayout { get; set; }
        public string achtergrondKleur { get; set; }

    }
    public class LayoutObject
    {
        public int layoutNummer { get; set; }

        public string element1 { get; set; }

        public string element2 { get; set; }
    }

    internal class JsonPresentatieReader : IPresentatieReader
    {
        public string PresentatieFileInhoud { get; private set; } = "";

        public ILayout getLayout(int layout_number, string element1, string element2)
        {
            ILayout? layout = null;
            
            if (layout_number == 1)
            {
                layout = new Layout_Intro(element1, element2);
            } else if (layout_number == 2) {
                layout = new Layout_TextImage(element1, element2);
            } else if (layout_number == 3) {
                layout = new Layout_Images(element1, element2);
            } else if (layout_number == 4) {
                layout = new Layout_Outro(element1, element2);
            }
            return layout;
        }

        public IEnumerator GetEnumerator()
        {
            var myDeserializedClass = JsonConvert.DeserializeObject<Rootobject>(PresentatieFileInhoud);
            foreach (DiaObject diaObject in myDeserializedClass.Presentatie.Dia)
            {
                Dia dia = new Dia(diaObject.diaNummer, getLayout(diaObject.diaLayout.layoutNummer, diaObject.diaLayout.element1, diaObject.diaLayout.element2), Color.FromName(diaObject.achtergrondKleur));
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
