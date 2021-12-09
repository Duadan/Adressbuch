using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Adressbuch_test
{
    public class LocalList
    {

        private static string filepath = "C:\\Users\\OvSchleppegrell\\source\\repos\\Adressbuch test\\Liste.csv";
        public List<string[]> contacts = new List<string[]>();

        public void MakeList()
        {
            using (StreamReader read = new StreamReader(filepath))
            {

                try
                {
                    while (!read.EndOfStream)
                    {
                        string[] tmp = read.ReadLine().Split(';');
                        contacts.Add(tmp);
                    }
                    //MessageBox.Show(Convert.ToString(contacts.Count), "hmm", MessageBoxButton.OK);
                }
                catch (Exception f)
                {
                    MessageBox.Show(f.Message, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }
        public void AddToList(string[] a) //stringarray= nick; vorname; name; Straße; Stadt; PLZ; Tel.; Email; Bday
        {
            contacts.Add(a);
        }
        public void DelFromList(int index) //i=Listboxindex
        {
            try
            {
                contacts.RemoveAt(index);
            }
            catch (Exception o)
            {
                MessageBox.Show(o.Message+contacts.Count+index, "Fehler", MessageBoxButton.OK);
            }
        }
        public void EditInList(string[] data, int index, ListBox ListNames)
        {
            contacts.RemoveAt(index);
            contacts.Add(data);
            ListNames.Items.RemoveAt(index);
            ListNames.Items.Add(data[0]);
        }
    }
}
