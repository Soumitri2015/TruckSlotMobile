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
    public partial class LoginPage : ContentPage
    {
        int count = 0;
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
       
        async void LogginButtton(object sender, EventArgs e)
        {
           
            var LoginEmail = Email.Text;
            var LoginPassword = Password.Text;
            if(LoginEmail==null ||LoginEmail==""||LoginPassword==null || LoginPassword=="")
            {
                await DisplayAlert("Alert", "Please EnterYour Email And Password", "OK");
            }
            else
            {
                var disp = new  CreditCardPage();
                await Navigation.PushModalAsync(disp);
            }
        }

       
    }
}