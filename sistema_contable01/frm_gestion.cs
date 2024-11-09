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

namespace sistema_contable01
{
    public partial class frm_gestion : Form
    {
        public frm_gestion()
        {
            InitializeComponent();
        }
        frm_empresa buscar_cli;
        private void button1_Click(object sender, EventArgs e)
        {
            //  if (txtNombre.Text != "" && txtnit.Text != "" && txtContrasenaUs.Text != "")
            // {
            clsgestion em = new clsgestion();
                try
                {

                em.Fecha_inicio = txtfecha_inicio.Text;
                em.Fecha_fin = txtfecha_fin.Text;
                em.Id_empresa = int.Parse(txtid_empresa.Text);
                em.guardar_gestion(); 
                
                    MessageBox.Show("Guardado correctamente", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    //dgvUsuario.DataSource = Llenar_lista_libro("contador").Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar : " + ex.Message);
                }
          //  }
            //else { MessageBox.Show("Falta rellenar datos al formulario ", "INFORMACION"); }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            buscar_cli = new frm_empresa();
            buscar_cli.dgbempresa.CellMouseDoubleClick += Dgvalumno_CellMouseDoubleClick;
            buscar_cli.ShowDialog();
        }
        
        private void Dgvalumno_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            txtid_empresa.Text = dgv[0, e.RowIndex].Value.ToString().Trim();
            txtnombre_empresa.Text = dgv[1, e.RowIndex].Value.ToString().Trim() + ' ' + dgv[2, e.RowIndex].Value.ToString().Trim();
            buscar_cli.Close();
        }

    }
}
