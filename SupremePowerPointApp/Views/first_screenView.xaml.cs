using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
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
        public first_screenView()
        {
            InitializeComponent();
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
                Presentatie? presentatie = presentatieBouwer.getPresentatie();
                if (presentatie == null)
                {
                    // Ingelezen bestand kan niet worden omgezet naar een valide presentatie
                    MessageBox.Show("Presentation file is invalid", "SupremePowerPoint", MessageBoxButton.OK, MessageBoxImage.Error);
                }

               
                int DiaNummer = presentatie.zichtbareDia;
                DiaNummer = 1;
                Dia? currentDia = presentatie.displayDia(DiaNummer);
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
                    slide3.RechterAfbeelding.Source = currentDia.diaLayout.getAfbeeldingElement();
                    DiaBox.Navigate(slide3);
                }
                else if (currentLayout == 4)
                {
                    DiaBox.Navigate("slide4.xaml");
                }
            }
        }  

      

        private void changeBG(object sender, MouseEventArgs e)
        {

            //mainDia.Background = new SolidColorBrush(Colors.Red);
        }

        private void DiaBox_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
