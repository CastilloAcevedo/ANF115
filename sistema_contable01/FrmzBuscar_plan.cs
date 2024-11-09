using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capa_negocio;

namespace sistema_contable01
{
    public partial class FrmzBuscar_plan : Form
    {
        public FrmzBuscar_plan()
        {
            InitializeComponent();
        }

        private void txtbuscar1_TextChanged(object sender, EventArgs e)
        {
            plan_cuenta cl = new plan_cuenta();
            dgvplan.DataMember = "tCuenta";
            cl.Descripcion = txtbuscar1.Text;
            dgvplan.DataSource = cl.buscar1();
            dgvplan.AutoResizeColumns();
            dgvplan.AutoResizeRows();
        }

        private void FrmzBuscar_plan_Load(object sender, EventArgs e)
        {
            dgvplan.Visible = true;
            pictureBox1.Visible = true;
            txtbuscar1.Visible = true;
            plan_cuenta cl = new plan_cuenta();
            dgvplan.DataMember = "tCuenta";

            dgvplan.DataSource = cl.buscar();
            dgvplan.AutoResizeColumns();
            dgvplan.AutoResizeRows();
            //dgv_asiento.AllowUserToAddRows = true;
        }
    }
}
