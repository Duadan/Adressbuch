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
        private bool Dark { get; set; }
        public AddEdit edit { get; set; }
        public People(LocalList src, ListBox ListNames, int mode, bool dark)
        {
            InitializeComponent();
            
            Source = src;
            this.ListNames = ListNames;
            Cal = mode;
            string[] tmp;
            Dark = dark;
            Adress.Content = "Straße:\nOrt:\nPLZ:";
            if (ListNames.SelectedItem == null)
            {
                ListNames.SelectedIndex = 0;
            }
            index = ListNames.SelectedIndex;
            switch (mode)
            {
                case 1:
                    Darkmode(Dark);
                    tmp = src.contacts[index];
                    NickL.Content = tmp[0];
                    FirstL.Content = tmp[1];
                    NameL.Content = tmp[2];
                    AdressL.Content = tmp[3] + "\n" + tmp[4] + "\n" + tmp[5];
                    TelNrL.Content = tmp[6];
                    EmailL.Content = tmp[7];
                    BDay.Content = tmp[8];
                    try
                    {
                        Pic.Source = new BitmapImage(new Uri(tmp[10]));
                    }
                    catch { }
                    break;


                case 2:
                    Darkmode(Dark);
                    tmp = src.five[index];
                    NickL.Content = tmp[0];
                    FirstL.Content = tmp[1];
                    NameL.Content = tmp[2];
                    AdressL.Content = tmp[3] + "\n" + tmp[4] + "\n" + tmp[5];
                    TelNrL.Content = tmp[6];
                    EmailL.Content = tmp[7];
                    BDay.Content=tmp[8];
                    try
                    {
                        Pic.Source = new BitmapImage(new Uri(tmp[10]));
                    }
                    catch { }
                    break;

                case 3:
                    Darkmode(Dark);
                    tmp = src.tmp[index];
                    NickL.Content = tmp[0];
                    FirstL.Content = tmp[1];
                    NameL.Content = tmp[2];
                    AdressL.Content = tmp[3] + "\n" + tmp[4] + "\n" + tmp[5];
                    TelNrL.Content = tmp[6];
                    EmailL.Content = tmp[7];
                    BDay.Content = tmp[8];
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
            edit = new AddEdit(Source, ListNames, index, Cal, Dark);
            PplCtrl.Content = edit;
        }
        public void Darkmode(bool dark)
        {
            Dark = dark;
            if (dark)
            {
                NickL.Foreground = FirstL.Foreground = NameL.Foreground = TelNrL.Foreground = AdressL.Foreground = EmailL.Foreground = BDay.Foreground = Brushes.White;
                BdayL.Foreground = LLMail.Foreground = LLTel.Foreground =Adress.Foreground= Brushes.White;
            }
            else
            {
                NickL.Foreground = FirstL.Foreground = NameL.Foreground = TelNrL.Foreground = AdressL.Foreground = EmailL.Foreground = BDay.Foreground = Brushes.Black;
                BdayL.Foreground = LLMail.Foreground = LLTel.Foreground = Adress.Foreground = Brushes.Black;
            }
        }
    }
}
