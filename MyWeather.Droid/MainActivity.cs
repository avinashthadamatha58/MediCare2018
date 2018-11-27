
using System;
using Android.App;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Plugin.Permissions;
using Android.Content.PM;
using Android.Gms.Common;
using Firebase.Auth;
using Firebase.Iid;
using Firebase.Messaging;
using Plugin.CurrentActivity;

namespace MyWeather.Droid
{
    [Activity(Label = "MediCare Anjanika",
    Icon = "@mipmap/launcher",
    LaunchMode = LaunchMode.SingleTask,
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {

		protected override void OnCreate (Bundle bundle)
		{
		    ToolbarResource = Resource.Layout.Toolbar;
		    TabLayoutResource = Resource.Layout.Tabbar;

		    base.OnCreate (bundle);
            Xamarin.Essentials.Platform.Init(this, bundle);
            CrossCurrentActivity.Current.Init(this, bundle);
            Forms.Init(this, bundle);
		
		    LoadApplication(new App());

		   // IsPlayServicesAvailable();

		}

        //public bool IsPlayServicesAvailable()
        //{
        //    int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
        //    if (resultCode != ConnectionResult.Success)
        //    {
        //        if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
        //        {
        //            Console.WriteLine($"Error: {GoogleApiAvailability.Instance.GetErrorString(resultCode)}");
        //        }
        //        else
        //        {
        //           Console.WriteLine("Error: Play services not supported!");
        //        }

        //        return false;
        //    }
        //    else
        //    {
        //        Console.WriteLine("Play Services Available");
        //        return true;
        //    }
        //}

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

    //[Service]
    //[IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    //public class MyFirebaseIIDService : FirebaseInstanceIdService
    //{
    //    public override void OnTokenRefresh()
    //    {
    //        var refreshedToken = FirebaseInstanceId.Instance.Token;
    //        Console.WriteLine($"Token Received: {refreshedToken}");
    //        SendRegistrationToServer(refreshedToken);
    //    }

    //    private void SendRegistrationToServer(string refreshedToken)
    //    {
    //        //throw new NotImplementedException();
    //    }
    //}
    ////to display in notification center
    //[Service]
    //[IntentFilter(new[] {"com.google.firebase.MESSAGING_EVENT"})]
    //public class MyFirebaseMessagingService : FirebaseMessagingService
    //{
    //    public override void OnMessageReceived(RemoteMessage message)
    //    {
    //        base.OnMessageReceived(message);

    //        Console.WriteLine("Received" + message);

    //        try
    //        {
    //            var msg = message.GetNotification().ToString();
    //            MessagingCenter.Send<object, string>(this, MyWeather.App.NotificationReceivedKey, msg);
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine("Error extracting message: "+ ex);
    //        }
    //    }
    //}
}


