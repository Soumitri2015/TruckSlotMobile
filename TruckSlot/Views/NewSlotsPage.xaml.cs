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
    public partial class NewSlotsPage : ContentPage
    {


        public NewSlotsPage(string SiteId = "", string SlotId = "")
        {
            InitializeComponent();
            BindingContext = new MyListPageViewModel(SiteId, SlotId);
        }
    }
}