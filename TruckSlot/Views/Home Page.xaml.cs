using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruckSlot.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home_Page : ContentPage
    {
        public Home_Page()
        {
            InitializeComponent();
        }

        public async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var disp = new ScannerPage();
            await Navigation.PushAsync(disp);
        }
    }
}