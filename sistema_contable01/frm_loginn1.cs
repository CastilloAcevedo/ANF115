using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_contable01
{
    public partial class frm_loginn1 : Form
    {
        public frm_loginn1()
        {
            InitializeComponent();
        }
        private void AbrirFormInPanel(object Formhijo)
        {
            if (this.home1.Controls.Count > 0)
                this.home1.Controls.RemoveAt(0);

            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.home1.Controls.Add(fh);
            this.home1.Tag = fh;
            fh.Show();

        }
       
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            label2.Text = "PLAN DE CUENTA";
            AbrirFormInPanel(new frmPlan_de_cuenta());
        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            label2.Text = "EMPRESA";
            AbrirFormInPanel(new frm_empresa());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (menu.Width == 140)
            {
                menu.Width = 10;
            }
            else
            {
                menu.Width = 140;
            }
        }

        private void minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void restaurar_Click(object sender, EventArgs e)
        {

        }

        private void maximizar_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            label2.Text = "ASIENTO CONTABLE";
            AbrirFormInPanel(new frm_asiento());
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            label2.Text = "USUARIOS";
            AbrirFormInPanel(new Frm_usuario());
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            label2.Text = "SUMAS Y SALDOS";
            AbrirFormInPanel(new Frm_sumas_saldos());
            
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            label2.Text = "LIBRO MAYOR";
            AbrirFormInPanel(new Frm_libro_mayor_fecha());
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            label2.Text = "LIBRO DIARIO ";
            AbrirFormInPanel(new Frm_report_asiento_fecha()); 
        }
    }
}
