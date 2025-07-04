using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Admin
{
    public partial class Perfil: Form
    {
        DadosUtilizador utilizador = new DadosUtilizador();
        ligacaoDB db = new ligacaoDB();

        public int nif;

        public Perfil(DadosUtilizador user)
        {
            InitializeComponent();
            db.inicializa();

            utilizador = user;
            nif = utilizador.id_utilizador;

            //MessageBox.Show("ID do utilizador: " + id); // debug
            Debug.WriteLine("NIF: " + nif); // debug

            carregarDados();

            // textbox invisível para tirar o foco
            textBox4.TabStop = false;
            textBox4.Visible = false;
            this.ActiveControl = textBox4;

            if (utilizador.email == "autobus.pap@gmail.com")
            {
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                label4.Visible = true;
                label4.Text = "Não é possível editar os dados do administrador principal.";
            }
            else
            {
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                label4.Visible = false;
            }
        }

        //botao de sair
        private void btVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }

        //funcao para carregar os dados do admin
        private void carregarDados()
        {
            // Abrir a ligação à BD
            if (db.open_connection())
            {
                string query = "SELECT * FROM utilizadores WHERE nif = @nif";

                MySqlCommand info = new MySqlCommand(query, db.connection);
                info.Parameters.AddWithValue("@nif", nif);

                MySqlDataReader rdr = info.ExecuteReader();

                if (rdr.Read())
                {
                    textBox1.Text = Convert.ToString(rdr["id_utilizador"]);
                    textBox2.Text = Convert.ToString(rdr["nome"]);
                    textBox3.Text = Convert.ToString(rdr["email"]);
                    textBox5.Text = Convert.ToString(rdr["telefone"]);
                    textBox6.Text = Convert.ToString(rdr["localidade"]);
                    dateTimePicker1.Text = Convert.ToString(rdr["nascimento"]);
                }

                rdr.Close();
                db.close_connection();
                Debug.WriteLine("Dados carregados com sucesso."); 
            }

            else
            {
                Debug.WriteLine("Falha ao carregar os dados.");
            }
        }

        private void btEscolherImgCriar_Click(object sender, EventArgs e)
        {
            ImagemPerfil formImagem = new ImagemPerfil(pictureBox2);
            formImagem.ShowDialog();
        }

        private void btCarregarImgCriar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Imagens|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(ofd.FileName);
            }
        }
    }
}
