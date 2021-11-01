using Acr.UserDialogs;
using Android.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace TruckSlot.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScannerPage : ContentPage
    {
        public ScannerPage()
        {
            InitializeComponent();
        }

        void  ZXingScannerView_OnScanResult(ZXing.Result result)
        {
          
            Device.BeginInvokeOnMainThread(() =>
            {
                if (result.Text != null)
                {
                    //UserDialogs.Instance.ShowLoading("Hold On");
                    //  ScanResult.Text = result.Text;
                    //var PageRedirect = new DriverInformation(result.Text);
                    //await Navigation.PushModalAsync(PageRedirect);
                    //App.Current.MainPage = new DriverInformation(result.Text);

                    //var disp = new DriverInformation(result.Text);

                    ////UserDialogs.Instance.HideLoading();
                    //await Navigation.PushAsync(disp);

                    //UserDialogs.Instance.ShowLoading("Hold On");

                    Navigation.PushAsync(new DriverInformation(result.Text));
                   //var Display = new DriverInformation(result.Text);
                   // App.Current.MainPage = Navigation.PushAsync.Display();
                    //UserDialogs.Instance.HideLoading();
                }

            });
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            UserDialogs.Instance.ShowLoading("Hold On We Are Getting Your Slot Data");
            //UserDialogs.Instance.Loading("Hold on");
          
            var disp = new DriverInformation();
            await Navigation.PushAsync(disp);
            UserDialogs.Instance.HideLoading();
        }
    }
}

