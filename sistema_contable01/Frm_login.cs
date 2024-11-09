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
    public partial class Frm_login : Form
    {
        public Frm_login()
        {
            InitializeComponent();
        }
        public static string codigo = "";
        public static string cuenta = "";
        public static string contra = "";
        public static string TipoCargo = "";
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {

                string cmd = string.Format("select *from contador where nombre='" + txtUsuario.Text + "' and contrasena='" + txtContra.Text + "'");
                DataSet ds = conexion.EjecutarComan(cmd);

                codigo = ds.Tables[0].Rows[0]["id_contador"].ToString().Trim();
                cuenta = ds.Tables[0].Rows[0]["nombre"].ToString().Trim();
                contra = ds.Tables[0].Rows[0]["contrasena"].ToString().Trim();
                TipoCargo = ds.Tables[0].Rows[0]["tipo"].ToString().Trim();

                //txtMuestra.Text = cuenta + " " + apellidoUs;
                if (cuenta == txtUsuario.Text.Trim() && contra == txtContra.Text.Trim())
                {
                    if (Convert.ToString(ds.Tables[0].Rows[0]["tipo"]) == "Admin")
                    {
                        /*this.Hide();
                        frmPrincipal venad = new frmPrincipal();
                        Program.CodigoUser = codigo;
                        Program.CargoUser = TipoCargo;
                        Program.NombreLog = cuenta;
                        venad.Show();*/
                        this.Hide();
                        frm_loginn1 venad = new frm_loginn1();
                        Program.CodigoUser = codigo;
                        Program.CargoUser = TipoCargo;
                        Program.NombreLog = cuenta;
                        venad.Show();
                    }
                    else
                    {
                        /*this.Hide();
                        frmPrincipal venUs = new frmPrincipal();
                        Program.CodigoUser = codigo;
                        Program.CargoUser = TipoCargo;
                        Program.NombreLog = cuenta;
                        venUs.Show();*/
                        this.Hide();
                        frm_loginn1 venad = new frm_loginn1();
                        Program.CodigoUser = codigo;
                        Program.CargoUser = TipoCargo;
                        Program.NombreLog = cuenta;
                        venad.Show(); 
                    }
                    //MessageBox.Show("Se ha iniciado ");
                }

            }
            catch (Exception ex)
            { MessageBox.Show("USUARIO O CONTRASEÑA INCORRECTA ", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Usuario";
                txtUsuario.ForeColor = Color.DimGray;
                //txtContra.Focus();
            }
        }

        private void txtContra_Leave(object sender, EventArgs e)
        {
            if (txtContra.Text == "")
            {
                txtContra.Text = "Contraseña";
                txtContra.ForeColor = Color.DimGray;
                txtContra.UseSystemPasswordChar = false;
               // btnIniciar.Focus();
            }
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;
               // txtContra.Focus();
            }
        }

        private void txtContra_Enter(object sender, EventArgs e)
        {
            if (txtContra.Text == "Contraseña")
            {
                txtContra.Text = "";
                txtContra.ForeColor = Color.Black;
                txtContra.UseSystemPasswordChar = true;
                //btnIniciar.Focus();
            }
        }

        private void Frm_login_Load(object sender, EventArgs e)
        {

        }

        private void iconminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void iconcerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
