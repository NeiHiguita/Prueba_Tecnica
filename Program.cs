using System;
using System.Collections.Generic;
public class Tarea
{
    public int id { get; set; }
    public string nombre { get; set; }
    public string descripcion { get; set; }
    public bool estado { get; set; }
    //public DateTime fecha { get; set; }
}
internal class Program
{
    //lista donde se guardarán las tareas
    private static List<Tarea> tareas = new List<Tarea>();
    //metodo para agragar tareas
    public static void AgregarTarea()
    {
        // para que se incremente el id cada vez que se crea una nueva tarea
        int nid = tareas.Count + 1;
        Console.Write("Ingrese el nombre de la tarea: ");
        string nnombre = Console.ReadLine();
        Console.Write("Ingrese la descripción de la tarea: ");
        string desc = Console.ReadLine();

        //crea un esquema para la nuava tarea y darle sus propiedades
        Tarea nuevaTarea = new Tarea
        {
            id = nid,
            nombre = nnombre,
            descripcion = desc,
            estado = false // El estado por defecto es false (pendiente)
        };

        tareas.Add(nuevaTarea);
        Console.WriteLine($"La tarea '{nnombre}' agregada correctamente, su id es: {nid}\n");
    }
    //metodo para listar las tareas
    public static void ListarTareas()
    {
        if (tareas.Count == 0)
        {
            Console.WriteLine("No hay tareas en la lista :(");
            return;
        }
        Console.WriteLine("Lista de Tareas:");
        Console.WriteLine("ID -  Nombre  - Estado - Descripción");
        Console.WriteLine("----------------------");
        foreach (var tarea in tareas)
        {
            //aqui se cambia el true y false por completado y pendiente
            string nombreEstado = tarea.estado ? "Completado" : "Pendiente";
            Console.WriteLine(tarea.id + " - " + tarea.nombre + " - " + nombreEstado + " - " + tarea.descripcion);
        }
        Console.WriteLine("\n");
    }
    //metodo para eliminar tareas
    public static void EliminarTarea(int id)
    {
        //busca la tarea por medio del id y la introduce en la nueva variable
        Tarea tareaAEliminar = tareas.Find(t => t.id == id);
        if (tareaAEliminar != null)
        {
            //elimina la tarea por medio de la nuava variable
            tareas.Remove(tareaAEliminar);
            Console.WriteLine($"La tarea '{tareaAEliminar.nombre}' eliminada correctamente :d\n");
        }
        else
        {
            Console.WriteLine($"Tarea con ID {id} no existe\n");
        }
    }
    public static void MarcarTarea(int id)
    {
        //busca la tarea por medio del id
        Tarea tareaEstado = tareas.Find(t => t.id == id);
        if (tareaEstado.estado == false)
        {
            //luego cambia el estado a true = completado
            tareaEstado.estado = true;
            Console.WriteLine($"La tarea '{tareaEstado.nombre}' completada :D\n");
        }
        else if(tareaEstado.estado == true){
            Console.WriteLine($"La tarea ya esta completada :D\n");
        }
        else
        {
            Console.WriteLine($"Tarea con ID {id} no existe\n");
        }
    }
    static void Main(string[] args)
    {
        int op;
        do
        {
            //esquema o menu para las opciones a realizar, se puede usar tambien un switch, aunque decidi usar condicionales if, else if y else
            Console.WriteLine("Bienvenido a la aplicación de gestión de tareas\n");
            Console.WriteLine("Elija la opcion que desea ejecutar");
            Console.WriteLine("1. Agregar tarea");
            Console.WriteLine("2. Listar tareas");
            Console.WriteLine("3. Marcar tarea como completada");
            Console.WriteLine("4. Eliminar tarea");
            Console.WriteLine("0. Salir");

            op = int.Parse(Console.ReadLine());

            if (op == 1)
            {
                //llamar el metodo para crear
                AgregarTarea();
            }
            else if (op == 2)
            {
                //llamar el metodo para listar
                ListarTareas();
            }
            else if (op == 3)
            {
                Console.WriteLine("Cambiar el estado de la tarea tarea");
                ListarTareas();
                Console.Write("Ingrese el ID de la tarea que ha completado: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    //llamar el metodo para completar las tareas
                    MarcarTarea(id);
                }
                else
                {
                    Console.WriteLine("ID no válido");
                }
            }
            else if (op == 4)
            {
                Console.WriteLine("Eliminar tarea");
                ListarTareas();
                Console.Write("Ingrese el ID de la tarea a eliminar: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    //llamar el metodo para eliminar tareas
                    EliminarTarea(id);
                }
                else
                {
                    Console.WriteLine("ID no válido");
                }
            }
            else if (op == 0)
            {
                //el bucle sigue infinitamente a menos de que elija la ocion 0 = salir
                Console.WriteLine("Saliendo...");
            }
            else
            {
                //si se digita un valor numerico diferente al del menu seguira en el bucle
                Console.WriteLine("Opcion no valida");
            }
        } while (op != 0);
    }
}