using System;
using TruckSlot.Services;
using TruckSlot.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruckSlot
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new CountryPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
