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
using capa_dato;
using System.Data.SqlClient;
using System.Globalization;

namespace sistema_contable01
{
    public partial class Frm_usuario : Form
    {
        public Frm_usuario()
        {
            InitializeComponent();
        }
        clsUsuario user = new clsUsuario();
        private void mostrarUser()
        {
           // dgvUsuario.DataSource = user.mostrar_usuario();
            //mostrar ususario

        }
        private void limpiar_textbox()
        {
            txtCodigoUs.Clear();
            txtBuscarUs.Clear();
            txtContrasenaUs.Clear();
            txtNombreUs.Clear();

            txtBuscarUs.Enabled=false;
            txtContrasenaUs.Enabled = false;
            txtNombreUs.Enabled = false;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Clear();

        }
        private void btnNuevoUs_Click(object sender, EventArgs e)
        {
            limpiar_textbox();
            btnGuardarUs.Enabled = true;
            btnModificarUs.Enabled = true;
            btnEliminarUs.Enabled = true;

            txtCargoUs.Enabled = true;
            txtBuscarUs.Enabled = true;
            txtContrasenaUs.Enabled = true;
            txtNombreUs.Enabled = true;
        }
        private string Mayuscula(string palabra)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(palabra);
        }
        private void btnGuardarUs_Click(object sender, EventArgs e)
        {
            if (txtNombreUs.Text != "" && txtCargoUs.Text != "" && txtContrasenaUs.Text != "")
            {
                    try
                    {
                        string nob;
                        nob = Mayuscula(txtNombreUs.Text);
                        user.Nombre = nob;// txtNombreUs.Text;
                        user.Clave = txtContrasenaUs.Text;
                        user.Cargo = txtCargoUs.Text;
                        user.guardar_usuario();
                    MessageBox.Show("Guardado correctamente", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    dgvUsuario.DataSource = Llenar_lista_libro("contador").Tables[0];
                }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al guardar : " + ex.Message);
                    }        
            }
            else { MessageBox.Show("Falta rellenar datos al formulario ", "INFORMACION"); }
        }

        private void btnModificarUs_Click(object sender, EventArgs e)
        {
            if (txtCodigoUs.Text != "" && txtCargoUs.Text != "" && txtContrasenaUs.Text != "")
            {
                try
                {
                    user.Id_usuario = txtCodigoUs.Text;
                    user.Nombre = Mayuscula(txtNombreUs.Text);//txtNombreUs.Text;
                    user.Clave = txtContrasenaUs.Text;
                    user.Cargo = Mayuscula(txtCargoUs.Text);
                    user.modificar_usuario();
                    MessageBox.Show("Modificado correctamente", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    dgvUsuario.DataSource = Llenar_lista_libro("contador").Tables[0];
                }
                catch (Exception ex)
                { MessageBox.Show("Error al modificar : " + ex.Message);}
            }
            else { MessageBox.Show("Falta rellenar datos al formulario ", "INFORMACION"); }

        }
        private void btnEliminarUs_Click(object sender, EventArgs e)
        {
            user.Id_usuario = txtCodigoUs.Text;

            DialogResult pregunta = MessageBox.Show("¿Esta seguro de eliminar ?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (pregunta == DialogResult.Yes)
            {
                user.eliminar_usuario();
                MessageBox.Show("Eliminado correctamente", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                dgvUsuario.DataSource = Llenar_lista_libro("contador").Tables[0];       
            }
        }

        private void dgvUsuario_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtCodigoUs.Text = dgvUsuario[0, e.RowIndex].Value.ToString().Trim();
            txtNombreUs.Text = dgvUsuario[1, e.RowIndex].Value.ToString().Trim();
            txtContrasenaUs.Text = dgvUsuario[2, e.RowIndex].Value.ToString().Trim();
            txtCargoUs.Text = dgvUsuario[3, e.RowIndex].Value.ToString().Trim();
        }
        public DataSet Llenar_lista_libro(string tabla)
        {
            DataSet ds;//select top 15 *from libro order by id_libro desc
            string cmd = string.Format("select top 15 *from " + tabla + " order by id_contador desc ");
            ds = conexion.EjecutarComan(cmd);
            return ds;
        }
        private void Frm_usuario_Load(object sender, EventArgs e)
        {
            dgvUsuario.DataSource = Llenar_lista_libro("contador").Tables[0];
        }
    }
}
