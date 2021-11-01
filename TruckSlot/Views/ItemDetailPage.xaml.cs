using System.ComponentModel;
using TruckSlot.ViewModels;
using Xamarin.Forms;

namespace TruckSlot.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}