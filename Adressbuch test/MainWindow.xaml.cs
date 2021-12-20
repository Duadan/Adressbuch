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
    /// löschen bearbeiten double-checken

    public partial class MainWindow : Window
    {
        public LocalList src = new LocalList();
        private int calendar;
        private People ppl;

        public MainWindow()
        {
            InitializeComponent();
            calendar = 2;
            src.MakeList();
            src.CalenderDiff(ListNames);
            Kalendar cal = new Kalendar(src);
            TheGrid.Content = cal;
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
                    src.DelFromList(ppl.NickL.Content.ToString());
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
            src.CalenderDiff(ListNames);
            Kalendar cal = new Kalendar(src);
            TheGrid.Content = cal;
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
                ppl = new People(src, ListNames, calendar);
                TheGrid.Content = ppl;
            }
        }

        private void SrchEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                calendar = 3;
                src.SearchFunktion(ListNames, TxtSearch.Text);
            }
        }
    }
}

