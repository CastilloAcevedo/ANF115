using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using capa_dato;
using System.Data;
//using System.Windows.Forms;

namespace capa_negocio
{
    public class clsUsuario:conexion
    {

        string id_usuario;
        string nombre;
        string cargo;
        string clave;

        public string Id_usuario
        {
            get { return id_usuario; }
            set { id_usuario = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }

        public string Clave
        {
            get { return clave; }
            set { clave = value; }
        }

        public clsUsuario()
        {
            Id_usuario = "";
            Nombre = "";
            Cargo = "";
            Clave = "";
        }

        public void guardar_usuario()
        {
            try
            {
                this.prepararProcedimientos("insetar_contador");
                //this.AgregarParametro("@id_usuario", id_usuario);
                this.agregarParametros("@nombre", nombre);
                this.agregarParametros("@contrasena", clave);
                this.agregarParametros("@tipo", cargo);
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


        public void modificar_usuario()
        {
            try
            {
                this.prepararProcedimientos("modificar_contador");
                this.agregarParametros("@id_contador", id_usuario);
                this.agregarParametros("@nombre", nombre);
                this.agregarParametros("@contrasena", clave);
                this.agregarParametros("@tipo", cargo);
                this.ejecutarProcedimientos();
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Clear();
                //MessageBox.Show("Modificado correctamente ", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception)
            {
                throw;//MessageBox.Show("Ha ocurrido un error \n" + e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void eliminar_usuario()
        {
            try
            {
                this.prepararProcedimientos("eliminar_contador");
                this.agregarParametros("@id_contador", Id_usuario);
                this.ejecutarProcedimientos();
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Clear();
            }
            catch (Exception)
            {
                throw;// MessageBox.Show("Ha ocurrido un error \n" + e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public DataSet buscar_user(string dato)
        {
            string s;
            s = " select *from usuario where apellidos like'" + dato + "%' or nombre like'" + dato + "%'";
            DataSet ds = new DataSet();
            ejecutarConsultas(s, "tablauser", ds);
            return ds;
        }


    }
}
