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

namespace Adressbuch_test
{
    /// <summary>
    /// Interaktionslogik für Kalendar.xaml
    /// </summary>
    public partial class Kalendar : UserControl
    {
        private readonly LocalList Source;
        public Kalendar(LocalList src)
        {
            InitializeComponent();
            Source = src;
            if (Convert.ToInt32(Source.five[0][9]) == 0)
            {
                ImgBday.Visibility = Visibility.Visible;
                BDayLabel.Content = Source.five[0][1] + " " + Source.five[0][2];
            }
        }

        private void NoCal(object sender, ContextMenuEventArgs e)
        {

        }
    }
}
