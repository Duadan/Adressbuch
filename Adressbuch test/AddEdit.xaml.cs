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
using Microsoft.Win32;

namespace Adressbuch_test
{
    /// <summary>
    /// Interaktionslogik für AddEdit.xaml
    /// </summary>

    public partial class AddEdit : UserControl
    {
        private static readonly string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Liste.csv";
        private LocalList Source { get; set; }
        private ListBox ListNames { get; set; }
        private int Index { get; set; }
        private int Mode { get; set; }
        private OpenFileDialog Picture { get; set; }
        private string FindPic { get; set; }

        public AddEdit(LocalList src, ListBox listNames, int index, int mode)
        {
            InitializeComponent();
            Mode = mode;
            Source = src;
            ListNames = listNames;
            Index = index;
            if (index >= 0 && src.contacts[index].Length >= 11)
            {
                FindPic = src.contacts[index][10];
            }
            if (index >= 0)
            {
                string a = ListNames.SelectedItem.ToString();
                if (Mode == 2)
                {
                    string[] b = a.Split(' ');
                    a = a.Split(' ')[1];
                    if (b.Length > 2)
                    {
                        for (int i = 2; i < b.Length; i++)
                        {
                            a += " "+b[i];
                        }
                    }

                }
                foreach (string[] arrg in src.contacts)
                {
                    if (arrg[0] == a)
                    {
                        try
                        {
                            NickNo.Text = arrg[0];
                            NickNo.IsReadOnly = true;
                            NickLabel.Content = "Nickname/KundenNr. Kann nicht verändert werden";
                            FirstName.Text = arrg[1];
                            NameB.Text = arrg[2];
                            Street.Text = arrg[3];
                            Town.Text = arrg[4];
                            PLZ.Text = arrg[5];
                            Tel.Text = arrg[6];
                            Mail.Text = arrg[7];
                            BDate.Text = arrg[8];
                            if (arrg.Length >= 11)
                            {
                                if (arrg[10] != "")
                                {
                                    try
                                    {
                                        img.Source = new BitmapImage(new Uri(arrg[10]));
                                    }
                                    catch (Exception f)
                                    {
                                        MessageBox.Show(f.Message, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                            }
                        }
                        catch { }
                    }
                }
            }
        }


        private void Done_Click(object sender, RoutedEventArgs e)
        {
            int isEmail = 0;
            bool isNumberP, isNumberT, isNumberD, isNew=true;
            isNumberP = int.TryParse(PLZ.Text, out int p);
            isNumberT = int.TryParse(Tel.Text, out int t);
            isNumberD = DateTime.TryParse(BDate.Text, out DateTime d);
            foreach (char c in Mail.Text)
            {
                if (c == '@')
                {
                    if (isEmail == 0)
                    {
                        isEmail += 1;
                    }
                    else
                    {
                        isEmail += 2;
                    }
                }
                if (isEmail >= 1)
                {
                    if (c == '.')
                    {
                        isEmail += 1;
                    }
                }
            }
            //StreamReader reader = new StreamReader(filepath);
            string ppls = NickNo.Text + ";" + FirstName.Text + ";" + NameB.Text + ";" + Street.Text + ";" + Town.Text + ";" + PLZ.Text + ";" + Tel.Text + ";" + Mail.Text + ";" + BDate.Text + ";" + Convert.ToString(d.DayOfYear) + ";" + FindPic;
            //if string[] in filepath go on, sonst fehlermeldung
            //reader = null;


            if (isNumberP == false)
            {
                PLZ.BorderBrush = Brushes.Red;
            }
            else
            {
                PLZ.BorderBrush = Brushes.DarkGray;
            }
            if (isNumberT == false)
            {
                Tel.BorderBrush = Brushes.Red;
            }
            else
            {
                Tel.BorderBrush = Brushes.DarkGray;
            }
            if (isNumberD == false)
            {
                BDate.BorderBrush = Brushes.Red;
            }
            else
            {
                BDate.BorderBrush = Brushes.DarkGray;
            }
            if (isEmail != 2)
            {
                Mail.BorderBrush = Brushes.Red;
            }
            else
            {
                Mail.BorderBrush = Brushes.DarkGray;
            }

            if (Index < 0)
            {
                foreach (string[] repeat in Source.contacts)
                {
                    if (NickNo.Text == repeat[0])
                    {
                        NickDbl.Content = "dieser Kontakt existiert bereits!";
                        isNew = false;
                        NickNo.BorderBrush = Brushes.Red;
                    }
                }
                if (isNew)
                {
                    NickDbl.Content = "";
                    NickNo.BorderBrush = Brushes.DarkGray;
                }
                if (isNumberT == isNumberP == isNumberD ==isNew== true && isEmail == 2)
                {
                    Source.AddToList(ppls.Split(';'));
                    if (Mode ==1)
                    {
                        ListNames.Items.Add(ppls.Split(';')[0]);
                    }

                    using (StreamWriter writer = File.AppendText(filepath))
                    {
                        writer.WriteLine(ppls);
                    }

                    MessageBox.Show("Kontakt wurde hinzugefügt", "yay", MessageBoxButton.OK, MessageBoxImage.Asterisk);

                    People edit = new People(Source, ListNames, 1);
                    AddEditCtrl.Content = edit;
                }

            }
            else if (isNumberT == isNumberP == isNumberD == true && Index >= 0 && isEmail == 2)
            {
                Source.EditInList(ppls.Split(';'), Index, ListNames,Mode);
                People edit = new People(Source, ListNames, 1);
                AddEditCtrl.Content = edit;
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Picture = new OpenFileDialog
            {
                Title = "Wählen Sie ein Profilbild aus",
                Filter = "Grafiken|*.jpg;*.jpeg;*.png;*.bmp"
            };
            if (Picture.ShowDialog() == true)
            {
                img.Source = new BitmapImage(new Uri(Picture.FileName));
                FindPic = Picture.FileName;
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            People edit = new People(Source, ListNames, Mode);
            AddEditCtrl.Content = edit;
        }
    }
}
