namespace FalconSushi.Formularios
{
    partial class FrmGestionPromocion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGestionPromocion));
            this.BtnEliminarSushi = new System.Windows.Forms.Button();
            this.BtnAddSushi = new System.Windows.Forms.Button();
            this.TxtComentarios = new System.Windows.Forms.TextBox();
            this.DgvSushi = new System.Windows.Forms.DataGridView();
            this.GCodigoS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GNombreS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GPrecioS = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.GDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sPPromocionListarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.falconSushiDataSet7 = new FalconSushi.FalconSushiDataSet7();
            this.sPPromocionListarTableAdapter = new FalconSushi.FalconSushiDataSet7TableAdapters.SPPromocionListarTableAdapter();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LblUsuarioRegistra = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSushi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPPromocionListarBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.falconSushiDataSet7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnEliminarSushi
            // 
            this.BtnEliminarSushi.BackColor = System.Drawing.Color.LightCoral;
            this.BtnEliminarSushi.Enabled = false;
            this.BtnEliminarSushi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminarSushi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminarSushi.Location = new System.Drawing.Point(707, 316);
            this.BtnEliminarSushi.Margin = new System.Windows.Forms.Padding(2);
            this.BtnEliminarSushi.Name = "BtnEliminarSushi";
            this.BtnEliminarSushi.Size = new System.Drawing.Size(144, 58);
            this.BtnEliminarSushi.TabIndex = 69;
            this.BtnEliminarSushi.Text = "Eliminar Sushi";
            this.BtnEliminarSushi.UseVisualStyleBackColor = false;
            this.BtnEliminarSushi.Click += new System.EventHandler(this.BtnEliminarSushi_Click);
            // 
            // BtnAddSushi
            // 
            this.BtnAddSushi.BackColor = System.Drawing.Color.PaleGreen;
            this.BtnAddSushi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddSushi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddSushi.Location = new System.Drawing.Point(545, 316);
            this.BtnAddSushi.Margin = new System.Windows.Forms.Padding(2);
            this.BtnAddSushi.Name = "BtnAddSushi";
            this.BtnAddSushi.Size = new System.Drawing.Size(158, 58);
            this.BtnAddSushi.TabIndex = 68;
            this.BtnAddSushi.Text = "Agregar Sushi";
            this.BtnAddSushi.UseVisualStyleBackColor = false;
            this.BtnAddSushi.Click += new System.EventHandler(this.BtnAddIngrediente_Click);
            // 
            // TxtComentarios
            // 
            this.TxtComentarios.Location = new System.Drawing.Point(237, 475);
            this.TxtComentarios.Multiline = true;
            this.TxtComentarios.Name = "TxtComentarios";
            this.TxtComentarios.Size = new System.Drawing.Size(156, 87);
            this.TxtComentarios.TabIndex = 67;
            // 
            // DgvSushi
            // 
            this.DgvSushi.AllowUserToAddRows = false;
            this.DgvSushi.AllowUserToDeleteRows = false;
            this.DgvSushi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvSushi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GCodigoS,
            this.GNombreS,
            this.GPrecioS});
            this.DgvSushi.Location = new System.Drawing.Point(545, 102);
            this.DgvSushi.Name = "DgvSushi";
            this.DgvSushi.ReadOnly = true;
            this.DgvSushi.RowHeadersVisible = false;
            this.DgvSushi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvSushi.Size = new System.Drawing.Size(306, 209);
            this.DgvSushi.TabIndex = 66;
            // 
            // GCodigoS
            // 
            this.GCodigoS.DataPropertyName = "SushiID";
            this.GCodigoS.HeaderText = "ID";
            this.GCodigoS.Name = "GCodigoS";
            this.GCodigoS.ReadOnly = true;
            this.GCodigoS.Width = 50;
            // 
            // GNombreS
            // 
            this.GNombreS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GNombreS.DataPropertyName = "Nombre";
            this.GNombreS.HeaderText = "Nombre";
            this.GNombreS.Name = "GNombreS";
            this.GNombreS.ReadOnly = true;
            // 
            // GPrecioS
            // 
            this.GPrecioS.DataPropertyName = "Precio";
            this.GPrecioS.HeaderText = "Precio";
            this.GPrecioS.Name = "GPrecioS";
            this.GPrecioS.ReadOnly = true;
            this.GPrecioS.Width = 70;
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Location = new System.Drawing.Point(19, 57);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(418, 20);
            this.TxtBuscar.TabIndex = 65;
            this.TxtBuscar.TextChanged += new System.EventHandler(this.TxtBuscar_TextChanged);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.Color.MediumOrchid;
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(761, 434);
            this.BtnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(105, 38);
            this.BtnCancelar.TabIndex = 64;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.BackColor = System.Drawing.Color.LightBlue;
            this.BtnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLimpiar.Location = new System.Drawing.Point(652, 476);
            this.BtnLimpiar.Margin = new System.Windows.Forms.Padding(2);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(105, 38);
            this.BtnLimpiar.TabIndex = 63;
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
            this.BtnEliminar.Location = new System.Drawing.Point(543, 476);
            this.BtnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(105, 38);
            this.BtnEliminar.TabIndex = 62;
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
            this.BtnEditar.Location = new System.Drawing.Point(652, 434);
            this.BtnEditar.Margin = new System.Windows.Forms.Padding(2);
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(105, 38);
            this.BtnEditar.TabIndex = 61;
            this.BtnEditar.Text = "Editar";
            this.BtnEditar.UseVisualStyleBackColor = false;
            this.BtnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.BackColor = System.Drawing.Color.PaleGreen;
            this.BtnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregar.Location = new System.Drawing.Point(543, 434);
            this.BtnAgregar.Margin = new System.Windows.Forms.Padding(2);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(105, 38);
            this.BtnAgregar.TabIndex = 60;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = false;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // TxtNombre
            // 
            this.TxtNombre.Location = new System.Drawing.Point(75, 377);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(231, 20);
            this.TxtNombre.TabIndex = 58;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(72, 361);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(234, 459);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 56;
            this.label3.Text = "Comentarios";
            // 
            // TxtPrecio
            // 
            this.TxtPrecio.Location = new System.Drawing.Point(19, 424);
            this.TxtPrecio.Name = "TxtPrecio";
            this.TxtPrecio.Size = new System.Drawing.Size(287, 20);
            this.TxtPrecio.TabIndex = 55;
            this.TxtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPrecio_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 408);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "Precio";
            // 
            // TxtCodigo
            // 
            this.TxtCodigo.Location = new System.Drawing.Point(19, 377);
            this.TxtCodigo.Name = "TxtCodigo";
            this.TxtCodigo.ReadOnly = true;
            this.TxtCodigo.Size = new System.Drawing.Size(50, 20);
            this.TxtCodigo.TabIndex = 53;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 361);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "ID";
            // 
            // CbVerActivos
            // 
            this.CbVerActivos.AutoSize = true;
            this.CbVerActivos.Checked = true;
            this.CbVerActivos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbVerActivos.Location = new System.Drawing.Point(443, 57);
            this.CbVerActivos.Name = "CbVerActivos";
            this.CbVerActivos.Size = new System.Drawing.Size(79, 17);
            this.CbVerActivos.TabIndex = 51;
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
            this.GDescripcion,
            this.GPrecio});
            this.DgvLista.DataSource = this.sPPromocionListarBindingSource;
            this.DgvLista.Location = new System.Drawing.Point(19, 102);
            this.DgvLista.Name = "DgvLista";
            this.DgvLista.ReadOnly = true;
            this.DgvLista.RowHeadersVisible = false;
            this.DgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvLista.Size = new System.Drawing.Size(483, 209);
            this.DgvLista.TabIndex = 50;
            this.DgvLista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvLista_CellClick);
            // 
            // GCodigo
            // 
            this.GCodigo.DataPropertyName = "PromocionID";
            this.GCodigo.HeaderText = "ID";
            this.GCodigo.Name = "GCodigo";
            this.GCodigo.ReadOnly = true;
            this.GCodigo.Width = 25;
            // 
            // GNombre
            // 
            this.GNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GNombre.DataPropertyName = "Nombre";
            this.GNombre.HeaderText = "Nombre";
            this.GNombre.Name = "GNombre";
            this.GNombre.ReadOnly = true;
            // 
            // GDescripcion
            // 
            this.GDescripcion.DataPropertyName = "Descripcion";
            this.GDescripcion.HeaderText = "Descripcion";
            this.GDescripcion.Name = "GDescripcion";
            this.GDescripcion.ReadOnly = true;
            this.GDescripcion.Width = 200;
            // 
            // GPrecio
            // 
            this.GPrecio.DataPropertyName = "Precio";
            this.GPrecio.HeaderText = "Precio";
            this.GPrecio.Name = "GPrecio";
            this.GPrecio.ReadOnly = true;
            // 
            // sPPromocionListarBindingSource
            // 
            this.sPPromocionListarBindingSource.DataMember = "SPPromocionListar";
            this.sPPromocionListarBindingSource.DataSource = this.falconSushiDataSet7;
            // 
            // falconSushiDataSet7
            // 
            this.falconSushiDataSet7.DataSetName = "FalconSushiDataSet7";
            this.falconSushiDataSet7.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sPPromocionListarTableAdapter
            // 
            this.sPPromocionListarTableAdapter.ClearBeforeFill = true;
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.Location = new System.Drawing.Point(22, 475);
            this.TxtDescripcion.Multiline = true;
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(156, 87);
            this.TxtDescripcion.TabIndex = 71;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 459);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 70;
            this.label5.Text = "Descripcion";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(191, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 73;
            this.label6.Text = "Buscar";
            // 
            // LblUsuarioRegistra
            // 
            this.LblUsuarioRegistra.AutoSize = true;
            this.LblUsuarioRegistra.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUsuarioRegistra.Location = new System.Drawing.Point(11, 9);
            this.LblUsuarioRegistra.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblUsuarioRegistra.Name = "LblUsuarioRegistra";
            this.LblUsuarioRegistra.Size = new System.Drawing.Size(151, 26);
            this.LblUsuarioRegistra.TabIndex = 72;
            this.LblUsuarioRegistra.Text = "Promociones";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(19, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 74;
            this.label7.Text = "Promociones";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(545, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 13);
            this.label8.TabIndex = 75;
            this.label8.Text = "Sushi de la promocion";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FalconSushi.Properties.Resources.FalconSushiLogo;
            this.pictureBox1.Location = new System.Drawing.Point(801, 484);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(94, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 76;
            this.pictureBox1.TabStop = false;
            // 
            // FrmGestionPromocion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 574);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LblUsuarioRegistra);
            this.Controls.Add(this.TxtDescripcion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BtnEliminarSushi);
            this.Controls.Add(this.BtnAddSushi);
            this.Controls.Add(this.TxtComentarios);
            this.Controls.Add(this.DgvSushi);
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
            this.Name = "FrmGestionPromocion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema FalconSushi - Promociones";
            this.Load += new System.EventHandler(this.FrmGestionPromocion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvSushi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPPromocionListarBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.falconSushiDataSet7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnEliminarSushi;
        private System.Windows.Forms.Button BtnAddSushi;
        private System.Windows.Forms.TextBox TxtComentarios;
        private System.Windows.Forms.DataGridView DgvSushi;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn GCodigoS;
        private System.Windows.Forms.DataGridViewTextBoxColumn GNombreS;
        private System.Windows.Forms.DataGridViewTextBoxColumn GPrecioS;
        private System.Windows.Forms.DataGridViewTextBoxColumn GCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn GNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn GDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn GPrecio;
        private System.Windows.Forms.BindingSource sPPromocionListarBindingSource;
        private FalconSushiDataSet7 falconSushiDataSet7;
        private FalconSushiDataSet7TableAdapters.SPPromocionListarTableAdapter sPPromocionListarTableAdapter;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LblUsuarioRegistra;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}