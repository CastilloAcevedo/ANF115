using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using capa_dato;
using System.Data;


namespace capa_negocio
{
   public class Libro:conexion
    {
        int id_libro;
        string fecha;
        string glosa;
        float total_debe;
        float total_haber;
        int id_conta;
        int razon_social;
        string tipo_;

           

        public int Id_libro
        {
            get
            {
                return id_libro;
            }

            set
            {
                id_libro = value;
            }
        }

        public string Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        public string Glosa
        {
            get
            {
                return glosa;
            }

            set
            {
                glosa = value;
            }
        }

        public float Total_debe
        {
            get
            {
                return total_debe;
            }

            set
            {
                total_debe = value;
            }
        }

        public float Total_haber
        {
            get
            {
                return total_haber;
            }

            set
            {
                total_haber = value;
            }
        }

        public int Id_conta
        {
            get
            {
                return id_conta;
            }

            set
            {
                id_conta = value;
            }
        }

        public int Razon_social
        {
            get
            {
                return razon_social;
            }

            set
            {
                razon_social = value;
            }
        }

        public string Tipo_
        {
            get
            {
                return tipo_;
            }

            set
            {
                tipo_ = value;
            }
        }

        public Libro() {
            id_libro = 0;
            fecha = "";
            glosa = "";
            total_debe = 0;
            total_haber = 0;
            id_conta = 0;
            razon_social = 0;
            tipo_ = "";
        }
public void insertar_libro()
        {
           prepararProcedimientos ("insetar_libro");
            agregarParametros("@fecha", fecha);
            agregarParametros("@glosa", glosa);
            agregarParametros("@total_debe",total_debe.ToString());
            agregarParametros("@total_haber", total_haber.ToString());
            agregarParametros("@id_conta", id_conta.ToString());
            agregarParametros("@razon_social", razon_social.ToString());
            agregarParametros("@tipo_", tipo_);
            ejecutarProcedimientos();


        }
        public void modificar_libro()
        {
            prepararProcedimientos("modificar_libro");
            agregarParametros("@id_libro", id_libro.ToString());
            agregarParametros("@fecha", fecha);
            agregarParametros("@glosa", glosa);
            agregarParametros("@total_debe",total_debe.ToString());
            agregarParametros("@total_haber",total_haber.ToString());
            agregarParametros("@razon_social", razon_social.ToString());
            agregarParametros("@tipo_", tipo_);
            ejecutarProcedimientos();


        }

        public void eliminar_libro() {
            prepararProcedimientos("eliminar_libro");
            agregarParametros("@id_libro", id_libro.ToString());
            ejecutarProcedimientos();
        }
        public DataSet imprimirli()
        {
            DataSet ds = new DataSet();
            ejecutarConsultas("tlibro", "select distinct (libro.fecha),plan_de_cuenta.descripcion as Detalle,detalle_libro.monto,detalle_libro.tipo,libro.glosa from plan_de_cuenta, detalle_libro, libro where plan_de_cuenta.id_plan = detalle_libro.id_plan and detalle_libro.id_libro = libro.id_libro", ds);
            return ds;
        }
        public DataSet imprimirlibro()
        {
            DataSet ds = new DataSet();
            ejecutarConsultas("tlibro1", "select * from libro", ds);
            return ds;
        }
        public DataSet mostar_fecha()
        {
            DataSet ds = new DataSet();
            ejecutarConsultas("tlibro2", "select fecha,id_libro from libro", ds);
            return ds;
        }
        public DataSet buscar_libro()
        {
            DataSet h = new DataSet();
            prepararProcedimientos("buscar_fecha");
            agregarParametros("@fecha", fecha);
             ejecutarconsultaparamostrardatos(h, "tlibro1");
          //  ejecutarProcedimientos();
            return h;

        }

        /*   public DataSet buscarPorNombre("")
           {
               DataSet ds = new DataSet();
               this.prepararProcedimientos("buscarplan");
               this.agregarParametros("@descripcion", nombre);
           }
               */
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
    }
}
