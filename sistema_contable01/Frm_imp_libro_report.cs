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
    public partial class Frm_imp_libro_report : Form
    {
        public Frm_imp_libro_report()
        {
            InitializeComponent();
        }

        private void Frm_imp_libro_report_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'Datos_Reportes.Imprimir_asiento' Puede moverla o quitarla según sea necesario.
          //this.Imprimir_asientoTableAdapter.Fill(this.Datos_Reportes.Imprimir_asiento);
            // TODO: esta línea de código carga datos en la tabla 'Datos_Reportes.Imprimir_asiento' Puede moverla o quitarla según sea necesario.
            //this.Imprimir_asientoTableAdapter.Fill(this.Datos_Reportes.Imprimir_asiento);

           this.Report_asiento_conta.RefreshReport();
        }
    }
}
