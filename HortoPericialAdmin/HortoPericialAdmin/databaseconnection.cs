using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace HortoPericialAdmin
{    
    class databaseconnection
    {
        public static MySqlConnection db = null;
        private string server;
        private string port;
        private string database;
        private string uid;
        private string password;

        public void dbConnection()
        {

            server = "sql3.freesqldatabase.com";
            port = "3306";
            database = "sql346213";
            uid = "sql346213";
            password = "qQ1*wW9*";
            string connectionString;
            connectionString = "Server=" + server + ";" + "Port=" + port + ";" + "Database=" +
            database + ";" + "Uid=" + uid + ";" + "Pwd=" + password + ";";
            
            try
            {
                db = new MySqlConnection(connectionString);
                db.Open();
            }
            catch (Exception msg)
            {
                System.Windows.MessageBox.Show( msg.Message , "Your Caption Here");
            }
        }
    }
}
