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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace vjezbe_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            string linija;
            linija = txtIme.Text + "|" + txtPrezime.Text + "|"+ comboBox1.Text + "|" + comboBox2.Text;
            StreamWriter sw = new StreamWriter("studenti.txt", true);
            sw.WriteLine(linija);
            sw.Close();
            txtIme.Text = "";
            txtPrezime.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            MessageBox.Show("Podaci su spremljeni!");

        }

        private void btnPrikazi_Click(object sender, EventArgs e)
        {
            string linija;
            StreamReader sr = new StreamReader("studenti.txt",true);
            linija = sr.ReadLine();
            List<string> lstStr = new List<string>();
            while (linija != null)
            {
                linija = linija.Replace("|", " ");
                lstStr.Add(linija);
                linija = sr.ReadLine();
            }
            lstStudenti.DataSource = lstStr;

            sr.Close();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
