using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace WpfNutWatch
{
    public partial class FormPagIni : Form
    {
        public FormPagIni()
        {
            InitializeComponent();
        }

        private void buttonFicheiro_Click(object sender, EventArgs e)
        {
            FTPClass ligar = new FTPClass();
            string arquivo = ligar.getfolderfile("a","a");
            string nome_arquivo = System.IO.Path.GetFileName(arquivo);
            textBoxFich.Text = arquivo;
            pictureBox1.ImageLocation = arquivo;
        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            Close(); 
        }
    }
}
