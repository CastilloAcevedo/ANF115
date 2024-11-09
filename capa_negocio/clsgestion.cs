using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using capa_dato;

namespace capa_negocio
{
    public class clsgestion:conexion
    {
        int id_gestion;
        string fecha_inicio;
        string fecha_fin;
        int id_empresa;

        public clsgestion()
        {
            id_gestion =0;
            fecha_inicio = "";
            fecha_fin = "";
            id_empresa = 0;
        }
        public int Id_gestion
        {
            get
            {
                return id_gestion;
            }

            set
            {
                id_gestion = value;
            }
        }

        public string Fecha_inicio
        {
            get
            {
                return fecha_inicio;
            }

            set
            {
                fecha_inicio = value;
            }
        }

        public string Fecha_fin
        {
            get
            {
                return fecha_fin;
            }

            set
            {
                fecha_fin = value;
            }
        }

        public int Id_empresa
        {
            get
            {
                return id_empresa;
            }

            set
            {
                id_empresa = value;
            }
        }
        public void guardar_gestion()
        {
            try
            {
                this.prepararProcedimientos("insertar_gestion");
                this.agregarParametros("@fecha_inicio", fecha_inicio);
                this.agregarParametros("@fecha_fin", fecha_fin);
                this.agregarParametros("@id_empresa", id_empresa.ToString());
                this.ejecutarProcedimientos();
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Clear();
                ///MessageBox.Show("Guardado correctamente", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception)
            {
                throw;//MessageBox.Show("Ha ocurrido un error \n" + e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void modificar_gestion()
        {
            try
            {
                this.prepararProcedimientos("modificar_gestion");
                this.agregarParametros("@id_gestion", id_gestion.ToString());
                this.agregarParametros("@fecha_inicio", fecha_inicio);
                this.agregarParametros("@fecha_fin", fecha_fin);
                this.agregarParametros("@id_empresa", id_empresa.ToString());
                this.ejecutarProcedimientos();
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Clear();
                ///MessageBox.Show("Guardado correctamente", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception)
            {
                throw;//MessageBox.Show("Ha ocurrido un error \n" + e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void eliminar_gestion()
        {
            try
            {
                this.prepararProcedimientos("eliminar_gestion");
                this.agregarParametros("@id_gestion", id_gestion.ToString());             
                this.ejecutarProcedimientos();
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Clear();
                ///MessageBox.Show("Guardado correctamente", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception)
            {
                throw;//MessageBox.Show("Ha ocurrido un error \n" + e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
