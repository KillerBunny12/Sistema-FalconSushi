namespace FalconSushi.Formularios
{
    partial class FrmGestionAgregarIngrediente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGestionAgregarIngrediente));
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.falconSushiDataSet4 = new FalconSushi.FalconSushiDataSet4();
            this.sPIngredienteListarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sPIngredienteListarTableAdapter = new FalconSushi.FalconSushiDataSet4TableAdapters.SPIngredienteListarTableAdapter();
            this.DgvLista = new System.Windows.Forms.DataGridView();
            this.GCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sPIngredienteListarBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.falconSushiDataSet5 = new FalconSushi.FalconSushiDataSet5();
            this.sPIngredienteListarTableAdapter1 = new FalconSushi.FalconSushiDataSet5TableAdapters.SPIngredienteListarTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.LblUsuarioRegistra = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.falconSushiDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPIngredienteListarBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPIngredienteListarBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.falconSushiDataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.Color.LightCoral;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(238, 323);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(114, 44);
            this.BtnCancelar.TabIndex = 10;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.BackColor = System.Drawing.Color.PaleGreen;
            this.BtnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptar.Location = new System.Drawing.Point(23, 323);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(119, 44);
            this.BtnAceptar.TabIndex = 9;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = false;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBuscar.Location = new System.Drawing.Point(67, 75);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(244, 22);
            this.TxtBuscar.TabIndex = 7;
            this.TxtBuscar.TextChanged += new System.EventHandler(this.TxtBuscar_TextChanged);
            // 
            // falconSushiDataSet4
            // 
            this.falconSushiDataSet4.DataSetName = "FalconSushiDataSet4";
            this.falconSushiDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sPIngredienteListarBindingSource
            // 
            this.sPIngredienteListarBindingSource.DataMember = "SPIngredienteListar";
            this.sPIngredienteListarBindingSource.DataSource = this.falconSushiDataSet4;
            // 
            // sPIngredienteListarTableAdapter
            // 
            this.sPIngredienteListarTableAdapter.ClearBeforeFill = true;
            // 
            // DgvLista
            // 
            this.DgvLista.AllowUserToAddRows = false;
            this.DgvLista.AllowUserToDeleteRows = false;
            this.DgvLista.AutoGenerateColumns = false;
            this.DgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GCodigo,
            this.GNombre});
            this.DgvLista.DataSource = this.sPIngredienteListarBindingSource1;
            this.DgvLista.Location = new System.Drawing.Point(23, 103);
            this.DgvLista.Name = "DgvLista";
            this.DgvLista.ReadOnly = true;
            this.DgvLista.RowHeadersVisible = false;
            this.DgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvLista.Size = new System.Drawing.Size(329, 209);
            this.DgvLista.TabIndex = 30;
            // 
            // GCodigo
            // 
            this.GCodigo.DataPropertyName = "IngredienteID";
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
            // sPIngredienteListarBindingSource1
            // 
            this.sPIngredienteListarBindingSource1.DataMember = "SPIngredienteListar";
            this.sPIngredienteListarBindingSource1.DataSource = this.falconSushiDataSet5;
            // 
            // falconSushiDataSet5
            // 
            this.falconSushiDataSet5.DataSetName = "FalconSushiDataSet5";
            this.falconSushiDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sPIngredienteListarTableAdapter1
            // 
            this.sPIngredienteListarTableAdapter1.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(163, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Buscar";
            // 
            // LblUsuarioRegistra
            // 
            this.LblUsuarioRegistra.AutoSize = true;
            this.LblUsuarioRegistra.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUsuarioRegistra.Location = new System.Drawing.Point(11, 9);
            this.LblUsuarioRegistra.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblUsuarioRegistra.Name = "LblUsuarioRegistra";
            this.LblUsuarioRegistra.Size = new System.Drawing.Size(254, 26);
            this.LblUsuarioRegistra.TabIndex = 37;
            this.LblUsuarioRegistra.Text = "Seleccione ingrediente";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FalconSushi.Properties.Resources.FalconSushiLogo;
            this.pictureBox1.Location = new System.Drawing.Point(309, -5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 51;
            this.pictureBox1.TabStop = false;
            // 
            // FrmGestionAgregarIngrediente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 377);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblUsuarioRegistra);
            this.Controls.Add(this.DgvLista);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.TxtBuscar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmGestionAgregarIngrediente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema FalconSushi - Sushis";
            this.Load += new System.EventHandler(this.FrmGestionAgregarIngrediente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.falconSushiDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPIngredienteListarBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPIngredienteListarBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.falconSushiDataSet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.TextBox TxtBuscar;
        private FalconSushiDataSet4 falconSushiDataSet4;
        private System.Windows.Forms.BindingSource sPIngredienteListarBindingSource;
        private FalconSushiDataSet4TableAdapters.SPIngredienteListarTableAdapter sPIngredienteListarTableAdapter;
        private System.Windows.Forms.DataGridView DgvLista;
        private System.Windows.Forms.DataGridViewTextBoxColumn GCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn GNombre;
        private System.Windows.Forms.BindingSource sPIngredienteListarBindingSource1;
        private FalconSushiDataSet5 falconSushiDataSet5;
        private FalconSushiDataSet5TableAdapters.SPIngredienteListarTableAdapter sPIngredienteListarTableAdapter1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblUsuarioRegistra;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}