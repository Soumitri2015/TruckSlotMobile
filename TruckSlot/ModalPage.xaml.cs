using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TruckSlot
{
    public partial class ModalPage : ContentPage
    {
        DateTime Date =new DateTime();
        public ModalPage()
        {
           
            InitializeComponent();
        }

        
         async void OnDismissButtonClicked(object sender,EventArgs e)
        {
            await Navigation.PopModalAsync();

            //await DisplayAlert("Slot", "Slot-No-525", "OK");
        }
        async void BookConfirm(object sender, EventArgs e)
        {
            var DriverName = Drivername.Text;
            var Driveremail = DriverEmail.Text;
            var Driverphone = DriverPhone.Text;
            Date = DateEntry.Date;
            if(Driveremail ==null ||Driveremail=="")
            {
                await DisplayAlert("DriverEmail", "Please Enter Driver Email", "OK");
            }
            if (DriverName == null || DriverName == "")
            {
                await DisplayAlert("DriverName", "Please Enter Drive rName ", "OK");
            }
            if (Driverphone == null || Driverphone == "")
            {
                await DisplayAlert("Driverphone", "Please Enter Driverphone", "OK");
            }

        }
        private void MainDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
             Date =Convert.ToDateTime( e.NewDate.ToString());
        }
    }
}
