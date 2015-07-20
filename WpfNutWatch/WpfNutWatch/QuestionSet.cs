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
    /// Classe para preenchimento do formulario QuestionSet
    /// </summary>
    public partial class QuestionSet : Form
    {
        int id;
        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionSet"/> class.
        /// </summary>
        public QuestionSet()
        {
            InitializeComponent();
            fillgridQS();
        }

        /// <summary>
        /// Handles the TextChanged event of the textBox1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBoxQS.TextLength == 0)
            {
                buttonDel.Visible = false;
                buttonEdit.Visible = false;
                buttonIns.Visible = false;
                if (id != -1)
                {
                    buttonCancel.Visible = true;
                }
            }

            if (textBoxQS
                .TextLength > 0)
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
                }
            }
        }

        /// <summary>
        /// Fillgrids the qs.
        /// </summary>
        private void fillgridQS()
        {
            id = -1;
            buttonDel.Visible = false;
            buttonEdit.Visible = false;
            buttonIns.Visible = false;
            buttonCancel.Visible = false;
            DBConnect NewcConnection = new DBConnect();
            NewcConnection.dbConnection();
            MySqlCommand querysql = new MySqlCommand("Select * From questionset", DBConnect.db);

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
                dataGridView1.Columns[1].HeaderText = "Question Set";
                dataGridView1.Columns[2].HeaderText = "ID Pergunta";
                dataGridView1.Columns[3].HeaderText = "ID Pre Diagnosico";
                dados.Update(tabela);
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            DBConnect.db.Close();
            textBoxQS.Clear();
        }

        /// <summary>
        /// Handles the Click event of the buttonCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            fillgridQS();
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
        /// Handles the Click event of the buttonIns control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonIns_Click(object sender, EventArgs e)
        {
            DBConnect NewcConnection = new DBConnect();
            NewcConnection.dbConnection();
            MySqlCommand verifica = new MySqlCommand("SELECT * FROM questionset WHERE name_qs LIKE @qs", DBConnect.db);

            verifica.Parameters.AddWithValue("@qs", this.textBoxQS.Text);
            MySqlDataReader read = verifica.ExecuteReader();
            int count = 0;
            while (read.Read())
            {
                count = count + 1;
            }
            DBConnect.db.Close();
            if (count == 0)
            {
                DialogResult dlg = MessageBox.Show("Confirma a inserção da QuestionSet " + this.textBoxQS.Text + "?", "MessageBox Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == DialogResult.Yes)
                {

                    NewcConnection = new DBConnect();
                    NewcConnection.dbConnection();
                    MySqlCommand querysql = new MySqlCommand("INSERT INTO questionset (name_qs) Values ('" + this.textBoxQS.Text + "')", DBConnect.db);
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
                MessageBox.Show("QuestionSet já existe!!");
            }
            DBConnect.db.Close();
            fillgridQS();
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

                    id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id_qs"].Value.ToString());
                    DBConnect NewcConnection = new DBConnect();
                    NewcConnection.dbConnection();
                    MySqlCommand querysql = new MySqlCommand("Select * From questionset where id_qs =" + id + "", DBConnect.db);
                    querysql.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    MySqlDataAdapter dados = new MySqlDataAdapter(querysql);
                    dados.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        textBoxQS.Text = dr["name_qs"].ToString();
                    }
                }
                catch
                {
                    buttonDel.Visible = false;
                    buttonEdit.Visible = false;
                    buttonIns.Visible = false;
                    textBoxQS.Clear();
                    id = -1;
                    MessageBox.Show("Selecione uma celula valida");
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonEdit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                DBConnect NewcConnection = new DBConnect();
                NewcConnection.dbConnection();
                MySqlCommand verifica = new MySqlCommand("SELECT * FROM questionset WHERE name_qs =  @qs", DBConnect.db);

                verifica.Parameters.AddWithValue("@qs", this.textBoxQS.Text);
                MySqlDataReader read = verifica.ExecuteReader();
                int count = 0;
                while (read.Read())
                {
                    count = count + 1;
                }
                DBConnect.db.Close();
                if (count == 0)
                {
                    DialogResult dlg = MessageBox.Show("Confirma a alteração na QuestionSet " + this.textBoxQS.Text + "?", "MessageBox Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlg == DialogResult.Yes)
                    {
                        NewcConnection = new DBConnect();
                        NewcConnection.dbConnection();
                        MySqlCommand querysql = new MySqlCommand(" UPDATE questionset set name_qs = @qs where id_qs =@Id", DBConnect.db);
                        querysql.Parameters.AddWithValue("@Id", id.ToString());
                        querysql.Parameters.AddWithValue("@qs", this.textBoxQS.Text);
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
                    MessageBox.Show("QuestionSet já existe!!");
                }
            }
            catch
            {
                MessageBox.Show("Ocorreu um erro!!");
            }

            fillgridQS();
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
                DialogResult dlg = MessageBox.Show("Quer apagar a QuestionSet " + this.textBoxQS.Text + "?", "MessageBox Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == DialogResult.Yes)
                {
                    DialogResult dlg2 = MessageBox.Show("Tem a certeza que quer apagar a QuestionSet " + this.textBoxQS.Text + " ?", "MessageBox Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlg2 == DialogResult.Yes)
                    {
                        DBConnect NewcConnection = new DBConnect();
                        NewcConnection.dbConnection();
                        MySqlCommand querysql = new MySqlCommand(" Delete from questionset where id_qs =@Id", DBConnect.db);
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

            fillgridQS();

        }
        
    }
}
