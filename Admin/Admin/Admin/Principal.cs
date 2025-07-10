using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using Mysqlx.Crud;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Diagnostics;
using System.Net.Http;
using System.IO;
using System.Net;
using System.Runtime.InteropServices.ComTypes;

namespace Admin
{
  public partial class Principal : Form
  {
    ligacaoDB db = new ligacaoDB();
    DadosUtilizador user = new DadosUtilizador();
    dadosAutocarro autocarro = new dadosAutocarro();


    public int nif;
    public int id;
    public string nome;
    bool menuExpandir;
    bool transicaoLatExpandir;

    public Principal(int nif, int id_utilizador, DadosUtilizador utilizador)
    {
      InitializeComponent();

      //mudar a cor da letra das celulas 
      dataGridViewAutocarro.CellFormatting += dataGridViewAutocarro_CellFormatting;
      dataGridViewUtilizador.CellFormatting += dataGridViewUtilizadores_CellFormatting;

      this.nif = nif;
      id = id_utilizador;

      this.user = utilizador;

      //flowLayoutPanelMenu.Width = 0;

      flowLayoutPanelMenu.Visible = false;

      //cor de seleção das células do DataGridView
      dataGridViewUtilizador.DefaultCellStyle.SelectionBackColor = Color.FromArgb(43, 34, 99); // azul
      dataGridViewUtilizador.DefaultCellStyle.SelectionForeColor = Color.FromArgb(255, 255, 255); // branco

      dataGridViewAutocarro.DefaultCellStyle.SelectionBackColor = Color.FromArgb(43, 34, 99); // azul
      dataGridViewAutocarro.DefaultCellStyle.SelectionForeColor = Color.FromArgb(255, 255, 255); // branco

      dataGridViewAutocarro.ColumnHeadersDefaultCellStyle.Font = new Font(
          dataGridViewAutocarro.Font, FontStyle.Bold
      );
      dataGridViewUtilizador.ColumnHeadersDefaultCellStyle.Font = new Font(
          dataGridViewAutocarro.Font, FontStyle.Bold
      );

      //placeholder
      ToolTip pesquisa = new ToolTip();
      pesquisa.SetToolTip(textBox1, "Pesquise pelo nome do utilizador.");
      pesquisa.SetToolTip(textBox2, "Pesquise pelo número do autocarro.");


      panelUtilizadores.Visible = false;
      panelAutocarros.Visible = false;

      TopMost = false;

      // removida a chamada duplicada de db.inicializa();
      if (!db.open_connection())
      {
        MessageBox.Show("Erro ao abrir a conexão!");
        return;
      }

      if (db.connection == null || db.connection.State != ConnectionState.Open)
      {
        MessageBox.Show("A conexão não está aberta!");
        return;
      }

      //query pasra buscar o nome do utilizador admin que está logado
      if (db.open_connection())
      {
        string query = "SELECT nome FROM utilizadores WHERE nif=@nif";

        MySqlCommand info = new MySqlCommand(query, db.connection);

        info.Parameters.AddWithValue("@nif", nif);

        MySqlDataReader lerNome = info.ExecuteReader();

        if (lerNome.Read())
        {
          btMeuPerfil.Text = lerNome["nome"].ToString();
        }

        lerNome.Close();
      }
    }

    private void Principal_Load(object sender, EventArgs e)
    {
      if (db.open_connection())
      {
        db.inicializa();
        db.open_connection();

        string query = "SELECT * FROM utilizadores WHERE nif = @nif";
        MySqlCommand info = new MySqlCommand(query, db.connection);
        info.Parameters.AddWithValue("@nif", nif);
        Debug.WriteLine("NIF do utilizador: " + nif);

        // Carregar imagem do utilizador (opcional, se tiveres imagem na pasta local)
        string URLImagem = "http://localhost:3000/api/imagens/utilizador/" + nif;
        using (var stream = new WebClient().OpenRead(URLImagem))
        {
          Image originalImage = Image.FromStream(stream);
          Bitmap resizedImage = new Bitmap(originalImage, new Size(30, 30)); // Tamanho 30x30
          btMeuPerfil.Image = resizedImage;
        }

        MySqlDataReader ler = info.ExecuteReader();

        if (ler.Read())
        {
          // Preencher objeto user
          user.id_utilizador = Convert.ToInt32(ler["id_utilizador"]);
          user.nif = Convert.ToInt32(ler["nif"]);
          user.nome = ler["nome"].ToString();
          user.email = ler["email"].ToString();
          user.telefone = Convert.ToInt32(ler["telefone"]);
          user.localidade = ler["localidade"].ToString();

          // Verifica se nascimento não é DBNull
          if (ler["nascimento"] != DBNull.Value)
            user.nascimento = Convert.ToDateTime(ler["nascimento"]);
          else
            user.nascimento = DateTime.Now;

          user.password = ler["password"].ToString();

          var tipo = ler["tipo_utilizador"].ToString();
          user.tipo_utilizador = tipo == "0" ? "Administrador" : "Cliente";

          var atividade = ler["atividade"].ToString();
          user.atividade = atividade == "1" ? "Ativa" : "Desativada";

          //user.foto = ler["foto"].ToString();
        }

        ler.Close();
        db.close_connection();
      }
    }


    //BOTAO SAIR
    private void btSair_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void btSair_MouseHover(object sender, EventArgs e)
    {
      btSair.BackgroundImage = Properties.Resources.x;
    }

    private void btSair_MouseLeave(object sender, EventArgs e)
    {
      btSair.BackgroundImage = Properties.Resources.xB;
    }


    //FUNÇÕES PARA A ANIMAÇÃO DO MENU
    private void transicao_Tick(object sender, EventArgs e)
    {
      if (menuExpandir)
      {
        //se o menu expandir, minimiza
        flowLayoutPanelMenu.Width -= 10;

        if (flowLayoutPanelMenu.Width == flowLayoutPanelMenu.MinimumSize.Width)
        {
          menuExpandir = false;
          transicao.Stop();
        }
        else
        {
          flowLayoutPanelMenu.Width += 10;

          if (flowLayoutPanelMenu.Width == flowLayoutPanelMenu.MinimumSize.Width)
          {
            menuExpandir = true;
            transicao.Stop();
          }
        }
      }
    }

    private void transicaoLateral_Tick(object sender, EventArgs e)
    {
      if (transicaoLatExpandir == true)
      {
        flowLayoutPanelMenu.Width -= 10; // Incremento maior para velocidade

        if (flowLayoutPanelMenu.Width <= 0)
        {
          transicaoLatExpandir = false;
          transicaoLateral.Stop();
        }

        panelUtilizadores.Visible = false;
        panelAutocarros.Visible = false;
      }
      else
      {
        flowLayoutPanelMenu.Width += 10; // Incremento maior para velocidade

        if (flowLayoutPanelMenu.Width >= 144)
        {
          transicaoLatExpandir = true;
          transicaoLateral.Stop();
        }
      }
    }


    private void btMenu_Click_1(object sender, EventArgs e)
    {
      transicaoLateral.Start();
      flowLayoutPanelMenu.Visible = true;
    }

    private void flowLayoutPanelMenu_Paint(object sender, PaintEventArgs e)
    {

    }











    //PARA O PANEL DE UTILIZADORES -----------------------------------------------------------------------------------
    private void btUtilizadores_Click(object sender, EventArgs e)
    {
      panelUtilizadores.Visible = true;
      panelAutocarros.Visible = false;

      btUtilizadores.BackColor = Color.MidnightBlue;
      btAutocarros.BackColor = Color.FromArgb(3, 3, 59);

      CarregarUtilizadores();
    }


    //botao de pesquisa dos utilizadores
    private void btPesquisarUtilizadores_Click(object sender, EventArgs e)
    {
      CarregarUtilizadores(textBox1.Text);
    }


    //textbox de pesquisa
    private void textBox1_TextChanged_1(object sender, EventArgs e)
    {
      CarregarUtilizadores(textBox1.Text);
    }


    //BOTAO DE EDITAR O UTILIZADOR
    private void btEditarUtilizadores_Click(object sender, EventArgs e)
    {
      if (dataGridViewUtilizador.SelectedRows.Count > 0) // Verifica se há uma linha selecionada
      {
        DadosUtilizador utilizadorSelecionado = new DadosUtilizador();

        // Obtém os valores da linha selecionada
        string id_utilizador = dataGridViewUtilizador.SelectedRows[0].Cells["id_utilizador"].Value.ToString();
        string nif = dataGridViewUtilizador.SelectedRows[0].Cells["nif"].Value.ToString();
        string nome = dataGridViewUtilizador.SelectedRows[0].Cells["nome"].Value.ToString();
        string email = dataGridViewUtilizador.SelectedRows[0].Cells["email"].Value.ToString();
        string telefone = dataGridViewUtilizador.SelectedRows[0].Cells["telefone"].Value.ToString();
        string localidade = dataGridViewUtilizador.SelectedRows[0].Cells["localidade"].Value.ToString();
        string nascimento = dataGridViewUtilizador.SelectedRows[0].Cells["nascimento"].Value.ToString();
        string tipo = dataGridViewUtilizador.SelectedRows[0].Cells["tipo_utilizador"].Value.ToString();
        string atividade = dataGridViewUtilizador.SelectedRows[0].Cells["atividade"].Value.ToString();

        // Fix for CS0029: Convert the string value to an integer using int.Parse or int.TryParse
        utilizadorSelecionado.id_utilizador = int.Parse(id_utilizador);
        utilizadorSelecionado.nif = int.Parse(nif);
        utilizadorSelecionado.nome = nome;
        utilizadorSelecionado.email = email;
        utilizadorSelecionado.telefone = int.Parse(telefone);
        utilizadorSelecionado.localidade = localidade;
        utilizadorSelecionado.nascimento = DateTime.Parse(nascimento);
        utilizadorSelecionado.tipo_utilizador = tipo;
        utilizadorSelecionado.atividade = atividade;

        using (Utilizador utilizador = new Utilizador("editar", utilizadorSelecionado)) // `using` garante que o objeto será descartado
        {
          this.Hide();
          utilizador.ShowDialog();
        }
        CarregarUtilizadores();
        this.Show();
      }
      else
      {
        MessageBox.Show("Por favor, selecione um utilizador para editar.", "AutoBus");
      }
    }


    //BOTAO DE ADICIONAR O UTILIZADOR
    private void btCriarUtilizador_Click_1(object sender, EventArgs e)
    {
      using (Utilizador utilizador = new Utilizador("criar", user)) // `using` garante que o objeto será descartado
      {
        this.Hide();
        utilizador.ShowDialog();
      }
      CarregarUtilizadores();
      this.Show();
    }


    //BOTAO DE ATIVAR O UTILIZADOR
    private void btAtivarUtilizador_Click(object sender, EventArgs e)
    {
      if (dataGridViewUtilizador.SelectedRows.Count > 0) // Verifica se há uma linha selecionada
      {
        DadosUtilizador utilizadorSelecionado = new DadosUtilizador();

        // Obtém os valores da linha selecionada
        string id_utilizador = dataGridViewUtilizador.SelectedRows[0].Cells["id_utilizador"].Value.ToString();
        string nif = dataGridViewUtilizador.SelectedRows[0].Cells["nif"].Value.ToString();
        string nome = dataGridViewUtilizador.SelectedRows[0].Cells["nome"].Value.ToString();
        string email = dataGridViewUtilizador.SelectedRows[0].Cells["email"].Value.ToString();
        string atividade = dataGridViewUtilizador.SelectedRows[0].Cells["atividade"].Value.ToString();

        utilizadorSelecionado.id_utilizador = int.Parse(id_utilizador);
        utilizadorSelecionado.nif = int.Parse(nif);
        utilizadorSelecionado.nome = nome;
        utilizadorSelecionado.email = email;
        utilizadorSelecionado.atividade = atividade;


        if (atividade == "Ativa")
        {
          MessageBox.Show("Não é possível ativar a conta pois a mesma já se encontra ativa.", "AutoBus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        else
        if (db.open_connection())
        {
          string query = "UPDATE utilizadores SET atividade = 1 WHERE id_utilizador = @id_utilizador";

          MySqlCommand cmd = new MySqlCommand(query, db.connection);

          cmd.Parameters.AddWithValue("@id_utilizador", id_utilizador);
          //dataGridViewUtilizador.SelectedRows[0].Cells["atividade"].Value.ToString();


          //pesquisa pelo nome do utilizador selecionado
          string pesquisa = "SELECT nome FROM utilizadores WHERE id_utilizador=@id_utilizador";

          MySqlCommand cmd2 = new MySqlCommand(pesquisa, db.connection);

          cmd2.Parameters.AddWithValue("@id_utilizador", id_utilizador);
          cmd2.Parameters.AddWithValue("@nome", nome);
          cmd2.ExecuteNonQuery();

          string msg = "Deseja ativar a conta deste utilizador? \nConta Nº: " + id_utilizador + "\nNome: " + nome;

          if (MessageBox.Show(msg, "AutoBus", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
          {
            cmd.ExecuteNonQuery();
            MessageBox.Show("A partir de agora, a conta do utilizador " + nome + ", nº" + id_utilizador + ", encontra-se ativa!", "AutoBus", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }

          CarregarUtilizadores();
        }

        else
        {
          MessageBox.Show("Erro ao conectar à base de dados.", "AutoBus", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }

      else
      {
        MessageBox.Show("Por favor, selecione um utilizador para ativar.", "AutoBus");
      }
    }

    //BOTAO PARA DESATIVAR A CONTA
    private void btDesativarUtilizador_Click(object sender, EventArgs e)
    {
      //o botão de eliminar os utilizadores será apenas para desativá-los. não haverá qualquer tipo de alteração na base de dados, neste caso,
      //que elimine permanentemente.
      //o ficar "desativado" só apagará do datagridview, ou seja, deixá-lo invisível. também mostrará, na base de dados se o "item" está ativo ou não.



      if (dataGridViewUtilizador.SelectedRows.Count > 0) // Verifica se há uma linha selecionada
      {
        // Obtém os valores da linha selecionada
        string id_utilizador = dataGridViewUtilizador.SelectedRows[0].Cells["id_utilizador"].Value.ToString();
        string nif = dataGridViewUtilizador.SelectedRows[0].Cells["nif"].Value.ToString();
        string nome = dataGridViewUtilizador.SelectedRows[0].Cells["nome"].Value.ToString();
        string email = dataGridViewUtilizador.SelectedRows[0].Cells["email"].Value.ToString();
        string atividade = dataGridViewUtilizador.SelectedRows[0].Cells["atividade"].Value.ToString();

        user.id_utilizador = int.Parse(id_utilizador);
        user.nif = int.Parse(nif);
        user.nome = nome;
        user.email = email;
        user.atividade = atividade;

        if (atividade == "Desativada")
        {
          MessageBox.Show("Não é possível desativar a conta pois a mesma já se encontra desativada.", "AutoBus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        else
        if (db.open_connection())
        {
          string query = "UPDATE utilizadores SET atividade = 0 WHERE id_utilizador = @id_utilizador";

          MySqlCommand cmd = new MySqlCommand(query, db.connection);

          cmd.Parameters.AddWithValue("@id_utilizador", id_utilizador);
          //dataGridViewUtilizador.SelectedRows[0].Cells["atividade"].Value.ToString();


          //pesquisa pelo nome do utilizador selecionado
          string pesquisa = "SELECT nome FROM utilizadores WHERE id_utilizador=@id_utilizador";

          MySqlCommand cmd2 = new MySqlCommand(pesquisa, db.connection);

          cmd2.Parameters.AddWithValue("@id_utilizador", id_utilizador);
          cmd2.Parameters.AddWithValue("@nome", nome);
          cmd2.ExecuteNonQuery();

          string msg = "Deseja desativar a conta deste utilizador? \nConta Nº: " + id_utilizador + "\nNome: " + nome;


          if (MessageBox.Show(msg, "AutoBus", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
          {
            cmd.ExecuteNonQuery();
            MessageBox.Show("A partir de agora, a conta do utilizador " + nome + ", nº" + id_utilizador + ", encontra-se desativada!", "AutoBus", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }

          CarregarUtilizadores();
        }

        else
        {
          MessageBox.Show("Erro ao conectar à base de dados.", "AutoBus");
        }
      }

      else
      {
        MessageBox.Show("Por favor, selecione um utilizador para desativar.", "AutoBus");
      }
    }


    private void dataGridViewUtilizador_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      if (dataGridViewUtilizador.Rows[e.RowIndex].Selected)
      {
        e.CellStyle.SelectionBackColor = Color.FromArgb(43, 34, 99); // azul
        e.CellStyle.SelectionForeColor = Color.FromArgb(255, 255, 255); // branco
      }
    }















    //PARA O PANEL DE AUTOCARROS ---------------------------------------------------------------------------------------
    private void btAutocarros_Click_1(object sender, EventArgs e)
    {
      panelAutocarros.Visible = true;
      panelUtilizadores.Visible = false;

      btAutocarros.BackColor = Color.MidnightBlue;
      btUtilizadores.BackColor = Color.FromArgb(3, 3, 59);

      CarregarAutocarros("");
    }

    private void panelAutocarros_Paint(object sender, PaintEventArgs e)
    {

    }


    //BOTAO DE EDITAR O AUTOCARRO
    private void btEditarAutocarro_Click_1(object sender, EventArgs e)
    {
      if (dataGridViewAutocarro.SelectedRows.Count > 0) // Verifica se há uma linha selecionada
      {
        // Obtém os valores da linha selecionada
        string id_autocarro = dataGridViewAutocarro.SelectedRows[0].Cells["idautocarro"].Value.ToString();
        string numero = dataGridViewAutocarro.SelectedRows[0].Cells["numero"].Value.ToString();
        string capacidade = dataGridViewAutocarro.SelectedRows[0].Cells["capacidade"].Value.ToString();
        string ar = dataGridViewAutocarro.SelectedRows[0].Cells["arCondicionado"].Value.ToString();
        string wifi = dataGridViewAutocarro.SelectedRows[0].Cells["wifi"].Value.ToString();
        string servico = dataGridViewAutocarro.SelectedRows[0].Cells["servico"].Value.ToString();

        autocarro.idautocarro = id_autocarro;
        autocarro.numero = numero;
        autocarro.capacidade = capacidade;
        autocarro.arCondicionado = ar;
        autocarro.wifi = wifi;
        autocarro.servico = servico;

        using (Autocarro autocarroForm = new Autocarro("editar", autocarro)) // `using` garante que o objeto será descartado
        {
          this.Hide();
          autocarroForm.ShowDialog();
        }
        CarregarAutocarros("");
        this.Show();
      }
      else
      {
        MessageBox.Show("Por favor, selecione um autocarro para editar.", "AutoBus");
      }
    }


    //BOTAO DE ADICIONAR O AUTOCARRO
    private void btAdicionarAutoC_Click_1(object sender, EventArgs e)
    {
      using (Autocarro autocarroForm = new Autocarro("criar", autocarro)) // `using` garante que o objeto será descartado
      {
        this.Hide();
        autocarroForm.ShowDialog();
      }
      CarregarAutocarros("");
      this.Show();
    }


    //BOTAO DE ATIVAR O AUTOCARRO
    private void btAtivarAuto_Click(object sender, EventArgs e)
    {
      if (dataGridViewAutocarro.SelectedRows.Count > 0) // Verifica se há uma linha selecionada
      {
        // Obtém os valores da linha selecionada
        string id_autocarro = dataGridViewAutocarro.SelectedRows[0].Cells["idautocarro"].Value.ToString();
        string numero = dataGridViewAutocarro.SelectedRows[0].Cells["numero"].Value.ToString();
        string servico = dataGridViewAutocarro.SelectedRows[0].Cells["servico"].Value.ToString();

        autocarro.idautocarro = id_autocarro;
        autocarro.numero = numero;
        autocarro.servico = servico;

        if (servico == "Ativo")
        {
          MessageBox.Show("Não é possível ativar o autocarro pois o mesmo já se encontra em serviço.", "AutoBus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        if (db.open_connection())
        {
          string query = "UPDATE autocarro SET servico = 1 WHERE idautocarro = @idautocarro";

          MySqlCommand cmd = new MySqlCommand(query, db.connection);

          cmd.Parameters.AddWithValue("@idautocarro", id_autocarro);


          //pesquisa pelo nome do utilizador selecionado
          string pesquisa = "SELECT numero FROM autocarro WHERE idautocarro = @idautocarro";

          MySqlCommand cmd2 = new MySqlCommand(pesquisa, db.connection);

          cmd2.Parameters.AddWithValue("@idautocarro", id_autocarro);
          cmd2.Parameters.AddWithValue("@numero", numero);
          cmd2.ExecuteNonQuery();

          string msg = "Deseja ativar este autocarro? \nAutocarro Nº: " + id_autocarro;


          if (MessageBox.Show(msg, "AutoBus", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
          {
            cmd.ExecuteNonQuery();
            MessageBox.Show("A partir de agora, o autocarro nº" + id_autocarro + " encontra-se ativo, em serviço!", "AutoBus");
          }

          CarregarAutocarros("");
        }

        else
        {
          MessageBox.Show("Erro ao conectar à base de dados.", "AutoBus", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }

      else
      {
        MessageBox.Show("Por favor, selecione um autocarro para ativar.", "AutoBus");
      }
    }


    //BOTAO DE DESATIVAR O AUTOCARRO
    private void btDesativarAuto_Click(object sender, EventArgs e)
    {
      if (dataGridViewAutocarro.SelectedRows.Count > 0) // Verifica se há uma linha selecionada
      {
        // Obtém os valores da linha selecionada
        string id_autocarro = dataGridViewAutocarro.SelectedRows[0].Cells["idautocarro"].Value.ToString();
        string numero = dataGridViewAutocarro.SelectedRows[0].Cells["numero"].Value.ToString();
        string servico = dataGridViewAutocarro.SelectedRows[0].Cells["servico"].Value.ToString();

        autocarro.idautocarro = id_autocarro;
        autocarro.numero = numero;
        autocarro.servico = servico;

        if (servico == "Fora de serviço")
        {
          MessageBox.Show("Não é possível desativar o autocarro pois o mesmo já se encontra fora de serviço.", "AutoBus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        else
        if (db.open_connection())
        {
          string query = "UPDATE autocarro SET servico = 0 WHERE idautocarro = @idautocarro";

          MySqlCommand cmd = new MySqlCommand(query, db.connection);

          cmd.Parameters.AddWithValue("@idautocarro", id_autocarro);


          //pesquisa pelo nome do utilizador selecionado
          string pesquisa = "SELECT numero FROM autocarro WHERE idautocarro = @idautocarro";

          MySqlCommand cmd2 = new MySqlCommand(pesquisa, db.connection);

          cmd2.Parameters.AddWithValue("@idautocarro", id_autocarro);
          cmd2.Parameters.AddWithValue("@numero", numero);
          cmd2.ExecuteNonQuery();

          string msg = "Deseja desativar este autocarro? \nAutocarro Nº: " + id_autocarro;


          if (MessageBox.Show(msg, "AutoBus", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
          {
            cmd.ExecuteNonQuery();
            MessageBox.Show("A partir de agora, o autocarro nº" + id_autocarro + " encontra-se fora de serviço!", "AutoBus");
          }

          CarregarAutocarros("");
        }

        else
        {
          MessageBox.Show("Erro ao conectar à base de dados.", "AutoBus");
        }
      }

      else
      {
        MessageBox.Show("Por favor, selecione um autocarro para desativar.", "AutoBus");
      }
    }


    //BOTAO DE VISUALIZAR E CRIAR ROTAS
    private void btCriarRotas_Click_1(object sender, EventArgs e)
    {
      Rotas rotas = new Rotas(); // criar a instância do formulário

      this.Hide(); // esconde o formulário atual
      rotas.ShowDialog(); // abre a pagina de forma modal (espera fechar)
      this.Show();
    }


    //textbox de pesquisa
    private void textBox2_TextChanged(object sender, EventArgs e)
    {
      CarregarAutocarros(textBox2.Text);
    }


    //botao de pesquisa dos autocarros
    private void btPesquisarAutocarro_Click(object sender, EventArgs e)
    {
      CarregarAutocarros(textBox2.Text);
    }

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    { }






    // FUNCOES DE PESQUISA -----------------------------------------------------
    // CARREGAR OS DADOS DOS UTILIZADORES NA GRIDVIEW
    private void CarregarUtilizadores(string nome = "")
    {
      if (db.open_connection())
      {
        dataGridViewUtilizador.Rows.Clear();
        dataGridViewUtilizador.Columns.Clear();

        // Definir as colunas do DataGridView
        if (!dataGridViewUtilizador.Columns.Contains("id_utilizador")) // ✔️ Evita adicionar colunas repetidas
        {
          dataGridViewUtilizador.Columns.Add("id_utilizador", "ID");
          dataGridViewUtilizador.Columns.Add("nif", "NIF");
          dataGridViewUtilizador.Columns.Add("nome", "Nome");
          dataGridViewUtilizador.Columns.Add("nascimento", "Data de nascimento");
          dataGridViewUtilizador.Columns.Add("telefone", "Telemóvel");
          dataGridViewUtilizador.Columns.Add("localidade", "Localidade");
          dataGridViewUtilizador.Columns.Add("email", "Email");
          dataGridViewUtilizador.Columns.Add("tipo_utilizador", "Tipos de utilizador");
          dataGridViewUtilizador.Columns.Add("atividade", "Estado da conta");
        }

        string query = "SELECT * FROM utilizadores WHERE nome LIKE @nome";
        MySqlCommand cmd = new MySqlCommand(query, db.connection);
        cmd.Parameters.AddWithValue("@nome", "%" + nome + "%");

        MySqlDataReader dataReader = cmd.ExecuteReader();

        while (dataReader.Read())
        {

          string tipo = dataReader["tipo_utilizador"].ToString();
          string atividade = dataReader["atividade"].ToString();

          if (tipo == "0")
          {
            tipo = "Administrador";
          }
          else
          {
            tipo = "Cliente";
          }

          if (atividade == "1")
          {
            atividade = "Ativa";
          }
          else
          {
            atividade = "Desativada";
          }

          object nascimentoObj = dataReader["nascimento"];

          string nascimentoFormatado = nascimentoObj is DateTime nascimentoVal ? nascimentoVal.ToString("yyyy-MM-dd") : "";

          dataGridViewUtilizador.Rows.Add(
          dataReader["id_utilizador"].ToString(),
          dataReader["nif"].ToString(),
          dataReader["nome"].ToString(),
          nascimentoFormatado,
          dataReader["telefone"].ToString(),
          dataReader["localidade"].ToString(),
          dataReader["email"].ToString(),
          tipo,
          atividade
          );
        }
        db.close_connection();
      }
    }


    // CARREGAR OS DADOS DOS AUTOCARROS NA GRIDVIEW
    private void CarregarAutocarros(string numero)
    {
      if (db.open_connection())
      {
        dataGridViewAutocarro.Rows.Clear();
        dataGridViewAutocarro.Columns.Clear();

        // Definir as colunas do DataGridView
        dataGridViewAutocarro.Columns.Add("idautocarro", "ID");
        dataGridViewAutocarro.Columns.Add("numero", "Número do autocarro");
        dataGridViewAutocarro.Columns.Add("capacidade", "Capacidade");
        dataGridViewAutocarro.Columns.Add("arCondicionado", "Ar-condicionado");
        dataGridViewAutocarro.Columns.Add("wifi", "WiFi");
        dataGridViewAutocarro.Columns.Add("servico", "Serviço");

        string query = "SELECT * FROM autocarro WHERE numero LIKE @numero";

        if (db.open_connection())
        {
          MySqlCommand cmd = new MySqlCommand(query, db.connection);
          cmd.Parameters.AddWithValue("@numero", "%" + numero + "%");

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
              servico = "Em serviço";
            }
            else
            {
              servico = "Fora de serviço";
            }


            dataGridViewAutocarro.Rows.Add(
                dataReader["idautocarro"].ToString(),
                dataReader["numero"].ToString(),
                dataReader["capacidade"].ToString(),
                ar,
                wifi,
                servico
            );
          }
          db.close_connection();
        }
      }
    }


    private void DataGridViewAutocarro_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    { }

    private void dataGridViewUtilizador_CellContentClick(object sender, DataGridViewCellEventArgs e)
    { }


    //BOTAO PARA VER O PERFIL
    private void btMeuPerfil_Click(object sender, EventArgs e)
    {
      using (Perfil perfil = new Perfil(user))
      {
        this.Hide();
        perfil.ShowDialog();
      }
      this.Show();
    }


    //mudar a cor da letra das células (estado do autocarro e da conta do utilizador)
    private void dataGridViewAutocarro_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      if (dataGridViewAutocarro.Columns[e.ColumnIndex].Name == "servico" && e.Value != null)
      {
        if (e.Value.ToString() == "Fora de serviço")
        {
          e.CellStyle.ForeColor = Color.Firebrick;
          e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
        }
        else
        {
          e.CellStyle.ForeColor = Color.LimeGreen;
          e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
        }
      }
    }

    private void dataGridViewUtilizadores_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      if (dataGridViewUtilizador.Columns[e.ColumnIndex].Name == "atividade" && e.Value != null)
      {
        if (e.Value.ToString() == "Desativada")
        {
          e.CellStyle.ForeColor = Color.Firebrick;
          e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
        }
        else
        {
          e.CellStyle.ForeColor = Color.LimeGreen;
          e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
        }
      }
    }
  }
}
