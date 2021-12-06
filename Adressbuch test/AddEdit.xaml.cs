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
        
        public AddEdit()
        {
            InitializeComponent();
        }


        private void Done_Click(object sender, RoutedEventArgs e)
        {            
            //StreamReader reader = new StreamReader(filepath);
            string ppls = NickNo.Text+";"+ FirstName.Text+";"+ Name.Text+";"+ Street.Text+";"+ Town.Text+";"+ PLZ.Text+";"+ Tel.Text+";"+ Mail.Text+";"+ BDate.Text;
            //if string[] in filepath go on, sonst fehlermeldung
            //reader = null;

            using (StreamWriter writer = File.AppendText(filepath))
            {
                writer.WriteLine(ppls);
            }

            MessageBox.Show("Kontakt wurde hinzugefügt", "yay", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            
            People edit = new People();
            AddEditCtrl.Content = edit;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            People edit = new People();
            AddEditCtrl.Content = edit;
        }
    }
}
