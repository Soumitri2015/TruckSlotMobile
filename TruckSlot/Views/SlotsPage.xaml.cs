using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckSlot.Helpers;
using TruckSlot.Models;
using TruckSlot.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruckSlot.Views
{
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SlotsPage : ContentPage
    {
        APICall aPICall = new APICall();
        public SlotsPage(string SiteId="",string SlotId="")
        {
            InitializeComponent();
           //var Slot= CryptoEngine.Decrypt(SlotId);
           // var SlotID = Slot.Substring(7);
            BindingContext = new MyListPageViewModel(SiteId, SlotId);
        }



        async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {


            try
            {
                Image frame = (Image)sender;
                TapGestureRecognizer tapGesture = (TapGestureRecognizer)frame.GestureRecognizers[0];
                await DisplayAlert("Info", "You selected " + tapGesture.CommandParameter.ToString(), "Ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "Ok");
            }
        }
    



        public Command<int> MessageOptions
        {
            get { return new Command<int>(i => MessageClickedCommand(i)); }
        }

        async void MessageClickedCommand(int id)
        {
            await DisplayAlert("Information", $"The id of this message is: {id}", "Ok");
        }

     
    }
}