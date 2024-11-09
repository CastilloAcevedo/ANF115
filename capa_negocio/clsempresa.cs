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
    public class clsempresa : conexion
    {
        int id_empresa;
        string nombre;
        string nit;
        string propietario;
        string ciudad;
        int telefono;
        string logo;
        string estado;
        int id_contador;
        public   clsempresa()
        {
            id_empresa = 0;
            nombre = "";
            nit = "";
            propietario = "";
            ciudad = "";
            telefono = 0;
            logo = "";
            estado = "";
            Id_contador = 0;

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

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Nit
        {
            get
            {
                return nit;
            }

            set
            {
                nit = value;
            }
        }

        public string Propietario
        {
            get
            {
                return propietario;
            }

            set
            {
                propietario = value;
            }
        }

        public string Ciudad
        {
            get
            {
                return ciudad;
            }

            set
            {
                ciudad = value;
            }
        }

        public int Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }

        public string Logo
        {
            get
            {
                return logo;
            }

            set
            {
                logo = value;
            }
        }

        public string Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }

        public int Id_contador
        {
            get
            {
                return id_contador;
            }

            set
            {
                id_contador = value;
            }
        }

        public DataTable TraerTipoempresa()
        {
            string consulta = "Select * from empresa order by nombre asc";

            SqlConnection myConeccion;
            conexion sp = new conexion();
            myConeccion = new SqlConnection();
            SqlCommand myConsulta = new SqlCommand(consulta, sp.conectar());

            DataTable tablaEmpleado = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(myConsulta);
            da.Fill(tablaEmpleado);

            return tablaEmpleado;
        }
        public void guardar_empresa()
        {
            try
            {
                this.prepararProcedimientos("insertar_empresa");         
                this.agregarParametros("@nombre", nombre);
                this.agregarParametros("@nit", nit);
                this.agregarParametros("@ciudad", ciudad);
                this.agregarParametros("@propietario", propietario);
                this.agregarParametros("@telefono", telefono.ToString());
                this.agregarParametros("@estado", estado);
                this.agregarParametros("@id_contador", id_contador.ToString());                
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
        public void nodificar_empresa()
        {
            try
            {
                this.prepararProcedimientos("modificar_empresa");
                this.agregarParametros("@id_empresa", id_empresa.ToString());
                this.agregarParametros("@nombre", nombre);
                this.agregarParametros("@nit", nit);
                this.agregarParametros("@ciudad", ciudad);
                this.agregarParametros("@propietario", propietario);
                this.agregarParametros("@telefono", telefono.ToString());
                this.agregarParametros("@estado", estado);
                this.agregarParametros("@id_contador", id_contador.ToString());
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
        public void eliminar_empresa()
        {
            try
            {
                this.prepararProcedimientos("eliminar_empresa");
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
        public DataSet imprimir()
        {
            DataSet ds = new DataSet();
            ejecutarConsultas("tEmpresa", "select * from empresa ", ds);
            return ds;
        }
    }
}
