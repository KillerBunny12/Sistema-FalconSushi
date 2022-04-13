namespace FalconSushi.Formularios
{
    partial class FrmGestioAgregarSushi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGestioAgregarSushi));
            this.DgvLista = new System.Windows.Forms.DataGridView();
            this.GCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sPSushiListarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.falconSushiDataSet8 = new FalconSushi.FalconSushiDataSet8();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.sPSushiListarTableAdapter = new FalconSushi.FalconSushiDataSet8TableAdapters.SPSushiListarTableAdapter();
            this.LblUsuarioRegistra = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPSushiListarBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.falconSushiDataSet8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            this.DgvLista.Location = new System.Drawing.Point(47, 89);
            this.DgvLista.Name = "DgvLista";
            this.DgvLista.ReadOnly = true;
            this.DgvLista.RowHeadersVisible = false;
            this.DgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvLista.Size = new System.Drawing.Size(329, 209);
            this.DgvLista.TabIndex = 34;
            // 
            // GCodigo
            // 
            this.GCodigo.DataPropertyName = "SushiID";
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
            // GPrecio
            // 
            this.GPrecio.DataPropertyName = "Precio";
            this.GPrecio.HeaderText = "Precio";
            this.GPrecio.Name = "GPrecio";
            this.GPrecio.ReadOnly = true;
            // 
            // sPSushiListarBindingSource
            // 
            this.sPSushiListarBindingSource.DataMember = "SPSushiListar";
            this.sPSushiListarBindingSource.DataSource = this.falconSushiDataSet8;
            // 
            // falconSushiDataSet8
            // 
            this.falconSushiDataSet8.DataSetName = "FalconSushiDataSet8";
            this.falconSushiDataSet8.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.Color.LightCoral;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(262, 358);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(114, 44);
            this.BtnCancelar.TabIndex = 33;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.BackColor = System.Drawing.Color.PaleGreen;
            this.BtnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptar.Location = new System.Drawing.Point(47, 358);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(119, 44);
            this.BtnAceptar.TabIndex = 32;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = false;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBuscar.Location = new System.Drawing.Point(91, 61);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(244, 22);
            this.TxtBuscar.TabIndex = 31;
            this.TxtBuscar.TextChanged += new System.EventHandler(this.TxtBuscar_TextChanged);
            // 
            // sPSushiListarTableAdapter
            // 
            this.sPSushiListarTableAdapter.ClearBeforeFill = true;
            // 
            // LblUsuarioRegistra
            // 
            this.LblUsuarioRegistra.AutoSize = true;
            this.LblUsuarioRegistra.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUsuarioRegistra.Location = new System.Drawing.Point(11, 9);
            this.LblUsuarioRegistra.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblUsuarioRegistra.Name = "LblUsuarioRegistra";
            this.LblUsuarioRegistra.Size = new System.Drawing.Size(192, 26);
            this.LblUsuarioRegistra.TabIndex = 35;
            this.LblUsuarioRegistra.Text = "Seleccione sushi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(190, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Buscar";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FalconSushi.Properties.Resources.FalconSushiLogo;
            this.pictureBox1.Location = new System.Drawing.Point(360, -7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 51;
            this.pictureBox1.TabStop = false;
            // 
            // FrmGestioAgregarSushi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 414);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblUsuarioRegistra);
            this.Controls.Add(this.DgvLista);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.TxtBuscar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGestioAgregarSushi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema FalconSushi - Promociones";
            this.Load += new System.EventHandler(this.FrmGestioAgregarSushi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPSushiListarBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.falconSushiDataSet8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvLista;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.BindingSource sPSushiListarBindingSource;
        private FalconSushiDataSet8 falconSushiDataSet8;
        private FalconSushiDataSet8TableAdapters.SPSushiListarTableAdapter sPSushiListarTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn GCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn GNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn GPrecio;
        private System.Windows.Forms.Label LblUsuarioRegistra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}