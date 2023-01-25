using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SupremePowerPointApp.Views
{
    /// <summary>
    /// Interaction logic for window.xaml
    /// </summary>
    public partial class first_screenView : UserControl
    {
        static int diaNummer = 1;
        Presentatie? presentatie = null;
        public first_screenView()
        {
            InitializeComponent();
        }

        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        // file dropdown onclick function , this will render the dropdowns which include open file button 
        private void FileButtonClick(object sender, RoutedEventArgs e)
        {
            // open een windows file explorer window, met JSON als file filter
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
            openFileDlg.DefaultExt = ".json";
            openFileDlg.Filter = "JSON (.json)|*.json";
            Nullable<bool> result = openFileDlg.ShowDialog();

            if (result == true)
            {
                //fileName.Text = openFileDlg.FileName;
                //TextBlock1.Text = System.IO.File.ReadAllText(openFileDlg.FileName);
                JsonPresentatieReader jsonPresentatieReader = new JsonPresentatieReader();
                PresentatieBouwer presentatieBouwer = new PresentatieBouwer(jsonPresentatieReader, openFileDlg.FileName);
                presentatie = presentatieBouwer.getPresentatie();
                if (presentatie == null)
                {
                    // Ingelezen bestand kan niet worden omgezet naar een valide presentatie
                    MessageBox.Show("Presentation file is invalid", "SupremePowerPoint", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
                showDiaLoop(presentatie, diaNummer);
            }
        }

        private void showDiaLoop(Presentatie presentatie, int diaNummer)
        {
            Dia? currentDia = presentatie.displayDia(diaNummer);
            if (currentDia == null)
            {
                MessageBox.Show("Oopsie-woopsie de dia is stukkie-wukkie");
            }

            int currentLayout = currentDia.diaLayout.layoutNumber;

            if (currentLayout == 1)
            {
                slide1 slide1 = new slide1();
                slide1.LinkerTekstvak.Text = currentDia.diaLayout.getTextElement();
                slide1.RechterAfbeelding.Source = currentDia.diaLayout.getAfbeeldingElement();
                DiaBox.Navigate(slide1);
            }
            else if (currentLayout == 2)
            {
                slide2 slide2 = new slide2();
                slide2.LinkerTekstvak.Text = currentDia.diaLayout.getTextElement();
                slide2.RechterAfbeelding.Source = currentDia.diaLayout.getAfbeeldingElement();
                DiaBox.Navigate(slide2);
            }
            else if (currentLayout == 3)
            {
                slide3 slide3 = new slide3();
                slide3.LinkerAfbeelding.Source = currentDia.diaLayout.getAfbeeldingElement();
                slide3.RechterAfbeelding.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "rechts_afbeelding.jpeg", UriKind.Absolute));
                DiaBox.Navigate(slide3);
            }
            else if (currentLayout == 4)
            {
                slide4 slide4 = new slide4();
                slide4.ClickDiaLink += ClickDiaLinkHandler;
                slide4.centerTextBox.Text = currentDia.diaLayout.getTextElement();
                DiaBox.Navigate(slide4);
            }

            void ClickDiaLinkHandler(Object sender, ClickDiaLinkArgs args)
            {
                diaNummer = args.nieuweDia;
                showDiaLoop(presentatie, diaNummer);
            }
        }

        private void changeBG(object sender, MouseEventArgs e)
        {

            //mainDia.Background = new SolidColorBrush(Colors.Red);
        }

        private void DiaBox_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void ChangeDia(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                if (diaNummer + 1 > presentatie.getDiaCount()) return; // We zijn al op de laatste dia
                diaNummer += 1;
            }
            else if (e.Key == Key.Up) {
                if (diaNummer == 1) return; // We zijn al op de eerste dia
                diaNummer -= 1;
            }

            showDiaLoop(presentatie, diaNummer);
        }
    }
}