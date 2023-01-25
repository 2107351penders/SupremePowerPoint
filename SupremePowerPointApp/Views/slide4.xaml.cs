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
    /// Interaction logic for slide4.xaml
    /// </summary>
    public partial class slide4 : Page
    {
        public slide4()
        {
            InitializeComponent();
        }

        public event EventHandler<ClickDiaLinkArgs> ClickDiaLink;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var args = new ClickDiaLinkArgs();
            args.nieuweDia = 2;
            ClickDiaLink.Invoke(this, args);
        }
    }

    public class ClickDiaLinkArgs : EventArgs
    {
        public int nieuweDia { get; set; }
    }

}
