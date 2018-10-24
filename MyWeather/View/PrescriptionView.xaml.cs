using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using MyWeather.Services;
using MyWeather.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyWeather.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrescriptionView : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public PrescriptionView()
        {
            InitializeComponent();
            if (Device.RuntimePlatform != Device.UWP)
                Icon = new FileImageSource { File = "prescription.png" };

            MyListView.ItemTapped += (sender, args) => MyListView.SelectedItem = null;

        }
    }
}
