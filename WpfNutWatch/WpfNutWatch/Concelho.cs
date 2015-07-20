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
    /// Classe do formulario de preenchimento do Concelho
    /// </summary>
    public partial class Concelho : Form
    {
        int id;

        /// <summary>
        /// Initializes a new instance of the <see cref="Concelho"/> class.
        /// </summary>
        public Concelho()
        {
            InitializeComponent();
            fillcombo();
            fillgridConc();
        }

        /// <summary>
        /// Fillcomboes this instance.
        /// </summary>
        public void fillcombo()
        {
            DBConnect NewConnection = new DBConnect();
            NewConnection.dbConnection();
            MySqlCommand querysql = new MySqlCommand("select * from distrito", DBConnect.db);
            MySqlDataReader dataread = querysql.ExecuteReader();            
            comboBox1.Items.Add("Selecione um Distrito");
            int count = 0;
            while (dataread.Read())
            {
                count = count + 1;
                comboBox1.Items.Add(dataread["id_distrito"].ToString() + " " + "-" + " " + dataread["nome_dist"].ToString());
            }
            if (count == 0)
            {
                comboBox1.Visible = false;
            }
            else
            {
                comboBox1.Visible = true;
            }

            DBConnect.db.Close();
            comboBox1.SelectedIndex = 0;
        }

        /// <summary>
        /// Fillgrids the conc.
        /// </summary>
        private void fillgridConc()
        {
            id = -1;
            buttonDel.Visible = false;
            buttonEdit.Visible = false;
            buttonIns.Visible = false;
            buttonCancel.Visible = false;
            DBConnect NewcConnection = new DBConnect();
            NewcConnection.dbConnection();
            MySqlCommand querysql = new MySqlCommand("Select id_concelho, iddistrito_fk, nome_dist, nome_conc From concelho, distrito where iddistrito_fk = id_distrito", DBConnect.db);

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
                this.dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].HeaderText = "Distrito";
                dataGridView1.Columns[3].HeaderText = "Concelho";
                dados.Update(tabela);
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            DBConnect.db.Close();
            textBoxConc.Clear();
            comboBox1.SelectedIndex = 0;
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
                    id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id_concelho"].Value.ToString());
                    DBConnect NewcConnection = new DBConnect();
                    NewcConnection.dbConnection();
                    MySqlCommand querysql = new MySqlCommand("Select id_concelho, iddistrito_fk, nome_dist, nome_conc From concelho, distrito where iddistrito_fk = id_distrito and id_concelho =" + id + "", DBConnect.db);
                    querysql.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    MySqlDataAdapter dados = new MySqlDataAdapter(querysql);
                    dados.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        textBoxConc.Text = dr["nome_conc"].ToString();
                        comboBox1.SelectedIndex = comboBox1.FindStringExact(dr["iddistrito_fk"].ToString() +" "+"-"+" " + dr["nome_dist"].ToString());
                    }
                }
                catch
                {
                    buttonDel.Visible = false;
                    buttonEdit.Visible = false;
                    buttonIns.Visible = false;
                    textBoxConc.Clear();
                    id = -1;
                    MessageBox.Show("Selecione uma celula valida");
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonIns control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonIns_Click(object sender, EventArgs e)
        {
            string selectedItem = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            string[] getid_dist = selectedItem.Split(' ');
            if (comboBox1.SelectedIndex != 0)
            {

                DBConnect NewcConnection = new DBConnect();
                NewcConnection.dbConnection();
                MySqlCommand verifica = new MySqlCommand("SELECT * FROM concelho WHERE nome_conc LIKE @Concelho", DBConnect.db);

                verifica.Parameters.AddWithValue("@Concelho", this.textBoxConc.Text);
                MySqlDataReader read = verifica.ExecuteReader();
                int count = 0;
                while (read.Read())
                {
                    count = count + 1;
                }
                DBConnect.db.Close();
            
                DialogResult dlg = MessageBox.Show("Confirma a inserção do Concelho " + this.textBoxConc.Text + " do Distrito "+getid_dist[2]+"?", "MessageBox Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == DialogResult.Yes)
                {
                    if (count == 0)
                    {
                        NewcConnection = new DBConnect();
                        NewcConnection.dbConnection();
                        MySqlCommand querysql = new MySqlCommand("INSERT INTO concelho (iddistrito_fk, nome_conc) Values ('" + getid_dist[0] + "','" + this.textBoxConc.Text + "')", DBConnect.db);
                        querysql.ExecuteNonQuery();
                        MessageBox.Show("Sucesso!!");
                    }
                    else
                    {
                        NewcConnection = new DBConnect();
                        NewcConnection.dbConnection();
                        MySqlCommand verifica1 = new MySqlCommand("SELECT * FROM concelho WHERE iddistrito_fk = @id_distrito", DBConnect.db);
                        verifica1.Parameters.AddWithValue("@id_distrito", getid_dist[0]);
                        MySqlDataReader read1 = verifica1.ExecuteReader();
                        int count1 = 0;
                        while (read1.Read())
                        {
                            count1 = count1 + 1;
                        }

                        DBConnect.db.Close();
                        if (count1 == 0)
                        {
                            NewcConnection = new DBConnect();
                            NewcConnection.dbConnection();
                            MySqlCommand querysql = new MySqlCommand("INSERT INTO concelho (iddistrito_fk, nome_conc) Values ('" + getid_dist[0] + "','" + this.textBoxConc.Text + "')", DBConnect.db);
                            querysql.ExecuteNonQuery();
                            MessageBox.Show("Sucesso!!");
                        }
                        else
                        {
                            MessageBox.Show("Concelho já existe!!");
                        }
                    }
                }
                DBConnect.db.Close();
                fillgridConc();
            }
            else
            {
                MessageBox.Show("Selecione um Distrito");
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the textBoxConc control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void textBoxConc_TextChanged(object sender, EventArgs e)
        {
            if (textBoxConc.TextLength == 0)
            {
                buttonDel.Visible = false;
                buttonEdit.Visible = false;
                buttonIns.Visible = false;
                if (id != -1)
                {
                    buttonCancel.Visible = true;
                }
            }

            if (textBoxConc.TextLength > 0)
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

        /// <summary>
        /// Handles the Click event of the buttonCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            fillgridConc();
        }

        /// <summary>
        /// Handles the Click event of the buttonSair control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonSair_Click(object sender, EventArgs e)
        {
            Close();
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
                    DialogResult dlg = MessageBox.Show("Quer apagar o Concelho " + this.textBoxConc.Text + "?", "MessageBox Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlg == DialogResult.Yes)
                    {
                        DialogResult dlg2 = MessageBox.Show("Tem a certeza que quer apagar o Concelho " + this.textBoxConc.Text + " ?", "MessageBox Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dlg2 == DialogResult.Yes)
                        {
                            DBConnect NewcConnection = new DBConnect();
                            NewcConnection.dbConnection();
                            MySqlCommand querysql = new MySqlCommand(" Delete from concelho where id_concelho =@Id", DBConnect.db);
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
             
            fillgridConc();
        }

        /// <summary>
        /// Handles the Click event of the buttonEdit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            string selectedItem = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            string[] getid_dist = selectedItem.Split(' ');
            if (comboBox1.SelectedIndex != 0)
            {

                DBConnect NewcConnection = new DBConnect();
                NewcConnection.dbConnection();
                MySqlCommand verifica = new MySqlCommand("SELECT * FROM concelho WHERE nome_conc LIKE @Concelho", DBConnect.db);

                verifica.Parameters.AddWithValue("@Concelho", this.textBoxConc.Text);
                MySqlDataReader read = verifica.ExecuteReader();
                int count = 0;
                while (read.Read())
                {
                    count = count + 1;
                }
                DBConnect.db.Close();

                if (count == 0)
                {
                    NewcConnection = new DBConnect();
                    NewcConnection.dbConnection();
                    //MySqlCommand querysql = new MySqlCommand("INSERT INTO concelho (iddistrito_fk, nome_conc) Values ('" + getid_dist[0] + "','" + this.textBoxConc.Text + "')", DBConnect.db);
                    MySqlCommand querysql = new MySqlCommand(" UPDATE concelho set iddistrito_fk = @Distrito, nome_conc = @Concelho where id_concelho =@Id", DBConnect.db);
                    querysql.Parameters.AddWithValue("@Id", id.ToString());
                    querysql.Parameters.AddWithValue("@Distrito", getid_dist[0]);
                    querysql.Parameters.AddWithValue("@Concelho", this.textBoxConc.Text); 
                    querysql.ExecuteNonQuery();
                    MessageBox.Show("Sucesso!!");
                }
                else
                {
                    NewcConnection = new DBConnect();
                    NewcConnection.dbConnection();
                    MySqlCommand verifica1 = new MySqlCommand("SELECT * FROM concelho WHERE iddistrito_fk = @id_distrito", DBConnect.db);
                    verifica1.Parameters.AddWithValue("@id_distrito", getid_dist[0]);
                    MySqlDataReader read1 = verifica1.ExecuteReader();
                    int count1 = 0;
                    while (read1.Read())
                    {
                        count1 = count1 + 1;
                    }

                    DBConnect.db.Close();
                    if (count1 == 0)
                    {
                        NewcConnection = new DBConnect();
                        NewcConnection.dbConnection();
                        MySqlCommand querysql = new MySqlCommand(" UPDATE concelho set iddistrito_fk = @Distrito, nome_conc = @Concelho where id_concelho =@Id", DBConnect.db);
                        querysql.Parameters.AddWithValue("@Id", id.ToString());
                        querysql.Parameters.AddWithValue("@Distrito", getid_dist[0]);
                        querysql.Parameters.AddWithValue("@Concelho", this.textBoxConc.Text); 
                        querysql.ExecuteNonQuery();
                        MessageBox.Show("Sucesso!!");
                    }
                    else
                    {
                        MessageBox.Show("Concelho já existe!!");
                    }
                }
                DBConnect.db.Close();
                fillgridConc();
            }
        }
    }
}
