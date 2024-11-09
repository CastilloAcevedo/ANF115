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
    public partial class Frm_libro_mayor_fecha : Form
    {
        public Frm_libro_mayor_fecha()
        {
            InitializeComponent();
        }

        private void Frm_libro_mayor_fecha_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'Datos_Reportes.libro_mayor_fecha' Puede moverla o quitarla según sea necesario.
            //this.libro_mayor_fechaTableAdapter.Fill(this.Datos_Reportes.libro_mayor_fecha);

            //this.reportViewer1.RefreshReport();
        }

        private void btn_buscar_lb_mayor_Click(object sender, EventArgs e)
        {
            DataSet ds;
            string cmd;
            cmd = string.Format("Exec libro_mayor_fecha '{0}','{1}'", dtp_fecha1.Text.Trim(), dtp_fecha2.Text.Trim());
            ds = conexion.EjecutarComan(cmd);
            Rport_libro_may_fecha.LocalReport.DataSources[0].Value = ds.Tables[0];

            this.Rport_libro_may_fecha.RefreshReport();
        }
    }
}
