
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AdministradorTareas.Droid
{
	[BroadcastReceiver]
	public class Receptor : BroadcastReceiver
	{
		public override void OnReceive (Context c, Intent intent)
		{
			PowerManager pm = (PowerManager)c.GetSystemService(Context.PowerService);
			PowerManager.WakeLock wl = pm.NewWakeLock (WakeLockFlags.Partial, "Notificacion"); 
			wl.Acquire (); 
			NotificationManager manager = (NotificationManager)c.GetSystemService (Context.NotificationService); 
			Notification notification = new Notification (Resource.Drawable.icon, "Tareas pendientes"); 
			PendingIntent pendiente = PendingIntent.GetActivity (c, 0, new Intent (c, typeof(MainActivity)), 0); 
			notification.SetLatestEventInfo (c, "Tareas pendientes", "Tienes tareas por hacer", pendiente); 
			manager.Notify (0, notification); 
			wl.Release ();
		}
	}
}

