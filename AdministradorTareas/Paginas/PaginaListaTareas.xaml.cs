using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AdministradorTareas
{
	public partial class PaginaListaTareas : ContentPage
	{
		public PaginaListaTareas ()
		{
			InitializeComponent ();
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			lstTareas.ItemsSource = App.BD.ObtenerTareas ();
		}

		void SeleccionarTarea(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem != null) {
				Tareas tarea = (Tareas)e.SelectedItem;
				PaginaEdicionTareas pagina = new PaginaEdicionTareas ();
				pagina.id = tarea.ID;

				Navigation.PushAsync (pagina);
			}
		}

		void NuevaTarea(object sender, EventArgs e)
		{
			Navigation.PushAsync (new PaginaEdicionTareas ());
		}
	}
}

