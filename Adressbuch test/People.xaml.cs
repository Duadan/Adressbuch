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
        //private static string filepath = "C:\\Users\\OvSchleppegrell\\source\\repos\\Adressbuch test\\Liste.csv";
        LocalList src;
        ListBox ListNames;
        int index = 0;
        public People(LocalList src, ListBox ListNames)
        {
            InitializeComponent();
            this.src = src;
            this.ListNames = ListNames;
            if (ListNames.SelectedItem != null)
            {
                index= ListNames.SelectedIndex;
                string[] tmp = src.contacts[index];
                NickL.Content = tmp[0];
                FirstL.Content = tmp[1];
                NameL.Content = tmp[2];
                AdressL.Content = tmp[3] + "\n" + tmp[4] + "\n" + tmp[5];
                TelNrL.Content = tmp[6];
                EmailL.Content = tmp[7];
            }

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            AddEdit edit = new AddEdit(src, ListNames, index);
            PplCtrl.Content =edit;
        }
    }
}
