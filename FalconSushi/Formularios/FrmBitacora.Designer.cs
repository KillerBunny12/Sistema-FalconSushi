namespace FalconSushi.Formularios
{
    partial class FrmBitacora
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBitacora));
            this.DgvLista = new System.Windows.Forms.DataGridView();
            this.GCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GDetalles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sPListarBitacoraMesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.falconSushiDataSet12 = new FalconSushi.FalconSushiDataSet12();
            this.CbVerUltimoMes = new System.Windows.Forms.CheckBox();
            this.sPListarBitacoraMesTableAdapter = new FalconSushi.FalconSushiDataSet12TableAdapters.SPListarBitacoraMesTableAdapter();
            this.LblUsuarioRegistra = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPListarBitacoraMesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.falconSushiDataSet12)).BeginInit();
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
            this.GDetalles,
            this.GFecha});
            this.DgvLista.DataSource = this.sPListarBitacoraMesBindingSource;
            this.DgvLista.Location = new System.Drawing.Point(12, 90);
            this.DgvLista.Name = "DgvLista";
            this.DgvLista.ReadOnly = true;
            this.DgvLista.RowHeadersVisible = false;
            this.DgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvLista.Size = new System.Drawing.Size(589, 458);
            this.DgvLista.TabIndex = 30;
            // 
            // GCodigo
            // 
            this.GCodigo.DataPropertyName = "BitacoraID";
            this.GCodigo.HeaderText = "ID";
            this.GCodigo.Name = "GCodigo";
            this.GCodigo.ReadOnly = true;
            this.GCodigo.Width = 30;
            // 
            // GDetalles
            // 
            this.GDetalles.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GDetalles.DataPropertyName = "Detalles";
            this.GDetalles.HeaderText = "Detalles";
            this.GDetalles.Name = "GDetalles";
            this.GDetalles.ReadOnly = true;
            // 
            // GFecha
            // 
            this.GFecha.DataPropertyName = "Fecha";
            this.GFecha.HeaderText = "Fecha";
            this.GFecha.Name = "GFecha";
            this.GFecha.ReadOnly = true;
            // 
            // sPListarBitacoraMesBindingSource
            // 
            this.sPListarBitacoraMesBindingSource.DataMember = "SPListarBitacoraMes";
            this.sPListarBitacoraMesBindingSource.DataSource = this.falconSushiDataSet12;
            // 
            // falconSushiDataSet12
            // 
            this.falconSushiDataSet12.DataSetName = "FalconSushiDataSet12";
            this.falconSushiDataSet12.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // CbVerUltimoMes
            // 
            this.CbVerUltimoMes.AutoSize = true;
            this.CbVerUltimoMes.Checked = true;
            this.CbVerUltimoMes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbVerUltimoMes.Location = new System.Drawing.Point(466, 67);
            this.CbVerUltimoMes.Name = "CbVerUltimoMes";
            this.CbVerUltimoMes.Size = new System.Drawing.Size(135, 17);
            this.CbVerUltimoMes.TabIndex = 31;
            this.CbVerUltimoMes.Text = "Mostrar solo ultimo mes";
            this.CbVerUltimoMes.UseVisualStyleBackColor = true;
            this.CbVerUltimoMes.CheckedChanged += new System.EventHandler(this.CbVerUltimoMes_CheckedChanged);
            // 
            // sPListarBitacoraMesTableAdapter
            // 
            this.sPListarBitacoraMesTableAdapter.ClearBeforeFill = true;
            // 
            // LblUsuarioRegistra
            // 
            this.LblUsuarioRegistra.AutoSize = true;
            this.LblUsuarioRegistra.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUsuarioRegistra.Location = new System.Drawing.Point(11, 42);
            this.LblUsuarioRegistra.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblUsuarioRegistra.Name = "LblUsuarioRegistra";
            this.LblUsuarioRegistra.Size = new System.Drawing.Size(100, 26);
            this.LblUsuarioRegistra.TabIndex = 32;
            this.LblUsuarioRegistra.Text = "Bitacora";
            // 
            // FrmBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 558);
            this.Controls.Add(this.LblUsuarioRegistra);
            this.Controls.Add(this.CbVerUltimoMes);
            this.Controls.Add(this.DgvLista);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBitacora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBitacora";
            this.Load += new System.EventHandler(this.FrmBitacora_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPListarBitacoraMesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.falconSushiDataSet12)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvLista;
        private System.Windows.Forms.CheckBox CbVerUltimoMes;
        private FalconSushiDataSet12 falconSushiDataSet12;
        private System.Windows.Forms.BindingSource sPListarBitacoraMesBindingSource;
        private FalconSushiDataSet12TableAdapters.SPListarBitacoraMesTableAdapter sPListarBitacoraMesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn GCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn GDetalles;
        private System.Windows.Forms.DataGridViewTextBoxColumn GFecha;
        private System.Windows.Forms.Label LblUsuarioRegistra;
    }
}