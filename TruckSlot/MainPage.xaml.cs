using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckSlot.MenuItems;
using TruckSlot.Views;
using Xamarin.Forms;

namespace TruckSlot
{
    public partial class MainPage : ContentPage
    {
        public List<MasterPageItem> menuList { get; set; }
        public MainPage()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                BookButton.IsVisible = false;

            });

            InitializeComponent();

          
        }

        private void TapImage(object sender, EventArgs e)
        {


            Device.BeginInvokeOnMainThread(() =>
            {
                if (BookButton.IsVisible == true)
                {
                    BookButton.IsVisible = false;
                }
                else
                {
                    BookButton.IsVisible = true;

                }

            });
        }
        async void OnButtonClicked(object sender, EventArgs e)
        {
            var disp = new ModalPage();
            await Navigation.PushModalAsync(disp);

            await DisplayAlert("Slot", "Slot-No-525", "OK");
        }
        private void MainDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            var Date = Convert.ToDateTime(e.NewDate.ToString());
        }
    }
}
