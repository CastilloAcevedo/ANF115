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
    public partial class Frm_libro_mayor_b : Form
    {
        FrmzBuscar_plan buscar_plan;
        public Frm_libro_mayor_b()
        {
            InitializeComponent();
        }
        
        private void Frm_libro_mayor_b_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'Datos_Reportes.libro_mayor_b' Puede moverla o quitarla según sea necesario.
            //this.libro_mayor_bTableAdapter.Fill(this.Datos_Reportes.libro_mayor_b);
            //this.reportViewer1.RefreshReport();
        }

        private void btn_buscar_plan_Click(object sender, EventArgs e)
        {//CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(DgvCategoriaBusq_CellMouseDoubleClick);
            buscar_plan = new FrmzBuscar_plan();
            buscar_plan.dgvplan.CellMouseDoubleClick += Dgvplan_CellMouseDoubleClick;
            buscar_plan.ShowDialog();
        }

        private void Dgvplan_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            txt_buscar_plan.Text = dgv[1, e.RowIndex].Value.ToString().Trim();
            //txtNombCatrg.Text = dgv[1, e.RowIndex].Value.ToString().Trim();
            buscar_plan.Close();
        }

        private void Dgvplan_CellMouseDoubleClick1(object sender, DataGridViewCellMouseEventArgs e)
        {
          
        }

        private void btn_buscar_lb_mayor_Click(object sender, EventArgs e)
        {
            DataSet ds;
            string cmd;
            cmd = string.Format("Exec libro_mayor_b '{0}','{1}','{2}'", txt_buscar_plan.Text, dtp_fecha1.Text.Trim(), dtp_fecha2.Text.Trim());
            ds = conexion.EjecutarComan(cmd);
            rport_libro_may_b.LocalReport.DataSources[0].Value = ds.Tables[0];

            this.rport_libro_may_b.RefreshReport();
        }
    }
}
