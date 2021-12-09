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
    /// sortbydate, search, image
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
        LocalList src= new LocalList();
        People nameList;

        private static string filepath = "C:\\Users\\OvSchleppegrell\\source\\repos\\Adressbuch test\\Liste.csv";
        public MainWindow()
        {
            InitializeComponent();
            Kalendar cal = new Kalendar();
            TheGrid.Content = cal;
            nameList = new People(src, ListNames);
            this.src.MakeList();//foreach (string[] str in contacts)List bla.add = str[0] <- sollte gehen, aber wäre indirekt, was meh
            foreach (string[] s in src.contacts)
            {
                ListNames.Items.Add(s[0]);
            }
            //ListNames.ItemsSource = src.contacts;//hier noch auf ersten string der Listeneinträge (foreach?)
            //ListNames.ItemsSource = (System.Collections.IEnumerable)src;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEdit add = new AddEdit(src, ListNames,-1);
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
            Kalendar cal = new Kalendar();
            TheGrid.Content = cal;
            //DateTime today = DateTime.Today;
            //int j = 0;
            //foreach (string[] i in src.contacts)
            //{
            //    int age = today.Year - Convert.ToDateTime(src.contacts[j][8]).Year;
            //    TimeSpan time = Convert.ToDateTime(src.contacts[8]).AddYears(age + 1) - today;
            //    j++;
            //}
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            //src.contacts.BinarySearch(??);
            //src.contacts.Find(x => x.contains(TxtSearch.Text));
            //ListNames.IsTextSearchEnabled = true;
            //IEnumerable<string> srch =
            //    from string[] a in src.contacts
            //    where a.Contains(TxtSearch.Text)
            //    select a[0];
            //foreach(string b in srch)
            //{
            //    //ListNames.Items.
            //}
        }

        private void SaveStuff(object sender, System.ComponentModel.CancelEventArgs e)
        {
            File.Delete(filepath);

            using (StreamWriter writer = File.AppendText(filepath))
            {
                foreach (string[] s in src.contacts)
                    writer.WriteLine(s[0] + ";" + s[1] + ";" + s[2] + ";" + s[3] + ";" + s[4] + ";" + s[5] + ";" + s[6] + ";" + s[7] + ";" + s[8]);
            }
        }

        private void ListNames_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            People ppl = new People(src, ListNames);
            TheGrid.Content = ppl;
        }
    }
}

