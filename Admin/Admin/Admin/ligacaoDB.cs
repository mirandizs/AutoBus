using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Admin
{
    internal class ligacaoDB
    {
        public MySqlConnection connection;
        string server;
        string port;
        public string data_base;
        string user_id;
        string password;

        public void inicializa()
        {
            server = "localhost"; // 127.0.0.1 OU localhost
            data_base = "pap";
            port = "3306";
            user_id = "root";
            password = "";
            string connection_string;

            connection_string = "SERVER=" + server + ";" +
                                "PORT=" + port + ";" +
                                "DATABASE=" + data_base + ";" +
                                "UID=" + user_id + ";" +
                                "PWD=" + password + ";";

            connection = new MySqlConnection(connection_string);
        }

        public bool open_connection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed ||
                    connection.State == System.Data.ConnectionState.Broken)
                {
                    connection.Open();
                }
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Não foi possível estabelacer ligação");
                        break;
                    case 1042:
                        MessageBox.Show("Execedeu o tempo de ligação");
                        break;
                    case 1045:
                        MessageBox.Show("Username/password incorretos");
                        break;
                    default:
                        MessageBox.Show("Erro: " + ex.Message);
                        break;
                }
                return false;
            }
        }

        public bool close_connection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public ligacaoDB()
        {
            inicializa();
        }
    }
}


