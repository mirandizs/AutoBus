using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin
{
    public partial class RotasAutocarro : Form
    {
        private string idSelecionado;

        ligacaoDB db = new ligacaoDB();
        dadosAutocarro autocarro = new dadosAutocarro();

        public RotasAutocarro(string idautocarro)
        {
            InitializeComponent();
            idSelecionado = idautocarro;

            MostrarRotas();

            textBox1.Text = idSelecionado;

            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.FromArgb(43, 34, 99); // azul
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.FromArgb(255, 255, 255); // branco

            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font(
                dataGridView2.Font, FontStyle.Bold
            );
        }


        //mostrar as rotas relacionadas ao autocarro selecionado
        public void MostrarRotas()
        {
            dataGridView2.Rows.Clear();

            if (string.IsNullOrWhiteSpace(idSelecionado))
            {
                MessageBox.Show("ID de autocarro inválido.", "Erro");
                return;
            }

            if (dataGridView2.Columns.Count == 0)
            {
                dataGridView2.Columns.Add("idautocarro", "Nº Autocarro");
                dataGridView2.Columns.Add("local", "Localidade");
                dataGridView2.Columns.Add("latitude", "Latitude");
                dataGridView2.Columns.Add("longitude", "Longitude");
                dataGridView2.Columns.Add("hora_partida", "Hora de partida");
            }

            string query = "SELECT * FROM pontos_rotas WHERE idautocarro = @idautocarro";

            if (db.open_connection())
            {
                MySqlCommand cmd = new MySqlCommand(query, db.connection);
                cmd.Parameters.AddWithValue("@idautocarro", idSelecionado);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    dataGridView2.Rows.Add(
                        dataReader["idautocarro"].ToString(),
                        dataReader["local"].ToString(),
                        dataReader["latitude"].ToString(),
                        dataReader["longitude"].ToString(),
                        TimeSpan.Parse(dataReader["hora_partida"].ToString()).ToString(@"hh\:mm\:ss")
                    );
                }

                dataReader.Close();
                db.close_connection();
            }
        }


        //botao de sair 
        private void btSair_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
