using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Programa.cs
{
    internal class GestorDeTareas
    {
        private List<Tarea> tareas = new List<Tarea>();
        private const string Archivo = "tareas.json";

        public void AgregarTarea(string titulo, string descripcion, string prioridad, DateTime fechaEntrega)
        {
            var nuevaTarea = new Tarea
            {
                Id = tareas.Count + 1,
                Titulo = titulo,
                Descripcion = descripcion,
                Prioridad = prioridad,
                FechaEntrega = fechaEntrega
            };
            tareas.Add(nuevaTarea);
        }

        public void ListarTareas()
        {
            if (tareas.Count == 0)
            {
                Console.WriteLine("No hay Tareas Registradas.");
                return;
            }

            foreach (var tarea in tareas)
            {
                Console.WriteLine($"[{tarea.Id}] {tarea.Titulo} - {tarea.Prioridad} (Entrega: {tarea.FechaEntrega:yyyy-MM-dd})");
            }
        }

        public void GuardarTareas()
        {
            var json = JsonSerializer.Serialize(tareas, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(Archivo, json);
        }

        public void CargarTareas()
        {
            if (File.Exists(Archivo))
            {
                var json = File.ReadAllText(Archivo);
                tareas = JsonSerializer.Deserialize<List<Tarea>>(json) ?? new List<Tarea>();
                Console.WriteLine("Tareas Cargadas Correctamente.");
            }
            else
            {
                Console.WriteLine("No hay Archivo de Tareas para Cargar.");
            }
        }

        public void EliminarTarea(int id)
        {
            var tarea = tareas.Find(t => t.Id == id);
            if (tarea != null)
            {
                tareas.Remove(tarea);
                Console.WriteLine($"Tarea con ID {id} Eliminada.");
            }
            else
            {
                Console.WriteLine("Tarea No Encontrada.");
            }
        }

        public void EditarTarea(int id, string nuevoTitulo, string nuevaDescripcion, string nuevaPrioridad, DateTime nuevaFechaEntrega)
        {
            var tarea = tareas.Find(t => t.Id == id);
            if (tarea != null)
            {
                tarea.Titulo = nuevoTitulo;
                tarea.Descripcion = nuevaDescripcion;
                tarea.Prioridad = nuevaPrioridad;
                tarea.FechaEntrega = nuevaFechaEntrega;
                Console.WriteLine($"Tarea con ID {id} Actualizada.");
            }
            else
            {
                Console.WriteLine("Tarea No Encontrada.");
            }
        }

        public void FiltrarPorPrioridad(string prioridad)
        {
            var tareasFiltradas = tareas.FindAll(t => t.Prioridad.ToLower() == prioridad.ToLower());
            if (tareasFiltradas.Count > 0)
            {
                foreach (var tarea in tareasFiltradas)
                {
                    Console.WriteLine($"[{tarea.Id}] {tarea.Titulo} - {tarea.Prioridad} (Entrega: {tarea.FechaEntrega:yyyy-MM-dd})");
                }
            }
            else
            {
                Console.WriteLine("No se Encontraron tareas con esa Prioridad.");
            }
        }

        public void VerDescripcion(int id)
        {
            var tarea = tareas.Find(t => t.Id == id);
            if (tarea != null)
            {
                Console.WriteLine($"\n--- Descripcion de la Tarea ---");
                Console.WriteLine($"ID: {tarea.Id}");
                Console.WriteLine($"Titulo: {tarea.Titulo}");
                Console.WriteLine($"Descripcion: {tarea.Descripcion}");
                Console.WriteLine($"Prioridad: {tarea.Prioridad}");
                Console.WriteLine($"Fecha de Entrega: {tarea.FechaEntrega:yyyy-MM-dd}");
            }
            else
            {
                Console.WriteLine("Tarea No Encontrada.");
            }
        }
    }
}
