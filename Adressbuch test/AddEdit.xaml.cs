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
        private static readonly string filepath = "C:\\Users\\OvSchleppegrell\\source\\repos\\Adressbuch test\\Liste.csv";
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
                NickNo.Text = src.contacts[index][0];
                FirstName.Text = src.contacts[index][1];
                NameB.Text = src.contacts[index][2];
                Street.Text = src.contacts[index][3];
                Town.Text = src.contacts[index][4];
                PLZ.Text = src.contacts[index][5];
                Tel.Text = src.contacts[index][6];
                Mail.Text = src.contacts[index][7];
                BDate.Text = src.contacts[index][8];
                if (src.contacts[index].Length >= 11)
                {
                    if (src.contacts[index][10] != "")
                    {
                        try
                        {
                            img.Source = new BitmapImage(new Uri(src.contacts[index][10]));
                        }
                        catch (Exception f)
                        {
                            MessageBox.Show(f.Message, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
        }


        private void Done_Click(object sender, RoutedEventArgs e)
        {
            int isEmail = 0;
            bool isNumberP, isNumberT, isNumberD;
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
                PLZ.Text = "Fehler! Bitte eine PostleitZAHL eingeben";
            }
            if (isNumberT == false)
            {
                Tel.Text = "Fehler! Bitte eine TelefonNUMMER eingeben";
            }
            if (isNumberD == false)
            {
                BDate.Text = "Bitte gültiges Datum eingeben!";
            }
            if (isEmail != 2)
            {
                Mail.Text = "Ungültig! Bitte eine gültige Emailadresse eingeben.";
            }

            else if (Index < 0)
            {
                foreach (string[] repeat in Source.contacts)
                {
                    if (NickNo.Text == repeat[0])
                    {
                        NickNo.Text = "dieser Kontakt existiert bereits, zum bearbeiten Kontakt auswählen und bearbeiten";
                    }
                }
                if (isNumberT == isNumberP == isNumberD == true && isEmail == 2)
                {
                    Source.AddToList(ppls.Split(';'));
                    ListNames.Items.Add(ppls.Split(';')[0]);

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
                Source.EditInList(ppls.Split(';'), Index, ListNames);
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
