using Programa.cs;
using System;

class Program
{
    public static void Main()
    {
        GestorDeTareas gestor = new GestorDeTareas();
        gestor.CargarTareas();

        while (true)
        {
            Console.WriteLine("\n  <<Planificador de Tareas>>");
            Console.WriteLine("1. Agregar Tarea");
            Console.WriteLine("2. Listar Tareas");
            Console.WriteLine("3. Guardar Tareas");
            Console.WriteLine("4. Eliminar Tarea");
            Console.WriteLine("5. Editar Tarea");
            Console.WriteLine("6. Filtrar Tareas por Prioridad");
            Console.WriteLine("7. Ver Descripcion de Tarea");
            Console.WriteLine("8. Salir");
            Console.Write("Seleccione una Opcion: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Titulo: ");
                    string titulo = Console.ReadLine();
                    Console.Write("Descripcion: ");
                    string descripcion = Console.ReadLine();
                    Console.Write("Prioridad (Alta, Media, Baja): ");
                    string prioridad = ValidarPrioridad();
                    Console.Write("Fecha de Entrega (YYYY-MM-DD): ");
                    DateTime fechaEntrega = ValidarFecha();
                    gestor.AgregarTarea(titulo, descripcion, prioridad, fechaEntrega);
                    Console.WriteLine("Tarea Agregada.");
                    break;

                case "2":
                    Console.WriteLine("\n Lista de Tareas  ");
                    gestor.ListarTareas();
                    break;

                case "3":
                    gestor.GuardarTareas();
                    Console.WriteLine("Tareas Guardadas.");
                    break;

                case "4":
                    Console.Write("ID de la Tarea a Eliminar: ");
                    int idEliminar = ValidarId();
                    gestor.EliminarTarea(idEliminar);
                    break;

                case "5":
                    Console.Write("ID de la Tarea a Editar: ");
                    int idEditar = ValidarId();
                    Console.Write("Nuevo Titulo: ");
                    string nuevoTitulo = Console.ReadLine();
                    Console.Write("Nueva Descripcion: ");
                    string nuevaDescripcion = Console.ReadLine();
                    Console.Write("Nueva Prioridad (Alta, Media, Baja): ");
                    string nuevaPrioridad = ValidarPrioridad();
                    Console.Write("Nueva Fecha de Entrega (YYYY-MM-DD): ");
                    DateTime nuevaFechaEntrega = ValidarFecha();
                    gestor.EditarTarea(idEditar, nuevoTitulo, nuevaDescripcion, nuevaPrioridad, nuevaFechaEntrega);
                    break;

                case "6":
                    Console.Write("Prioridad a Filtrar (Alta, Media, Baja): ");
                    string prioridadFiltrar = ValidarPrioridad();
                    Console.WriteLine($"\n--- Tareas con Prioridad {prioridadFiltrar} ---");
                    gestor.FiltrarPorPrioridad(prioridadFiltrar);
                    break;

                case "7":
                    Console.Write("ID de la Tarea: ");
                    int idDescripcion = ValidarId();
                    gestor.VerDescripcion(idDescripcion);
                    break;

                case "8":
                    Console.WriteLine("Saliendo del Programa...");
                    return;

                default:
                    Console.WriteLine("Opcion No Valida. Intente Nuevamente.");
                    break;
            }
        }
    }

    private static string ValidarPrioridad()
    {
        while (true)
        {
            string prioridad = Console.ReadLine()?.ToLower();
            if (prioridad == "alta" || prioridad == "media" || prioridad == "baja") return prioridad;
            Console.Write("Prioridad Invalida. Intente Nuevamente (Alta, Media, Baja): ");
        }
    }

    private static DateTime ValidarFecha()
    {
        while (true)
        {
            if (DateTime.TryParse(Console.ReadLine(), out DateTime fecha)) return fecha;
            Console.Write("Fecha No Valida. Intente Nuevamente (YYYY-MM-DD): ");
        }
    }

    private static int ValidarId()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int id)) return id;
            Console.Write("ID No Valido. Intente Nuevamente: ");
        }
    }
}


