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
namespace sistema_contable01
{
    public partial class frm_asiento : Form
    {
        public frm_asiento()
        {
            InitializeComponent();
            llenarconboPresentacion();
        }

        private void frm_asiento_Load(object sender, EventArgs e)
        {

        }
        private void llenarconboPresentacion()
        {
            try
            {
                Libro sdd = new Libro();
                conbempresa.DataSource = sdd.TraerTipoempresa();
                conbempresa.ValueMember = "id_empresa";
                conbempresa.DisplayMember = "nombre";

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message.ToString());
            }


        }
        
    
        private void button1_Click_1(object sender, EventArgs e)
        {
            dgvplan.Visible = true;
            pictureBox1.Visible = true;
            txtbuscar1.Visible = true;
            plan_cuenta cl = new plan_cuenta();
            dgvplan.DataMember = "tCuenta";

            dgvplan.DataSource = cl.buscar();
            dgvplan.AutoResizeColumns();
            dgvplan.AutoResizeRows();
        
        }

        public static int cont_fila = 0;
        public static double total_debe;
        public static double total_haber;
        string dato1;
        string dato2,dato_ex;

        private void dgvplan_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {            
          
            bool existe = false;
            int num_fila = 0;
            
            if (cont_fila == 0){
                dgv_asiento.AllowUserToAddRows = true;
                dato1 = dgvplan[0, e.RowIndex].Value.ToString().Trim();
                dato2 = dgvplan[1, e.RowIndex].Value.ToString().Trim();
             
                dgv_asiento.Rows.Add(dgvplan[2, e.RowIndex].Value.ToString().Trim(), dato1,dato2,0,0);
                cont_fila++;
                
                dgvplan.Hide();
                pictureBox1.Hide();
                txtbuscar1.Hide();
            }
                
            else {
                dato_ex = dgvplan[2, e.RowIndex].Value.ToString().Trim();

                
                foreach (DataGridViewRow fila in dgv_asiento.Rows){
                    if (fila.Cells[0].Value.ToString()== dgvplan[2, e.RowIndex].Value.ToString().Trim())
                    {
                         existe = true;
                         num_fila = fila.Index;
                    }
                }
                if (existe == true){
                    dgv_asiento.AllowUserToAddRows = true;
            
                    dato_ex = dgvplan[2, e.RowIndex].Value.ToString().Trim();
                    dgv_asiento.Rows[num_fila].Cells[0].Value = dato_ex;
                    dgv_asiento.Rows[num_fila].Cells[1].Value= dgvplan[0, e.RowIndex].Value.ToString().Trim();
                    dgv_asiento.Rows[num_fila].Cells[2].Value = dgvplan[1, e.RowIndex].Value.ToString().Trim();
                    cont_fila++;
                    dgvplan.Hide();
                    pictureBox1.Hide();
                    txtbuscar1.Hide();

                }
                else { 
                    dgv_asiento.Rows.Add(dgvplan[2, e.RowIndex].Value.ToString().Trim(), dgvplan[0, e.RowIndex].Value.ToString().Trim(), dgvplan[1, e.RowIndex].Value.ToString().Trim(), 0,0);                       
                    cont_fila++;
                    dgvplan.Hide();
                    pictureBox1.Hide();
                    txtbuscar1.Hide();
                }
             }
             total_debe = 0;
             total_haber = 0;
            
            foreach (DataGridViewRow fila in dgv_asiento.Rows)
            {
                total_debe += Convert.ToDouble(fila.Cells[3].Value);
                total_haber += Convert.ToDouble(fila.Cells[4].Value);              
            }
            txtTotal_debe.Text = "Bs " + total_debe.ToString();
            txtTotal_haber.Text = "Bs " + total_haber.ToString();
            txtbuscar1.Clear();
            dgv_asiento.AllowUserToAddRows = false;
        }




        double t_debe=0;
        double t_haber=0;
        private void dgv_asiento_CellEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            total_debe = 0;
            total_haber = 0;
           
            foreach (DataGridViewRow fila in dgv_asiento.Rows)
            {
       
                 total_debe += Convert.ToDouble(fila.Cells[3].Value);
                total_haber += Convert.ToDouble(fila.Cells[4].Value);
                t_debe = total_debe;
                t_haber = total_haber;
            }
            txtTotal_debe.Text = "Bs " + total_debe.ToString();
            txtTotal_haber.Text = "Bs " + total_haber.ToString();
        }

        //-----------------------------------------------------------------------------
        Libro lb = new Libro();
        detalle_libro dl = new detalle_libro();
        private void btnGuardar_Click_1(object sender, EventArgs e)
        { int cont = 0,cont1=0;
            total_debe = 0;
            total_haber = 0;
    
            foreach (DataGridViewRow fila in dgv_asiento.Rows)
            {
             
                string  deber = dgv_asiento.Rows[cont].Cells[3].Value.ToString();
              string  haber = dgv_asiento.Rows[cont].Cells[4].Value.ToString();
                if (deber=="0" && haber=="0")
                {
                    cont1 = 0;
                    //------------------------------------------------------------------------------------
                    foreach (DataGridViewRow fila1 in dgv_asiento.Rows)
                    {
                        string deber1 = dgv_asiento.Rows[cont1].Cells[3].Value.ToString();
                        string haber1 = dgv_asiento.Rows[cont1].Cells[4].Value.ToString();
                        if (deber1 == "0" && haber1 == "0")
                        {
                            dgv_asiento.Rows.RemoveAt(dgv_asiento.Rows[cont1].Index);
                            cont_fila--;
                        }
                        cont1 = cont1 + 1;

                    }cont1 =0;
                    //------------------------------------------------------------------------------------
                    
                }
                cont=cont + 1;
               
            }
            //**************************************************************************
            cont1 = 0;
            foreach (DataGridViewRow fila1 in dgv_asiento.Rows)
            {
                string deber1 = dgv_asiento.Rows[cont1].Cells[3].Value.ToString();
                string haber1 = dgv_asiento.Rows[cont1].Cells[4].Value.ToString();
                if (deber1 == "0" && haber1 == "0")
                {
                    dgv_asiento.Rows.RemoveAt(dgv_asiento.Rows[cont1].Index);
                    cont_fila--;
                }
                cont1 = cont1 + 1;

            }
            cont1 = 0;
            //--------------------------------------------------------------------------

            foreach (DataGridViewRow fila in dgv_asiento.Rows)
            {
                total_debe += Convert.ToDouble(fila.Cells[3].Value);
                total_haber += Convert.ToDouble(fila.Cells[4].Value);
                t_debe = total_debe;
                t_haber = total_haber;
            }
            txtTotal_debe.Text = "Bs " + total_debe.ToString();
            txtTotal_haber.Text = "Bs " + total_haber.ToString();



            //**************************************************************************
            if (txtTotal_debe.Text != txtTotal_haber.Text ||(total_debe<=0 && total_haber<=0))
            { MessageBox.Show("DEBE Y HABER TIENE QUE SER IGUALES Y MAYOR A CERO", "INFORMACION");}
            else
            {
                if (cont_fila != 0)
                { try
                    {
                        
                        lb.Fecha = txtfecha.Text;
                        lb.Glosa = txtglosa.Text;
                        lb.Total_debe = float.Parse(t_debe.ToString());
                        lb.Total_haber = float.Parse(t_haber.ToString());
                        lb.Id_conta = int.Parse(Program.CodigoUser);
                        lb.Razon_social =Convert.ToInt32(conbempresa.SelectedValue);
                        lb.Tipo_ = txtTipo.Text;
                        lb.insertar_libro();
                    
                        string cmd = string.Format("select max(id_libro) as id_libro from libro");
                        DataSet ds = conexion.EjecutarComan(cmd);
                        string Numfac = ds.Tables[0].Rows[0]["id_libro"].ToString().Trim();
    
                        foreach (DataGridViewRow Fila in dgv_asiento.Rows)
                        {
                            cmd = string.Format("Exec insetar_detalle '{0}','{1}','{2}','{3}'", Fila.Cells[0].Value.ToString(), Numfac, Fila.Cells[3].Value.ToString(), Fila.Cells[4].Value.ToString());
                            ds = conexion.EjecutarComan(cmd);                     
                        }
                        MessageBox.Show("EL ASIENTO SE GUARDO CON EXITO...!", "INFORMACION");
                        this.limpiar_todo();

                        if (chb_Imprimir_as.Checked==true)
                        {
                            cmd = "Exec Imprimir_asiento " + Numfac;
                            ds = conexion.EjecutarComan(cmd);
                            Frm_imp_libro_report fr = new Frm_imp_libro_report();
                            fr.Report_asiento_conta.LocalReport.DataSources[0].Value = ds.Tables[0];
                            fr.ShowDialog();
                            limpiar_todo();
                        }
                        else { limpiar_todo(); }

                    }
                    catch (Exception er)
                    { MessageBox.Show("SE COLGO POR DEPREESION  " + er.ToString()); }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //DataGridView dg = (DataGridView)sender;
            
        }
    
        private void limpiar_todo()
        {
            txtglosa.Clear();
            txtTotal_debe.Clear();
            txtTotal_haber.Clear();
            cont_fila = 0;
            total_debe = 0;
            total_haber = 0;
            dgv_asiento.Rows.Clear();
        }
        public DataSet Llenar_lista_libro(string tabla)
        {
            DataSet ds;//select top 15 *from libro order by id_libro desc
            string cmd = string.Format("select top 15 *from " + tabla + " order by id_libro desc ");
            ds = conexion.EjecutarComan(cmd);
            return ds;
        }
        private void tp_lista_libro_Click(object sender, EventArgs e)
        {
            //----------------
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgv_lista_libro.DataSource = Llenar_lista_libro("libro").Tables[0];
        }

        private void dgv_lista_libro_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            String dato;
            dato = dgv_lista_libro[0, e.RowIndex].Value.ToString().Trim();
        
            string cmd;
            DataSet ds;
            cmd = "Exec Imprimir_asiento " + dato;
            ds = conexion.EjecutarComan(cmd);
          
            Frm_imp_libro_report fr = new Frm_imp_libro_report();
            fr.Report_asiento_conta.LocalReport.DataSources[0].Value = ds.Tables[0];
            fr.ShowDialog();
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



        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (cont_fila > 0)
            {
                total_debe = total_debe - (Convert.ToDouble(dgv_asiento.Rows[dgv_asiento.CurrentRow.Index].Cells[3].Value));
                total_haber = total_haber - (Convert.ToDouble(dgv_asiento.Rows[dgv_asiento.CurrentRow.Index].Cells[4].Value));
                txtTotal_debe.Text = "Bs " + total_debe;
                txtTotal_haber.Text = "Bs " + total_haber;

                string sd = Convert.ToString(dgv_asiento.Rows[dgv_asiento.CurrentRow.Index].Cells[0].Value);

                if (sd != "")
                {
                    dgv_asiento.Rows.RemoveAt(dgv_asiento.CurrentRow.Index);
                    cont_fila--;
                }
                else
                {
                    dgv_asiento.ClearSelection();
                    MessageBox.Show("NO HAY ELEMENTOS A ELIMINAR ", "ATENCION");
                }

            }
        }
        private static double  deber=0;
        private static double haber = 0;
        private void dgv_asiento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int f = 0;
            int c=0;

            string fila = dgv_asiento.CurrentCell.OwningRow.Index.ToString();
            string col = dgv_asiento.CurrentCell.OwningColumn.Index.ToString();
            f = Convert.ToInt32(fila.ToString());
            c = int.Parse(col.ToString());
            dgv_asiento.CurrentCell.ReadOnly = false;
            if (c == 3)
            {
                dgv_asiento.Rows[f].Cells[4].Value = 0;
            }
            if(c==4) {
                dgv_asiento.Rows[f].Cells[3].Value = 0;
            }
            //*****************************************************************
            total_debe = 0;
            total_haber = 0;
        
            foreach (DataGridViewRow filas in dgv_asiento.Rows)
            {
                total_debe += Convert.ToDouble(filas.Cells[3].Value);
                total_haber += Convert.ToDouble(filas.Cells[4].Value);
                t_debe = total_debe;
                t_haber = total_haber;
            }
            txtTotal_debe.Text = "Bs " + total_debe;
            txtTotal_haber.Text = "Bs " + total_haber;


        }

        private void Dgv_asiento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            total_debe = 0;
            total_haber = 0;
        
            foreach (DataGridViewRow filas in dgv_asiento.Rows)
            {
                total_debe += Convert.ToDouble(filas.Cells[3].Value);
                total_haber += Convert.ToDouble(filas.Cells[4].Value);
                t_debe = total_debe;
                t_haber = total_haber;
            }
            txtTotal_debe.Text = "Bs " + total_debe;
            txtTotal_haber.Text = "Bs " + total_haber;//dgv_asiento.CurrentCell.ReadOnly = false;
        }

        private void dgv_asiento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            total_debe = 0;
            total_haber = 0;
   
            foreach (DataGridViewRow fila in dgv_asiento.Rows)
            {
                total_debe += Convert.ToDouble(fila.Cells[3].Value);
                total_haber += Convert.ToDouble(fila.Cells[4].Value);
                t_debe = total_debe;
                t_haber = total_haber;
            }
            txtTotal_debe.Text = "Bs " + total_debe;
            txtTotal_haber.Text = "Bs " + total_haber;
        }

        private void dgv_asiento_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            total_debe = 0;
            total_haber = 0;

            foreach (DataGridViewRow fila in dgv_asiento.Rows)
            {
                total_debe += Convert.ToDouble(fila.Cells[3].Value);
                total_haber += Convert.ToDouble(fila.Cells[4].Value);
                t_debe = total_debe;
                t_haber = total_haber;
            }
            txtTotal_debe.Text = "Bs " + total_debe;
            txtTotal_haber.Text = "Bs " + total_haber;
        }

        private void dgv_asiento_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            total_debe = 0;
            total_haber = 0;
        
            foreach (DataGridViewRow fila in dgv_asiento.Rows)
            {
                total_debe += Convert.ToDouble(fila.Cells[3].Value);
                total_haber += Convert.ToDouble(fila.Cells[4].Value);
                t_debe = total_debe;
                t_haber = total_haber;
            }
            txtTotal_debe.Text = "Bs " + total_debe;
            txtTotal_haber.Text = "Bs " + total_haber;
        }

        private void dgv_asiento_Click(object sender, EventArgs e)
        {
            total_debe = 0;
            total_haber = 0;
       
            foreach (DataGridViewRow fila in dgv_asiento.Rows)
            {
                total_debe += Convert.ToDouble(fila.Cells[3].Value);
                total_haber += Convert.ToDouble(fila.Cells[4].Value);
                t_debe = total_debe;
                t_haber = total_haber;
            }
            txtTotal_debe.Text = "Bs " + total_debe;
            txtTotal_haber.Text = "Bs " + total_haber;
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            total_debe = 0;
            total_haber = 0;
        
            foreach (DataGridViewRow fila in dgv_asiento.Rows)
            {
                total_debe += Convert.ToDouble(fila.Cells[3].Value);
                total_haber += Convert.ToDouble(fila.Cells[4].Value);
                t_debe = total_debe;
                t_haber = total_haber;
            }
            txtTotal_debe.Text = "Bs " + total_debe;
            txtTotal_haber.Text = "Bs " + total_haber;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            dgv_asiento.Rows.Clear();
            txtglosa.Clear();
            txtTotal_debe.Clear();
            txtTotal_haber.Clear();
            cont_fila = 0;
        }

        private void dgvplan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnNuevo_Click1(object sender, EventArgs e)
        {
            limpiar_todo();
        }
    }
}
