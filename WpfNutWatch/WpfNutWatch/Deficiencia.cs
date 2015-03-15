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
    public partial class Deficiencia : Form
    {
        int id;

        public Deficiencia()
        {
            InitializeComponent();
            fillgridDef();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fillgridDef()
        {
            id = -1;
            buttonDel.Visible = false;
            buttonEdit.Visible = false;
            buttonIns.Visible = false;
            buttonCancel.Visible = false;
            DBConnect NewcConnection = new DBConnect();
            NewcConnection.dbConnection();
            MySqlCommand querysql = new MySqlCommand("Select * From deficiencias", DBConnect.db);

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
                dataGridView1.Columns[1].HeaderText = "Deficiencia";
                dados.Update(tabela);
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            DBConnect.db.Close();
            textBoxDef.Clear();
        }

        private void buttonIns_Click(object sender, EventArgs e)
        {
            DBConnect NewcConnection = new DBConnect();
            NewcConnection.dbConnection();
            MySqlCommand verifica = new MySqlCommand("SELECT * FROM deficiencias WHERE nome_deficiencia LIKE @def", DBConnect.db);
          
            verifica.Parameters.AddWithValue("@def", this.textBoxDef.Text);
            MySqlDataReader read = verifica.ExecuteReader();
            int count = 0;
            while (read.Read())
            {
                count = count + 1;
            }
            DBConnect.db.Close(); 
            if (count == 0)
            {
                DialogResult dlg = MessageBox.Show("Confirma a inserção da deficiencia " + this.textBoxDef.Text + "?", "MessageBox Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == DialogResult.Yes)
                {

                    NewcConnection = new DBConnect();
                    NewcConnection.dbConnection();
                    MySqlCommand querysql = new MySqlCommand("INSERT INTO deficiencias (nome_deficiencia) Values ('" + this.textBoxDef.Text + "')", DBConnect.db);
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
                MessageBox.Show("Deficiencia já existe!!");
            }
            DBConnect.db.Close();           
            fillgridDef();
        }

        private void textBoxDef_TextChanged(object sender, EventArgs e)
        {
            if (textBoxDef.TextLength == 0)
            {
                buttonDel.Visible = false;
                buttonEdit.Visible = false;
                buttonIns.Visible = false;
                if (id != -1)
                {
                    buttonCancel.Visible = true;
                }
            }

            if (textBoxDef.TextLength > 0)
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            fillgridDef();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    buttonDel.Visible = true;
                    buttonEdit.Visible = true;

                    id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id_deficiencia"].Value.ToString());
                    DBConnect NewcConnection = new DBConnect();
                    NewcConnection.dbConnection();
                    MySqlCommand querysql = new MySqlCommand("Select * From deficiencias where id_deficiencia =" + id + "", DBConnect.db);
                    querysql.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    MySqlDataAdapter dados = new MySqlDataAdapter(querysql);
                    dados.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        textBoxDef.Text = dr["nome_deficiencia"].ToString();
                    }
                }
                catch
                {
                    buttonDel.Visible = false;
                    buttonEdit.Visible = false;
                    buttonIns.Visible = false;
                    textBoxDef.Clear();
                    id = -1;
                    MessageBox.Show("Selecione uma celula valida");
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
           try
                {
                    DialogResult dlg = MessageBox.Show("Quer apagar a deficienccia " + this.textBoxDef.Text + "?", "MessageBox Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlg == DialogResult.Yes)
                    {
                        DialogResult dlg2 = MessageBox.Show("Tem a certeza que quer apagar a deficiencia " + this.textBoxDef.Text + " ?", "MessageBox Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dlg2 == DialogResult.Yes)
                        {
                            DBConnect NewcConnection = new DBConnect();
                            NewcConnection.dbConnection();
                            MySqlCommand querysql = new MySqlCommand(" Delete from deficiencias where id_deficiencia =@Id", DBConnect.db);
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
             
            fillgridDef();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                DBConnect NewcConnection = new DBConnect();
                NewcConnection.dbConnection();
                MySqlCommand verifica = new MySqlCommand("SELECT * FROM deficiencias WHERE nome_deficiencia =  @def", DBConnect.db);

                verifica.Parameters.AddWithValue("@def", this.textBoxDef.Text);
                MySqlDataReader read = verifica.ExecuteReader();
                int count = 0;
                while (read.Read())
                {
                    count = count + 1;
                }
                DBConnect.db.Close();
                if (count == 0)
                {
                    DialogResult dlg = MessageBox.Show("Confirma a alteração na deficiencia " + this.textBoxDef.Text + "?", "MessageBox Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlg == DialogResult.Yes)
                    {
                        NewcConnection = new DBConnect();
                        NewcConnection.dbConnection();
                        MySqlCommand querysql = new MySqlCommand(" UPDATE deficiencias set nome_deficiencia = @def where id_deficiencia =@Id", DBConnect.db);
                        querysql.Parameters.AddWithValue("@Id", id.ToString());
                        querysql.Parameters.AddWithValue("@def", this.textBoxDef.Text);
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
                    MessageBox.Show("Deficiencia já existe!!");
                }
            }
            catch
            {
                MessageBox.Show("Ocorreu um erro!!");
            }

            fillgridDef();
        }        


    }
}
