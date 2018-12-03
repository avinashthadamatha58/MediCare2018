using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyWeather.View
{
    public partial class WeatherView : ContentPage
    {
        public WeatherView()
        {
            InitializeComponent();

            if (Device.RuntimePlatform != Device.UWP)
                Icon = new FileImageSource { File = "pills.png" };


            MessagingCenter.Subscribe<object, string>(this, "UpdateLabel", (s, e) =>
            {

                Device.BeginInvokeOnMainThread(() =>
                {

                    BackgroundServiceLabel.Text = e;
                });
            });
        }
       

        //protected override void OnAppearing()
        //{
        //base.OnAppearing();

        //    MessagingCenter.Subscribe<object, string>(this, App.NotificationReceivedKey, OnMessageReceived);
        //}

        //void OnMessageReceived(object sender, string msg)
        //{
        //    Device.BeginInvokeOnMainThread(() => { lblMsg.Text = msg; });
        //}
        ////async void OnBtnSendClicked(object sender, EventArgs e)
        ////{
        ////    Debug.WriteLine($"Sending message: " + txtMsg.Text);

        ////    var content = new StringContent("\"" + txtMsg.Text + "\"", Encoding.UTF8, "application/json");
        ////    var result = await _client.PostAsync("xamunotifications", content);
        ////    Debug.WriteLine("Send result: " + result.IsSuccessStatusCode);
        ////}

        //protected override void OnDisappearing()
        //{
        //    base.OnDisappearing();
        //    MessagingCenter.Unsubscribe<object>(this, App.NotificationReceivedKey);
        //}
    }
}
