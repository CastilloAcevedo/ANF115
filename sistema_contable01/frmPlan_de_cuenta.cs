using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
//using System.Data;
using capa_dato;
using capa_negocio;

namespace sistema_contable01
{
    public partial class frmPlan_de_cuenta : Form
    {
        public frmPlan_de_cuenta()
        {
            InitializeComponent();
            llenar();
            this.llenarconboPresentacion();
        }
        public void llenar()
        {
            try
            {
                plan_cuenta plan = new plan_cuenta();
                cncuenta.DataSource = plan.traernivel();
                cncuenta.ValueMember = "id_plan";
                cncuenta.DisplayMember = "descripcion";
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo Modificar" + ex.Message);
            }
        }
        private void frmPlan_de_cuenta_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            pictureBox3.Visible = false;
            pictureBox4.Visible = true;


        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            pictureBox4.Visible = false;
            pictureBox3.Visible = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                /*int fila = this.dgvCuenta.RowCount;

                for (int i = 1; i < fila; i++)
                {
                     plan_cuenta cl = new plan_cuenta();
                     cl.Nivel1 = Convert.ToString(dgvCuenta["Nivel1", i].Value);
                    cl.Nivel2 = Convert.ToString(dgvCuenta["Nivel2", i].Value);
                    cl.Nivel3 = Convert.ToString(dgvCuenta["Nivel3", i].Value);
                        cl.Nivel4 = Convert.ToString(dgvCuenta["Nivel1", i].Value);
                        cl.Nivel5 = Convert.ToString(dgvCuenta["Nivel1", i].Value);
                        cl.Descripcion = (dgvCuenta["Descripcion", i].Value);
                        cl.Tipo = (dgvCuenta["Tipo", i].Value);
                    }
                    */
                if (cncuenta.Text == "") { 
                plan_cuenta plan = new plan_cuenta();
                plan.Nivel1 = int.Parse(txtnivel1.Text);           
                plan.Descripcion = txtdescripcion.Text;
                plan.Tipo = txtagrupacion.Text;
              //  plan.Cuenta_padre = Convert.ToInt32(cncuenta.SelectedValue);
                plan.insertar_cuenta2();
                MessageBox.Show("Guardado con exito ......!!!! " );
                }
                else
                {
                    plan_cuenta plan = new plan_cuenta();
                    plan.Nivel1 = int.Parse(txtnivel1.Text);
                    plan.Descripcion = txtdescripcion.Text;
                    plan.Tipo = txtagrupacion.Text;
                    plan.Cuenta_padre = Convert.ToInt32(cncuenta.SelectedValue);
                    plan.insertar_cuenta();
                    MessageBox.Show("Guardado con exito ......!!!! ");
                }
            }
            catch (Exception ex)
            { MessageBox.Show("No se pudo guardar " + ex.Message); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            plan_cuenta cl = new plan_cuenta();
            dgvCuenta.DataMember = "tCuenta";
            dgvCuenta.DataSource = cl.imprimir();
            dgvCuenta.AutoResizeColumns();
            dgvCuenta.AutoResizeRows();
        }
        private void llenarconboPresentacion()
        {
            try
            {
                plan_cuenta sdd = new plan_cuenta();
                cncuenta.DataSource = sdd.TraerTipocuenta();
                cncuenta.ValueMember = "id_plan";
                cncuenta.DisplayMember = "descripcion";
                //cncuenta.SelectedValue = "";
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message.ToString());
            }


        }//funcion apart

        private void button3_Click(object sender, EventArgs e)
        {/*

            try
            {
                plan_cuenta cl = new plan_cuenta();
                cl.Id_Cuenta = int.Parse(txtid.Text);
                cl.eliminar_cuenta
                MessageBox.Show("Eliminado correctamente");

                txtnivel1.Clear();
                txtnivel2.Clear();
                txtnivel3.Clear();
                txtnivel4.Clear();
                txtnivel5.Clear();
                txtestado.Clear();
            }
            catch (Exception ex)
            { MessageBox.Show("No se pudo Eliminar" + ex.Message); }

        }*/
            try
            {

                plan_cuenta plan = new plan_cuenta();
                plan.Id_plan = int.Parse(txtid_plan.Text);
                plan.eliminar_cuenta();
                MessageBox.Show("Eliminado con exito ......!!!! ");
            }
            catch (Exception ex)
            { MessageBox.Show("No se pudo Eliminar" + ex.Message); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                /*int fila = this.dgvCuenta.RowCount;

                for (int i = 1; i < fila; i++)
                {
                     plan_cuenta cl = new plan_cuenta();
                     cl.Nivel1 = Convert.ToString(dgvCuenta["Nivel1", i].Value);
                    cl.Nivel2 = Convert.ToString(dgvCuenta["Nivel2", i].Value);
                    cl.Nivel3 = Convert.ToString(dgvCuenta["Nivel3", i].Value);
                        cl.Nivel4 = Convert.ToString(dgvCuenta["Nivel1", i].Value);
                        cl.Nivel5 = Convert.ToString(dgvCuenta["Nivel1", i].Value);
                        cl.Descripcion = (dgvCuenta["Descripcion", i].Value);
                        cl.Tipo = (dgvCuenta["Tipo", i].Value);
                    }
                    */
                if (cncuenta.Text == "")
                {
                    plan_cuenta plan = new plan_cuenta();
                    plan.Id_plan = int.Parse(txtid_plan.Text);
                    plan.Nivel1 = int.Parse(txtnivel1.Text);
                    plan.Descripcion = txtdescripcion.Text;
                    plan.Tipo = txtagrupacion.Text;
                    //  plan.Cuenta_padre = Convert.ToInt32(cncuenta.SelectedValue);
                    plan.modificar_cuenta();
                    MessageBox.Show("Modificado  con exito ......!!!! ");
                }
                else
                {
                   
              

                plan_cuenta plan = new plan_cuenta();
                    plan.Id_plan = int.Parse(txtid_plan.Text);
                    plan.Nivel1 = int.Parse(txtnivel1.Text);
                    plan.Descripcion = txtdescripcion.Text;
                    plan.Tipo = txtagrupacion.Text;
                    plan.Cuenta_padre = Convert.ToInt32(cncuenta.SelectedValue);
                    plan.modificar_cuenta1();
                    MessageBox.Show("Modificado con exito ......!!!! ");
                  }
            }
            catch (Exception ex)
            { MessageBox.Show("No se pudo guardar " + ex.Message); }
        }

        private void dgvCuenta_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid_plan.Text = dgvCuenta[0, e.RowIndex].Value.ToString();
            txtnivel1.Text = dgvCuenta[1, e.RowIndex].Value.ToString();
            txtdescripcion.Text = dgvCuenta[2, e.RowIndex].Value.ToString();
           txtagrupacion.Text = dgvCuenta[3, e.RowIndex].Value.ToString();
          //  cncuenta.Text = dgvCuenta[4, e.RowIndex].Value.ToString();
        }

        private void agrupacion1_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  txtnivel1.Text = agrupacion1.SelectedValue.ToString();
           /* txtdescripcion.Text = agrupacion1.AccessibleDescription;
            txtnivel2.Text ="0";
            txtnivel3.Text = "0";
            txtnivel4.Text = "0";
            txtnivel5.Text = "0";
           // txtnivel2.Text = "0";*/

        }

        private void dgvCuenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtid_plan.Clear();
            txtnivel1.Clear();
            txtdescripcion.Clear();
            txtagrupacion.Text = "";
        }
    }
}
    

