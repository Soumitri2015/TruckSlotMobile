using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckSlot.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruckSlot.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountryPage1 : ContentPage
    {
        private Picker _picker;

        public CountryPage1()
        {
            this.Title = "Confirmation ";
            InitializeComponent();
        }

        //protected override bool OnBackButtonPressed()
        //{
        //    // If you want to continue going back
        //    base.OnBackButtonPressed();
        //    return false;

        //    // If you want to stop the back button
        //    await Navigation.PushAsync(new CountryPage1());
        //    return true;

        //}
    }
}