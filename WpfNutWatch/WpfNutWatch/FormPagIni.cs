using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace WpfNutWatch
{
    public partial class FormPagIni : Form
    {
        // FTP
        String url = @"ftp://nutwatch.twomini.com/imagensINI/";
        String Http = @"http://nutwatch.twomini.com/imagensDiag/";
        String user = "u963389833";
        String pwd = "Jonas123"; 

        string id_ini;

        public FormPagIni()
        {
            InitializeComponent();
            fillgridIni();
            ButtonName();
        }

        private void ButtonName()
        {
            DBConnect NewcConnection = new DBConnect();
            NewcConnection.dbConnection();
            MySqlCommand verifica = new MySqlCommand("SELECT * FROM inicio", DBConnect.db);

            MySqlDataReader read = verifica.ExecuteReader();
            int count = 0;
            while (read.Read())
            {
                count = count + 1;
                id_ini = read["id_Inicio"].ToString();
                textBoxTitulo.Text = read["tituloini"].ToString();
                textBoxPagIni.Text = read["inicio_texto"].ToString();
                textBoxFich.Text = read["inicio_imagem"].ToString();
                string aux = Http + "default_image.png";
                //MessageBox.Show(aux);
                try
                {
                    pictureBox1.Load(aux);
                }
                catch
                {
                    //pictureBox1.Image = Properties.Resources.default_image;
                    MessageBox.Show("Erro a carregar a imagem ou imagem inixistente !!!");
                }               
            }
            DBConnect.db.Close();
            if (count == 0)
            {
                buttonInserir.Text = "Inserir";
            }
            else
            {
                buttonInserir.Text = "Update";
            }
        }

        private void buttonFicheiro_Click(object sender, EventArgs e)
        {
            FTPClass ligar = new FTPClass();
            string caminho = ligar.getfolderfile("para a","Página inicial");
            string nome_arquivo = System.IO.Path.GetFileName(caminho);
            textBoxFich.Text = caminho;
            pictureBox1.ImageLocation = caminho;
        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            Close(); 
        }

        private void fillgridIni()
        {
            //id = -1;
            //buttonDel.Visible = false;
            //buttonEdit.Visible = false;
            //buttonIns.Visible = false;
            //buttonCancel.Visible = false;
            DBConnect NewcConnection = new DBConnect();
            NewcConnection.dbConnection();
            MySqlCommand querysql = new MySqlCommand("Select * From inicio", DBConnect.db);

            try
            {
                MySqlDataAdapter dados = new MySqlDataAdapter();
                dados.SelectCommand = querysql;
                DataTable tabela = new DataTable();
                dados.Fill(tabela);
                BindingSource fonte = new BindingSource();
                fonte.DataSource = tabela;
                dataGridView1.DataSource = fonte;
                //this.dataGridView1.Columns[0].Visible = false;
                //this.dataGridView1.Columns[1].Visible = false;
                //dataGridView1.Columns[2].HeaderText = "Distrito";
                //dataGridView1.Columns[3].HeaderText = "Concelho";
                dados.Update(tabela);
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            DBConnect.db.Close();
            //textBoxConc.Clear();
            //comboBox1.SelectedIndex = 0;
        }

        private void buttonInserir_Click(object sender, EventArgs e)
        {

            DBConnect NewcConnection = new DBConnect();
            NewcConnection.dbConnection();
            MySqlCommand verifica = new MySqlCommand("SELECT * FROM inicio", DBConnect.db);

            MySqlDataReader read = verifica.ExecuteReader();
            int count = 0;
            while (read.Read())
            {
                count = count + 1;

            }
            DBConnect.db.Close();

            string nome_arquivo = System.IO.Path.GetFileName(textBoxFich.Text);
            string aux_arquivo = "imagensINI/" + nome_arquivo + "";
            MessageBox.Show(aux_arquivo);

            if (textBoxFich.TextLength == 0)
            {
                if (count == 0)
                {
                    NewcConnection = new DBConnect();
                    NewcConnection.dbConnection();
                    MySqlCommand inserir = new MySqlCommand("INSERT INTO inicio (tituloini, inicio_texto, inicio_imagem) Values ('" + textBoxTitulo + "','" + this.textBoxPagIni.Text + "','" + aux_arquivo + "')", DBConnect.db);
                    inserir.ExecuteNonQuery();
                    MessageBox.Show("Sucesso!!");
                }
                else
                {
                    try
                    {
                        NewcConnection = new DBConnect();
                        NewcConnection.dbConnection();
                        MySqlCommand querysql = new MySqlCommand(" UPDATE inicio set tituloini = @Titulo, inicio_texto = @Texto, inicio_imagem = @Image where id_Inicio = @Id", DBConnect.db);
                        querysql.Parameters.AddWithValue("@Id", id_ini);
                        querysql.Parameters.AddWithValue("@Titulo", this.textBoxTitulo.Text);
                        querysql.Parameters.AddWithValue("@Texto", this.textBoxPagIni.Text);
                        querysql.Parameters.AddWithValue("@Image", aux_arquivo);
                        querysql.ExecuteNonQuery();
                        DBConnect.db.Close();
                        MessageBox.Show("Alteração Gravada!!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    MessageBox.Show(aux_arquivo);
                }

            }
            else
            {
                MessageBox.Show("escolha uma foto");
            }
        }

    }
}
