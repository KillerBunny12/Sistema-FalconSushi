using System;
using System.Data;
using System.Windows.Forms;

namespace FalconSushi.Formularios
{
    public partial class FrmBitacora : Form
    {
        DataTable DTListaBitacora;
        public bool VerUltimoMes;
        Logica.Bitacora MiBitacora;

        public FrmBitacora()
        {
            InitializeComponent();
            DTListaBitacora = new DataTable();
            MiBitacora = new Logica.Bitacora();
        }

        private void FrmBitacora_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'falconSushiDataSet12.SPListarBitacoraMes' table. You can move, or remove it, as needed.
            this.sPListarBitacoraMesTableAdapter.Fill(this.falconSushiDataSet12.SPListarBitacoraMes);
            MdiParent = Locale.ObjetosGlobales.MiFormPrincipal;


            LlenarLista(this.CbVerUltimoMes.Checked);

        }

        public void LlenarLista(bool VerUltimoMes)
        {


            DTListaBitacora.Clear();
            DTListaBitacora = MiBitacora.ListarBitacora(VerUltimoMes);
            DgvLista.DataSource = DTListaBitacora;
            DgvLista.ClearSelection();
        }

        private void CbVerUltimoMes_CheckedChanged(object sender, EventArgs e)
        {
            VerUltimoMes = CbVerUltimoMes.Checked;
            LlenarLista(CbVerUltimoMes.Checked);
        }
    }
}
