using System;

using Xamarin.Forms;

namespace AdministradorTareas
{
	public class App : Application
	{
		public static BaseDatos BD;
		
		public App ()
		{
			#if __ANDROID__ 
			AdministradorTareas.Droid.Utilerias.CrearAlarma(); 
			#endif

			string db = "tareas1.db3";
			string ruta = System.IO.Path.Combine (Environment.GetFolderPath (
				              Environment.SpecialFolder.Personal), db);

			BD = new BaseDatos (ruta);

			// The root page of your application
			MainPage = new NavigationPage( new PaginaListaTareas() );
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

