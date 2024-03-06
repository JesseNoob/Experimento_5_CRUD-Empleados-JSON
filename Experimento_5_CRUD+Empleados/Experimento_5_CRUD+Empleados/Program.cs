using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Experimento_5_CRUD_Trabajadores.MiniDataBase;

namespace Experimento_5_CRUD_Trabajadores
{
    public class Program
    {

        public static void EscribirMenu()
        {
            Console.WriteLine("\t\tMenu\n 1) Crear Empleado\n 2) Eliminar empleado\n 3) Mostrar Empleados\n 4) Actualizar Empleado\n 5) BuscarEmpleado\n 6) Salir");
        }
        public static void MostraEmpleados(List<Empleado> lista)
        {
            int i = 0;
            foreach(var objeto in lista)
            {
                
                Console.WriteLine("Empleado #{0}\nNombre: {1}\nApellido: {2}\nPuesto: {3}\nId: {4}",i+1,objeto.Nombre, objeto.Apellido, objeto.Puesto, objeto.ID);
                Console.WriteLine("---------------------------");
                i++;
            }
        }
        public static void SolicitarDatos()
        {
            string nombre, apellido, puesto; int id;
            Console.WriteLine("Ingrese su nombre");
            nombre = Console.ReadLine();
            Console.WriteLine("Ingrese su apellido");
            apellido = Console.ReadLine();
            Console.WriteLine("Ingrese su puesto");
            puesto = Console.ReadLine();
            Console.WriteLine("Ingrese su ID");
            id = int.Parse(Console.ReadLine());
            GestionDeDatos.CrearElemento(nombre, apellido, puesto, id);
            GestionDeDatos.SerializarObjetos();
        }
        
        static void Main(string[] args)

        {
            GestionDeDatos.CargarDatos();
               int opcion;
                do
                {
                    EscribirMenu();
                    opcion = int.Parse(Console.ReadLine());
                    string campo, contenido;
                switch (opcion)
                {
                    case 1:
                        SolicitarDatos();
                        Console.WriteLine("|Cambio realizado exitosamente|");
                    break;

                    case 2:
                        Console.WriteLine("Ingrese el indice del elemento");
                        GestionDeDatos.EliminarElemento(int.Parse(Console.ReadLine()) - 1);
                        Console.WriteLine("|Cambio realizado exitosamente|");
                    break;

                    case 3:
                        if (GestionDeDatos.ListaPrincipal.Count() == 0)
                        {
                            Console.WriteLine("Lista vacia");
                        }
                        MostraEmpleados(GestionDeDatos.ListaPrincipal);
                    break;

                    case 4:
                        Console.WriteLine("Ingrese el indice del elemento");
                        int indice = int.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese el campo a actualizar");
                        campo = Console.ReadLine();

                        Console.WriteLine("Actualice los datos");
                        contenido = Console.ReadLine();

                        GestionDeDatos.ActualizarElemento(indice, campo, contenido);
                        Console.WriteLine("|Cambio realizado exitosamente|");
                    break;

                    case 5:
                         Console.WriteLine("Ingrese el campo que se va a buscar");
                         campo = Console.ReadLine();
                         Console.WriteLine("Ingrese el dato del campo para iniciar busqueda");
                         contenido = Console.ReadLine();
                         //Resultados de la dupla
                         (bool Existe, int i) = GestionDeDatos.BuscarEmpleado(GestionDeDatos.ListaPrincipal, campo, contenido);
                         if (Existe)
                         {
                             Console.WriteLine("\n------------\nDato Encontrado:\nNombre: {0}\nApellido: {1}\nPuesto: {2}\nID: {3}\n------------", GestionDeDatos.ListaPrincipal[i].Nombre, GestionDeDatos.ListaPrincipal[i].Apellido, GestionDeDatos.ListaPrincipal[i].Puesto, GestionDeDatos.ListaPrincipal[i].ID);
                         }
                         else
                         {
                             Console.WriteLine("Dato No encontrado o Campo mal escrito");
                         }
                    break;

                    case 6:
                        Console.WriteLine("Adios");
                    continue;
                }
                        
                    Console.ReadKey();
                    Console.Clear();
                } while (opcion != 6);
               Console.ReadKey();
        }

    }
}
