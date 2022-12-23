using SupremePowerPointApp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupremePowerPointTest
{
    public class JsonPresentatieReaderTest
    {
        JsonPresentatieReader jsonPresentatieReader;

        [SetUp]
        public void Setup()
        {
            jsonPresentatieReader = new JsonPresentatieReader();
        }

        [Test]
        public void TestOpenPresentatieGeldig()
        {
            // We lezen een bestaand bestand in dus gelezen inhoud kan niet leeg zijn
            PresentatieBouwer presentatieBouwer = new PresentatieBouwer(jsonPresentatieReader, "voorbeeld_presentatie.json");
            Assert.IsNotEmpty(jsonPresentatieReader.PresentatieFileInhoud);
        }

        [Test]
        public void TestOpenPresentatieOngeldig()
        {
            // Wanneer we een niet bestaand bestand proberen in te lezen moet PresentatieBouwer.presentatie null zijn
            PresentatieBouwer presentatieBouwer = new PresentatieBouwer(jsonPresentatieReader, "niet_bestaande_presentatie.json");
            Assert.IsNull(presentatieBouwer.getPresentatie());
        }

        [Test]
        public void TestResultaatPresentatie()
        {
            // Onze voorbeeld presentatie bevat twee dia's. Het resulterende Presentatie object moet dus ook twee dia's bevatten
            PresentatieBouwer presentatieBouwer = new PresentatieBouwer(jsonPresentatieReader, "voorbeeld_presentatie.json");
            Presentatie resultaat = presentatieBouwer.getPresentatie();
            Assert.AreEqual(resultaat.getDiaCount(), 2);
        }
    }
}