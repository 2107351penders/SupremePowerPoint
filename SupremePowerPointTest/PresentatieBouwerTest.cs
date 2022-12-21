using SupremePowerPointApp;
using System.Collections;

namespace SupremePowerPointTest
{
    internal class ListPresentatieReader : IPresentatieReader
    {
        /*
         * Helper klasse die een lijst met nep dia's implementeert als een IPresentatieReader.
         * Met behulp van deze klasse kunnen we onze PresentatieBouwer testen.
         */
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool openPresentatie(string presentatieBestand)
        {
            return 0;
        }
    }

    public class TPresentatieBouwerTest
    {
        SupremePowerPointApp.PresentatieBouwer presentatieBouwer;
        ListPresentatieReader listPresentatieReader = new ListPresentatieReader();


        [SetUp]
        public void Setup()
        {
            presentatieBouwer = new SupremePowerPointApp.PresentatieBouwer(); 
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}