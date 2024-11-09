using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capa_dato;

namespace sistema_contable01
{
    public partial class Frm_report_asiento_fecha : Form
    {
        public Frm_report_asiento_fecha()
        {
            InitializeComponent();
        }

        private void Frm_report_asiento_fecha_Load(object sender, EventArgs e)
        {
           
            // TODO: esta línea de código carga datos en la tabla 'Datos_Reportes.Imprimir_asiento' Puede moverla o quitarla según sea necesario.
            //this.Imprimir_asientoTableAdapter.Fill(this.Datos_Reportes.Imprimir_asiento);
            // TODO: esta línea de código carga datos en la tabla 'Datos_Reportes.Imprimir_asiento_fecha' Puede moverla o quitarla según sea necesario.
            //this.Imprimir_asiento_fechaTableAdapter.Fill(this.Datos_Reportes.Imprimir_asiento_fecha);

            //this.repot_asiento_fecha.RefreshReport();
            //this.reportViewer2.RefreshReport();
        }

        private void btn_mostrar_Click(object sender, EventArgs e)
        {
            DataSet ds;
            string cmd;
            cmd = string.Format("Exec Imprimir_asiento_fecha '{0}','{1}'", dtp_fecha1.Text.Trim(), dtp_fecha2.Text.Trim());
            ds = conexion.EjecutarComan(cmd);
            repot_asiento_fecha.LocalReport.DataSources[0].Value = ds.Tables[0];

            this.repot_asiento_fecha.RefreshReport();
        }
    }
}
