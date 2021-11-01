using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruckSlot
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TruckSlot.Views.Home_Page())
            {
                BarBackgroundColor = Color.RoyalBlue
            };
            
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
