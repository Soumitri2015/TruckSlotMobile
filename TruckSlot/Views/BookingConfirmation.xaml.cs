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
    public partial class BookingConfirmation : ContentPage
    {
        public BookingConfirmation( int BookingId)
        {
           var  BookingReference1 = CryptoEngine.Encrypt(BookingId.ToString());
           // BookingReference.Text = BookingReference1;
            InitializeComponent();
        }
    }
}