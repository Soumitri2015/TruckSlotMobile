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
    public partial class LoadingIndicator : ContentPage
    {
        public LoadingIndicator()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
                UserDialogs.Instance.ShowLoading("Hold On");
        }
    }
}