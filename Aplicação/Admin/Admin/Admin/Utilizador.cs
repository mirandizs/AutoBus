using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin
{
  public partial class Utilizador : Form
  {
    ligacaoDB db = new ligacaoDB();
    DadosUtilizador utilizador = new DadosUtilizador();

    //private int nif;
    public int id;

    public Utilizador(string opcao, DadosUtilizador user)
    {
      InitializeComponent();

      db.inicializa();

      Debug.WriteLine("Executou");
      Debug.WriteLine(user);

      utilizador = user;

      TopMost = false;

      carregarDados();

      textBox1.Text = utilizador.id_utilizador.ToString();
      textBox2.Text = utilizador.nif.ToString();
      textBox3.Text = utilizador.nome;
      textBox4.Text = utilizador.email;
      textBox5.Text = utilizador.telefone.ToString();
      textBox6.Text = utilizador.localidade;
      dateTimePicker1.Text = utilizador.nascimento.ToString();
      comboBox2.Text = utilizador.tipo_utilizador;
      comboBox1.Text = utilizador.atividade;


      string URLImagem = "http://localhost:3000/api/imagens/utilizador/" + utilizador.nif;
      Debug.WriteLine(URLImagem);
      Debug.WriteLine("A tentar carregar imagem");

      pictureBox1.ImageLocation = URLImagem;

      panelCriar.Visible = false;
      panelEditar.Visible = false;

      // Lógica para controlar a visibilidade dos painéis
      if (opcao == "criar")
      {
        panelCriar.Visible = true;
        panelEditar.Visible = false;
      }
      else if (opcao == "editar")
      {
        panelEditar.Visible = true;
        panelCriar.Visible = false;
      }

      //textbox invisivel para tirar o foco de outras textboxes
      textBox15.TabStop = false;
      textBox15.Visible = false;
      this.ActiveControl = textBox15;
    }



    Funcoes funcoes = new Funcoes();


    //CÓDIGO PARA >>>>CRIAR<<<< O UTILIZADOR -----------------------------------
    private void btCriarUtilizador_Click(object sender, EventArgs e)
    {


      if (CaminhoImagem!= null)
      {
        Debug.WriteLine(CaminhoImagem);
        int nif_input = int.Parse(textBox8.Text);
        Debug.WriteLine(textBox2.Text);
        funcoes.UploadImagem(CaminhoImagem, nif_input);
      }

      ////caso as passwords não forem iguais
      if (textBox13.Text != textBox14.Text)
      {
        label21.Text = "As palavras-passe não coincidem.";
        label21.Visible = true;
      }

      else if (textBox13.Text == textBox14.Text)
      {
        label21.Visible = false;

        //caso os campos não estejam todos completos ou sejam nulos
        if (string.IsNullOrWhiteSpace(textBox8.Text) || string.IsNullOrWhiteSpace(textBox9.Text) ||
            string.IsNullOrWhiteSpace(textBox10.Text) || string.IsNullOrWhiteSpace(textBox11.Text) ||
            string.IsNullOrWhiteSpace(textBox12.Text) || string.IsNullOrWhiteSpace(textBox13.Text) ||
            string.IsNullOrWhiteSpace(textBox14.Text))
        {
          if (string.IsNullOrWhiteSpace(comboBox3.Text) || string.IsNullOrWhiteSpace(comboBox4.Text) ||
              string.IsNullOrWhiteSpace(dateTimePicker2.Text))
          {
            label21.Text = "Todos os campos precisam de estar preenchidos";
            label21.Visible = true;
          }
        }
        else
        {
          label21.Visible = false;

          //caso as passwords tenham menos que 8 caracteres
          if (textBox10.Text.Length < 8 || textBox11.Text.Length < 8)
          {
            label21.Text = "A palavra-passe deve conter no mínimo 8 caracteres.";
            label21.Visible = true;
          }
          else
          {
            label21.Visible = false;

            // Verificar se o NIF tem exatamente 9 dígitos numéricos
            if (textBox8.Text.Length != 9 || !textBox8.Text.All(char.IsDigit))
            {
              label21.Text = "O NIF deve conter exatamente 9 dígitos numéricos.";
              label21.Visible = true;
            }

            // Verificar se o número de telemóvel tem pelo menos 9 dígitos
            if (textBox11.Text.Length < 9 || !textBox11.Text.All(char.IsDigit))
            {
              label21.Text = "O número de telemóvel deve conter exatamente 9 dígitos numéricos.";
              label21.Visible = true;
            }

            else
            {
              label21.Visible = false;

              // Verificar se a idade é menor de 18 anos
              DateTime dataNascimento;
              if (!DateTime.TryParse(dateTimePicker2.Text, out dataNascimento))
              {
                label21.Text = "Data de nascimento inválida.";
                label21.Visible = true;
              }
              else
              {
                int idade = DateTime.Today.Year - dataNascimento.Year;
                if (dataNascimento.Date > DateTime.Today.AddYears(-idade)) idade--; // Ajuste para aniversário ainda não ocorrido

                if (idade < 18)
                {
                  label21.Text = "É necessário ter pelo menos 18 anos para criar uma conta.";
                  label21.Visible = true;
                }
                else
                {
                  label21.Visible = false;

                  if (db.open_connection())
                  {
                    string queryNIF = "SELECT COUNT(1) FROM utilizadores WHERE nif = @nif";

                    using (MySqlCommand sql = new MySqlCommand(queryNIF, db.connection))
                    {
                      sql.Parameters.AddWithValue("@nif", textBox8.Text);

                      object result = sql.ExecuteScalar();
                      int count = (result != null && int.TryParse(result.ToString(), out int value)) ? value : 0;

                      if (count > 0)
                      {
                        label21.Text = "O NIF inserido já existe.";
                        label21.Visible = true;
                      }

                      else
                      {
                        label21.Visible = false;


                        string queryEmail = "SELECT COUNT(1) FROM utilizadores WHERE email = @email";

                        using (MySqlCommand sql2 = new MySqlCommand(queryEmail, db.connection))
                        {
                          sql2.Parameters.AddWithValue("@email", textBox10.Text);

                          object result2 = sql2.ExecuteScalar();
                          int count2 = (result2 != null && int.TryParse(result.ToString(), out int valor)) ? valor : 0;

                          if (count2 > 0)
                          {
                            label21.Text = "O e-mail inserido já existe.";
                            label21.Visible = true;
                          }

                          else
                          {
                            label21.Visible = false;

                            //mensagem para confirmar os dados e aceder o form principal
                            MessageBoxButtons botao = MessageBoxButtons.YesNo;
                            System.Windows.Forms.DialogResult resultado;

                            resultado = MessageBox.Show(this, "As informações inseridas estão corretas?", "AutoBus", botao);

                            if (resultado == System.Windows.Forms.DialogResult.Yes)
                            {

                              //definir a query
                              string queryX = "INSERT INTO utilizadores (nif, nome, nascimento, telefone, localidade, email, password, tipo_utilizador, atividade) " +
                                              "VALUES (@nif, @nome, @nascimento, @telefone, @localidade, @email, @password, @tipo_utilizador, @atividade)";

                              string tipoUtilizador = (comboBox4.Text == "Administrador") ? "0" : "1";
                              string atividade = (comboBox3.Text == "Inativo") ? "0" : "1";

                              //abrir a ligação à BD
                              if (db.open_connection())
                              {
                                //criar o comando e associar a query com a ligação através do construtor
                                MySqlCommand cmd = new MySqlCommand(queryX, db.connection);
                                cmd.Parameters.AddWithValue("@nif", textBox8.Text);
                                cmd.Parameters.AddWithValue("@nome", textBox9.Text);
                                cmd.Parameters.AddWithValue("@nascimento", dateTimePicker2.Value.ToString("yyyy-MM-dd"));
                                cmd.Parameters.AddWithValue("@telefone", textBox11.Text);
                                cmd.Parameters.AddWithValue("@localidade", textBox12.Text);
                                cmd.Parameters.AddWithValue("@email", textBox10.Text);
                                cmd.Parameters.AddWithValue("@password", textBox13.Text);
                                cmd.Parameters.AddWithValue("@tipo_utilizador", tipoUtilizador);
                                cmd.Parameters.AddWithValue("@atividade", atividade);

                                //executar o comando
                                cmd.ExecuteNonQuery();

                                //fechar a ligação à BD
                                db.close_connection();
                              }

                              MessageBox.Show("Utilizador criado com sucesso!", "AutoBus", MessageBoxButtons.OK, MessageBoxIcon.Information);

                              Close();

                              textBox8.Clear();
                              textBox9.Clear();
                              textBox10.Clear();
                              textBox11.Clear();
                              textBox12.Clear();
                              textBox13.Clear();
                              textBox14.Clear();
                              comboBox3.SelectedIndex = -1;
                              comboBox4.SelectedIndex = -1;
                              dateTimePicker2.Value = DateTime.Today;
                            }
                            else
                            {
                              MessageBox.Show("Criação cancelada pelo utilizador.", "AutoBus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                          }
                        }
                      }
                    }
                  }

                  db.close_connection();
                }
              }
            }
          }
        }
      }
    }

    private string CaminhoImagem = "";
    //botao de escolher imagem do pc
    private void btCarregarImgCriar_Click(object sender, EventArgs e)
    {
      OpenFileDialog ofd = new OpenFileDialog();
      ofd.Filter = "Imagens|*.jpg;*.jpeg;*.png;*.bmp";

      if (ofd.ShowDialog() == DialogResult.OK)
      {
        pictureBox2.Image = Image.FromFile(ofd.FileName);
        CaminhoImagem = ofd.FileName;
      }
    }

    //botao de escolher imagem predefinida
    private void btEscolherImgCriar_Click(object sender, EventArgs e)
    {
      ImagemPerfil formImagem = new ImagemPerfil(pictureBox2);
      formImagem.ShowDialog();

      if (!string.IsNullOrEmpty(formImagem.CaminhoImagemSelecionada))
      {
        CaminhoImagem = formImagem.CaminhoImagemSelecionada;
      }
    }

    //botao de voltar para a pagina anterior
    private void btVoltarCriar_Click(object sender, EventArgs e)
    {
      Close();
    }
    private void btPass_Click(object sender, EventArgs e)
    {
      if (textBox13.UseSystemPasswordChar == true)
      {
        btPass.Image = Properties.Resources.aberto;
        textBox13.UseSystemPasswordChar = false;
      }
      else
      {
        btPass.Image = Properties.Resources.fechado;
        textBox13.UseSystemPasswordChar = true;
      }
    }

    private void btConfirmarPass_Click(object sender, EventArgs e)
    {
      if (textBox14.UseSystemPasswordChar == true)
      {
        btConfirmarPass.Image = Properties.Resources.aberto;
        textBox14.UseSystemPasswordChar = false;
      }
      else
      {
        btConfirmarPass.Image = Properties.Resources.fechado;
        textBox14.UseSystemPasswordChar = true;
      }
    }







    //CÓDIGO PARA >>>>EDITAR<<<< O UTILIZADOR
    private void btEditarUtilizador_Click(object sender, EventArgs e)
    {


      // Verificar se o número de telemóvel tem pelo menos 9 dígitos
      if (textBox5.Text.Length < 9 || !textBox5.Text.All(char.IsDigit))
      {
        label7.Text = "O número de telemóvel deve conter exatamente 9 dígitos numéricos.";
        label7.Visible = true;
      }

      else
      {
        label7.Visible = false;

        // Verificar se a idade é menor de 18 anos
        DateTime dataNascimento;
        if (!DateTime.TryParse(dateTimePicker1.Text, out dataNascimento))
        {
          label7.Text = "Data de nascimento inválida.";
          label7.Visible = true;
        }
        else
        {
          int idade = DateTime.Today.Year - dataNascimento.Year;
          if (dataNascimento.Date > DateTime.Today.AddYears(-idade)) idade--; // Ajuste para aniversário ainda não ocorrido

          if (idade < 18)
          {
            label7.Text = "É necessário ter pelo menos 18 anos para criar uma conta.";
            label7.Visible = true;
          }
          else
          {
            label7.Visible = false;

            //abrir a ligação à BD
            if (db.open_connection())
            {
              //definir a query
              string query = "UPDATE utilizadores SET nif=@nif, nome=@nome, nascimento=@nascimento, telefone=@telefone, localidade=@localidade, email=@email, tipo_utilizador=@tipo_utilizador, atividade=@atividade WHERE nif=@nif";

              string tipoUtilizador = (comboBox2.Text == "Administrador") ? "0" : "1";
              string atividade = (comboBox1.Text == "Ativo") ? "1" : "0";

              //criar o comando e associar a query com a ligação através do construtor
              MySqlCommand cmd = new MySqlCommand(query, db.connection);

              cmd.Parameters.AddWithValue("@nif", textBox2.Text);
              cmd.Parameters.AddWithValue("@nome", textBox3.Text);
              cmd.Parameters.AddWithValue("@email", textBox4.Text);
              cmd.Parameters.AddWithValue("@telefone", textBox5.Text);
              cmd.Parameters.AddWithValue("@localidade", textBox6.Text);
              cmd.Parameters.AddWithValue("@nascimento", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
              cmd.Parameters.AddWithValue("@atividade", atividade);
              cmd.Parameters.AddWithValue("@tipo_utilizador", tipoUtilizador);

              MessageBoxButtons botoes = MessageBoxButtons.YesNo;
              System.Windows.Forms.DialogResult resultado;

              resultado = MessageBox.Show(this, "Tem certeza que deseja alterar os dados?", "AutoBus", botoes);

              if (resultado == System.Windows.Forms.DialogResult.Yes) //caso "sim"
              {
                //executar o comando
                cmd.ExecuteNonQuery();

                //Editar imagens
                funcoes.UploadImagem(CaminhoImagem, utilizador.nif);

                MessageBox.Show("Dados alterados com sucesso.", "AutoBus", MessageBoxButtons.OK, MessageBoxIcon.Information);
              }
              else //caso "não"
              {
                MessageBox.Show("Operação cancelada.");
              }

              //fechar a ligação à BD
              db.close_connection();
            }
            else
            {
              MessageBox.Show("Erro ao conectar à base de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          }
        }
      }
    }

    //botao de escolher imagens do pc
    private void btCarregarImgEditar_Click(object sender, EventArgs e)
    {
      OpenFileDialog ofd = new OpenFileDialog();
      ofd.Filter = "Imagens|*.jpg;*.jpeg;*.png;*.bmp";

      if (ofd.ShowDialog() == DialogResult.OK)
      {
        pictureBox1.Image = Image.FromFile(ofd.FileName);
        CaminhoImagem = ofd.FileName;
      }
    }

    //botao de escolher imagem predefinida
    private void btEscolherImgEditar_Click(object sender, EventArgs e)
    {
      ImagemPerfil formImagem = new ImagemPerfil(pictureBox1);
      formImagem.ShowDialog();

      if (!string.IsNullOrEmpty(formImagem.CaminhoImagemSelecionada))
      {
        CaminhoImagem = formImagem.CaminhoImagemSelecionada;
      }
    }

    //botao de voltar para a pagina anterior
    private void btVoltarEditar_Click(object sender, EventArgs e)
    {
      Close();
    }


    //funcao para carregar os dados do utilizador
    private void carregarDados()
    {
      // Abrir a ligação à BD
      if (db.open_connection())
      {
        // Definir a query de pesquisa
        string query = "SELECT * FROM utilizadores WHERE id_utilizador = @id_utilizador";

        MySqlCommand cmdDados = new MySqlCommand(query, db.connection);
        cmdDados.Parameters.AddWithValue("@id_utilizador", id);

        MySqlDataReader rdr = cmdDados.ExecuteReader();

        if (rdr.Read())
        {
          textBox1.Text = Convert.ToString(rdr["id_utilizador"]);
          textBox2.Text = Convert.ToString(rdr["nif"]);
          textBox3.Text = Convert.ToString(rdr["nome"]);
          textBox4.Text = Convert.ToString(rdr["email"]);
          textBox5.Text = Convert.ToString(rdr["telefone"]);
          textBox6.Text = Convert.ToString(rdr["localidade"]);
          dateTimePicker1.Text = Convert.ToString(rdr["nascimento"]);

          int atividade = Convert.ToInt32(rdr["atividade"]);
          comboBox1.Text = (atividade == 0) ? "Inativo" : "Ativo";

          int tipoUtilizador = Convert.ToInt32(rdr["tipo_utilizador"]);
          comboBox2.Text = (tipoUtilizador == 0) ? "Administrador" : "Utilizador";

          string caminhoImagem = Path.Combine(@"C:\Users\sofis\Desktop\pap\ServidorAutoBus\Servidor\Uploads", "Uploads", $"{rdr["nif"]}.jpg");

          if (File.Exists(caminhoImagem))
          {
            pictureBox1.Image = Image.FromFile(caminhoImagem);
            Debug.WriteLine("Imagem carregada: "+ $"{ rdr["nif"]}");
          }
          else
          {
            // Imagem padrão caso não exista
            string caminhoDefault = Path.Combine(@"C:\Users\sofis\Desktop\pap\ServidorAutoBus\Servidor\Uploads", "img", "default-profile.png");
            if (File.Exists(caminhoDefault))
            {
              pictureBox1.Image = Image.FromFile(caminhoDefault);
              Debug.WriteLine("Imagem default carregada");
            }
            else
            {
              pictureBox1.Image = null; // ou deixa vazio
              Debug.WriteLine("Erro ao carregar imagem");
            }
          }
        }

        rdr.Close();
        db.close_connection(); // Fecha a conexão com a BD
      }
    }






    //PERMISSOES DE INSERCAO DA PAGINA CRIAR UTILIZADOR --------------------------------------------------------------------------------------
    //textbox do nif 
    private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
    {
      // permitir apenas números e controlo como backspace
      if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
      {
        e.Handled = true; // impede a tecla de ser processada
        textBox8.MaxLength = 9;
      }
    }

    //textbox do nome
    private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
    {
      // Permite apenas letras, controlo (como backspace) e espaços
      if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
      {
        e.Handled = true; // Bloqueia a tecla
      }
    }

    //textbox do telefone
    private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
    {
      // permitir apenas números e controlo como backspace
      if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
      {
        e.Handled = true; // impede a tecla de ser processada
        textBox8.MaxLength = 9;
      }
    }

    //textbox da localidade
    private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
    {
      // permite apenas letras, controlo (como backspace) e espaços
      if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
      {
        e.Handled = true; // Bloqueia a tecla
      }
    }


    //PERMISSOES DE INSERCAO DA PAGINA EDITAR UTILIZADOR --------------------------------------------------------------------------------------
    //textbox do nif
    private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
    {
      // permitir apenas números e controlo como backspace
      if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
      {
        e.Handled = true; // impede a tecla de ser processada
        textBox8.MaxLength = 9;
      }
    }

    //textbox do nome
    private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
    {
      // permite apenas letras, controlo (como backspace) e espaços
      if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
      {
        e.Handled = true; // Bloqueia a tecla
      }
    }

    //textbox do numero de telemovel 
    private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
    {
      // permitir apenas números e controlo como backspace
      if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
      {
        e.Handled = true; // impede a tecla de ser processada
        textBox8.MaxLength = 9;
      }
    }

    //textbox da localidade
    private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
    {
      // permite apenas letras, controlo (como backspace) e espaços
      if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
      {
        e.Handled = true; // Bloqueia a tecla
      }
    }



    private void panelEditar_Paint(object sender, PaintEventArgs e)
    {

    }
  }
}
