using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Admin
{
    public partial class Autocarro: Form
    {
        ligacaoDB db = new ligacaoDB();
        dadosAutocarro autocarroDados = new dadosAutocarro();

        public int idAuto;
        //private int numero;

        public Autocarro(string opcao, dadosAutocarro auto)
        {
            InitializeComponent();
            db.inicializa();

            TopMost = false;

            autocarroDados = auto;

            panelCriar.Visible = false;
            panelEditar.Visible = false;

            // lógica para controlar a visibilidade dos painéis
            if (opcao == "criar")
            {
                panelCriar.Visible = true;
                panelEditar.Visible = false;

                carregarDados();
            }
            else if (opcao == "editar")
            {
                panelEditar.Visible = true;
                panelCriar.Visible = false;
            }

            label8.Visible = false;

            //textbox invisivel para tirar o foco de outras textboxes
            textBox3.TabStop = false;
            textBox3.Visible = false;
            this.ActiveControl = textBox3;

            textBox4.Text = autocarroDados.numero;
            textBox5.Text = autocarroDados.capacidade;
            comboBox1.Text = autocarroDados.arCondicionado;
            comboBox2.Text = autocarroDados.wifi;
            comboBox3.Text = autocarroDados.servico;
        }


        private void panelCriar_Paint(object sender, PaintEventArgs e)
        {

        }


        //BOTAO DE SAIR
        private void btSairCriar_Click(object sender, EventArgs e)
        {
            Close();
        }


        //CÓDIGO PARA >>>>ADICIONAR<<<< O AUTOCARRO -----------------------------------------------------------
        private void btAdicionarAutocarro_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("botao clicado.");

            // Verificar se os campos obrigatórios estão preenchidos
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                // Verificar se todos os radio buttons foram selecionados
                if (!(radioButton1.Checked || radioButton2.Checked) ||
                    !(radioButton3.Checked || radioButton4.Checked) ||
                    !(radioButton5.Checked || radioButton6.Checked))
                {
                    label8.Text = "Todos os campos precisam de estar preenchidos ou selecionados.";
                    label8.Visible = true;
                    return;
                }
            }

            label8.Visible = false;

            // Abrir ligação à BD
            if (db.open_connection())
            {
                string query = "SELECT COUNT(*) FROM autocarro WHERE numero = @numero";

                using (MySqlCommand sql = new MySqlCommand(query, db.connection))
                {
                    sql.Parameters.AddWithValue("@numero", textBox1.Text);
                    int count = Convert.ToInt32(sql.ExecuteScalar());

                    if (count > 0)
                    {
                        label8.Text = "O número inserido já existe.";
                        label8.Visible = true;
                        db.close_connection();
                        return;
                    }
                }

                label8.Visible = false;

                // Confirmar dados
                DialogResult resultado = MessageBox.Show(this, "As informações inseridas estão corretas?", "AutoBus", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    string insertQuery = "INSERT INTO autocarro (numero, capacidade, arCondicionado, wifi, servico) " +
                                         "VALUES (@numero, @capacidade, @arCondicionado, @wifi, @servico)";

                    int wifi = radioButton1.Checked ? 1 : 0;
                    int ar = radioButton3.Checked ? 1 : 0;
                    int servico = radioButton5.Checked ? 1 : 0;

                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, db.connection))
                    {
                        cmd.Parameters.AddWithValue("@numero", textBox1.Text);
                        cmd.Parameters.AddWithValue("@capacidade", textBox2.Text);
                        cmd.Parameters.AddWithValue("@arCondicionado", ar);
                        cmd.Parameters.AddWithValue("@wifi", wifi);
                        cmd.Parameters.AddWithValue("@servico", servico);

                        cmd.ExecuteNonQuery();
                    }

                    db.close_connection();

                    Debug.WriteLine("Operação feita com sucesso!.");
                    MessageBox.Show("Autocarro adicionado com sucesso!", "AutoBus", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpar campos
                    textBox1.Clear();
                    textBox2.Clear();
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                    radioButton5.Checked = false;
                    radioButton6.Checked = false;

                    this.Close();
                }
                else
                {
                    Debug.WriteLine("Operação cancelada.");
                    MessageBox.Show("Autocarro inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.close_connection();
                }
            }
            else
            {
                MessageBox.Show("Erro ao conectar à base de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //CÓDIGO PARA >>>>EDITAR<<<< O AUTOCARRO ------------------------------------------------------------------------
        private void btEditarAutocarro_Click(object sender, EventArgs e)
        {
            //definir a query
            string query = "UPDATE autocarro SET capacidade=@capacidade, arCondicionado=@arCondicionado, wifi=@wifi, servico=@servico WHERE numero=@numero";

            //abrir a ligação à BD
            if (db.open_connection())
            {
                int wifi = -1;
                int ar = -1; 
                int servico = -1;

                if (comboBox1.SelectedIndex == 0)
                {
                    wifi = 1; //corresponde a "Sim"
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    wifi = 0; //corresponde a "Não"
                }

                if (comboBox2.SelectedIndex == 0)
                {
                    ar = 1; //corresponde a "Sim"
                }
                else if (comboBox2.SelectedIndex == 1)
                {
                    ar = 0; //corresponde a "Não"
                }

                if (comboBox3.SelectedIndex == 0)
                {
                    servico = 1; //corresponde a "ativo"
                }
                else if (comboBox3.SelectedIndex == 1)
                {
                    servico = 0; //corresponde a "fora de servico"
                }

                MySqlCommand cmd = new MySqlCommand(query, db.connection);

                cmd.Parameters.AddWithValue("@numero", textBox4.Text);
                cmd.Parameters.AddWithValue("@capacidade", textBox5.Text);
                cmd.Parameters.AddWithValue("@arCondicionado", ar);
                cmd.Parameters.AddWithValue("@wifi", wifi);
                cmd.Parameters.AddWithValue("@servico", servico);

                MessageBoxButtons botoes = MessageBoxButtons.YesNo;
                System.Windows.Forms.DialogResult resultado;

                resultado = MessageBox.Show(this, "Tem certeza que deseja alterar os dados?", "AutoBus", botoes);

                if (resultado == System.Windows.Forms.DialogResult.Yes) //caso "sim"
                {
                    //executar o comando
                    cmd.ExecuteNonQuery();

                    //fechar a ligação à BD
                    db.close_connection();

                    MessageBox.Show("Autocarro editado com sucesso!", "AutoBus", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    textBox4.Clear();
                    textBox5.Clear();
                    comboBox1.SelectedIndex = -1;
                    comboBox2.SelectedIndex = -1;
                    comboBox3.SelectedIndex = -1;

                    this.Close();
                }
                else //caso "não"
                {
                    MessageBox.Show("Operação cancelada.");
                }
            }

            else
            {
                MessageBox.Show("Autocarro inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //botao sair
        private void btSairEditar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panelEditar_Paint(object sender, PaintEventArgs e)
        {        }


        //carregar os dados
        private void carregarDados()
        {
            // Abrir a ligação à BD
            if (db.open_connection())
            {
                // Definir a query de pesquisa
                string query = "SELECT * FROM autocarro WHERE idautocarro = @idautocarro";

                MySqlCommand cmdDados = new MySqlCommand(query, db.connection);
                cmdDados.Parameters.AddWithValue("@idautocarro", autocarroDados.idautocarro); // ou idAuto, conforme usares

                MySqlDataReader reader = cmdDados.ExecuteReader();

                if (reader.Read())
                {
                    textBox4.Text = reader["numero"].ToString();
                    textBox5.Text = reader["capacidade"].ToString();

                    // arCondicionado
                    comboBox1.SelectedIndex = Convert.ToInt32(reader["arCondicionado"]) == 1 ? 0 : 1;

                    // wifi
                    comboBox2.SelectedIndex = Convert.ToInt32(reader["wifi"]) == 1 ? 0 : 1;

                    // servico
                    comboBox3.SelectedIndex = Convert.ToInt32(reader["servico"]) == 1 ? 0 : 1;
                }

                reader.Close();
                db.close_connection();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // permitir apenas números e controlo como backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // impede a tecla de ser processada
                textBox1.MaxLength = 5;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // permitir apenas números e controlo como backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // impede a tecla de ser processada
                textBox2.MaxLength = 5;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            // permitir apenas números e controlo como backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // impede a tecla de ser processada
                textBox5.MaxLength = 2;
            }
        }
    }
}
