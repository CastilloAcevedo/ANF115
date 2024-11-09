using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using capa_dato;

namespace capa_negocio
{
    public class plan_cuenta: conexion
    {
        int id_plan;
        int nivel1;
        string descripcion;
        string tipo;
        int cuenta_padre;

        public int Id_plan
        {
            get
            {
                return id_plan;
            }

            set
            {
                id_plan = value;
            }
        }

        public int Nivel1
        {
            get
            {
                return nivel1;
            }

            set
            {
                nivel1 = value;
            }
        }


        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        public string Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }

        public int Id_Cuenta { get; set; }

     

        public int Cuenta_padre
        {
            get
            {
                return cuenta_padre;
            }

            set
            {
                cuenta_padre = value;
            }
        }

        public plan_cuenta()
        {
            id_plan = 0;
            nivel1 = 0;
            descripcion = "";
            tipo = "";
            cuenta_padre = 0;

        }
        public DataTable traernivel()
        {
            string consul = "select id_plan,descripcion from plan_de_cuenta where tipo='Agrupacion'";
            SqlConnection myconecion;
            conexion sa = new conexion();
            myconecion = new SqlConnection();
            SqlCommand myConecion = new SqlCommand(consul, sa.conectar());
            DataTable plan = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter(myConecion);
            ds.Fill(plan);
            return plan;
        }
        public void insertar_cuenta() {
            prepararProcedimientos("insertearberificaando");
            agregarParametros("@nivel", nivel1.ToString());
            agregarParametros("@descripcion", descripcion);
            agregarParametros("@tipo", tipo);
            agregarParametros("@cuentapadre", cuenta_padre.ToString());
            ejecutarProcedimientos();

        }
        public void insertar_cuenta2()
        {
            prepararProcedimientos("insertearberificaando2");
            agregarParametros("@nivel", nivel1.ToString());
            agregarParametros("@descripcion", descripcion);
            agregarParametros("@tipo", tipo);
           // agregarParametros("@cuentapadre", cuenta_padre.ToString());
            ejecutarProcedimientos();

        }
        public void insertar_cuenta1()
        {
            prepararProcedimientos("insertearberificaando1");
            agregarParametros("@nivel", nivel1.ToString());
            agregarParametros("@descripcion", descripcion);
            agregarParametros("@tipo", tipo);
            agregarParametros("@cuentapadre", cuenta_padre.ToString());
            ejecutarProcedimientos();

        }
        public void modificar_cuenta()
        {
            prepararProcedimientos("modificar_plan");
            agregarParametros("@id_plan", id_plan.ToString());
            agregarParametros("@nivel", nivel1.ToString());        
            agregarParametros("@descripcion", descripcion);
            agregarParametros("@tipo", tipo);
            ejecutarProcedimientos();

        }
        public void modificar_cuenta1()
        {
            prepararProcedimientos("modificar_plan1");
            agregarParametros("@id_plan", id_plan.ToString());
            agregarParametros("@nivel", nivel1.ToString());
            agregarParametros("@descripcion", descripcion);
            agregarParametros("@tipo", tipo);
            agregarParametros("@cuentapadre", cuenta_padre.ToString());
            ejecutarProcedimientos();

        }
        public void eliminar_cuenta() {
            prepararProcedimientos("eliminar_cuenta");
            agregarParametros("@id_plan", id_plan.ToString());
            ejecutarProcedimientos();

        }
        public DataSet imprimir()
        {
            //select DISTINCT phijo.id_plan, phijo.descripcion,phijo.nivel,ppadre.descripcion as 'ceneta padre',phijo.tipo from plan_de_cuenta phijo, plan_de_cuenta ppadre, plan_de_cuenta p where  phijo.cuenta_padre = ppadre.id_plan
            DataSet ds = new DataSet();
            ejecutarConsultas("tCuenta", "select * from plan_de_cuenta", ds);
            return ds;
        }
        public DataSet buscar()
        {
            DataSet h = new DataSet();
            prepararProcedimientos("buscar");
            ejecutarconsultaparamostrardatos(h, "tCuenta");
            return h;

        }
        public DataSet buscar1()
        {
            DataSet h = new DataSet();
            prepararProcedimientos("buscar1");
            agregarParametros("@descripcion", descripcion);
            ejecutarconsultaparamostrardatos(h, "tCuenta");
            return h;

        }
        public DataTable TraerTipocuenta()
        {
            string consulta = "Select * from plan_de_cuenta order by descripcion asc";

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
 