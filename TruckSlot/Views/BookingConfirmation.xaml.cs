using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckSlot.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruckSlot.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookingConfirmation : ContentPage
    {
        public BookingConfirmation( string BookingId="")
        {
            BookingReference.Text = CryptoEngine.Encrypt(BookingId);
            InitializeComponent();
        }
    }
}