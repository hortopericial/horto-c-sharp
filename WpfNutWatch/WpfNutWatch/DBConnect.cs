using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace WpfNutWatch
{
    class DBConnect
    {

        public static MySqlConnection db = null;
        private string server;
        private string port;
        private string database;
        private string uid;
        private string password;

        /// <summary>
        /// Databases the connection.
        /// </summary>
        public void dbConnection()
        {            
            //server = "ltictrab.ddns.net";
            //port = "3306";
            //port = "3307";
            //uid = "user";
            //connectionString = "Server=" + server + ";" + "Port=" + port + ";" + "Database=" +
            //database + ";" + "Uid=" + uid + ";" + "Pwd=" + password + ";

            //server = "localhost";
            //database = "hortopericial";
            //uid = "root";
            //password = "root";
            /*server = "mysql.2freehosting.com";         
            database = "u963389833_horto";
            uid = "u963389833_horto";            
            password = "Jonas123";*/

            server = "localhost";
            database = "sql483442";
            uid = "root";
            password = "";
            port = "3306";
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
                System.Windows.MessageBox.Show(msg.Message, "Your Caption Here");
            }
        }
    }
}
