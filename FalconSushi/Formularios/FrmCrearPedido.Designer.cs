namespace FalconSushi.Formularios
{
    partial class FrmCrearPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCrearPedido));
            this.TxtTotalCompra = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnCrearCompra = new System.Windows.Forms.Button();
            this.DgvListaSushi = new System.Windows.Forms.DataGridView();
            this.GCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblUsuarioRegistra = new System.Windows.Forms.Label();
            this.TxtNumeroFactura = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DtpFecha = new System.Windows.Forms.DateTimePicker();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtnAgregarSushi = new System.Windows.Forms.ToolStripButton();
            this.BtnEliminarSushi = new System.Windows.Forms.ToolStripButton();
            this.DgvListaPromocion = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.BtnAgregarPromocion = new System.Windows.Forms.ToolStripButton();
            this.BtnEliminarPromocion = new System.Windows.Forms.ToolStripButton();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.CBCliente = new System.Windows.Forms.CheckBox();
            this.TxtCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListaSushi)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListaPromocion)).BeginInit();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtTotalCompra
            // 
            this.TxtTotalCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotalCompra.Location = new System.Drawing.Point(267, 437);
            this.TxtTotalCompra.Name = "TxtTotalCompra";
            this.TxtTotalCompra.ReadOnly = true;
            this.TxtTotalCompra.Size = new System.Drawing.Size(183, 26);
            this.TxtTotalCompra.TabIndex = 30;
            this.TxtTotalCompra.Text = "0";
            this.TxtTotalCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(53, 435);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 26);
            this.label3.TabIndex = 29;
            this.label3.Text = "Total de la compra";
            // 
            // BtnCrearCompra
            // 
            this.BtnCrearCompra.BackColor = System.Drawing.Color.PaleGreen;
            this.BtnCrearCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCrearCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCrearCompra.Location = new System.Drawing.Point(759, 423);
            this.BtnCrearCompra.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCrearCompra.Name = "BtnCrearCompra";
            this.BtnCrearCompra.Size = new System.Drawing.Size(121, 55);
            this.BtnCrearCompra.TabIndex = 28;
            this.BtnCrearCompra.Text = "Crear Compra";
            this.BtnCrearCompra.UseVisualStyleBackColor = false;
            this.BtnCrearCompra.Click += new System.EventHandler(this.BtnCrearCompra_Click);
            // 
            // DgvListaSushi
            // 
            this.DgvListaSushi.AllowUserToAddRows = false;
            this.DgvListaSushi.AllowUserToDeleteRows = false;
            this.DgvListaSushi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvListaSushi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GCodigo,
            this.GNombre,
            this.GCantidad,
            this.GPrecio});
            this.DgvListaSushi.Location = new System.Drawing.Point(58, 199);
            this.DgvListaSushi.Margin = new System.Windows.Forms.Padding(2);
            this.DgvListaSushi.Name = "DgvListaSushi";
            this.DgvListaSushi.ReadOnly = true;
            this.DgvListaSushi.RowHeadersVisible = false;
            this.DgvListaSushi.RowHeadersWidth = 51;
            this.DgvListaSushi.RowTemplate.Height = 24;
            this.DgvListaSushi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvListaSushi.Size = new System.Drawing.Size(409, 187);
            this.DgvListaSushi.TabIndex = 21;
            this.DgvListaSushi.VirtualMode = true;
            // 
            // GCodigo
            // 
            this.GCodigo.DataPropertyName = "SushiID";
            this.GCodigo.HeaderText = "ID";
            this.GCodigo.MinimumWidth = 6;
            this.GCodigo.Name = "GCodigo";
            this.GCodigo.ReadOnly = true;
            this.GCodigo.Width = 50;
            // 
            // GNombre
            // 
            this.GNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GNombre.DataPropertyName = "Nombre";
            this.GNombre.HeaderText = "Nombre";
            this.GNombre.MinimumWidth = 6;
            this.GNombre.Name = "GNombre";
            this.GNombre.ReadOnly = true;
            // 
            // GCantidad
            // 
            this.GCantidad.DataPropertyName = "Cantidad";
            this.GCantidad.HeaderText = "Cantidad";
            this.GCantidad.MinimumWidth = 6;
            this.GCantidad.Name = "GCantidad";
            this.GCantidad.ReadOnly = true;
            this.GCantidad.Width = 70;
            // 
            // GPrecio
            // 
            this.GPrecio.DataPropertyName = "Precio";
            this.GPrecio.HeaderText = "Precio";
            this.GPrecio.MinimumWidth = 6;
            this.GPrecio.Name = "GPrecio";
            this.GPrecio.ReadOnly = true;
            // 
            // LblUsuarioRegistra
            // 
            this.LblUsuarioRegistra.AutoSize = true;
            this.LblUsuarioRegistra.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUsuarioRegistra.Location = new System.Drawing.Point(398, 51);
            this.LblUsuarioRegistra.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblUsuarioRegistra.Name = "LblUsuarioRegistra";
            this.LblUsuarioRegistra.Size = new System.Drawing.Size(330, 26);
            this.LblUsuarioRegistra.TabIndex = 27;
            this.LblUsuarioRegistra.Text = "Compra registrada por: USER";
            // 
            // TxtNumeroFactura
            // 
            this.TxtNumeroFactura.Location = new System.Drawing.Point(26, 57);
            this.TxtNumeroFactura.Margin = new System.Windows.Forms.Padding(2);
            this.TxtNumeroFactura.Name = "TxtNumeroFactura";
            this.TxtNumeroFactura.Size = new System.Drawing.Size(154, 20);
            this.TxtNumeroFactura.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 42);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Numero de factura";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(189, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Fecha";
            // 
            // DtpFecha
            // 
            this.DtpFecha.Location = new System.Drawing.Point(192, 57);
            this.DtpFecha.Margin = new System.Windows.Forms.Padding(2);
            this.DtpFecha.Name = "DtpFecha";
            this.DtpFecha.Size = new System.Drawing.Size(198, 20);
            this.DtpFecha.TabIndex = 23;
            this.DtpFecha.ValueChanged += new System.EventHandler(this.DtpFecha_ValueChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnAgregarSushi,
            this.BtnEliminarSushi});
            this.toolStrip1.Location = new System.Drawing.Point(58, 170);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(221, 27);
            this.toolStrip1.TabIndex = 22;
            // 
            // BtnAgregarSushi
            // 
            this.BtnAgregarSushi.BackColor = System.Drawing.Color.PaleGreen;
            this.BtnAgregarSushi.Image = ((System.Drawing.Image)(resources.GetObject("BtnAgregarSushi.Image")));
            this.BtnAgregarSushi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnAgregarSushi.Name = "BtnAgregarSushi";
            this.BtnAgregarSushi.Size = new System.Drawing.Size(104, 24);
            this.BtnAgregarSushi.Text = "Agregar Sushi";
            this.BtnAgregarSushi.Click += new System.EventHandler(this.BtnAgregarSushi_Click);
            // 
            // BtnEliminarSushi
            // 
            this.BtnEliminarSushi.BackColor = System.Drawing.Color.LightCoral;
            this.BtnEliminarSushi.Image = ((System.Drawing.Image)(resources.GetObject("BtnEliminarSushi.Image")));
            this.BtnEliminarSushi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnEliminarSushi.Name = "BtnEliminarSushi";
            this.BtnEliminarSushi.Size = new System.Drawing.Size(105, 24);
            this.BtnEliminarSushi.Text = "Eliminar Sushi";
            this.BtnEliminarSushi.Click += new System.EventHandler(this.BtnEliminarSushi_Click);
            // 
            // DgvListaPromocion
            // 
            this.DgvListaPromocion.AllowUserToAddRows = false;
            this.DgvListaPromocion.AllowUserToDeleteRows = false;
            this.DgvListaPromocion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvListaPromocion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.DgvListaPromocion.Location = new System.Drawing.Point(507, 199);
            this.DgvListaPromocion.Margin = new System.Windows.Forms.Padding(2);
            this.DgvListaPromocion.Name = "DgvListaPromocion";
            this.DgvListaPromocion.ReadOnly = true;
            this.DgvListaPromocion.RowHeadersVisible = false;
            this.DgvListaPromocion.RowHeadersWidth = 51;
            this.DgvListaPromocion.RowTemplate.Height = 24;
            this.DgvListaPromocion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvListaPromocion.Size = new System.Drawing.Size(409, 187);
            this.DgvListaPromocion.TabIndex = 31;
            this.DgvListaPromocion.VirtualMode = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PromocionID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Nombre";
            this.dataGridViewTextBoxColumn2.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Cantidad";
            this.dataGridViewTextBoxColumn3.HeaderText = "Cantidad";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 70;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Precio";
            this.dataGridViewTextBoxColumn4.HeaderText = "Precio";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnAgregarPromocion,
            this.BtnEliminarPromocion});
            this.toolStrip2.Location = new System.Drawing.Point(507, 170);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(283, 27);
            this.toolStrip2.TabIndex = 32;
            // 
            // BtnAgregarPromocion
            // 
            this.BtnAgregarPromocion.BackColor = System.Drawing.Color.PaleGreen;
            this.BtnAgregarPromocion.Image = ((System.Drawing.Image)(resources.GetObject("BtnAgregarPromocion.Image")));
            this.BtnAgregarPromocion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnAgregarPromocion.Name = "BtnAgregarPromocion";
            this.BtnAgregarPromocion.Size = new System.Drawing.Size(135, 24);
            this.BtnAgregarPromocion.Text = "Agregar Promocion";
            this.BtnAgregarPromocion.Click += new System.EventHandler(this.BtnAgregarPromocion_Click);
            // 
            // BtnEliminarPromocion
            // 
            this.BtnEliminarPromocion.BackColor = System.Drawing.Color.LightCoral;
            this.BtnEliminarPromocion.Image = ((System.Drawing.Image)(resources.GetObject("BtnEliminarPromocion.Image")));
            this.BtnEliminarPromocion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnEliminarPromocion.Name = "BtnEliminarPromocion";
            this.BtnEliminarPromocion.Size = new System.Drawing.Size(136, 24);
            this.BtnEliminarPromocion.Text = "Eliminar Promocion";
            this.BtnEliminarPromocion.Click += new System.EventHandler(this.BtnEliminarPromocion_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.Color.LightCoral;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(620, 423);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(123, 55);
            this.BtnCancelar.TabIndex = 44;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // CBCliente
            // 
            this.CBCliente.AutoSize = true;
            this.CBCliente.Location = new System.Drawing.Point(26, 82);
            this.CBCliente.Name = "CBCliente";
            this.CBCliente.Size = new System.Drawing.Size(103, 17);
            this.CBCliente.TabIndex = 45;
            this.CBCliente.Text = "Datos de cliente";
            this.CBCliente.UseVisualStyleBackColor = true;
            this.CBCliente.CheckedChanged += new System.EventHandler(this.CBCliente_CheckedChanged);
            // 
            // TxtCliente
            // 
            this.TxtCliente.Location = new System.Drawing.Point(26, 106);
            this.TxtCliente.Name = "TxtCliente";
            this.TxtCliente.ReadOnly = true;
            this.TxtCliente.Size = new System.Drawing.Size(154, 20);
            this.TxtCliente.TabIndex = 46;
            this.TxtCliente.Text = "Anonimo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 26);
            this.label1.TabIndex = 47;
            this.label1.Text = "Crear nuevo pedido";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FalconSushi.Properties.Resources.FalconSushiLogo;
            this.pictureBox1.Location = new System.Drawing.Point(885, 391);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(94, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 77;
            this.pictureBox1.TabStop = false;
            // 
            // FrmCrearPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 482);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtCliente);
            this.Controls.Add(this.CBCliente);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.DgvListaPromocion);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.TxtTotalCompra);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnCrearCompra);
            this.Controls.Add(this.DgvListaSushi);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.LblUsuarioRegistra);
            this.Controls.Add(this.TxtNumeroFactura);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DtpFecha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCrearPedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema FalconSushi - Pedidos";
            this.Load += new System.EventHandler(this.FrmCrearPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvListaSushi)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListaPromocion)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtTotalCompra;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnCrearCompra;
        private System.Windows.Forms.DataGridView DgvListaSushi;
        private System.Windows.Forms.Label LblUsuarioRegistra;
        private System.Windows.Forms.TextBox TxtNumeroFactura;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DtpFecha;
        private System.Windows.Forms.ToolStripButton BtnAgregarSushi;
        private System.Windows.Forms.ToolStripButton BtnEliminarSushi;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridView DgvListaPromocion;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton BtnAgregarPromocion;
        private System.Windows.Forms.ToolStripButton BtnEliminarPromocion;
        private System.Windows.Forms.DataGridViewTextBoxColumn GCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn GNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn GCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn GPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.CheckBox CBCliente;
        private System.Windows.Forms.TextBox TxtCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}