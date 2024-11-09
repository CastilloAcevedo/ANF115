using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capa_dato;
using capa_negocio;
namespace capa_negocio
{
  public  class detalle_libro:conexion
    {
        int id_libro;
        float debe;
        float haber;
        int id_pla;

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

        public float Debe
        {
            get
            {
                return debe;
            }

            set
            {
                debe = value;
            }
        }

        public float Haber
        {
            get
            {
                return haber;
            }

            set
            {
                haber = value;
            }
        }


        public int Id_pla
        {
            get
            {
                return id_pla;
            }

            set
            {
                id_pla = value;
            }
        }
        public detalle_libro()
        {
            id_libro = 0;
            debe = 0;
            haber = 0;
            id_pla = 0;
        }
        public void insertar_detalle() {
            prepararProcedimientos("insetar_detalle");
            agregarParametros("@id_plan", id_pla.ToString());
            agregarParametros("@id_libro", id_libro.ToString());
            agregarParametros("@debe", debe.ToString());
            agregarParametros("@haber", haber.ToString());
            ejecutarProcedimientos();

        }
        public void modificar_detalle()
        {
            prepararProcedimientos("modificar_detalle");
            agregarParametros("@id_plan", id_pla.ToString());
            agregarParametros("@id_libro", id_libro.ToString());
            agregarParametros("@debe", debe.ToString());
            agregarParametros("@haber", haber.ToString());
           
          
            ejecutarProcedimientos();

        }
        public void eliminar_detalle()
        {
            prepararProcedimientos("eliminar_detalle");
            agregarParametros("@id_libro", id_libro.ToString());
            agregarParametros("@id_plan", id_pla.ToString());
            ejecutarProcedimientos();

        }

    }
}
