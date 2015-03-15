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
    public partial class Questionario : Form
    {
        int id;
        public Questionario()
        {
            InitializeComponent();
            fillcombo();
            fillgridPerg();
        }

        public void fillcombo()
        {
            DBConnect NewConnection = new DBConnect();
            NewConnection.dbConnection();
            MySqlCommand querysql = new MySqlCommand("select * from questionset", DBConnect.db);
            MySqlDataReader dataread = querysql.ExecuteReader();
            comboBox1.Items.Add("Selecione um QuestionSet");
            int count = 0;
            while (dataread.Read())
            {
                count = count + 1;
                comboBox1.Items.Add(dataread["id_qs"].ToString() + " " + "-" + " " + dataread["name_qs"].ToString());
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

        private void fillgridPerg()
        {
            id = -1;
            buttonDel.Visible = false;
            buttonEdit.Visible = false;
            buttonIns.Visible = false;
            buttonCancel.Visible = false;
            DBConnect NewcConnection = new DBConnect();
            NewcConnection.dbConnection();
            MySqlCommand querysql = new MySqlCommand("Select id_quest, id_qs, questao, name_qs From questionarios, questionset where id_qs_fk = id_qs", DBConnect.db);
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
                dataGridView1.Columns[2].HeaderText = "Questão";
                dataGridView1.Columns[3].HeaderText = "QuestionSet";
                dados.Update(tabela);
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            DBConnect.db.Close();
            textBoxPerg.Clear();
            comboBox1.SelectedIndex = 0;
        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxPerg_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPerg.TextLength == 0)
            {
                buttonDel.Visible = false;
                buttonEdit.Visible = false;
                buttonIns.Visible = false;
                if (id != -1)
                {
                    buttonCancel.Visible = true;
                }
            }

            if (textBoxPerg.TextLength > 0)
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    buttonDel.Visible = true;
                    buttonEdit.Visible = true;

                    id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id_quest"].Value.ToString());
                    DBConnect NewcConnection = new DBConnect();
                    NewcConnection.dbConnection();
                    MySqlCommand querysql = new MySqlCommand("Select id_quest, id_qs_fk, questao, name_qs From questionarios, questionset where id_qs_fk = id_qs and id_quest =" + id + "", DBConnect.db);
                    querysql.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    MySqlDataAdapter dados = new MySqlDataAdapter(querysql);
                    dados.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        textBoxPerg.Text = dr["questao"].ToString();
                        comboBox1.SelectedIndex = comboBox1.FindStringExact(dr["id_qs_fk"].ToString() + " " + "-" + " " + dr["name_qs"].ToString());
                    }
                }
                catch
                {
                    buttonDel.Visible = false;
                    buttonEdit.Visible = false;
                    buttonIns.Visible = false;
                    textBoxPerg.Clear();
                    id = -1;
                    MessageBox.Show("Selecione uma celula valida");
                }
            }
        }

        private void buttonIns_Click(object sender, EventArgs e)
        {
            string selectedItem = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            string[] getid_qs = selectedItem.Split(' ');
            if (comboBox1.SelectedIndex != 0)
            {

                DBConnect NewcConnection = new DBConnect();
                NewcConnection.dbConnection();
                MySqlCommand verifica = new MySqlCommand("SELECT * FROM questionarios WHERE questao LIKE @Questao", DBConnect.db);

                verifica.Parameters.AddWithValue("@Questao", this.textBoxPerg.Text);
                MySqlDataReader read = verifica.ExecuteReader();
                int count = 0;
                while (read.Read())
                {
                    count = count + 1;
                }
                DBConnect.db.Close();

                DialogResult dlg = MessageBox.Show("Confirma a inserção da Pergunta " + this.textBoxPerg.Text + " do QuestionSet " + getid_qs[2] + "?", "MessageBox Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == DialogResult.Yes)
                {
                    if (count == 0)
                    {
                        NewcConnection = new DBConnect();
                        NewcConnection.dbConnection();
                        MySqlCommand querysql = new MySqlCommand("INSERT INTO questionarios (id_qs_fk, questao) Values ('" + getid_qs[0] + "','" + this.textBoxPerg.Text + "')", DBConnect.db);
                        querysql.ExecuteNonQuery();
                        MessageBox.Show("Sucesso!!");
                    }
                    else
                    {
                        NewcConnection = new DBConnect();
                        NewcConnection.dbConnection();
                        MySqlCommand verifica1 = new MySqlCommand("SELECT * FROM questionarios WHERE id_qs_fk = @id_qs", DBConnect.db);
                        verifica1.Parameters.AddWithValue("@id_qs", getid_qs[0]);
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
                            MySqlCommand querysql = new MySqlCommand("INSERT INTO questionarios (id_qs_fk, questao) Values ('" + getid_qs[0] + "','" + this.textBoxPerg.Text + "')", DBConnect.db);
                            querysql.ExecuteNonQuery();
                            MessageBox.Show("Sucesso!!");
                        }
                        else
                        {
                            MessageBox.Show("Pergunta já existe!!");
                        }
                    }
                }
                DBConnect.db.Close();
                fillgridPerg();
            }
            else
            {
                MessageBox.Show("Selecione um QuestionSet");
            }
        }
    }
}
