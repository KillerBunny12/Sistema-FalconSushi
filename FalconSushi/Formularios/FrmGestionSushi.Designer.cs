namespace FalconSushi.Formularios
{
    partial class FrmGestionSushi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGestionSushi));
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnEditar = new System.Windows.Forms.Button();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtPrecio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CbVerActivos = new System.Windows.Forms.CheckBox();
            this.DgvLista = new System.Windows.Forms.DataGridView();
            this.GCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sPSushiListarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.falconSushiDataSet3 = new FalconSushi.FalconSushiDataSet3();
            this.DgvIngredientes = new System.Windows.Forms.DataGridView();
            this.GCodigoI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GNombreI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sPConsultarIngredientePorSushiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.falconSushiDataSet2 = new FalconSushi.FalconSushiDataSet2();
            this.sPConsultarIngredientePorSushiTableAdapter = new FalconSushi.FalconSushiDataSet2TableAdapters.SPConsultarIngredientePorSushiTableAdapter();
            this.sPSushiListarTableAdapter = new FalconSushi.FalconSushiDataSet3TableAdapters.SPSushiListarTableAdapter();
            this.TxtComentarios = new System.Windows.Forms.TextBox();
            this.BtnAddIngrediente = new System.Windows.Forms.Button();
            this.BtnEliminarIngrediente = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.LblUsuarioRegistra = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPSushiListarBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.falconSushiDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvIngredientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPConsultarIngredientePorSushiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.falconSushiDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Location = new System.Drawing.Point(9, 54);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(418, 20);
            this.TxtBuscar.TabIndex = 45;
            this.TxtBuscar.TextChanged += new System.EventHandler(this.TxtBuscar_TextChanged);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.Color.MediumOrchid;
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(753, 430);
            this.BtnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(105, 38);
            this.BtnCancelar.TabIndex = 44;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.BackColor = System.Drawing.Color.LightBlue;
            this.BtnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLimpiar.Location = new System.Drawing.Point(644, 472);
            this.BtnLimpiar.Margin = new System.Windows.Forms.Padding(2);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(105, 38);
            this.BtnLimpiar.TabIndex = 43;
            this.BtnLimpiar.Text = "Limpiar";
            this.BtnLimpiar.UseVisualStyleBackColor = false;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.BackColor = System.Drawing.Color.LightCoral;
            this.BtnEliminar.Enabled = false;
            this.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminar.Location = new System.Drawing.Point(535, 472);
            this.BtnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(105, 38);
            this.BtnEliminar.TabIndex = 42;
            this.BtnEliminar.Text = "Desactivar";
            this.BtnEliminar.UseVisualStyleBackColor = false;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnEditar
            // 
            this.BtnEditar.BackColor = System.Drawing.Color.Orange;
            this.BtnEditar.Enabled = false;
            this.BtnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEditar.Location = new System.Drawing.Point(644, 430);
            this.BtnEditar.Margin = new System.Windows.Forms.Padding(2);
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(105, 38);
            this.BtnEditar.TabIndex = 41;
            this.BtnEditar.Text = "Editar";
            this.BtnEditar.UseVisualStyleBackColor = false;
            this.BtnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.BackColor = System.Drawing.Color.PaleGreen;
            this.BtnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregar.Location = new System.Drawing.Point(535, 430);
            this.BtnAgregar.Margin = new System.Windows.Forms.Padding(2);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(105, 38);
            this.BtnAgregar.TabIndex = 40;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = false;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // TxtNombre
            // 
            this.TxtNombre.Location = new System.Drawing.Point(65, 373);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(231, 20);
            this.TxtNombre.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(62, 357);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 455);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Comentarios";
            // 
            // TxtPrecio
            // 
            this.TxtPrecio.Location = new System.Drawing.Point(9, 420);
            this.TxtPrecio.Name = "TxtPrecio";
            this.TxtPrecio.Size = new System.Drawing.Size(287, 20);
            this.TxtPrecio.TabIndex = 34;
            this.TxtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPrecio_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 404);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Precio";
            // 
            // TxtCodigo
            // 
            this.TxtCodigo.Location = new System.Drawing.Point(9, 373);
            this.TxtCodigo.Name = "TxtCodigo";
            this.TxtCodigo.ReadOnly = true;
            this.TxtCodigo.Size = new System.Drawing.Size(50, 20);
            this.TxtCodigo.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 357);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "ID";
            // 
            // CbVerActivos
            // 
            this.CbVerActivos.AutoSize = true;
            this.CbVerActivos.Checked = true;
            this.CbVerActivos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbVerActivos.Location = new System.Drawing.Point(433, 54);
            this.CbVerActivos.Name = "CbVerActivos";
            this.CbVerActivos.Size = new System.Drawing.Size(79, 17);
            this.CbVerActivos.TabIndex = 30;
            this.CbVerActivos.Text = "Ver activos";
            this.CbVerActivos.UseVisualStyleBackColor = true;
            this.CbVerActivos.CheckedChanged += new System.EventHandler(this.CbVerActivos_CheckedChanged);
            // 
            // DgvLista
            // 
            this.DgvLista.AllowUserToAddRows = false;
            this.DgvLista.AllowUserToDeleteRows = false;
            this.DgvLista.AutoGenerateColumns = false;
            this.DgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GCodigo,
            this.GNombre,
            this.GPrecio});
            this.DgvLista.DataSource = this.sPSushiListarBindingSource;
            this.DgvLista.Location = new System.Drawing.Point(9, 98);
            this.DgvLista.Name = "DgvLista";
            this.DgvLista.ReadOnly = true;
            this.DgvLista.RowHeadersVisible = false;
            this.DgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvLista.Size = new System.Drawing.Size(483, 209);
            this.DgvLista.TabIndex = 29;
            this.DgvLista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvLista_CellClick);
            // 
            // GCodigo
            // 
            this.GCodigo.DataPropertyName = "SushiID";
            this.GCodigo.HeaderText = "ID";
            this.GCodigo.Name = "GCodigo";
            this.GCodigo.ReadOnly = true;
            this.GCodigo.Width = 50;
            // 
            // GNombre
            // 
            this.GNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GNombre.DataPropertyName = "Nombre";
            this.GNombre.HeaderText = "Nombre";
            this.GNombre.Name = "GNombre";
            this.GNombre.ReadOnly = true;
            // 
            // GPrecio
            // 
            this.GPrecio.DataPropertyName = "Precio";
            this.GPrecio.HeaderText = "Precio";
            this.GPrecio.Name = "GPrecio";
            this.GPrecio.ReadOnly = true;
            this.GPrecio.Width = 150;
            // 
            // sPSushiListarBindingSource
            // 
            this.sPSushiListarBindingSource.DataMember = "SPSushiListar";
            this.sPSushiListarBindingSource.DataSource = this.falconSushiDataSet3;
            // 
            // falconSushiDataSet3
            // 
            this.falconSushiDataSet3.DataSetName = "FalconSushiDataSet3";
            this.falconSushiDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DgvIngredientes
            // 
            this.DgvIngredientes.AllowUserToAddRows = false;
            this.DgvIngredientes.AllowUserToDeleteRows = false;
            this.DgvIngredientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvIngredientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GCodigoI,
            this.GNombreI});
            this.DgvIngredientes.Location = new System.Drawing.Point(535, 98);
            this.DgvIngredientes.Name = "DgvIngredientes";
            this.DgvIngredientes.ReadOnly = true;
            this.DgvIngredientes.RowHeadersVisible = false;
            this.DgvIngredientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvIngredientes.Size = new System.Drawing.Size(306, 209);
            this.DgvIngredientes.TabIndex = 46;
            // 
            // GCodigoI
            // 
            this.GCodigoI.DataPropertyName = "IngredienteID";
            this.GCodigoI.HeaderText = "ID";
            this.GCodigoI.Name = "GCodigoI";
            this.GCodigoI.ReadOnly = true;
            this.GCodigoI.Width = 50;
            // 
            // GNombreI
            // 
            this.GNombreI.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GNombreI.DataPropertyName = "Nombre";
            this.GNombreI.HeaderText = "Nombre";
            this.GNombreI.Name = "GNombreI";
            this.GNombreI.ReadOnly = true;
            // 
            // sPConsultarIngredientePorSushiBindingSource
            // 
            this.sPConsultarIngredientePorSushiBindingSource.DataMember = "SPConsultarIngredientePorSushi";
            this.sPConsultarIngredientePorSushiBindingSource.DataSource = this.falconSushiDataSet2;
            // 
            // falconSushiDataSet2
            // 
            this.falconSushiDataSet2.DataSetName = "FalconSushiDataSet2";
            this.falconSushiDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sPConsultarIngredientePorSushiTableAdapter
            // 
            this.sPConsultarIngredientePorSushiTableAdapter.ClearBeforeFill = true;
            // 
            // sPSushiListarTableAdapter
            // 
            this.sPSushiListarTableAdapter.ClearBeforeFill = true;
            // 
            // TxtComentarios
            // 
            this.TxtComentarios.Location = new System.Drawing.Point(12, 471);
            this.TxtComentarios.Multiline = true;
            this.TxtComentarios.Name = "TxtComentarios";
            this.TxtComentarios.Size = new System.Drawing.Size(371, 87);
            this.TxtComentarios.TabIndex = 47;
            // 
            // BtnAddIngrediente
            // 
            this.BtnAddIngrediente.BackColor = System.Drawing.Color.PaleGreen;
            this.BtnAddIngrediente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddIngrediente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddIngrediente.Location = new System.Drawing.Point(535, 312);
            this.BtnAddIngrediente.Margin = new System.Windows.Forms.Padding(2);
            this.BtnAddIngrediente.Name = "BtnAddIngrediente";
            this.BtnAddIngrediente.Size = new System.Drawing.Size(158, 58);
            this.BtnAddIngrediente.TabIndex = 48;
            this.BtnAddIngrediente.Text = "Agregar ingrediente";
            this.BtnAddIngrediente.UseVisualStyleBackColor = false;
            this.BtnAddIngrediente.Click += new System.EventHandler(this.BtnAddIngrediente_Click);
            // 
            // BtnEliminarIngrediente
            // 
            this.BtnEliminarIngrediente.BackColor = System.Drawing.Color.LightCoral;
            this.BtnEliminarIngrediente.Enabled = false;
            this.BtnEliminarIngrediente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminarIngrediente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminarIngrediente.Location = new System.Drawing.Point(697, 312);
            this.BtnEliminarIngrediente.Margin = new System.Windows.Forms.Padding(2);
            this.BtnEliminarIngrediente.Name = "BtnEliminarIngrediente";
            this.BtnEliminarIngrediente.Size = new System.Drawing.Size(144, 58);
            this.BtnEliminarIngrediente.TabIndex = 49;
            this.BtnEliminarIngrediente.Text = "Eliminar ingrediente";
            this.BtnEliminarIngrediente.UseVisualStyleBackColor = false;
            this.BtnEliminarIngrediente.Click += new System.EventHandler(this.BtnEliminarIngrediente_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(182, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 51;
            this.label5.Text = "Buscar";
            // 
            // LblUsuarioRegistra
            // 
            this.LblUsuarioRegistra.AutoSize = true;
            this.LblUsuarioRegistra.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUsuarioRegistra.Location = new System.Drawing.Point(11, 9);
            this.LblUsuarioRegistra.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblUsuarioRegistra.Name = "LblUsuarioRegistra";
            this.LblUsuarioRegistra.Size = new System.Drawing.Size(72, 26);
            this.LblUsuarioRegistra.TabIndex = 50;
            this.LblUsuarioRegistra.Text = "Sushi";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 52;
            this.label6.Text = "Sushi";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(535, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 13);
            this.label7.TabIndex = 53;
            this.label7.Text = "Ingredientes del sushi";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FalconSushi.Properties.Resources.FalconSushiLogo;
            this.pictureBox1.Location = new System.Drawing.Point(781, 480);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(94, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 54;
            this.pictureBox1.TabStop = false;
            // 
            // FrmGestionSushi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 570);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LblUsuarioRegistra);
            this.Controls.Add(this.BtnEliminarIngrediente);
            this.Controls.Add(this.BtnAddIngrediente);
            this.Controls.Add(this.TxtComentarios);
            this.Controls.Add(this.DgvIngredientes);
            this.Controls.Add(this.TxtBuscar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnEditar);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtPrecio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtCodigo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CbVerActivos);
            this.Controls.Add(this.DgvLista);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGestionSushi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema Falcon Sushi - Sushis";
            this.Load += new System.EventHandler(this.FrmGestionSushi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPSushiListarBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.falconSushiDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvIngredientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPConsultarIngredientePorSushiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.falconSushiDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnEditar;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtPrecio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CbVerActivos;
        private System.Windows.Forms.DataGridView DgvLista;
        private System.Windows.Forms.DataGridViewTextBoxColumn GCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn GNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn GPrecio;
        private System.Windows.Forms.BindingSource sPSushiListarBindingSource;
        private FalconSushiDataSet3 falconSushiDataSet3;
        private System.Windows.Forms.DataGridView DgvIngredientes;
        private System.Windows.Forms.BindingSource sPConsultarIngredientePorSushiBindingSource;
        private FalconSushiDataSet2 falconSushiDataSet2;
        private FalconSushiDataSet2TableAdapters.SPConsultarIngredientePorSushiTableAdapter sPConsultarIngredientePorSushiTableAdapter;
        private FalconSushiDataSet3TableAdapters.SPSushiListarTableAdapter sPSushiListarTableAdapter;
        private System.Windows.Forms.TextBox TxtComentarios;
        private System.Windows.Forms.Button BtnAddIngrediente;
        private System.Windows.Forms.Button BtnEliminarIngrediente;
        private System.Windows.Forms.DataGridViewTextBoxColumn GCodigoI;
        private System.Windows.Forms.DataGridViewTextBoxColumn GNombreI;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LblUsuarioRegistra;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}