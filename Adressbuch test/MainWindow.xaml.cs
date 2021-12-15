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
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    /// image, schön machen
    //class DBC
    //{
    //    private static string filepath = "C:\\Users\\source\\repos\\Adressbuch test\\liste.csv";
    //    private StreamReader reader = new StreamReader(filepath);
    //    private StreamWriter writer = new StreamWriter(filepath);

    //    public List<Ppl> GetPeople()
    //    {
    //        List<Ppl> ppls = new List<Ppl>();
    //        ppls.Clear();
    //        try
    //        {
    //            while (!reader.EndOfStream)
    //            {
    //                string[] tmp = reader.ReadLine().Split(';');
    //                ppls.Add(new Ppl(tmp[0], tmp[1], tmp[2], Convert.ToDateTime(tmp[3]), tmp[4], tmp[7], tmp[8], tmp[9]));
    //            }
    //        }
    //        catch
    //        {

    //        }
    //        return ppls;
    //    }
    //}



    public partial class MainWindow : Window
    {
        LocalList src = new LocalList();
        //People nameList;
        int calendar;

        //private static string filepath = "C:\\Users\\OvSchleppegrell\\source\\repos\\Adressbuch test\\Liste.csv";
        public MainWindow()
        {
            InitializeComponent();
            
            Kalendar cal = new Kalendar();
            TheGrid.Content = cal;
            calendar = 2;
            src.MakeList();
            //foreach (string[] s in src.contacts)
            //{
            //    ListNames.Items.Add(s[0]);
            //}
            src.CalenderDiff(ListNames);
            //nameList = new People(src, ListNames,calendar);

            //ListNames.ItemsSource = src.contacts;//hier noch auf ersten string der Listeneinträge (foreach?)
            //ListNames.ItemsSource = (System.Collections.IEnumerable)src;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEdit add = new AddEdit(src, ListNames, -1, calendar);
            TheGrid.Content = add;
        }


        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            if (ListNames.SelectedItem != null)
            {
                MessageBoxResult erm = MessageBox.Show("Möchten sie den Eintrag wirklich löschen?", "Löschen", button: MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (erm == MessageBoxResult.Yes)
                {
                    src.DelFromList(ListNames.SelectedIndex);
                    //TxtSearch.Text = Convert.ToString(ListNames.SelectedIndex);
                    ListNames.Items.Remove(ListNames.SelectedItem);
                }
            }
            else
            {
                MessageBox.Show("erst Benutzer Auswählen, dann löschen", "Fehler");
            }
        }

        private void BtnDate_Click(object sender, RoutedEventArgs e)
        {
            calendar = 2;
            Kalendar cal = new Kalendar();
            TheGrid.Content = cal;
            src.CalenderDiff(ListNames);
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            calendar = 3;
            src.SearchFunktion(ListNames, TxtSearch.Text, calendar);
        }

        private void Closing_SaveStuff(object sender, System.ComponentModel.CancelEventArgs e)
        {
            src.SaveStuff();
        }

        private void BtnPpl_Click(object sender, RoutedEventArgs e)
        {
            calendar = 1;
            ListNames.Items.Clear();
            foreach (string[] s in src.contacts)
            {
                ListNames.Items.Add(s[0]);
            }
        }

        private void ListNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListNames.SelectedIndex >= 0)
            {
                People ppl = new People(src, ListNames, calendar);
                TheGrid.Content = ppl;
            }
        }
    }
}

