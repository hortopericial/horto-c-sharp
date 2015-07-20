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
    /// <summary>
    /// Classe para preencher o formulario Contactos
    /// </summary>
    public partial class Contactos : Form
    {
        int id;
        /// <summary>
        /// Initializes a new instance of the <see cref="Contactos"/> class.
        /// </summary>
        public Contactos()
        {
            InitializeComponent();
            fillgridContact();
        }

        /// <summary>
        /// Fillgrids the contact.
        /// </summary>
        private void fillgridContact()
        {
            id = -1;
            buttonDel.Visible = false;
            buttonEdit.Visible = false;
            buttonIns.Visible = false;
            buttonCancel.Visible = false;
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
            textBoxNome.Clear();
            textBoxMorada.Clear();
            textBoxTel1.Clear();
            textBoxTel2.Clear();
            textBoxEmail.Clear();
        }

        /// <summary>
        /// Handles the Click event of the buttonClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Handles the Click event of the buttonIns control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the CellClick event of the dataGridView1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the Click event of the buttonDel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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


        /// <summary>
        /// Handles the Click event of the buttonCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            fillgridContact();
        }

        private void textBoxNome_TextChanged(object sender, EventArgs e)
        {
            if (textBoxNome.TextLength == 0)
            {
                buttonDel.Visible = false;
                buttonEdit.Visible = false;
                buttonIns.Visible = false;
                if (id != -1)
                {
                    buttonCancel.Visible = true;
                }
            }

            if (textBoxNome.TextLength > 0)
            {

                if (id != -1)
                {
                    buttonDel.Visible = true;
                    buttonEdit.Visible = true;
                    buttonCancel.Visible = true;
                    buttonIns.Visible = false;
                }
                else
                {
                    buttonIns.Visible = true;
                    buttonCancel.Visible = true;
                }
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                DBConnect NewcConnection = new DBConnect();
                NewcConnection.dbConnection();
                MySqlCommand verifica = new MySqlCommand("SELECT * FROM contactos WHERE contatonome LIKE @nome and contatomorada like @morada and contatocontato1 like @tel1 and contatocontato2 like @tel2 and contatoemail like @email  ", DBConnect.db);

                verifica.Parameters.AddWithValue("@nome", this.textBoxNome.Text);
                verifica.Parameters.AddWithValue("@morada", this.textBoxMorada.Text);
                verifica.Parameters.AddWithValue("@tel1", this.textBoxTel1.Text);
                verifica.Parameters.AddWithValue("@tel2", this.textBoxTel2.Text);
                verifica.Parameters.AddWithValue("@email", this.textBoxEmail.Text);
                MySqlDataReader read = verifica.ExecuteReader();
                int count = 0;
                while (read.Read())
                {
                    count = count + 1;
                }
                DBConnect.db.Close();
                if (count == 0)
                {
                    DialogResult dlg = MessageBox.Show("Confirma a alteração no Contacto " + this.textBoxNome.Text + "?", "MessageBox Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlg == DialogResult.Yes)
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

                        NewcConnection = new DBConnect();
                        NewcConnection.dbConnection();
                        MySqlCommand querysql = new MySqlCommand(" UPDATE Contactos set contatonome=@nome, contatomorada=@morada, contatocontato1=@tel1, contatocontato2=@tel2, contatoemail=@email  where Id =@Id_c", DBConnect.db);
                        querysql.Parameters.AddWithValue("@Id_c", id.ToString());

                        querysql.Parameters.AddWithValue("@nome", this.textBoxNome.Text);
                        querysql.Parameters.AddWithValue("@morada", aux_morada_final);
                        querysql.Parameters.AddWithValue("@tel1", aux_tel1_final);
                        querysql.Parameters.AddWithValue("@tel2", aux_tel2_final);
                        querysql.Parameters.AddWithValue("@email", aux_email_final);
                       
                        querysql.ExecuteNonQuery();
                        DBConnect.db.Close();
                        MessageBox.Show("Alteração Gravada!!");
                    }
                    else
                    {
                        MessageBox.Show("Alteração cancelada!!");
                    }
                }
                else
                {
                    MessageBox.Show("Contacto já existe!!");
                }
            }
            catch
            {
                MessageBox.Show("Ocorreu um erro!!");
            }

            fillgridContact();
        } 
               
    }
}
