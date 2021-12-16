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
using System.IO;

namespace Adressbuch_test
{
    /// <summary>
    /// Interaktionslogik für People.xaml
    /// </summary>
    public partial class People : UserControl
    {
        private LocalList Source { get; set; }
        private ListBox ListNames { get; set; }
        private int index = 0;
        private int Cal { get; set; }
        public People(LocalList src, ListBox ListNames, int mode)
        {
            InitializeComponent();
            Source = src;
            this.ListNames = ListNames;
            Cal = mode;
            string[] tmp;
            if (ListNames.SelectedItem == null)
            {
                ListNames.SelectedIndex = 0;
            }
            index = ListNames.SelectedIndex;
            switch (mode)
            {
                case 1:
                    tmp = src.contacts[index];
                    NickL.Content = tmp[0];
                    FirstL.Content = tmp[1];
                    NameL.Content = tmp[2];
                    AdressL.Content = tmp[3] + "\n" + tmp[4] + "\n" + tmp[5];
                    TelNrL.Content = tmp[6];
                    EmailL.Content = tmp[7];
                    try
                    {
                        Pic.Source = new BitmapImage(new Uri(tmp[10]));
                    }
                    catch { }
                    break;


                case 2:
                    tmp = src.five[index];
                    NickL.Content = tmp[0];
                    FirstL.Content = tmp[1];
                    NameL.Content = tmp[2];
                    AdressL.Content = tmp[3] + "\n" + tmp[4] + "\n" + tmp[5];
                    TelNrL.Content = tmp[6];
                    EmailL.Content = tmp[7];
                    try
                    {
                        Pic.Source = new BitmapImage(new Uri(tmp[10]));
                    }
                    catch { }
                    break;

                case 3:
                    tmp = src.tmp[index];
                    NickL.Content = tmp[0];
                    FirstL.Content = tmp[1];
                    NameL.Content = tmp[2];
                    AdressL.Content = tmp[3] + "\n" + tmp[4] + "\n" + tmp[5];
                    TelNrL.Content = tmp[6];
                    EmailL.Content = tmp[7];
                    try
                    {
                        Pic.Source = new BitmapImage(new Uri(tmp[10]));
                    }
                    catch { }
                    break;
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            AddEdit edit = new AddEdit(Source, ListNames, index, Cal);
            PplCtrl.Content = edit;
        }
    }
}
