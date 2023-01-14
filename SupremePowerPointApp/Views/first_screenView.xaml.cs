using System;
using System.Collections.Generic;
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
            }

        }  

      

        private void changeBG(object sender, MouseEventArgs e)
        {

            //mainDia.Background = new SolidColorBrush(Colors.Red);
        }
    }
}
