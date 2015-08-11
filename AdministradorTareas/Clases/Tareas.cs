using System;
using SQLite;

namespace AdministradorTareas
{
	[Table("Tareas")]
	public class Tareas
	{
		[PrimaryKey]
		public string ID { get; set; }
		public string Nombre { get; set; }
		public string Descripcion { get; set; }
		public int Tipo { get; set; }
		public bool Realizada { get; set; }
		public DateTime Fecha { get; set; }
	}
}

