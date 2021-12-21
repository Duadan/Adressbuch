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
        public List<string[]> five = new List<string[]>();
        public List<string[]> tmp = new List<string[]>();

        private static readonly string filepath = AppDomain.CurrentDomain.BaseDirectory+"\\Liste.csv";
        public List<string[]> contacts = new List<string[]>();

        public void MakeList()
        {
            using (StreamReader read = new StreamReader(filepath))
            {

                try
                {
                    while (!read.EndOfStream)
                    {
                        string[] tmp1 = read.ReadLine().Split(';');
                        contacts.Add(tmp1);
                    }
                    //MessageBox.Show(Convert.ToString(contacts.Count), "hmm", MessageBoxButton.OK);
                }
                catch (Exception f)
                {
                    MessageBox.Show(f.Message, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }
        public void AddToList(string[] a) //stringarray= nick; vorname; name; Straße; Stadt; PLZ; Tel.; Email; Bday;DaysToBday
        {
            contacts.Add(a);
            tmp.Add(a);
            five.Add(a);
        }
        public void DelFromList(string index) //index=Listboxindex
        {
            try
            {
                for (int i = 0; i < contacts.Count(); i++)
                {
                    if (index == contacts[i][0])
                    {
                        contacts.RemoveAt(i);
                    }
                }
            }
            catch (Exception o)
            {
                MessageBox.Show(o.Message + contacts.Count + index, "Fehler", MessageBoxButton.OK);
            }
        }
        public void EditInList(string[] data, int index, ListBox ListNames, int window)
        {
            if (window == 2)
            {
                string[] a = ListNames.SelectedItem.ToString().Split(' ');
                DelFromList(a[1]);
            }
            else
            {
                DelFromList(ListNames.SelectedItem.ToString());
            }
            AddToList(data);
            ListNames.Items.RemoveAt(index);
            if (window == 2)
            {
                ListNames.Items.Add(data[8]+" "+data[0]);
            }
            else
            {
                ListNames.Items.Add(data[0]);
            }
        }
        public void CalenderDiff(ListBox ListNames)
        {
            DateTime today = DateTime.Today;
            TimeSpan time;
            ListNames.Items.Clear();

            try
            {
                foreach (string[] i in contacts)
                {
                    int age = today.Year - Convert.ToDateTime(i[8]).Year;
                    if (Convert.ToDateTime(i[8]).AddYears(age)>= today)
                    {
                        time = Convert.ToDateTime(i[8]).AddYears(age) - today;
                        i[9] = Convert.ToString(time.Days);
                    }
                    else
                    {
                        time = Convert.ToDateTime(i[8]).AddYears(age + 1) - today;
                        i[9] = Convert.ToString(time.Days);
                    }
                }
            }
            catch(Exception f)
            {
                string meh="";
                foreach(string i in contacts[0])
                {
                    meh += i+" ";
                }
                MessageBox.Show(f.Message+" "+meh , "meh");
            }
            //five = contacts.OrderBy(contact => Convert.ToInt32(contact[9])).Take(5).ToList();
            try
            {
                five = contacts.OrderBy(contact => Convert.ToInt32(contact[9])).Take(contacts.Count() < 5 ? contacts.Count() : 5).ToList();
                for (int i = 0; i < (five.Count() < 5 ? five.Count() : 5); i++)
                {
                    ListNames.Items.Add(five[i][8] + " " + five[i][0]);
                }
            }
            catch(Exception f)
            {
                MessageBox.Show(f.Message, "Fehler");
            }
        }
        public void SearchFunktion(ListBox ListNames, string srchTxt)
        {
            bool noRepeat=true;
            tmp.Clear();
            ListNames.Items.Clear();
            foreach(string[] a in contacts)
            {
                for(int i=0;i<8; i++)
                {
                    if (a[i].ToLower().Contains(srchTxt.ToLower()))
                    {
                        foreach (string c in ListNames.Items)
                        {
                            if (a[0] == c)
                            {
                                noRepeat = false;
                            }
                            else
                            {
                                noRepeat = true;
                            }
                        }
                        if (noRepeat)
                        {
                            ListNames.Items.Add(a[0]);
                            tmp.Add(a);
                        }
                    }
                }
                //foreach(string b in a)
                //{
                //    if (b.ToLower().Contains(srchTxt.ToLower()))
                //    {
                //        foreach(string c in ListNames.Items)
                //        {
                //            if (a[0] == c)
                //            {
                //                noRepeat = false;
                //            }
                //            else
                //            {
                //                noRepeat = true;
                //            }
                //        }
                //        if (noRepeat)
                //        {
                //            ListNames.Items.Add(a[0]);
                //            tmp.Add(a);
                //        }
                //    }
                //}
            }
        }
        
        public void SaveStuff()
        {
            File.Delete(filepath);

            using (StreamWriter writer = File.AppendText(filepath))
            {
                foreach (string[] s in contacts)
                    if (s.Length >= 11)
                    {
                        writer.WriteLine(s[0] + ";" + s[1] + ";" + s[2] + ";" + s[3] + ";" + s[4] + ";" + s[5] + ";" + s[6] + ";" + s[7] + ";" + s[8] + ";" + s[9] + ";" + s[10]);
                    }
                    else
                    {
                        writer.WriteLine(s[0] + ";" + s[1] + ";" + s[2] + ";" + s[3] + ";" + s[4] + ";" + s[5] + ";" + s[6] + ";" + s[7] + ";" + s[8] + ";" + s[9]);
                    }
            }
        }
    }
}
