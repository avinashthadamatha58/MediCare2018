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
using MyWeather.Services;
using Plugin.LocalNotifications;
using Xamarin.Forms;

namespace MyWeather.Droid.Services
{
    [BroadcastReceiver]
    public class BackgroundReceiver : BroadcastReceiver
    {
        public async override void OnReceive(Context context, Intent intent)
        {
            PowerManager pm = (PowerManager)context.GetSystemService(Context.PowerService);
            PowerManager.WakeLock wakeLock = pm.NewWakeLock(WakeLockFlags.Partial, "BackgroundReceiver");
            wakeLock.Acquire();

            var mediCareService = new MediCareService();
            var wappa = await mediCareService.GetDrug(1);
            // Wait(1000);
            LocalNotificationsImplementation.NotificationIconId = Resource.Drawable.love;
            CrossLocalNotifications.Current.Show("Time to take your medicines!", wappa.DrugName);
            MessagingCenter.Send<object, string>(this, "UpdateLabel", wappa.DrugName);

            wakeLock.Release();
        }
    }
}