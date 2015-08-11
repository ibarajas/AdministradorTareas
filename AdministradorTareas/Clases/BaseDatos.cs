using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using SQLite;

namespace AdministradorTareas
{
	public class BaseDatos : SQLiteConnection
	{
		ObservableCollection<Tareas> TablaTareas;
		
		public BaseDatos (string path) : base(path)
		{
			CrearTablas ();
		}

		void CrearTablas()
		{
			CreateTable<Tareas> ();
			TablaTareas = new ObservableCollection<Tareas> (this.Table<Tareas>().ToList() );
		}

		public ObservableCollection<Tareas> ObtenerTareas()
		{
			return new ObservableCollection<Tareas> (this.Table<Tareas>().ToList() );
		}

		public Tareas ObtenerTarea(string id)
		{
			return (id == "") 
				? new Tareas () 
					: Table<Tareas> ().Where (t => t.ID == id).First ();
					//: TablaTareas.Where (t => t.ID == id).First ();
		}

		public void Guardar(string id, string nombre, string descripcion,
			int tipo, bool realizada, DateTime fecha)
		{
			Tareas tarea = ObtenerTarea (id);
			tarea.Nombre = nombre;
			tarea.Descripcion = descripcion;
			tarea.Tipo = tipo;
			tarea.Realizada = realizada;
			tarea.Fecha = fecha;

			if (id == "")
				AgregarTarea (tarea);
			else
				ActualizarTarea (tarea);
		}

		void AgregarTarea (Tareas tarea)
		{
			tarea.ID = Guid.NewGuid ().ToString ();
			//TablaTareas.Add (tarea);
			this.Insert(tarea);
		}

		void ActualizarTarea(Tareas tarea)
		{
			//int pos = TablaTareas.IndexOf (tarea);
			//TablaTareas [pos] = tarea;
			this.Update(tarea);
		}

		public void EliminarTarea(string id)
		{
			Tareas tarea = TablaTareas.Where (t => t.ID == id).First ();
			//TablaTareas.Remove (tarea);
			this.Delete(tarea);
		}
	}
}

