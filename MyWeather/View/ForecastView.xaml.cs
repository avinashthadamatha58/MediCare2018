using Xamarin.Forms;

namespace MyWeather.View
{
    public partial class ForecastView : ContentPage
    {
        public ForecastView()
        {
            InitializeComponent();
            if (Device.RuntimePlatform != Device.UWP)
                Icon = new FileImageSource { File = "folder.png" };

            ListViewWeather.ItemTapped += (sender, args) => ListViewWeather.SelectedItem = null;
        }
    }
}
