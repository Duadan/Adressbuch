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
        private People ppl { get; set; }
        public bool isDark = false;
        private AddEdit add { get; set; }

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
            add = new AddEdit(src, ListNames, -1, calendar, isDark);
            TheGrid.Content = add;
        }


        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            if (ListNames.SelectedItem != null)
            {
                if (MessageBox.Show("Möchten sie den Eintrag wirklich löschen?", "Löschen", button: MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
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
                ppl = new People(src, ListNames, calendar,isDark);
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

        public void Dark_Click(object sender, RoutedEventArgs e)
        {
            if (isDark == false)
            {
                SolidColorBrush dark = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2F2F2F"));
                ContBack.Background = dark;
                Head.Background = Brushes.DarkBlue;
                ListBack.Background = dark;
                TitleL.Foreground = Brushes.White;
                SrchL.Foreground = Brushes.White;
                ListNames.Background = dark;
                ListNames.Foreground = Brushes.White;
                isDark = true;
            }
            else if (isDark)
            {
                SolidColorBrush bright = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6FA8DC"));
                ContBack.Background = Brushes.White;
                Head.Background = bright;
                ListBack.Background = Brushes.White;
                TitleL.Foreground = Brushes.Black;
                SrchL.Foreground = Brushes.Black;
                ListNames.Background = Brushes.White;
                ListNames.Foreground = Brushes.Black;
                isDark = false;
                
            }
            if (TheGrid.Content == ppl)
            {
                if (ppl.PplCtrl.Content == ppl.edit)
                {
                    ppl.edit.Darkmode(isDark);
                }
                else
                {
                    ppl.Darkmode(isDark);
                }
                
            }
            else if (TheGrid.Content == add)
            {
                add.Darkmode(isDark);
            }
        }
    }
}

