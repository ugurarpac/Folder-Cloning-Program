using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace file_cloning
{
    public partial class cloner : Form
    {
        public cloner()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kopyala(textBox1.Text, textBox2.Text+@"\Output", true);
            MessageBox.Show("Kopyalama Başarılı");
        }
        protected void Kopyala(string Prmt1, string prmt2, bool prmt3)
        {
            DirectoryInfo DrInf = new DirectoryInfo(Prmt1);
            DirectoryInfo[] DrInfLst = DrInf.GetDirectories();
            if (!Directory.Exists(prmt2))
            {
                Directory.CreateDirectory(prmt2);
            }

            FileInfo[] dosya = DrInf.GetFiles();
            string path1 = "";
            foreach (FileInfo FFF in dosya)
            {
                path1 = Path.Combine(prmt2, FFF.Name);
                FFF.CopyTo(path1, false);
            }
            if (true)
            {
                foreach (DirectoryInfo bilgi in DrInfLst)
                {
                    path1 = Path.Combine(prmt2, bilgi.Name);
                    Kopyala(bilgi.FullName, path1, true);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                textBox2.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void cloner_Load(object sender, EventArgs e)
        {

        }
    }
}
