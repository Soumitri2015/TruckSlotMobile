using Acr.UserDialogs;
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
    public partial class DriverInformation : ContentPage
    {
        string SlotId1 = "N0WbPQtsEHEwf_ZMVCY9Wg==";
        public DriverInformation(string Id = "")
        {
            //SlotId1 = Id;
            InitializeComponent();
           
        }

        private async void Confirm_Clicked(object sender, EventArgs e)
        {
            var Name = Drivername.Text;
            var Phone = DriverPhone.Text;
            var Address = DriverAddress.Text;
            var Email = DriverEmail.Text;
            var SlotID = SlotId1;
            if (Name == null || Phone == "" || Address == null || Email == "")
            {
                await DisplayAlert("Alert", "Please EnterYour Details", "OK");
            }
            else
            {

                //For Popup

                if (!this.popuplayout.IsVisible)
                {
                    this.popuplayout.IsVisible = !this.popuplayout.IsVisible;
                    this.popuplayout.AnchorX = 1;
                    this.popuplayout.AnchorY = 1;

                    Animation scaleAnimation = new Animation(
                        f => this.popuplayout.Scale = f,
                        0.5,
                        1,
                        Easing.SinInOut);

                    Animation fadeAnimation = new Animation(
                        f => this.popuplayout.Opacity = f,
                        0,
                        1,
                        Easing.SinInOut);
                    scaleAnimation.Commit(this.popuplayout, "popupScaleAnimation", 250);
                    fadeAnimation.Commit(this.popuplayout, "popupFadeAnimation", 250);
                    //DriverTextBox.IsVisible = false;
                    DriverTextBox.IsVisible = false;
                    ButtonsDown.IsVisible = false;
                    
                }
                else
                {
                    await Task.WhenAny<bool>
                      (
                        this.popuplayout.FadeTo(0, 200, Easing.SinInOut)
                      );

                    this.popuplayout.IsVisible = !this.popuplayout.IsVisible;
                }

                //var disp = new CreditCardPage(Name, Address, Email, Phone, SlotID.ToString());
                //await Navigation.PushAsync(disp);
            }
        }

        private async void NotPayment(object sender, EventArgs e)
        {
            await Task.WhenAny<bool>
                     (
                       this.popuplayout.FadeTo(0, 200, Easing.SinInOut)
                     );

            this.popuplayout.IsVisible = !this.popuplayout.IsVisible;
            DriverTextBox.IsVisible = true;
            ButtonsDown.IsVisible = true;
            popuplayout.IsVisible = false;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if(DriverEmail.TextColor==Color.Red)
            {
                await DisplayAlert("Alert", "Please Set A valid Email", "OK");
                DriverTextBox.IsVisible = true;
                ButtonsDown.IsVisible = true;
                popuplayout.IsVisible = false;
            }
            else
            {
                var Name = Drivername.Text;
                var Phone = DriverPhone.Text;
                var Address = DriverAddress.Text;
                var Email = DriverEmail.Text;
                var SlotID = SlotId1;
                var disp = new CreditCardPage(Name, Address, Email, Phone, SlotID.ToString());
                await Navigation.PushAsync(disp);
            }
           
        }


        private async void CloseButton_Clicked(object sender, EventArgs e)
        {


          var AlertData=  await DisplayAlert("Alert", "Click Yes To Close", "Yes","No");

            if(AlertData==true)
            {
                var RedirectTo = new ScannerPage();
                await Navigation.PushAsync(RedirectTo);
            }
       
         }
    }
}

