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
    public partial class Scanner1 : ContentPage
    {
        private ZXingScannerPage scan;
        public Scanner1(ZXingScannerPage scan)
        {
            scan.OnScanResult += (Result) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();
                    QrCode.Text = Result.Text;
                });
            };
        }
    }
}