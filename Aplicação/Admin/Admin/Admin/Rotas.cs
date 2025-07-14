using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Admin
{
    public partial class Rotas : Form
    {
        ligacaoDB db = new ligacaoDB();
        dadosAutocarro autocarro = new dadosAutocarro();

        private Dictionary<string, (string Latitude, string Longitude)> cidadesCoords = new Dictionary<string, (string Latitude, string Longitude)>();

        public Rotas()
        {
            InitializeComponent();

            label7.Visible = false;

            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(43, 34, 99); // azul
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.FromArgb(255, 255, 255); // branco

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(
                dataGridView1.Font, FontStyle.Bold
            );

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList; //permite apenas selecionar os items da lista, sem poder escrever
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;


            //textbox invisivel para tirar o foco de outras textboxes
            textBox1.TabStop = false;
            textBox1.Visible = false;
            this.ActiveControl = textBox1;
        }

        private void Rotas_Load(object sender, EventArgs e)
        {
            CarregarAutocarros();
            MostrarAutocarros();
            PreencherCidades();
        }

        private void btSairUtilizador_Click(object sender, EventArgs e)
        {
            Close();
        }


        //CARREGAR OS AUTOCARROS NA DATA GRID VIEW 1
        private void CarregarAutocarros()
        {
            db.open_connection();

            // Definir as colunas do DataGridView
            dataGridView1.Columns.Add("idautocarro", "ID");
            dataGridView1.Columns.Add("numero", "Número do autocarro");
            dataGridView1.Columns.Add("capacidade", "Capacidade");
            dataGridView1.Columns.Add("arCondicionado", "Ar-Condicionado");
            dataGridView1.Columns.Add("wifi", "WiFi");
            dataGridView1.Columns.Add("servico", "Serviço");

            string query = "SELECT * FROM autocarro";

            if (db.open_connection())
            {
                MySqlCommand cmd = new MySqlCommand(query, db.connection);
                cmd.Parameters.AddWithValue("@numero", autocarro.numero); // Definir o parâmetro

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    string ar = dataReader["arCondicionado"].ToString();
                    string wifi = dataReader["wifi"].ToString();
                    string servico = dataReader["servico"].ToString();

                    //verifica se o autocarro tem ar condicionado
                    if (ar == "1")
                    {
                        ar = "Sim";
                    }
                    else
                    {
                        ar = "Não";
                    }

                    //verifica se o autocarro tem wifi
                    if (wifi == "1")
                    {
                        wifi = "Sim";
                    }
                    else
                    {
                        wifi = "Não";
                    }

                    // verifica se o autocarro está ativo
                    if (servico == "1")
                    {
                        servico = "Ativo";
                    }
                    else
                    {
                        servico = "Fora de serviço";
                    }

                    dataGridView1.Rows.Add(
                        dataReader["idautocarro"].ToString(),
                        dataReader["numero"].ToString(),
                        dataReader["capacidade"].ToString(),
                        ar,
                        wifi,
                        servico
                    );
                }
                dataReader.Close();
                db.close_connection();
            }
        }


        //BOTAO PARA VISUALIZAR AS ROTAS DO AUTOCARRO SELECIONADO NO DATAGRIDVIEW 1
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Debug.WriteLine("Coluna selecionada");
                string id_autocarro = dataGridView1.SelectedRows[0].Cells["idautocarro"].Value.ToString();
                string numero = dataGridView1.SelectedRows[0].Cells["numero"].Value.ToString();
                string capacidade = dataGridView1.SelectedRows[0].Cells["capacidade"].Value.ToString();
                string ar = dataGridView1.SelectedRows[0].Cells["arCondicionado"].Value.ToString();
                string wifi = dataGridView1.SelectedRows[0].Cells["wifi"].Value.ToString();
                string servico = dataGridView1.SelectedRows[0].Cells["servico"].Value.ToString();

                autocarro.idautocarro = id_autocarro;
                autocarro.numero = numero;
                autocarro.capacidade = capacidade;
                autocarro.arCondicionado = ar;
                autocarro.wifi = wifi;
                autocarro.servico = servico;


                using (RotasAutocarro rotas = new RotasAutocarro(id_autocarro))
                {
                    this.Hide();
                    rotas.ShowDialog();
                }
                this.Show();
            }
            else
            {
                Debug.WriteLine("Nenhuma coluna selecionada");
                MessageBox.Show("Por favor, selecione um autocarro para visualizar as suas rotas.", "AutoBus");
            }
        }


        //BOTAO DE CRIAR ROTA
        private void btCriarRota_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(maskedTextBox1.Text) || string.IsNullOrWhiteSpace(comboBox1.Text) || 
                string.IsNullOrWhiteSpace(comboBox2.Text))
            {
                label7.Text = "Todos os campos precisam de estar preenchidos";
                label7.Visible = true;
                return;
            }

            string numeroAutocarro = comboBox1.Text;
            string idAutocarro = BuscarIdAutocarroPorNumero(numeroAutocarro);

            if (idAutocarro == null)
            {
                MessageBox.Show("Não foi possível encontrar o autocarro selecionado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string local = comboBox2.Text;
            string horaInput = maskedTextBox1.Text.Replace(" ", "");
            string horaFormatada = horaInput;

            if (TimeSpan.TryParse(horaInput, out TimeSpan time))
            {
                horaFormatada = time.ToString(@"hh\:mm\:ss");
            }

            // Verificar se a rota já existe
            string queryVerificacao = "SELECT COUNT(*) FROM pontos_rotas WHERE idautocarro = @idautocarro AND local = @local AND hora_partida = @hora_partida";

            if (db.open_connection())
            {
                MySqlCommand cmdVerifica = new MySqlCommand(queryVerificacao, db.connection);
                cmdVerifica.Parameters.AddWithValue("@idautocarro", idAutocarro);
                cmdVerifica.Parameters.AddWithValue("@local", local);
                cmdVerifica.Parameters.AddWithValue("@hora_partida", horaFormatada);

                int count = Convert.ToInt32(cmdVerifica.ExecuteScalar());
                db.close_connection();

                if (count > 0)
                {
                    MessageBox.Show("Esta rota já existe para este autocarro.", "AutoBus", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Confirmação
            DialogResult resultado = MessageBox.Show(this, "As informações inseridas estão corretas?", "AutoBus", MessageBoxButtons.YesNo);

            if (resultado == DialogResult.Yes)
            {
                string queryX = "INSERT INTO pontos_rotas (idautocarro, local, latitude, longitude, hora_partida) " +
                                "VALUES (@idautocarro, @local, @latitude, @longitude, @hora_partida)";

                if (db.open_connection())
                {
                    MySqlCommand cmd = new MySqlCommand(queryX, db.connection);
                    cmd.Parameters.AddWithValue("@idautocarro", idAutocarro);
                    cmd.Parameters.AddWithValue("@local", local);
                    cmd.Parameters.AddWithValue("@latitude", textBox3.Text);
                    cmd.Parameters.AddWithValue("@longitude", textBox4.Text);
                    cmd.Parameters.AddWithValue("@hora_partida", horaFormatada);

                    cmd.ExecuteNonQuery();
                    db.close_connection();
                }

                MessageBox.Show("A rota para o autocarro Nº " + idAutocarro + " foi criada com sucesso!", "AutoBus", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();

                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                textBox3.Clear();
                textBox4.Clear();
                maskedTextBox1.Clear();
            }
            else
            {
                MessageBox.Show("Rota inválida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //PERMISSOES DE INSERCAO DE DADOS --------------------------------------------------------------------------------------
        //maskedtextbox da hora de partida
        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // permitir apenas números e controlo como backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // impede a tecla de ser processada
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '-' &&
                e.KeyChar != ',' &&
                e.KeyChar != '.')
            {
                e.Handled = true; // bloqueia a tecla
            }

            // permitir só um sinal de "-" no início
            if (e.KeyChar == '-' && ((sender as System.Windows.Forms.TextBox).SelectionStart != 0 || (sender as System.Windows.Forms.TextBox).Text.Contains("-")))
            {
                e.Handled = true;
            }

            // permitir só uma vírgula ou ponto decimal
            if ((e.KeyChar == ',' || e.KeyChar == '.') &&
                ((sender as System.Windows.Forms.TextBox).Text.Contains(",") || (sender as System.Windows.Forms.TextBox).Text.Contains(".")))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '-' &&
                e.KeyChar != ',' &&
                e.KeyChar != '.')
            {
                e.Handled = true; // bloqueia a tecla
            }

            // permitir só um sinal de "-" no início
            if (e.KeyChar == '-' && ((sender as System.Windows.Forms.TextBox).SelectionStart != 0 || (sender as System.Windows.Forms.TextBox).Text.Contains("-")))
            {
                e.Handled = true;
            }

            // permitir só uma vírgula ou ponto decimal
            if ((e.KeyChar == ',' || e.KeyChar == '.') &&
                ((sender as System.Windows.Forms.TextBox).Text.Contains(",") || (sender as System.Windows.Forms.TextBox).Text.Contains(".")))
            {
                e.Handled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        { }


        //MOSTRAR NUMEROS DOS AUTOCARROS EXISTENTES NA BD
        private void MostrarAutocarros()
        {
            comboBox1.Items.Clear();

            if (db.open_connection())
            {
                string query = "SELECT numero FROM autocarro";

                MySqlCommand cmd = new MySqlCommand(query, db.connection);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    comboBox1.Items.Add(dataReader["numero"].ToString());
                }
                dataReader.Close();
                db.close_connection();
            }
            else
            {
                MessageBox.Show("Não foi possível carregar os autocarros.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //CARREGAR CIDADES
        private void PreencherCidades()
        {
            cidadesCoords.Add("Braga", ("41.5454", "-8.4265"));
            cidadesCoords.Add("Bragança", ("41.8061", "-6.7567"));
            cidadesCoords.Add("Castelo Branco", ("39.8222", "-7.4918"));
            cidadesCoords.Add("Coimbra", ("40.2033", "-8.4103"));
            cidadesCoords.Add("Évora", ("38.5667", "-7.9000"));
            cidadesCoords.Add("Faro", ("37.0194", "-7.9304"));
            cidadesCoords.Add("Guarda", ("40.5373", "-7.2676"));
            cidadesCoords.Add("Leiria", ("39.7495", "-8.8077"));
            cidadesCoords.Add("Lisboa", ("38.7169", "-9.1399"));
            cidadesCoords.Add("Portalegre", ("39.2922", "-7.4289"));
            cidadesCoords.Add("Porto", ("41.1496", "-8.6109"));
            cidadesCoords.Add("Santarém", ("39.2362", "-8.6851"));
            cidadesCoords.Add("Setúbal", ("38.5244", "-8.8882"));
            cidadesCoords.Add("Viana do Castelo", ("41.6946", "-8.8345"));
            cidadesCoords.Add("Vila Real", ("41.3006", "-7.7422"));
            cidadesCoords.Add("Viseu", ("40.6610", "-7.9097"));

            comboBox2.Items.AddRange(cidadesCoords.Keys.OrderBy(c => c).ToArray());
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                string cidadeSelecionada = comboBox2.SelectedItem.ToString();

                if (cidadesCoords.TryGetValue(cidadeSelecionada, out var coordenadas))
                {
                    textBox3.Text = coordenadas.Latitude;
                    textBox4.Text = coordenadas.Longitude;
                }
            }
        }


        //BUSCAR AUTOCARRO PELO NUMERO 
        private string BuscarIdAutocarroPorNumero(string numero)
        {
            string id = null;
            if (db.open_connection())
            {
                string query = "SELECT idautocarro FROM autocarro WHERE numero = @numero LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(query, db.connection);
                cmd.Parameters.AddWithValue("@numero", numero);
                var result = cmd.ExecuteScalar();
                if (result != null)
                    id = result.ToString();
                db.close_connection();
            }
            return id;
        }
    }
}
