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
          //Al cargar el form
          //Se llena la lita por defecto mostrando solo el ultimo mes
            this.sPListarBitacoraMesTableAdapter.Fill(this.falconSushiDataSet12.SPListarBitacoraMes);
            MdiParent = Locale.ObjetosGlobales.MiFormPrincipal;


            LlenarLista(this.CbVerUltimoMes.Checked);

        }

        public void LlenarLista(bool VerUltimoMes)
        {
            //Se llena la lista
            //Y se le asignan a los datagrid

            DTListaBitacora.Clear();
            DTListaBitacora = MiBitacora.ListarBitacora(VerUltimoMes);
            DgvLista.DataSource = DTListaBitacora;
            DgvLista.ClearSelection();
        }

        private void CbVerUltimoMes_CheckedChanged(object sender, EventArgs e)
        {
            //En caso de darle click al checkbox, se cambia el tipo de visualizacion
            //de la bitacora
            VerUltimoMes = CbVerUltimoMes.Checked;
            LlenarLista(CbVerUltimoMes.Checked);
        }
    }
}
