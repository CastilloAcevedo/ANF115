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
using System.Data.SqlClient;
using System.Globalization;
namespace sistema_contable01
{
    public partial class frm_empresa : Form
    {
        public frm_empresa()
        {
            InitializeComponent();
            imprimir_empresa();
        }
        public void imprimir_empresa()
        {
            clsempresa cl = new clsempresa();
            dgbempresa.DataMember = "tEmpresa";
            dgbempresa.DataSource = cl.imprimir();
            dgbempresa.AutoResizeColumns();
            dgbempresa.AutoResizeRows();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frm_empresa_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevoUs_Click(object sender, EventArgs e)
        {
            btnGuardarUs.Enabled = true;
            btnModificarUs.Enabled = true;
            btnEliminarUs.Enabled = true;
            btnimprimir.Enabled = true;

            txtid_empresa.Enabled = true;
            txtBuscarUs.Enabled = true;
            txtpropietario.Enabled = true;
            txtNombre.Enabled = true;
            txtnit.Enabled = true;
            txtciudad.Enabled = true;
            txttelefono.Enabled = true;
            conbestado.Enabled = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnimprimir_Click(object sender, EventArgs e)
        {
            clsempresa cl= new clsempresa();
            dgbempresa.DataMember = "tEmpresa";
            dgbempresa.DataSource = cl.imprimir();
            dgbempresa.AutoResizeColumns();
            dgbempresa.AutoResizeRows();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_gestion gs = new frm_gestion();
            gs.Show();// = true;
        }

        private void btnGuardarUs_Click(object sender, EventArgs e)
        {
           clsempresa  em = new clsempresa();
            try
            {

                em.Nombre = txtNombre.Text;
                em.Nit = txtnit.Text;
                em.Ciudad = txtciudad.Text;
                em.Propietario = txtpropietario.Text;
                em.Telefono=int.Parse(txttelefono.Text);
                em.Estado = conbestado.Text;
                em.Id_contador= int.Parse(Program.CodigoUser);
                em.guardar_empresa();

                MessageBox.Show("Guardado correctamente", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
              //  imprimir_empresa();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar : " + ex.Message);
            }
        }

        private void btnModificarUs_Click(object sender, EventArgs e)
        {
            clsempresa em = new clsempresa();
            try
            {
                em.Id_empresa= int.Parse(txtid_empresa.Text);
                em.Nombre = txtNombre.Text;
                em.Nit = txtnit.Text;
                em.Ciudad = txtciudad.Text;
                em.Propietario = txtpropietario.Text;
                em.Telefono = int.Parse(txttelefono.Text);
                em.Estado = conbestado.Text;
                em.Id_contador = int.Parse(Program.CodigoUser);
                em.nodificar_empresa();

                MessageBox.Show("Modificado con Exito ....", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
               // imprimir_empresa();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar : " + ex.Message);
            }
        }

        private void btnEliminarUs_Click(object sender, EventArgs e)
        {
            clsempresa em = new clsempresa();
            try
            {
                em.Id_empresa = int.Parse(txtid_empresa.Text);
                
                em.eliminar_empresa();

                MessageBox.Show("Eliminado con Exito ....", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
              //  imprimir_empresa();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar : " + ex.Message);
            }
        }

        private void dgvUsuario_DoubleClick(object sender, EventArgs e)
        {
          
        }

        private void dgbempresa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgbempresa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid_empresa.Text = dgbempresa[0, e.RowIndex].Value.ToString().Trim();
            txtNombre.Text = dgbempresa[1, e.RowIndex].Value.ToString().Trim();
            txtnit.Text = dgbempresa[2, e.RowIndex].Value.ToString().Trim();
            txtciudad.Text = dgbempresa[3, e.RowIndex].Value.ToString().Trim();
            txtpropietario.Text= dgbempresa[4, e.RowIndex].Value.ToString().Trim();
            txttelefono.Text= dgbempresa[5, e.RowIndex].Value.ToString().Trim();
            conbestado.Text= dgbempresa[6, e.RowIndex].Value.ToString().Trim();

        }
    }
}
