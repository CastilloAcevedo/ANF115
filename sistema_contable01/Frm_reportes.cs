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
using capa_negocio;

namespace sistema_contable01
{
    public partial class Frm_reportes : Form
    {
        public Frm_reportes()
        {
            InitializeComponent();
        }

        private void btn_libro_diario_Click(object sender, EventArgs e)
        {
            Frm_report_asiento_fecha fr = new Frm_report_asiento_fecha();
            fr.ShowDialog();
        }

        private void btn_libro_may_b_Click(object sender, EventArgs e)
        {
            Frm_libro_mayor_b fr = new Frm_libro_mayor_b();
            fr.ShowDialog();
        }

        private void bn_libro_may_f_Click(object sender, EventArgs e)
        {
            Frm_libro_mayor_fecha fr = new Frm_libro_mayor_fecha();
            fr.ShowDialog();
        }

        private void btn_suma_saldo_Click(object sender, EventArgs e)
        {
            Frm_sumas_saldos fr = new Frm_sumas_saldos();
            fr.ShowDialog();
        }
        private void Privilegi_user()
        {
            if (Program.CargoUser != "Administrador")
                {
                    //btnTrabajadora.Enabled = false;
                    //btn_usuario.Enabled = false;
                    btn_suma_saldo.Enabled = false;
                    /*
                    btCategoria.Visible = false;
                    button4.Visible = false;
                    button7.Visible = false;*/
                }
        }
        
    private void Frm_reportes_Load(object sender, EventArgs e)
        {

        }
    }
}
