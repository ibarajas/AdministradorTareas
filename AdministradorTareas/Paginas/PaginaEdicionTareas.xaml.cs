using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AdministradorTareas
{
	public partial class PaginaEdicionTareas : ContentPage
	{
		public string id = "";

		public PaginaEdicionTareas ()
		{
			InitializeComponent ();
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			dtpFecha.MaximumDate = DateTime.Now;

			if (id != "") {
				Tareas tarea = App.BD.ObtenerTarea (id);
				txtNombre.Text = tarea.Nombre;
				txtDescripcion.Text = tarea.Descripcion;
				pckTipo.SelectedIndex = tarea.Tipo;
				swtRealizada.IsToggled = tarea.Realizada;
				dtpFecha.Date = tarea.Fecha;
			}
		}

		void MostrarFecha(object sender, ToggledEventArgs e)
		{
			bool mostrar = e.Value;
			lblFecha.IsVisible = mostrar;
			dtpFecha.IsVisible = mostrar;
		}

		void Guardar(object sender, EventArgs e)
		{
			string nombre = txtNombre.Text;
			string descripcion = txtDescripcion.Text;
			int tipo = pckTipo.SelectedIndex;
			bool realizada = swtRealizada.IsToggled;
			DateTime fecha = dtpFecha.Date;

			App.BD.Guardar (id, nombre, descripcion, tipo, realizada, fecha);
			DisplayAlert ("Exito", "La tarea ha sido guardada con exito", "OK");
		}

		void Eliminar(object sender, EventArgs e)
		{
			App.BD.EliminarTarea (id);
			DisplayAlert ("Exito", "La tarea ha sido eliminada con exito", "OK");
		}
	}
}

