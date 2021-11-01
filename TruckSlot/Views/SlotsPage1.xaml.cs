using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckSlot.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruckSlot.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SlotsPage1 : ContentPage
    {
        public SlotsPage1( string SiteId="",string SlotId="")
        {
            InitializeComponent();
            BindingContext = new MyListPageViewModel(SiteId, SlotId);
        }

        async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {


            try
            {
                Image frame = (Image)sender;
                TapGestureRecognizer tapGesture = (TapGestureRecognizer)frame.GestureRecognizers[0];
                await DisplayAlert("Info", "You selected " + tapGesture.CommandParameter.ToString(), "Ok");
            }
            catch(Exception ex)
            {

            }
           
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var disp = new ScannerPage();
            //await Navigation.PushModalAsync(disp);

            await Navigation.PushAsync(disp);
        }
    }
}