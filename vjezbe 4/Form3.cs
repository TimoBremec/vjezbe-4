using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vjezbe_4
{
    public partial class Form3 : Form2
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            List<string> current;
            if (listBox1.DataSource is List<string> dsList)
            {
                current = new List<string>(dsList);
            }
            else
            {
                current = listBox1.Items.Cast<string>().ToList();
            }

            
            var selected = listBox1.SelectedItems.Cast<string>().ToList();
            if (selected.Count == 0)
            {
                MessageBox.Show("Nije odabrana nijedna linija za brisanje.", "Obriši", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            
            var potvrda = MessageBox.Show($"Želite li obrisati {selected.Count} odabranu/odabrane stavku/stavke?", "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (potvrda != DialogResult.Yes) return;

            
            foreach (var s in selected)
            {
                for (int i = current.Count - 1; i >= 0; i--)
                {
                    if (current[i] == s) current.RemoveAt(i);
                }
            }

            
            listBox1.DataSource = null;
            listBox1.Items.Clear();
            listBox1.DataSource = current;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string linija;
            StreamReader sr = new StreamReader("studenti.txt", true);
            linija = sr.ReadLine();
            List<string> lstStr = new List<string>();
            while (linija != null)
            {
                linija = linija.Replace("|", " ");
                lstStr.Add(linija);
                linija = sr.ReadLine();
            }
            listBox1.DataSource = lstStr;

            sr.Close();




        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> filterList = new List<string>();
            StreamReader sr = new StreamReader("studenti.txt", true);
            string linija = sr.ReadLine();
            while (linija != null)
            {
                string[] razlomljena = linija.Split('|');
                if (razlomljena[2] == comboBox1.SelectedItem.ToString())
                {
                    linija = linija.Replace("|", " ");
                    filterList.Add(linija);
                }
                linija = sr.ReadLine();
            }
            listBox1.DataSource = filterList;   
        }
    }
}
