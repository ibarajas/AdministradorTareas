using Android.Content;
using Xamarin.Forms;
using Android.OS;
using Android.App;

namespace AdministradorTareas.Droid
{
	public static class Utilerias
	{
		public static void CrearAlarma () { 
			Intent intencion = new Intent(Forms.Context, typeof(Receptor)); 
			PendingIntent pendiente = PendingIntent.GetBroadcast(Forms.Context, 0, intencion, PendingIntentFlags.UpdateCurrent); 
			AlarmManager alarma = (AlarmManager) Forms.Context.GetSystemService(Context.AlarmService); 
			alarma.Set(AlarmType.ElapsedRealtime, SystemClock.ElapsedRealtime () + 60000, pendiente); 
		}
	}
}

