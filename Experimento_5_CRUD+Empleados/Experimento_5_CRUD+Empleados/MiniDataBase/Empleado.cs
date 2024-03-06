using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experimento_5_CRUD_Trabajadores.MiniDataBase
{
    public class Empleado
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Puesto { get; set; }
        public int ID { get; set; }
        

        public Empleado(string nombre, string apellido, string puesto, int id)
        {
            Nombre = nombre;
            Apellido = apellido;
            Puesto = puesto;
            ID = id;
            
        }
        public Empleado() { }
    }
}
