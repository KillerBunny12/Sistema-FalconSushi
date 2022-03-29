namespace FalconSushi.Formularios
{
    partial class FrmPedidos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPedidos));
            this.DgvLista = new System.Windows.Forms.DataGridView();
            this.GCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GNumeroFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvDetalles = new System.Windows.Forms.DataGridView();
            this.GCodigoD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.CbVerActivos = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDetalles)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvLista
            // 
            this.DgvLista.AllowUserToAddRows = false;
            this.DgvLista.AllowUserToDeleteRows = false;
            this.DgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GCodigo,
            this.GNumeroFactura,
            this.GCliente,
            this.GFecha,
            this.GTotal,
            this.GUsuario});
            this.DgvLista.Location = new System.Drawing.Point(12, 82);
            this.DgvLista.Name = "DgvLista";
            this.DgvLista.ReadOnly = true;
            this.DgvLista.RowHeadersVisible = false;
            this.DgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvLista.Size = new System.Drawing.Size(483, 404);
            this.DgvLista.TabIndex = 30;
            this.DgvLista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvLista_CellClick);
            // 
            // GCodigo
            // 
            this.GCodigo.DataPropertyName = "PedidoID";
            this.GCodigo.HeaderText = "ID";
            this.GCodigo.Name = "GCodigo";
            this.GCodigo.ReadOnly = true;
            this.GCodigo.Width = 30;
            // 
            // GNumeroFactura
            // 
            this.GNumeroFactura.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GNumeroFactura.DataPropertyName = "NumeroFactura";
            this.GNumeroFactura.HeaderText = "#Factura";
            this.GNumeroFactura.Name = "GNumeroFactura";
            this.GNumeroFactura.ReadOnly = true;
            // 
            // GCliente
            // 
            this.GCliente.DataPropertyName = "NombreCliente";
            this.GCliente.HeaderText = "Cliente";
            this.GCliente.Name = "GCliente";
            this.GCliente.ReadOnly = true;
            this.GCliente.Width = 70;
            // 
            // GFecha
            // 
            this.GFecha.DataPropertyName = "Fecha";
            this.GFecha.HeaderText = "Fecha";
            this.GFecha.Name = "GFecha";
            this.GFecha.ReadOnly = true;
            // 
            // GTotal
            // 
            this.GTotal.DataPropertyName = "Total";
            this.GTotal.HeaderText = "Total";
            this.GTotal.Name = "GTotal";
            this.GTotal.ReadOnly = true;
            this.GTotal.Width = 60;
            // 
            // GUsuario
            // 
            this.GUsuario.DataPropertyName = "NombreUsuario";
            this.GUsuario.HeaderText = "Usuario";
            this.GUsuario.Name = "GUsuario";
            this.GUsuario.ReadOnly = true;
            this.GUsuario.Width = 70;
            // 
            // DgvDetalles
            // 
            this.DgvDetalles.AllowUserToAddRows = false;
            this.DgvDetalles.AllowUserToDeleteRows = false;
            this.DgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDetalles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GCodigoD,
            this.GNombre,
            this.GCantidad,
            this.GPrecio,
            this.GSubtotal});
            this.DgvDetalles.Location = new System.Drawing.Point(512, 82);
            this.DgvDetalles.Name = "DgvDetalles";
            this.DgvDetalles.ReadOnly = true;
            this.DgvDetalles.RowHeadersVisible = false;
            this.DgvDetalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvDetalles.Size = new System.Drawing.Size(483, 404);
            this.DgvDetalles.TabIndex = 31;
            // 
            // GCodigoD
            // 
            this.GCodigoD.DataPropertyName = "PedidoDetalleID";
            this.GCodigoD.HeaderText = "ID";
            this.GCodigoD.Name = "GCodigoD";
            this.GCodigoD.ReadOnly = true;
            this.GCodigoD.Width = 30;
            // 
            // GNombre
            // 
            this.GNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GNombre.DataPropertyName = "NombreProducto";
            this.GNombre.HeaderText = "Producto";
            this.GNombre.Name = "GNombre";
            this.GNombre.ReadOnly = true;
            // 
            // GCantidad
            // 
            this.GCantidad.DataPropertyName = "Cantidad";
            this.GCantidad.HeaderText = "Cantidad";
            this.GCantidad.Name = "GCantidad";
            this.GCantidad.ReadOnly = true;
            this.GCantidad.Width = 50;
            // 
            // GPrecio
            // 
            this.GPrecio.DataPropertyName = "Precio";
            this.GPrecio.HeaderText = "Precio";
            this.GPrecio.Name = "GPrecio";
            this.GPrecio.ReadOnly = true;
            this.GPrecio.Width = 70;
            // 
            // GSubtotal
            // 
            this.GSubtotal.DataPropertyName = "Subtotal";
            this.GSubtotal.HeaderText = "Sutotal";
            this.GSubtotal.Name = "GSubtotal";
            this.GSubtotal.ReadOnly = true;
            this.GSubtotal.Width = 70;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.Color.MediumOrchid;
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(390, 506);
            this.BtnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(105, 38);
            this.BtnCancelar.TabIndex = 46;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.BackColor = System.Drawing.Color.LightCoral;
            this.BtnEliminar.Enabled = false;
            this.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminar.Location = new System.Drawing.Point(11, 506);
            this.BtnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(105, 38);
            this.BtnEliminar.TabIndex = 45;
            this.BtnEliminar.Text = "Desactivar";
            this.BtnEliminar.UseVisualStyleBackColor = false;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Location = new System.Drawing.Point(11, 56);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(418, 20);
            this.TxtBuscar.TabIndex = 48;
            this.TxtBuscar.TextChanged += new System.EventHandler(this.TxtBuscar_TextChanged);
            // 
            // CbVerActivos
            // 
            this.CbVerActivos.AutoSize = true;
            this.CbVerActivos.Checked = true;
            this.CbVerActivos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbVerActivos.Location = new System.Drawing.Point(435, 56);
            this.CbVerActivos.Name = "CbVerActivos";
            this.CbVerActivos.Size = new System.Drawing.Size(79, 17);
            this.CbVerActivos.TabIndex = 47;
            this.CbVerActivos.Text = "Ver activos";
            this.CbVerActivos.UseVisualStyleBackColor = true;
            this.CbVerActivos.CheckedChanged += new System.EventHandler(this.CbVerActivos_CheckedChanged);
            // 
            // FrmPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 581);
            this.Controls.Add(this.TxtBuscar);
            this.Controls.Add(this.CbVerActivos);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.DgvDetalles);
            this.Controls.Add(this.DgvLista);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPedidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema Falcon Sushi - Pedidos";
            this.Load += new System.EventHandler(this.FrmPedidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDetalles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvLista;
        private System.Windows.Forms.DataGridViewTextBoxColumn GCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn GNumeroFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn GCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn GFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn GTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn GUsuario;
        private System.Windows.Forms.DataGridView DgvDetalles;
        private System.Windows.Forms.DataGridViewTextBoxColumn GCodigoD;
        private System.Windows.Forms.DataGridViewTextBoxColumn GNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn GCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn GPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn GSubtotal;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.CheckBox CbVerActivos;
    }
}