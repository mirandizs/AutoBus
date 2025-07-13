namespace Admin
{
    partial class Principal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.flowLayoutPanelMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btUtilizadores = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btAutocarros = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btMeuPerfil = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btMenu = new System.Windows.Forms.Button();
            this.btSair = new System.Windows.Forms.Button();
            this.panelUtilizadores = new System.Windows.Forms.Panel();
            this.btAtivarUtilizador = new System.Windows.Forms.Button();
            this.btEditarUtilizadores = new System.Windows.Forms.Button();
            this.btDesativarUtilizador = new System.Windows.Forms.Button();
            this.btCriarUtilizador = new System.Windows.Forms.Button();
            this.btPesquisarUtilizadores = new System.Windows.Forms.Button();
            this.dataGridViewUtilizador = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.transicao = new System.Windows.Forms.Timer(this.components);
            this.transicaoLateral = new System.Windows.Forms.Timer(this.components);
            this.panelAutocarros = new System.Windows.Forms.Panel();
            this.btAtivarAuto = new System.Windows.Forms.Button();
            this.dataGridViewAutocarro = new System.Windows.Forms.DataGridView();
            this.btPesquisarAutocarro = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btCriarRotas = new System.Windows.Forms.Button();
            this.btAdicionarAutoC = new System.Windows.Forms.Button();
            this.btDesativarAuto = new System.Windows.Forms.Button();
            this.btEditarAutocarro = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.flowLayoutPanelMenu.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelUtilizadores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUtilizador)).BeginInit();
            this.panelAutocarros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAutocarro)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanelMenu
            // 
            this.flowLayoutPanelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(59)))));
            this.flowLayoutPanelMenu.Controls.Add(this.panel2);
            this.flowLayoutPanelMenu.Controls.Add(this.panel4);
            this.flowLayoutPanelMenu.Controls.Add(this.panel5);
            this.flowLayoutPanelMenu.Controls.Add(this.panel3);
            this.flowLayoutPanelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanelMenu.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelMenu.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanelMenu.Name = "flowLayoutPanelMenu";
            this.flowLayoutPanelMenu.Padding = new System.Windows.Forms.Padding(0, 37, 0, 0);
            this.flowLayoutPanelMenu.Size = new System.Drawing.Size(189, 600);
            this.flowLayoutPanelMenu.TabIndex = 4;
            this.flowLayoutPanelMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanelMenu_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(59)))));
            this.panel2.Location = new System.Drawing.Point(4, 41);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(196, 47);
            this.panel2.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(59)))));
            this.panel4.Controls.Add(this.btUtilizadores);
            this.panel4.Location = new System.Drawing.Point(4, 96);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(213, 53);
            this.panel4.TabIndex = 10;
            // 
            // btUtilizadores
            // 
            this.btUtilizadores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(59)))));
            this.btUtilizadores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btUtilizadores.FlatAppearance.BorderSize = 0;
            this.btUtilizadores.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btUtilizadores.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.btUtilizadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btUtilizadores.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btUtilizadores.ForeColor = System.Drawing.Color.White;
            this.btUtilizadores.Image = global::Admin.Properties.Resources.userB;
            this.btUtilizadores.Location = new System.Drawing.Point(-16, 0);
            this.btUtilizadores.Margin = new System.Windows.Forms.Padding(4);
            this.btUtilizadores.Name = "btUtilizadores";
            this.btUtilizadores.Size = new System.Drawing.Size(229, 53);
            this.btUtilizadores.TabIndex = 2;
            this.btUtilizadores.TabStop = false;
            this.btUtilizadores.Text = "    Utilizadores";
            this.btUtilizadores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btUtilizadores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btUtilizadores.UseVisualStyleBackColor = false;
            this.btUtilizadores.Click += new System.EventHandler(this.btUtilizadores_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(59)))));
            this.panel5.Controls.Add(this.btAutocarros);
            this.panel5.Location = new System.Drawing.Point(4, 157);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(213, 53);
            this.panel5.TabIndex = 11;
            // 
            // btAutocarros
            // 
            this.btAutocarros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(59)))));
            this.btAutocarros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAutocarros.FlatAppearance.BorderSize = 0;
            this.btAutocarros.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btAutocarros.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.btAutocarros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAutocarros.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAutocarros.ForeColor = System.Drawing.Color.White;
            this.btAutocarros.Image = global::Admin.Properties.Resources.autobusB;
            this.btAutocarros.Location = new System.Drawing.Point(-16, -7);
            this.btAutocarros.Margin = new System.Windows.Forms.Padding(4);
            this.btAutocarros.Name = "btAutocarros";
            this.btAutocarros.Size = new System.Drawing.Size(225, 53);
            this.btAutocarros.TabIndex = 2;
            this.btAutocarros.TabStop = false;
            this.btAutocarros.Text = "    Autocarros";
            this.btAutocarros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAutocarros.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btAutocarros.UseVisualStyleBackColor = false;
            this.btAutocarros.Click += new System.EventHandler(this.btAutocarros_Click_1);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btMeuPerfil);
            this.panel3.Location = new System.Drawing.Point(3, 217);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(204, 396);
            this.panel3.TabIndex = 12;
            // 
            // btMeuPerfil
            // 
            this.btMeuPerfil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(59)))));
            this.btMeuPerfil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btMeuPerfil.FlatAppearance.BorderSize = 0;
            this.btMeuPerfil.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btMeuPerfil.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.btMeuPerfil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMeuPerfil.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btMeuPerfil.ForeColor = System.Drawing.Color.White;
            this.btMeuPerfil.Image = global::Admin.Properties.Resources.default_profile1;
            this.btMeuPerfil.Location = new System.Drawing.Point(-15, 328);
            this.btMeuPerfil.Name = "btMeuPerfil";
            this.btMeuPerfil.Size = new System.Drawing.Size(233, 57);
            this.btMeuPerfil.TabIndex = 29;
            this.btMeuPerfil.Text = "          naosei";
            this.btMeuPerfil.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btMeuPerfil.UseVisualStyleBackColor = false;
            this.btMeuPerfil.Click += new System.EventHandler(this.btMeuPerfil_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(59)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btMenu);
            this.panel1.Controls.Add(this.btSair);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1366, 62);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 15F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(608, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 34);
            this.label1.TabIndex = 3;
            this.label1.Text = "AutoBus";
            // 
            // btMenu
            // 
            this.btMenu.BackColor = System.Drawing.Color.Transparent;
            this.btMenu.BackgroundImage = global::Admin.Properties.Resources.menuB;
            this.btMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btMenu.FlatAppearance.BorderSize = 0;
            this.btMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.btMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMenu.Location = new System.Drawing.Point(4, 6);
            this.btMenu.Margin = new System.Windows.Forms.Padding(4);
            this.btMenu.Name = "btMenu";
            this.btMenu.Size = new System.Drawing.Size(65, 50);
            this.btMenu.TabIndex = 2;
            this.btMenu.TabStop = false;
            this.btMenu.UseVisualStyleBackColor = false;
            this.btMenu.Click += new System.EventHandler(this.btMenu_Click_1);
            // 
            // btSair
            // 
            this.btSair.BackColor = System.Drawing.Color.Transparent;
            this.btSair.BackgroundImage = global::Admin.Properties.Resources.xB;
            this.btSair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btSair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSair.FlatAppearance.BorderSize = 0;
            this.btSair.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.btSair.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSair.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btSair.Location = new System.Drawing.Point(1292, 1);
            this.btSair.Margin = new System.Windows.Forms.Padding(4);
            this.btSair.Name = "btSair";
            this.btSair.Size = new System.Drawing.Size(58, 61);
            this.btSair.TabIndex = 2;
            this.btSair.TabStop = false;
            this.btSair.UseVisualStyleBackColor = false;
            this.btSair.Click += new System.EventHandler(this.btSair_Click);
            this.btSair.MouseLeave += new System.EventHandler(this.btSair_MouseLeave);
            this.btSair.MouseHover += new System.EventHandler(this.btSair_MouseHover);
            // 
            // panelUtilizadores
            // 
            this.panelUtilizadores.Controls.Add(this.textBox3);
            this.panelUtilizadores.Controls.Add(this.btAtivarUtilizador);
            this.panelUtilizadores.Controls.Add(this.btEditarUtilizadores);
            this.panelUtilizadores.Controls.Add(this.btDesativarUtilizador);
            this.panelUtilizadores.Controls.Add(this.btCriarUtilizador);
            this.panelUtilizadores.Controls.Add(this.btPesquisarUtilizadores);
            this.panelUtilizadores.Controls.Add(this.dataGridViewUtilizador);
            this.panelUtilizadores.Controls.Add(this.textBox1);
            this.panelUtilizadores.Controls.Add(this.label2);
            this.panelUtilizadores.Location = new System.Drawing.Point(189, 53);
            this.panelUtilizadores.Margin = new System.Windows.Forms.Padding(4);
            this.panelUtilizadores.Name = "panelUtilizadores";
            this.panelUtilizadores.Size = new System.Drawing.Size(1165, 547);
            this.panelUtilizadores.TabIndex = 5;
            // 
            // btAtivarUtilizador
            // 
            this.btAtivarUtilizador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(59)))));
            this.btAtivarUtilizador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAtivarUtilizador.FlatAppearance.BorderSize = 0;
            this.btAtivarUtilizador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAtivarUtilizador.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btAtivarUtilizador.ForeColor = System.Drawing.Color.White;
            this.btAtivarUtilizador.Location = new System.Drawing.Point(391, 114);
            this.btAtivarUtilizador.Margin = new System.Windows.Forms.Padding(4);
            this.btAtivarUtilizador.Name = "btAtivarUtilizador";
            this.btAtivarUtilizador.Size = new System.Drawing.Size(165, 28);
            this.btAtivarUtilizador.TabIndex = 18;
            this.btAtivarUtilizador.Text = "Ativar utilizador";
            this.btAtivarUtilizador.UseVisualStyleBackColor = false;
            this.btAtivarUtilizador.Click += new System.EventHandler(this.btAtivarUtilizador_Click);
            // 
            // btEditarUtilizadores
            // 
            this.btEditarUtilizadores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(59)))));
            this.btEditarUtilizadores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btEditarUtilizadores.FlatAppearance.BorderSize = 0;
            this.btEditarUtilizadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEditarUtilizadores.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btEditarUtilizadores.ForeColor = System.Drawing.Color.White;
            this.btEditarUtilizadores.Location = new System.Drawing.Point(40, 114);
            this.btEditarUtilizadores.Margin = new System.Windows.Forms.Padding(4);
            this.btEditarUtilizadores.Name = "btEditarUtilizadores";
            this.btEditarUtilizadores.Size = new System.Drawing.Size(163, 28);
            this.btEditarUtilizadores.TabIndex = 17;
            this.btEditarUtilizadores.Text = "Editar utilizador";
            this.btEditarUtilizadores.UseVisualStyleBackColor = false;
            this.btEditarUtilizadores.Click += new System.EventHandler(this.btEditarUtilizadores_Click);
            // 
            // btDesativarUtilizador
            // 
            this.btDesativarUtilizador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(59)))));
            this.btDesativarUtilizador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btDesativarUtilizador.FlatAppearance.BorderSize = 0;
            this.btDesativarUtilizador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDesativarUtilizador.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btDesativarUtilizador.ForeColor = System.Drawing.Color.White;
            this.btDesativarUtilizador.Location = new System.Drawing.Point(573, 114);
            this.btDesativarUtilizador.Margin = new System.Windows.Forms.Padding(4);
            this.btDesativarUtilizador.Name = "btDesativarUtilizador";
            this.btDesativarUtilizador.Size = new System.Drawing.Size(195, 28);
            this.btDesativarUtilizador.TabIndex = 16;
            this.btDesativarUtilizador.Text = "Desativar utilizador";
            this.btDesativarUtilizador.UseVisualStyleBackColor = false;
            this.btDesativarUtilizador.Click += new System.EventHandler(this.btDesativarUtilizador_Click);
            // 
            // btCriarUtilizador
            // 
            this.btCriarUtilizador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(59)))));
            this.btCriarUtilizador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCriarUtilizador.FlatAppearance.BorderSize = 0;
            this.btCriarUtilizador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCriarUtilizador.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btCriarUtilizador.ForeColor = System.Drawing.Color.White;
            this.btCriarUtilizador.Location = new System.Drawing.Point(221, 114);
            this.btCriarUtilizador.Margin = new System.Windows.Forms.Padding(4);
            this.btCriarUtilizador.Name = "btCriarUtilizador";
            this.btCriarUtilizador.Size = new System.Drawing.Size(145, 28);
            this.btCriarUtilizador.TabIndex = 15;
            this.btCriarUtilizador.Text = "Criar utilizador";
            this.btCriarUtilizador.UseVisualStyleBackColor = false;
            this.btCriarUtilizador.Click += new System.EventHandler(this.btCriarUtilizador_Click_1);
            // 
            // btPesquisarUtilizadores
            // 
            this.btPesquisarUtilizadores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(59)))));
            this.btPesquisarUtilizadores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btPesquisarUtilizadores.FlatAppearance.BorderSize = 0;
            this.btPesquisarUtilizadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPesquisarUtilizadores.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPesquisarUtilizadores.ForeColor = System.Drawing.SystemColors.Control;
            this.btPesquisarUtilizadores.Image = global::Admin.Properties.Resources.lupaB;
            this.btPesquisarUtilizadores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPesquisarUtilizadores.Location = new System.Drawing.Point(1004, 32);
            this.btPesquisarUtilizadores.Name = "btPesquisarUtilizadores";
            this.btPesquisarUtilizadores.Size = new System.Drawing.Size(132, 39);
            this.btPesquisarUtilizadores.TabIndex = 14;
            this.btPesquisarUtilizadores.Text = " Pesquisar";
            this.btPesquisarUtilizadores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btPesquisarUtilizadores.UseVisualStyleBackColor = false;
            this.btPesquisarUtilizadores.Click += new System.EventHandler(this.btPesquisarUtilizadores_Click);
            // 
            // dataGridViewUtilizador
            // 
            this.dataGridViewUtilizador.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewUtilizador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUtilizador.Location = new System.Drawing.Point(40, 164);
            this.dataGridViewUtilizador.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewUtilizador.Name = "dataGridViewUtilizador";
            this.dataGridViewUtilizador.RowHeadersWidth = 51;
            this.dataGridViewUtilizador.Size = new System.Drawing.Size(1096, 353);
            this.dataGridViewUtilizador.TabIndex = 9;
            this.dataGridViewUtilizador.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridViewUtilizador.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUtilizador_CellContentClick);
            this.dataGridViewUtilizador.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewUtilizador_CellFormatting);
            this.dataGridViewUtilizador.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUtilizador_CellMouseLeave);
            this.dataGridViewUtilizador.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewUtilizador_CellMouseMove);
            this.dataGridViewUtilizador.SelectionChanged += new System.EventHandler(this.dataGridViewUtilizador_SelectionChanged);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(820, 37);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(167, 30);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 15.75F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(59)))));
            this.label2.Location = new System.Drawing.Point(33, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 39);
            this.label2.TabIndex = 4;
            this.label2.Text = "Utilizadores";
            // 
            // transicao
            // 
            this.transicao.Interval = 10;
            this.transicao.Tick += new System.EventHandler(this.transicao_Tick);
            // 
            // transicaoLateral
            // 
            this.transicaoLateral.Interval = 10;
            this.transicaoLateral.Tick += new System.EventHandler(this.transicaoLateral_Tick);
            // 
            // panelAutocarros
            // 
            this.panelAutocarros.Controls.Add(this.textBox4);
            this.panelAutocarros.Controls.Add(this.btAtivarAuto);
            this.panelAutocarros.Controls.Add(this.dataGridViewAutocarro);
            this.panelAutocarros.Controls.Add(this.btPesquisarAutocarro);
            this.panelAutocarros.Controls.Add(this.textBox2);
            this.panelAutocarros.Controls.Add(this.btCriarRotas);
            this.panelAutocarros.Controls.Add(this.btAdicionarAutoC);
            this.panelAutocarros.Controls.Add(this.btDesativarAuto);
            this.panelAutocarros.Controls.Add(this.btEditarAutocarro);
            this.panelAutocarros.Controls.Add(this.label3);
            this.panelAutocarros.Location = new System.Drawing.Point(189, 53);
            this.panelAutocarros.Margin = new System.Windows.Forms.Padding(4);
            this.panelAutocarros.Name = "panelAutocarros";
            this.panelAutocarros.Size = new System.Drawing.Size(1165, 547);
            this.panelAutocarros.TabIndex = 6;
            this.panelAutocarros.Paint += new System.Windows.Forms.PaintEventHandler(this.panelAutocarros_Paint);
            // 
            // btAtivarAuto
            // 
            this.btAtivarAuto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(59)))));
            this.btAtivarAuto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAtivarAuto.FlatAppearance.BorderSize = 0;
            this.btAtivarAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAtivarAuto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAtivarAuto.ForeColor = System.Drawing.Color.White;
            this.btAtivarAuto.Location = new System.Drawing.Point(416, 114);
            this.btAtivarAuto.Margin = new System.Windows.Forms.Padding(4);
            this.btAtivarAuto.Name = "btAtivarAuto";
            this.btAtivarAuto.Size = new System.Drawing.Size(159, 28);
            this.btAtivarAuto.TabIndex = 28;
            this.btAtivarAuto.Text = "Ativar autocarro";
            this.btAtivarAuto.UseVisualStyleBackColor = false;
            this.btAtivarAuto.Click += new System.EventHandler(this.btAtivarAuto_Click);
            // 
            // dataGridViewAutocarro
            // 
            this.dataGridViewAutocarro.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewAutocarro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAutocarro.Location = new System.Drawing.Point(40, 164);
            this.dataGridViewAutocarro.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewAutocarro.Name = "dataGridViewAutocarro";
            this.dataGridViewAutocarro.RowHeadersWidth = 51;
            this.dataGridViewAutocarro.Size = new System.Drawing.Size(926, 353);
            this.dataGridViewAutocarro.TabIndex = 27;
            this.dataGridViewAutocarro.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridViewAutocarro_CellFormatting);
            // 
            // btPesquisarAutocarro
            // 
            this.btPesquisarAutocarro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(59)))));
            this.btPesquisarAutocarro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btPesquisarAutocarro.FlatAppearance.BorderSize = 0;
            this.btPesquisarAutocarro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPesquisarAutocarro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPesquisarAutocarro.ForeColor = System.Drawing.SystemColors.Control;
            this.btPesquisarAutocarro.Image = global::Admin.Properties.Resources.lupaB;
            this.btPesquisarAutocarro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPesquisarAutocarro.Location = new System.Drawing.Point(1004, 32);
            this.btPesquisarAutocarro.Name = "btPesquisarAutocarro";
            this.btPesquisarAutocarro.Size = new System.Drawing.Size(132, 39);
            this.btPesquisarAutocarro.TabIndex = 26;
            this.btPesquisarAutocarro.Text = " Pesquisar";
            this.btPesquisarAutocarro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btPesquisarAutocarro.UseVisualStyleBackColor = false;
            this.btPesquisarAutocarro.Click += new System.EventHandler(this.btPesquisarAutocarro_Click);
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBox2.Location = new System.Drawing.Point(820, 37);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(167, 30);
            this.textBox2.TabIndex = 25;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // btCriarRotas
            // 
            this.btCriarRotas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(59)))));
            this.btCriarRotas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCriarRotas.FlatAppearance.BorderSize = 0;
            this.btCriarRotas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCriarRotas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCriarRotas.ForeColor = System.Drawing.Color.White;
            this.btCriarRotas.Location = new System.Drawing.Point(786, 114);
            this.btCriarRotas.Margin = new System.Windows.Forms.Padding(4);
            this.btCriarRotas.Name = "btCriarRotas";
            this.btCriarRotas.Size = new System.Drawing.Size(94, 28);
            this.btCriarRotas.TabIndex = 24;
            this.btCriarRotas.Text = "Rotas";
            this.btCriarRotas.UseVisualStyleBackColor = false;
            this.btCriarRotas.Click += new System.EventHandler(this.btCriarRotas_Click_1);
            // 
            // btAdicionarAutoC
            // 
            this.btAdicionarAutoC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(59)))));
            this.btAdicionarAutoC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btAdicionarAutoC.FlatAppearance.BorderSize = 0;
            this.btAdicionarAutoC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAdicionarAutoC.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAdicionarAutoC.ForeColor = System.Drawing.Color.White;
            this.btAdicionarAutoC.Location = new System.Drawing.Point(221, 114);
            this.btAdicionarAutoC.Margin = new System.Windows.Forms.Padding(4);
            this.btAdicionarAutoC.Name = "btAdicionarAutoC";
            this.btAdicionarAutoC.Size = new System.Drawing.Size(178, 28);
            this.btAdicionarAutoC.TabIndex = 23;
            this.btAdicionarAutoC.Text = "Adicionar autocarro";
            this.btAdicionarAutoC.UseVisualStyleBackColor = false;
            this.btAdicionarAutoC.Click += new System.EventHandler(this.btAdicionarAutoC_Click_1);
            // 
            // btDesativarAuto
            // 
            this.btDesativarAuto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(59)))));
            this.btDesativarAuto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btDesativarAuto.FlatAppearance.BorderSize = 0;
            this.btDesativarAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDesativarAuto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDesativarAuto.ForeColor = System.Drawing.Color.White;
            this.btDesativarAuto.Location = new System.Drawing.Point(593, 114);
            this.btDesativarAuto.Margin = new System.Windows.Forms.Padding(4);
            this.btDesativarAuto.Name = "btDesativarAuto";
            this.btDesativarAuto.Size = new System.Drawing.Size(175, 28);
            this.btDesativarAuto.TabIndex = 22;
            this.btDesativarAuto.Text = "Desativar autocarro";
            this.btDesativarAuto.UseVisualStyleBackColor = false;
            this.btDesativarAuto.Click += new System.EventHandler(this.btDesativarAuto_Click);
            // 
            // btEditarAutocarro
            // 
            this.btEditarAutocarro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(59)))));
            this.btEditarAutocarro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btEditarAutocarro.FlatAppearance.BorderSize = 0;
            this.btEditarAutocarro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEditarAutocarro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEditarAutocarro.ForeColor = System.Drawing.Color.White;
            this.btEditarAutocarro.Location = new System.Drawing.Point(40, 114);
            this.btEditarAutocarro.Margin = new System.Windows.Forms.Padding(4);
            this.btEditarAutocarro.Name = "btEditarAutocarro";
            this.btEditarAutocarro.Size = new System.Drawing.Size(163, 28);
            this.btEditarAutocarro.TabIndex = 21;
            this.btEditarAutocarro.Text = "Editar Autocarro";
            this.btEditarAutocarro.UseVisualStyleBackColor = false;
            this.btEditarAutocarro.Click += new System.EventHandler(this.btEditarAutocarro_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 15.75F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(59)))));
            this.label3.Location = new System.Drawing.Point(33, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 39);
            this.label3.TabIndex = 14;
            this.label3.Text = "Autocarros";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(3, 10);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(20, 22);
            this.textBox3.TabIndex = 19;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(1144, 522);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(16, 22);
            this.textBox4.TabIndex = 29;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::Admin.Properties.Resources.autocarroEsc;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1350, 600);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanelMenu);
            this.Controls.Add(this.panelAutocarros);
            this.Controls.Add(this.panelUtilizadores);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "    ";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.flowLayoutPanelMenu.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelUtilizadores.ResumeLayout(false);
            this.panelUtilizadores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUtilizador)).EndInit();
            this.panelAutocarros.ResumeLayout(false);
            this.panelAutocarros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAutocarro)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btMenu;
        private System.Windows.Forms.Button btSair;
        private System.Windows.Forms.Panel panelUtilizadores;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer transicao;
        private System.Windows.Forms.Timer transicaoLateral;
        private System.Windows.Forms.DataGridView dataGridViewUtilizador;
        private System.Windows.Forms.Panel panelAutocarros;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btUtilizadores;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btAutocarros;
        private System.Windows.Forms.Button btPesquisarUtilizadores;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btEditarUtilizadores;
        private System.Windows.Forms.Button btDesativarUtilizador;
        private System.Windows.Forms.Button btCriarUtilizador;
        private System.Windows.Forms.Button btPesquisarAutocarro;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btCriarRotas;
        private System.Windows.Forms.Button btAdicionarAutoC;
        private System.Windows.Forms.Button btDesativarAuto;
        private System.Windows.Forms.Button btEditarAutocarro;
        private System.Windows.Forms.DataGridView dataGridViewAutocarro;
        private System.Windows.Forms.Button btAtivarUtilizador;
        private System.Windows.Forms.Button btAtivarAuto;
        private System.Windows.Forms.Button btMeuPerfil;
    private System.Windows.Forms.TextBox textBox3;
    private System.Windows.Forms.TextBox textBox4;
  }
}