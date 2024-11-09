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
    public partial class Frm_sumas_saldos : Form
    {
        public Frm_sumas_saldos()
        {
            InitializeComponent();
        }

        private void Frm_sumas_saldos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'Datos_Reportes.Suma_saldo' Puede moverla o quitarla según sea necesario.
            //this.Suma_saldoTableAdapter.Fill(this.Datos_Reportes.Suma_saldo);

            //this.Rp_suma_saldo.RefreshReport();
        }

        private void btn_mostrar_Click(object sender, EventArgs e)
        {
            DataSet ds;
            string cmd;
            cmd = string.Format("Exec Suma_saldo '{0}','{1}'", dtp_fecha1.Text.Trim(), dtp_fecha2.Text.Trim());
            ds = conexion.EjecutarComan(cmd);
            Rp_suma_saldo.LocalReport.DataSources[0].Value = ds.Tables[0];

            this.Rp_suma_saldo.RefreshReport();
        }
    }
}
