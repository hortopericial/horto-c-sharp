using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net;
using System.IO;


namespace WpfNutWatch
{
    public partial class FormPagIni : Form
    {
        // FTP        
        String directoria = "views/mainPage/images/";
        String ftp_url = @"ftp://nutwatch.twomini.com/";
        String Http = @"http://nutwatch.twomini.com/";
        String user = "u963389833";
        String pwd = "Jonas123";

        string id_ini;

        public FormPagIni()
        {
            InitializeComponent();
            fillgridIni();
            ButtonName();
        }

        private void textfic()
        {
            DBConnect NewcConnection = new DBConnect();
            NewcConnection.dbConnection();
            MySqlCommand verifica = new MySqlCommand("SELECT * FROM Inicio", DBConnect.db);
            MySqlDataReader read = verifica.ExecuteReader();
            while (read.Read())
            {                           
                string aux = Http + read["mainimage"].ToString();
                textBoxFich.Text = aux;                
            }
            DBConnect.db.Close();                   
        }

        private void ButtonName()
        {
            DBConnect NewcConnection = new DBConnect();
            NewcConnection.dbConnection();
            MySqlCommand verifica = new MySqlCommand("SELECT * FROM Inicio", DBConnect.db);

            MySqlDataReader read = verifica.ExecuteReader();
            int count = 0;
            while (read.Read())
            {
                count = count + 1;
                id_ini = read["id_Inicio"].ToString();
                textBoxTitulo.Text = read["maintitle"].ToString();
                textBoxPagIni.Text = read["mainbody"].ToString();
                string aux = Http + read["mainimage"].ToString();
                textBoxFich.Text = aux;
                try
                {
                    WebClient client = new WebClient();                    
                    byte[] imageData = client.DownloadData(aux);                   
                    //this.pictureBox1.ImageLocation = aux;
                    this.pictureBox1.Image = Image.FromStream(new MemoryStream(imageData));
                }
                catch
                {
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
            string caminho = ligar.getfolderfile("para a", "Página inicial");
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
            MySqlCommand querysql = new MySqlCommand("Select * From Inicio", DBConnect.db);

            try
            {
                MySqlDataAdapter dados = new MySqlDataAdapter();
                dados.SelectCommand = querysql;
                DataTable tabela = new DataTable();
                dados.Fill(tabela);
                BindingSource fonte = new BindingSource();
                fonte.DataSource = tabela;
                dataGridView1.DataSource = fonte;
                this.dataGridView1.Columns[0].Visible = false;
                //this.dataGridView1.Columns[1].Visible = false;
                //dataGridView1.Columns[2].HeaderText = "Distrito";
                //dataGridView1.Columns[3].HeaderText = "Concelho";
                dados.Update(tabela);
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                if(dataGridView1.RowCount == 0)
                {
                    buttonInserir.Text = "Inserir";
                }
                else
                {
                    buttonInserir.Text = "Update";
                    textfic();
                }
                   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            DBConnect.db.Close();         
        }

        private void buttonInserir_Click(object sender, EventArgs e)
        {
            FTPClass ftp = new FTPClass();
            DBConnect NewcConnection = new DBConnect();
            NewcConnection.dbConnection();
            MySqlCommand verifica = new MySqlCommand("SELECT * FROM Inicio", DBConnect.db);
            MySqlDataReader read = verifica.ExecuteReader();
            int count = 0;
            string old_file="";
            while (read.Read())
            {
                old_file = read["mainimage"].ToString();                    
                count = count + 1;
            }
            DBConnect.db.Close();
            string nome_arquivo = System.IO.Path.GetFileName(textBoxFich.Text);
            string aux_arquivo = directoria + nome_arquivo;
            if (textBoxFich.TextLength != 0 && textBoxPagIni.TextLength != 0 && textBoxTitulo.TextLength !=0)
            {
                if (count == 0)
                {
                    NewcConnection = new DBConnect();
                    NewcConnection.dbConnection();
                    MySqlCommand inserir = new MySqlCommand("INSERT INTO Inicio (maintitle, mainbody, mainimage) Values ('" + this.textBoxTitulo.Text + "','" + this.textBoxPagIni.Text + "','" + aux_arquivo + "')", DBConnect.db);
                    inserir.ExecuteNonQuery();
                    ftp.upload(textBoxFich.Text, ftp_url, user, pwd, nome_arquivo, directoria); 
                    fillgridIni();
                    MessageBox.Show("Sucesso!!");
                 }
                 else
                 {
                    try
                    {   
                        NewcConnection = new DBConnect();
                        NewcConnection.dbConnection();
                        if (textBoxFich.Text == Http + old_file || textBoxFich.TextLength == 0)
                        {
                            MessageBox.Show("true");
                            MySqlCommand querysql = new MySqlCommand(" UPDATE Inicio set maintitle = @Titulo, mainbody = @Texto where id_Inicio = @Id", DBConnect.db);
                            querysql.Parameters.AddWithValue("@Id", id_ini);
                            querysql.Parameters.AddWithValue("@Titulo", this.textBoxTitulo.Text);
                            querysql.Parameters.AddWithValue("@Texto", this.textBoxPagIni.Text);                      
                            querysql.ExecuteNonQuery();
                        }
                        else
                        {
                            MessageBox.Show("false");
                            MySqlCommand querysql = new MySqlCommand(" UPDATE Inicio set maintitle = @Titulo, mainbody = @Texto, mainimage = @Image where id_Inicio = @Id", DBConnect.db);
                            querysql.Parameters.AddWithValue("@Id", id_ini);
                            querysql.Parameters.AddWithValue("@Titulo", this.textBoxTitulo.Text);
                            querysql.Parameters.AddWithValue("@Texto", this.textBoxPagIni.Text);
                            querysql.Parameters.AddWithValue("@Image", aux_arquivo);
                            querysql.ExecuteNonQuery();
                            if (old_file != null && old_file != "")
                            {
                                ftp.apagar_ficheiro(old_file, ftp_url, user, pwd, "");
                            }
                            ftp.upload(textBoxFich.Text, ftp_url, user, pwd, nome_arquivo, directoria);
                        
                        }
                        
                        DBConnect.db.Close();
                            
                        fillgridIni();
                        MessageBox.Show("Alteração Gravada!!");
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show(ex.ToString());
                        }                       
                    }
                }
                else
                {
                    MessageBox.Show("Falta preencher campos");
                }
            }
        }
    }

