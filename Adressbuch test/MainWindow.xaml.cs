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
        private static string filepath = "C:\\Users\\OvSchleppegrell\\source\\repos\\Adressbuch test\\Liste.csv";
        public MainWindow()
        {
            InitializeComponent();
            Kalendar cal = new Kalendar();
            TheGrid.Content = cal;   
        }
        
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEdit add = new AddEdit();
            TheGrid.Content = add;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            AddEdit edit = new AddEdit();
            TheGrid.Content = edit;
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult erm = MessageBox.Show("Möchten sie den Eintrag wirklich löschen?", "Löschen", button: MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (erm == MessageBoxResult.Yes)
            {
                ListNames.Items.Remove(ListNames.SelectedItem);/*da kommt dann noch was*/
            }
        }

        private void BtnDate_Click(object sender, RoutedEventArgs e)
        {
            Kalendar cal = new Kalendar();
            TheGrid.Content = cal;
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filepath))
                {
                    while (!reader.EndOfStream)
                    {
                        //foreach x in ListNames    if tmp[0]==ListNames.Items[x] go on     else add
                        string[] tmp = reader.ReadLine().Split(';');
                        ListNames.Items.Add(tmp[0]);
                    }
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message, "Fehler", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }

        private void Btnppl_Click(object sender, RoutedEventArgs e)
        {
            People ppl = new People();
            TheGrid.Content = ppl;
        }
       
    }
}
