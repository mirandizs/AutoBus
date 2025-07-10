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
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net;

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
            nif = utilizador.nif;

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
          try
          {
            textBox1.Text = utilizador.id_utilizador.ToString();
            textBox2.Text = utilizador.nome;
            textBox3.Text = utilizador.email;
            textBox5.Text = utilizador.telefone.ToString();
            textBox6.Text = utilizador.localidade;

            if (utilizador.nascimento > dateTimePicker1.MinDate && utilizador.nascimento < dateTimePicker1.MaxDate)
            {
              dateTimePicker1.Value = utilizador.nascimento;
            }
            else
            {
              // Define uma data padrão válida
              dateTimePicker1.Value = DateTime.Now;
            }

            Debug.WriteLine("Dados carregados sem BD.");
          }
          catch (Exception ex)
          {
            Debug.WriteLine("Erro ao carregar dados do objeto: " + ex.Message);
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

    private void Perfil_Load(object sender, EventArgs e)
    {
      string URLImagem = "http://localhost:3000/api/imagens/utilizador/" + nif;
      using (var stream = new WebClient().OpenRead(URLImagem))
      {
        Image originalImage = Image.FromStream(stream);
        Bitmap resizedImage = new Bitmap(originalImage, new Size(140, 135)); // Tamanho 30x30
        pictureBox2.Image = resizedImage;
      }
    }
  }
}
