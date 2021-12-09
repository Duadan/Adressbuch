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
    /// Interaktionslogik für AddEdit.xaml
    /// </summary>

    public partial class AddEdit : UserControl
    {
        private static string filepath = "C:\\Users\\OvSchleppegrell\\source\\repos\\Adressbuch test\\Liste.csv";
        LocalList src;
        ListBox ListNames;
        int index;
        public AddEdit(LocalList src, ListBox ListNames, int index)
        {
            InitializeComponent();
            this.src = src;
            this.ListNames = ListNames;
            this.index = index;
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
            }
        }


        private void Done_Click(object sender, RoutedEventArgs e)
        {
            bool isNumberP, isNumberT;
            isNumberP = int.TryParse(PLZ.Text, out int p);
            isNumberT = int.TryParse(Tel.Text, out int t);
            //StreamReader reader = new StreamReader(filepath);
            string ppls = NickNo.Text + ";" + FirstName.Text + ";" + NameB.Text + ";" + Street.Text + ";" + Town.Text + ";" + PLZ.Text + ";" + Tel.Text + ";" + Mail.Text + ";" + BDate.Text;
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
            else if (index < 0)
            {
                if (isNumberT == isNumberP == true)
                {
                    src.AddToList(ppls.Split(';'));
                    ListNames.Items.Add(ppls.Split(';')[0]);

                    using (StreamWriter writer = File.AppendText(filepath))
                    {
                        writer.WriteLine(ppls);
                    }

                    MessageBox.Show("Kontakt wurde hinzugefügt", "yay", MessageBoxButton.OK, MessageBoxImage.Asterisk);

                    People edit = new People(src, ListNames);
                    AddEditCtrl.Content = edit;
                }
            }
            else if (isNumberT==isNumberP==true&&index >= 0)
            {
                src.EditInList(ppls.Split(';'), index, ListNames);
                People edit = new People(src, ListNames);
                AddEditCtrl.Content = edit;
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            People edit = new People(src, ListNames);
            AddEditCtrl.Content = edit;
        }
    }
}
