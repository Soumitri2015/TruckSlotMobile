using Acr.UserDialogs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TruckSlot.Helpers;
using TruckSlot.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruckSlot.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreditCardPage : ContentPage
    {
        APICall aPICall = new APICall();
        string Name = "";
        string address = "";
        string Email = "";
        string Phone = "";
        string Slotid1 = "";
           
        public CreditCardPage(string DName="",string DAddress="",string DEmail="",string DPhone="",string SlotID="")
        {
            Name = DName;
            address = DAddress;
            Email = DEmail;
            Phone = DPhone;
            Slotid1 = SlotID;

            //Email.Text = DEmail;
            //Address.Text = DAddress;
            //Phone.Text = DPhone;
            //Name.Text = DName;
            //SlotId.Text = SlotID;
            //Name.Text = DName;




            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            UserDialogs.Instance.ShowLoading("Hold On");
            int Slotid = 0;
            int CompanyId = 0;
            int SiteID = 0;
            int PaymentID = 0;

            var DEmail = Email;
            var DName = Name;
            var DAddress = address;
            var DPhone = Phone;
            var SlotI = Slotid1;
            var CardHolderName = HolderName.Text;
            var CardNumber = CardNumberEntry.Text;
            var Expiry = CardExpiry.Text;
            var Cvv = CardCvv.Text;
            var Slot = CryptoEngine.Decrypt(Slotid1.ToString());
            var DecryptSlotID = Slot.Substring(7);


            //For Getting SiteID And CompanyId


            Uri url = new Uri("https://app.scalehouseai.com/api/SlotsAPI/GetSlotsByIdByMobileAPI/" + DecryptSlotID);
            Task<string> task = Task.Run<string>(async () => await aPICall.GetURL(url));
            SlotsVM slotsVM = Newtonsoft.Json.JsonConvert.DeserializeObject<SlotsVM>(task.Result);
            if (slotsVM != null)
            {
                SiteID = slotsVM.SiteId;
                Slotid = slotsVM.SlotId;

                Uri urlForSites = new Uri("https://app.scalehouseai.com/api/SitesAPI/GetSitesByIdByMobileAPI/" + SiteID);
                Task<string> rersult = Task.Run<string>(async () => await aPICall.GetURL(urlForSites));
                SitesVM sitesVM = Newtonsoft.Json.JsonConvert.DeserializeObject<SitesVM>(rersult.Result);
                if(sitesVM !=null)
                {
                    CompanyId = sitesVM.CompanyId;

                    //Entry In Payment Table

                    PaymentVM paymentVM = new PaymentVM();
                    paymentVM.CardHolderName = CardHolderName;
                    paymentVM.CardNumber = CardNumber;
                    paymentVM.ExpiryDate = Expiry;
                    paymentVM.Cvv = Cvv;
                    paymentVM.CompanyId = CompanyId;
                    paymentVM.SiteId = SiteID;


                    Uri u = new Uri("https://app.scalehouseai.com/api/TruckAPI/CreatePaymentByMobileAPI");

                    var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(paymentVM);
                    var payload = jsonString;

                    HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");

                    Task<string> TaskForCreatePayment = Task.Run<string>(async () => await aPICall.PostURI(u, c));
                    ReturnAPIVM returnAPIVM  = Newtonsoft.Json.JsonConvert.DeserializeObject<ReturnAPIVM>(TaskForCreatePayment.Result);
                    if(returnAPIVM !=null)
                    {
                        PaymentID = returnAPIVM.Id;

                        //Entry In TruckLotBookBook Table
                   
                        TruckLotBook bookingVM = new TruckLotBook();
                        bookingVM.DriverEmail = DEmail;
                        bookingVM.DriverAddr = DAddress;
                        bookingVM.DriverName = DName;
                        bookingVM.TimeEntry = System.DateTime.Now;
                        bookingVM.TimeExit = null;
                        bookingVM.Hours = 24 * 60;
                        bookingVM.Status = 1;
                        bookingVM.SiteId = SiteID;
                        bookingVM.CompanyId = CompanyId;
                        bookingVM.SlotId = Slotid;
                        bookingVM.PaymentId = PaymentID;
                        


                        Uri urlForCreateTBooking = new Uri("https://app.scalehouseai.com/api/BookingAPI/CreateTruckLotBookingByMobileAPI");

                        var jsonStringForTBooking = Newtonsoft.Json.JsonConvert.SerializeObject(bookingVM);
                        var BookData = jsonStringForTBooking;

                        HttpContent contextFotTruckLot = new StringContent(BookData, Encoding.UTF8, "application/json");
                        Task<string> TaskForCreateTruckLot = Task.Run<string>(async () => await aPICall.PostURI(urlForCreateTBooking, contextFotTruckLot));

                        ReturnAPIVM returnAPIVMTruckLot = Newtonsoft.Json.JsonConvert.DeserializeObject<ReturnAPIVM>(TaskForCreateTruckLot.Result);
                        UserDialogs.Instance.HideLoading();
                        var disp = new NewSlotsPage(SiteID.ToString(), Slotid1.ToString());


                        await Navigation.PushAsync(disp);
                        //App.Current.MainPage = new SlotsPage1(SiteID.ToString(), Slotid1.ToString());

                    }

                }

            }

          


        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (RememberMeCheck.IsChecked == false)
            {
                RememberMeCheck.IsChecked = true;
            }
            else if (RememberMeCheck.IsChecked ==true)
            {
                RememberMeCheck.IsChecked = false;
            }
           
        }

        async Task<string> PostURI(Uri uri, HttpContent context)
        {
            var response = string.Empty;
            using (var client = new HttpClient())
            {
                HttpResponseMessage result = await client.PostAsync(uri, context);
                if (result.IsSuccessStatusCode)
                {
                    response = result.StatusCode.ToString();
                }
            }
            return response;
        }

        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "Clicked on ToolBar", "OK");
        }
    }
   
}