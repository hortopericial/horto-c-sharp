using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections;

namespace WpfNutWatch
{
    /// <summary>
    /// Classe para preencher o formulario distrito
    /// </summary>
    public partial class Distrito : Form
    {
        int id;

        /// <summary>
        /// Initializes a new instance of the <see cref="Distrito"/> class.
        /// </summary>
        public Distrito()
        {
            InitializeComponent();
            fillgridDis();
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
            MySqlCommand verifica = new MySqlCommand("SELECT * FROM distrito WHERE nome_dist LIKE @distrito", DBConnect.db);
          
            verifica.Parameters.AddWithValue("@distrito", this.textBoxDis.Text);
            MySqlDataReader read = verifica.ExecuteReader();
            int count = 0;
            while (read.Read())
            {
                count = count + 1;
            }
            DBConnect.db.Close(); 
            if (count == 0)
            {
                DialogResult dlg = MessageBox.Show("Confirma a inserção do Distrito " + this.textBoxDis.Text + "?", "MessageBox Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == DialogResult.Yes)
                {

                    NewcConnection = new DBConnect();
                    NewcConnection.dbConnection();
                    MySqlCommand querysql = new MySqlCommand("INSERT INTO distrito (nome_dist) Values ('" + this.textBoxDis.Text + "')", DBConnect.db);
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
                MessageBox.Show("Distrito já existe!!");
            }
            DBConnect.db.Close();           
            fillgridDis();
        }

        /// <summary>
        /// Fillgrids the dis.
        /// </summary>
        private void fillgridDis()
        {
            id = -1;
            buttonDel.Visible = false;
            buttonEdit.Visible = false;
            buttonIns.Visible = false;
            buttonCancel.Visible = false;
            DBConnect NewcConnection = new DBConnect();
            NewcConnection.dbConnection();
            MySqlCommand querysql = new MySqlCommand("Select * From distrito", DBConnect.db);

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
                dataGridView1.Columns[1].HeaderText = "Distrito";
                dados.Update(tabela);
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            DBConnect.db.Close();
            textBoxDis.Clear();
        
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
                    
                    id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id_distrito"].Value.ToString());
                    DBConnect NewcConnection = new DBConnect();
                    NewcConnection.dbConnection();
                    MySqlCommand querysql = new MySqlCommand("Select * From distrito where id_distrito =" + id + "", DBConnect.db);
                    querysql.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    MySqlDataAdapter dados = new MySqlDataAdapter(querysql);
                    dados.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        textBoxDis.Text = dr["nome_dist"].ToString();
                    }
                }
                catch
                {
                    buttonDel.Visible = false;
                    buttonEdit.Visible = false;
                    buttonIns.Visible = false;
                    textBoxDis.Clear();
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
                MySqlCommand verifica = new MySqlCommand("SELECT * FROM distrito WHERE nome_dist LIKE @distrito", DBConnect.db);
          
                verifica.Parameters.AddWithValue("@distrito", this.textBoxDis.Text);
                MySqlDataReader read = verifica.ExecuteReader();
                int count = 0;
                while (read.Read())
                {
                    count = count + 1;
                }
                DBConnect.db.Close();
                if (count == 0)
                {
                    DialogResult dlg = MessageBox.Show("Confirma a alteração no Distrito " + this.textBoxDis.Text + "?", "MessageBox Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlg == DialogResult.Yes)
                    {
                        NewcConnection = new DBConnect();
                        NewcConnection.dbConnection();
                        MySqlCommand querysql = new MySqlCommand(" UPDATE distrito set nome_dist = @distrito where id_distrito =@Id", DBConnect.db);
                        querysql.Parameters.AddWithValue("@Id", id.ToString());
                        querysql.Parameters.AddWithValue("@distrito", this.textBoxDis.Text);
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
                    MessageBox.Show("Distrito já existe!!");
                }
            }
            catch
            {
                MessageBox.Show("Ocorreu um erro!!");
            }
            
            fillgridDis();
        }

        /// <summary>
        /// Handles the Click event of the buttonDel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonDel_Click(object sender, EventArgs e)
        {

            DBConnect NewcConnection = new DBConnect();
            NewcConnection.dbConnection();
            MySqlCommand verifica = new MySqlCommand("SELECT * FROM concelho WHERE iddistrito_fk = @Id", DBConnect.db);

            verifica.Parameters.AddWithValue("@Id", id.ToString());
            MySqlDataReader read = verifica.ExecuteReader();
            int count = 0;
            while (read.Read())
            {
                count = count + 1;
            }
            DBConnect.db.Close();
            if (count == 0)
            {
                try
                {
                    DialogResult dlg = MessageBox.Show("Quer apagar o Distrito " + this.textBoxDis.Text + "?", "MessageBox Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                     if (dlg == DialogResult.Yes)
                     {
                         DialogResult dlg2 = MessageBox.Show("Tem a certeza que quer apagar o Distrito " + this.textBoxDis.Text + " ?", "MessageBox Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                         if (dlg2 == DialogResult.Yes)
                         {
                             NewcConnection = new DBConnect();
                             NewcConnection.dbConnection();
                             MySqlCommand querysql = new MySqlCommand(" Delete from distrito where id_distrito =@Id", DBConnect.db);
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
            }
            else
            {
                DialogResult dlg = MessageBox.Show("Quer apagar o Distrito " + this.textBoxDis.Text + " e os concelhos associados?", "MessageBox Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == DialogResult.Yes)
                {
                    DialogResult dlg2 = MessageBox.Show("Tem a certeza que quer apagar o Distrito " + this.textBoxDis.Text + " e os concelhos associados?", "MessageBox Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlg2 == DialogResult.Yes)
                    {
                        NewcConnection = new DBConnect();
                        NewcConnection.dbConnection();
                        MySqlCommand querysql = new MySqlCommand(" Delete from concelho where iddistrito_fk =@Id", DBConnect.db);
                        querysql.Parameters.AddWithValue("@Id", id.ToString());
                        querysql.ExecuteNonQuery();
                        DBConnect.db.Close();

                        NewcConnection = new DBConnect();
                        NewcConnection.dbConnection();
                        MySqlCommand querysql1 = new MySqlCommand(" Delete from distrito where id_distrito =@Id", DBConnect.db);
                        querysql1.Parameters.AddWithValue("@Id", id.ToString());
                        querysql1.ExecuteNonQuery();
                        DBConnect.db.Close();
                        MessageBox.Show("Apagados com sucesso!!!");
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
            fillgridDis();
        }

        /// <summary>
        /// Handles the TextChanged event of the textBoxDis control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void textBoxDis_TextChanged(object sender, EventArgs e)
        {

            if (textBoxDis.TextLength == 0)
            {
                buttonDel.Visible = false;
                buttonEdit.Visible = false;
                buttonIns.Visible = false;
                if (id != -1)
                {
                    buttonCancel.Visible = true;
                }
            }

            if (textBoxDis.TextLength > 0)
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
            fillgridDis();
        }
    }
}
