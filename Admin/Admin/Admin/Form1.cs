using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Admin
{
  public partial class Form1 : Form
  {
    ligacaoDB db = new ligacaoDB();
    public static DadosUtilizador utilizadorSessao;
    public Form1()
    {
      InitializeComponent();
      db.inicializa();

      label4.Visible = false;

      //textbox invisivel para tirar o foco de outras textboxes
      textBox3.TabStop = false;
      textBox3.Visible = false;
      this.ActiveControl = textBox3;
    }

    private void btSair_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void btInfo_Click(object sender, EventArgs e)
    {
      MessageBox.Show("AutoBus © 2024 by Sofia Miranda \nLicensed under CC BY-NC-ND 4.0", "AutoBus", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btEntrar_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
      {
        label4.Text = "*Todos os campos devem ser preenchidos.";
        label4.Visible = true;
        return;
      }

      label4.Visible = false;

      string email = textBox1.Text;
      string password = textBox2.Text;

      db.open_connection();

      string query = @"SELECT *
                     FROM utilizadores 
                     WHERE email = @email AND password = @password";

      using (MySqlCommand cmd = new MySqlCommand(query, db.connection))
      {
        cmd.Parameters.AddWithValue("@email", email);
        cmd.Parameters.AddWithValue("@password", password);

        using (MySqlDataReader reader = cmd.ExecuteReader())
        {
          if (!reader.Read())
          {
            label4.Text = "*Email ou palavra-passe incorretos.";
            label4.Visible = true;
            return;
          }

          int id_utilizador = reader.GetInt32("id_utilizador");
          int nif = reader.GetInt32("nif");
          int tipo = reader.IsDBNull(reader.GetOrdinal("tipo_utilizador")) ? 0 : Convert.ToInt32(reader.GetByte(reader.GetOrdinal("tipo_utilizador")));
          int atividade = reader.IsDBNull(reader.GetOrdinal("atividade")) ? 0 : Convert.ToInt32(reader.GetByte(reader.GetOrdinal("atividade")));


          if (tipo != 0)
          {
            MessageBox.Show("Acesso permitido apenas para administradores.", "AutoBus", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return;
          }

          if (atividade == 0)
          {
            MessageBox.Show("A sua conta está inativa. Por favor, contacte o suporte.\n\nE-mail: autobus.pap@gmail.com\nTelemóvel: 916942618", "AutoBus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
          }

          // Preencher o objeto DadosUtilizador
          DadosUtilizador utilizador = new DadosUtilizador
          {
            id_utilizador = reader.GetInt32("id_utilizador"),
            nif = reader.GetInt32("nif"),
            tipo_utilizador = tipo.ToString(),
            atividade = atividade.ToString(),
            email = email,
            password = password,
            nome = reader["nome"].ToString(),
            telefone = reader.IsDBNull(reader.GetOrdinal("telefone")) ? 0 : reader.GetInt32("telefone"),
            localidade = reader["localidade"].ToString(),
            nascimento = reader.IsDBNull(reader.GetOrdinal("nascimento")) ? DateTime.MinValue : reader.GetDateTime("nascimento")
          };

          // Guardar em sessão
          Sessao.UtilizadorAtual = utilizador;

          // Acesso autorizado
          MessageBox.Show(this, "Bem vindo(a) de volta!", "AutoBus", MessageBoxButtons.OK);

          Principal principal = new Principal(nif, id_utilizador, utilizador);
          principal.Show();

          textBox1.Clear();
          textBox2.Clear();
        }
      }

      db.close_connection();
    }


    //botão para mostrar ou esconder a password
    private void button1_Click(object sender, EventArgs e)
    {
      if (textBox2.UseSystemPasswordChar == true)
      {
        button1.Image = Properties.Resources.abertoB;
        textBox2.UseSystemPasswordChar = false;
      }
      else
      {
        button1.Image = Properties.Resources.fechadoA;
        textBox2.UseSystemPasswordChar = true;
      }
    }
  }
}
