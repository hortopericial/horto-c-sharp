using MySql.Data.MySqlClient;
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
    public partial class Especies : Form
    {
        int id;
        public Especies()
        {
            InitializeComponent();
            fillgridEsp();
            fillcombo();
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

        private void fillgridEsp()
        {
            id = -1;
            buttonDel.Visible = false;
            buttonEdit.Visible = false;
            buttonIns.Visible = false;
            buttonCancel.Visible = false;
            DBConnect NewcConnection = new DBConnect();
            NewcConnection.dbConnection();
            MySqlCommand querysql = new MySqlCommand("Select * From especies", DBConnect.db);

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
                this.dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Nome Comum";
                dataGridView1.Columns[2].HeaderText = "Nome Cientifico";
                dados.Update(tabela);
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            DBConnect.db.Close();
            textBoxEspNCo.Clear();
            textBoxEspNCi.Clear();
        }


        private void buttonSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxEspNCo_TextChanged(object sender, EventArgs e)
        {
            if (textBoxEspNCo.TextLength == 0)
            {
                buttonDel.Visible = false;
                buttonEdit.Visible = false;
                buttonIns.Visible = false;
                if (id != -1)
                {
                    buttonCancel.Visible = true;
                }
            }

            if (textBoxEspNCo.TextLength > 0 && textBoxEspNCi.TextLength >0)
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

        private void textBoxEspNCi_TextChanged(object sender, EventArgs e)
        {
            if (textBoxEspNCi.TextLength == 0)
            {
                buttonDel.Visible = false;
                buttonEdit.Visible = false;
                buttonIns.Visible = false;
                if (id != -1)
                {
                    buttonCancel.Visible = true;
                }
            }

            if (textBoxEspNCo.TextLength > 0 && textBoxEspNCi.TextLength > 0)
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

        private void buttonIns_Click(object sender, EventArgs e)
        {
            string selectedItem = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            string[] getid_qs = selectedItem.Split(' ');
            if (comboBox1.SelectedIndex != 0)
            {

                DBConnect NewcConnection = new DBConnect();
                NewcConnection.dbConnection();
                MySqlCommand verifica = new MySqlCommand("SELECT * FROM especies WHERE nome_comum LIKE @nomecomum and nome_cientifico Like @nomecientifico", DBConnect.db);

                verifica.Parameters.AddWithValue("@nomecomum", this.textBoxEspNCo.Text);
                verifica.Parameters.AddWithValue("@nomecientifico", this.textBoxEspNCi.Text);
                MySqlDataReader read = verifica.ExecuteReader();
                int count = 0;
                while (read.Read())
                {
                    count = count + 1;
                }
                DBConnect.db.Close();

                DialogResult dlg = MessageBox.Show("Confirma a inserção da Especie " + this.textBoxEspNCo.Text + " do QuestionSet " + getid_qs[2] + "?", "MessageBox Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == DialogResult.Yes)
                {
                    if (count == 0)
                    {
                        NewcConnection = new DBConnect();
                        NewcConnection.dbConnection();
                        MySqlCommand querysql = new MySqlCommand("INSERT INTO especies (nome_comum, nome_cientifico, questionset_id_qs) Values ('" + this.textBoxEspNCo.Text + "','" + this.textBoxEspNCi.Text + "','" + getid_qs[0] + "')", DBConnect.db);
                        querysql.ExecuteNonQuery();
                        MessageBox.Show("Sucesso!!");
                    }
                    else
                    {
                        NewcConnection = new DBConnect();
                        NewcConnection.dbConnection();
                        MySqlCommand verifica1 = new MySqlCommand("SELECT * FROM especies WHERE questionset_id_qs = @id_qs", DBConnect.db);
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
                            MySqlCommand querysql = new MySqlCommand("INSERT INTO especies (nome_comum, nome_cientifico, question_id_qs) Values ('" + this.textBoxEspNCo.Text + "','" + this.textBoxEspNCi.Text + "','" + getid_qs[0] + "')", DBConnect.db);
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
                fillgridEsp();
            }
            else
            {
                MessageBox.Show("Selecione um QuestionSet");
            }

        }
    }
}
