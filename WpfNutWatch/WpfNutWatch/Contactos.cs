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
    public partial class Contactos : Form
    {
        int id;
        public Contactos()
        {
            InitializeComponent();
            fillgridContact();
        }

        private void fillgridContact()
        {
            //id = -1;
            //buttonDel.Visible = false;
            //buttonEdit.Visible = false;
            //buttonIns.Visible = false;
            //buttonCancel.Visible = false;
            DBConnect NewcConnection = new DBConnect();
            NewcConnection.dbConnection();
            MySqlCommand querysql = new MySqlCommand("Select * From contactos", DBConnect.db);

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
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            DBConnect.db.Close();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonIns_Click(object sender, EventArgs e)
        {
            //string selectedItem = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            //string[] getid_dist = selectedItem.Split(' ');
            if (textBoxNome.TextLength != 0)
            {
                if (textBoxMorada.TextLength != 0 || textBoxTel1.TextLength != 0 || textBoxTel2.TextLength != 0 || textBoxEmail.TextLength != 0)
                {
                    string aux_morada_final = null;
                    string aux_tel1_final = null;
                    string aux_tel2_final = null;
                    string aux_email_final = null;
                    string aux_morada = "Morada: ";
                    string aux_tel = "Tel.: (+351) ";
                    string aux_email = "Email: ";
                    if (textBoxMorada.TextLength != 0)
                    {
                        aux_morada_final = aux_morada + textBoxMorada.Text;
                    }
                    if (textBoxTel1.TextLength != 0)
                    {
                        aux_tel1_final = aux_tel + textBoxTel1.Text;
                    }
                    if (textBoxTel2.TextLength != 0)
                    {
                        aux_tel2_final = aux_tel + textBoxTel2.Text;
                    }
                    if (textBoxEmail.TextLength != 0)
                    {
                        aux_email_final = aux_email + textBoxEmail.Text;
                    }

                    DBConnect NewcConnection = new DBConnect();
                    NewcConnection.dbConnection();
                    MySqlCommand verifica = new MySqlCommand("SELECT * FROM contactos WHERE contatonome LIKE @nome", DBConnect.db);
                    verifica.Parameters.AddWithValue("@nome", this.textBoxNome.Text);
                    MySqlDataReader read = verifica.ExecuteReader();
                    int count = 0;
                    while (read.Read())
                    {
                        count = count + 1;
                    }
                    DBConnect.db.Close();
                    if (count == 0)
                    {
                        DialogResult dlg = MessageBox.Show("Confirma a inserção do contato " + this.textBoxNome.Text + "?", "MessageBox Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dlg == DialogResult.Yes)
                        {

                            NewcConnection = new DBConnect();
                            NewcConnection.dbConnection();
                            MySqlCommand querysql = new MySqlCommand("INSERT INTO contactos (contatonome, contatomorada, contatocontato1, contatocontato2, contatoemail) Values ('" + this.textBoxNome.Text + "','" + aux_morada_final + "','" + aux_tel1_final + "','" + aux_tel2_final + "','" + aux_email_final +"')", DBConnect.db);
                            querysql.ExecuteNonQuery();
                            MessageBox.Show("Sucesso!!");
                        }
                        else
                        {
                            MessageBox.Show("Operação Cancelada!!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Contato já existe!!");
                    }
                    DBConnect.db.Close();
                    fillgridContact();
                }
                else 
                {
                    MessageBox.Show("Tem de inserir pelo menos um Contato!");
                }
             
            }
            else
            {
                MessageBox.Show("Não preencheu o Nome!");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    buttonDel.Visible = true;
                    buttonEdit.Visible = true;

                    id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                    DBConnect NewcConnection = new DBConnect();
                    NewcConnection.dbConnection();
                    MySqlCommand querysql = new MySqlCommand("Select * From contactos where Id =" + id + "", DBConnect.db);
                    querysql.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    MySqlDataAdapter dados = new MySqlDataAdapter(querysql);
                    dados.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        textBoxNome.Text = dr["contatonome"].ToString();
                        if (dr["contatomorada"].ToString().Length != 0)
                        {
                            string morada = dr["contatomorada"].ToString();                            
                            textBoxMorada.Text = morada.Substring(8,morada.Length-8);
                        }
                        if (dr["contatocontato1"].ToString().Length != 0)
                        {
                            string tel1 = dr["contatocontato1"].ToString();
                            string[] gettel1 = tel1.Split(' ');
                            textBoxTel1.Text = gettel1[2];
                        }
                        if (dr["contatocontato2"].ToString().Length != 0)
                        {
                            string tel2 = dr["contatocontato2"].ToString();
                            string[] gettel2 = tel2.Split(' ');
                            textBoxTel2.Text = gettel2[2];
                        }
                        if (dr["contatoemail"].ToString().Length != 0)
                        {
                            string email = dr["contatoemail"].ToString();
                            string[] getemail = email.Split(' ');
                            textBoxEmail.Text = getemail[1];
                        }                                                                  
                    }
                }
                catch
                {
                    buttonDel.Visible = false;
                    buttonEdit.Visible = false;
                    buttonIns.Visible = false;
                    textBoxNome.Clear();
                    textBoxMorada.Clear();
                    textBoxTel1.Clear();
                    textBoxTel2.Clear();
                    textBoxEmail.Clear();
                    id = -1;
                    MessageBox.Show("Selecione uma celula valida");
                }
            }

        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dlg = MessageBox.Show("Quer apagar o contato " + this.textBoxNome.Text + "?", "MessageBox Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == DialogResult.Yes)
                {
                    DialogResult dlg2 = MessageBox.Show("Tem a certeza que quer apagar o contato " + this.textBoxNome.Text + " ?", "MessageBox Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlg2 == DialogResult.Yes)
                    {
                        DBConnect NewcConnection = new DBConnect();
                        NewcConnection.dbConnection();
                        MySqlCommand querysql = new MySqlCommand(" Delete from contactos where Id =@Id", DBConnect.db);
                        querysql.Parameters.AddWithValue("@Id", id.ToString());
                        querysql.ExecuteNonQuery();
                        MessageBox.Show("Apagado com sucesso!!");
                        DBConnect.db.Close();
                    }
                    else
                    {
                        MessageBox.Show("Operação anulada!!!");
                    }
                }
                else
                {
                    MessageBox.Show("Operação anulada!!!");
                }
            }
            catch
            {
                MessageBox.Show("Ocorreu um erro!!");
            }

            fillgridContact();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fillgridContact();
        } 
               
    }
}
