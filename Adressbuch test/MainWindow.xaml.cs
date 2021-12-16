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
    /// schön machen

    public partial class MainWindow : Window
    {
        LocalList src = new LocalList();
        private int calendar;

        public MainWindow()
        {
            InitializeComponent();
            Kalendar cal = new Kalendar();
            TheGrid.Content = cal;
            calendar = 2;
            src.MakeList();
            src.CalenderDiff(ListNames);
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
            src.SearchFunktion(ListNames, TxtSearch.Text);
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

