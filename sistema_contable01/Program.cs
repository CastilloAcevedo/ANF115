using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_contable01
{
    static class Program
    {

        public static string CargoUser;
        public static string CodigoUser;
        public static string NombreLog;
        //public static string ApellidoLog;
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            //Application.Run(new frm_asiento());
            //Application.Run(new Frm_report_asiento_fecha());
            Application.Run(new Frm_login());
            //Application.Run(new frm_planes());
            //Application.Run(new Frm_sumas_saldos());
            //Application.Run(new Frm_libro_mayor_b());
            //Application.Run(new Frm_libro_mayor_fecha());
        }
    }
}
