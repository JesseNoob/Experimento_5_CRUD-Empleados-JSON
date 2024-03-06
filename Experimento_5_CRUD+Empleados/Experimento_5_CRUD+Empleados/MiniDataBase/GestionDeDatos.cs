using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Net.NetworkInformation;
using Experimento_5_CRUD_Trabajadores.MiniDataBase;


namespace Experimento_5_CRUD_Trabajadores.MiniDataBase
{
    public class GestionDeDatos
    {
        #region Datos
        //Direccion del banco de datos
        public static string RutaDeAcceso = "../../MiniDataBase/JSON/Empleados.json";
        //Intermediario del banco de datos (Utilizado para realizar operaciones o para cargar en el, el contenido de los archivos JSON)
        public static List <Empleado> ListaPrincipal = new List <Empleado> ();
        #endregion

        #region CRUD
        public static void CrearElemento(string nombre, string apellido, string puesto,int id)
        {
           Empleado trabajador = new Empleado (nombre, apellido, puesto, id);
           ListaPrincipal.Add(trabajador);
           
        }
        public static void ActualizarElemento(int indice, string campo, string contenido)
        {
            if ((indice - 1 < ListaPrincipal.Count()) && (indice - 1 > ListaPrincipal.Count()))
            {
                Console.WriteLine("Indice erroneo");
            }
            else
            {
                switch (campo.ToLower())
                {
                    case "nombre":
                        ListaPrincipal[indice - 1].Nombre = contenido;
                        break;
                    case "apellido":
                        ListaPrincipal[indice - 1].Apellido = contenido;
                        break;
                    case "puesto":
                        ListaPrincipal[indice - 1].Puesto = contenido;
                        break;
                    case "id":
                        ListaPrincipal[indice - 1].ID = int.Parse(contenido);
                        break;
                    //Habran mas campos
                    default:
                        Console.WriteLine("Campo no encontrado");
                        break;
                }
            }
        }
        public static void EliminarElemento(int indice)
        {
            
            if ((indice < ListaPrincipal.Count()) && (indice > ListaPrincipal.Count()))
            {
                Console.WriteLine("Indice erroneo");

            }
            else
            {
                ListaPrincipal.RemoveAt(indice);
            }
            
        }
        #endregion

        #region GestionarDatos
        public static void CargarDatos()
        {
            if (File.Exists(RutaDeAcceso))
            {
                ListaPrincipal = DeserializarJSON();

            }
            
        }
        //Dupla
        public static (bool,int) BuscarEmpleado(List<Empleado>lista, string campo,string contenido)
        {
            for (int i = 0; i < ListaPrincipal.Count(); i++)
            {
                if (campo.ToLower() == "nombre")
                {
                    if (lista[i].Nombre == contenido)
                    {
                        
                        return (true,i);
                    }
                }else if (campo.ToLower() == "apellido")
                {
                    if (lista[i].Apellido == contenido)
                    {
                        return (true, i);
                    }
                }else if (campo.ToLower() == "id")
                {
                    if (lista[i].ID == int.Parse(contenido))
                    {
                        return (true, i);
                    }
                }
        
            }
            return (false,0);
        }
        #endregion

        #region JSON
        public static void SerializarObjetos()
        {
            string ArchivosJSON = JsonConvert.SerializeObject(ListaPrincipal.ToArray());
            File.WriteAllText(RutaDeAcceso, ArchivosJSON);
            
        }
        public static string LeerArchivoJSON()
        {
            string ContenidoJSON;
            using (StreamReader lector = new StreamReader(RutaDeAcceso))
            {
                ContenidoJSON = lector.ReadToEnd();
            }
            return ContenidoJSON;
        }
        public static List<Empleado> DeserializarJSON()
        {
            List<Empleado> JSON = JsonConvert.DeserializeObject<List<Empleado>>(LeerArchivoJSON());
            return JSON;
        }
        #endregion
    }
}
