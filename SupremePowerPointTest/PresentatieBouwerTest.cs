using SupremePowerPointApp;
using System.Collections;
using System.Drawing;

namespace SupremePowerPointTest
{
    internal class ListPresentatieReader : IPresentatieReader
    {
       /*
        * Helper klasse die een lijst met nep dia's implementeert als een IPresentatieReader.
        * Met behulp van deze klasse kunnen we onze PresentatieBouwer testen.
        */

        List<Dia> diaLijst = new List<Dia>();

        public IEnumerator GetEnumerator()
        {
            diaLijst.Add(new Dia(1, new Layout_Intro("test", "test"), Color.White));
            diaLijst.Add(new Dia(2, new Layout_Intro("test", "test"), Color.White));
            diaLijst.Add(new Dia(3, new Layout_Intro("test", "test"), Color.White));
            diaLijst.Add(new Dia(4, new Layout_Intro("test", "test"), Color.White));
            
            return diaLijst.GetEnumerator();
        }

        public bool openPresentatie(string presentatieBestand)
        {
            return false;
        }
    }

    public class PresentatieBouwerTest
    {
        SupremePowerPointApp.PresentatieBouwer presentatieBouwer;
        ListPresentatieReader listPresentatieReader;
        Presentatie? presentatie;

        [SetUp]
        public void Setup()
        {
            listPresentatieReader = new ListPresentatieReader();
            presentatieBouwer = new SupremePowerPointApp.PresentatieBouwer(listPresentatieReader, "ListPresentatieReader.openPresentatie");
            presentatie = presentatieBouwer.getPresentatie();
        }

        [Test]
        public void TestOpenPresentatie()
        {
            // ListPresentatieReader hoeft geen bestand te openen. Presentatie mag dus niet null zijn.
            Assert.IsNotNull(presentatieBouwer.getPresentatie());
        }

        [Test]
        public void TestDisplayDia()
        {
           /* Er bestaat een dia met diaNummer 3 in LijstPresentatieReader. displayDia(3) moet dus goed gaan en de zichtbare dia
            * moet hierna 3 zijn.
            */
            presentatie.displayDia(3);
            Assert.AreEqual(3, presentatie.zichtbareDia);
        }
    }
}