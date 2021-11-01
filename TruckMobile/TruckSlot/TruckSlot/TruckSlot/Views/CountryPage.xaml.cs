using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TruckSlot.Models;
using TruckSlot.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Xamarin.Essentials.Permissions;

namespace TruckSlot.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountryPage : ContentPage
    {
        private IList countries;

        public CountryPage()
        {
            InitializeComponent();
            LoadLocation();

        }


        private void LoadLocation()
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.BaseAddress = "https://app.scalehouseai.com";
                    var json = webClient.DownloadString("/api/SitesAPI/GetAllLocations");
                    var list = JsonConvert.DeserializeObject<List<LocationViewModel>>(json);
                    //return list.ToList();
                    this.Location.ItemsSource = list;
                }
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }


        async void submit_Clicked(object sender, EventArgs e)
        {
            BookingVM booking = new BookingVM();
            LocationViewModel sl = this.Location.SelectedItem as LocationViewModel;
            string Location = sl.ID.ToString();
            string Slots = this.Slots.Text;
            string PhoneNo = this.PhoneNo.Text;
            string CardName = this.CardName.Text;
            string CardNumber = this.CardNumber.Text;
            string ExpireDate = this.ExpireDate.Text;
            string CVV = this.CVV.Text;

            if (Location == "")
            {
                this.Location.BackgroundColor = Color.LightPink;
                return;
            }
            else
            {
                booking.SiteId = Convert.ToInt32(Location);
            }
            if (Slots == "")
            {
                this.Slots.BackgroundColor = Color.LightPink;
                return;
            }
            else
            {
                booking.SlotName = Slots;
            }
            if (PhoneNo == "")
            {
                this.PhoneNo.BackgroundColor = Color.LightPink;
                return;
            }
            else
            {
                booking.DriverMob = PhoneNo;
            }
            if (CardName == "")
            {
                this.CardName.BackgroundColor = Color.LightPink;
                return;
            }
            else
            {
                booking.DriverName = CardName;
            }
            if (CardNumber == "")
            {
                this.CardNumber.BackgroundColor = Color.LightPink;
                return;
            }
            else
            {
                booking.CardNumber = CardNumber;
            }
            if (ExpireDate == "")
            {
                this.ExpireDate.BackgroundColor = Color.LightPink;
                return;
            }
            else
            {
                string[] monthYear = ExpireDate.Split('/');
                int year = 1990, month = 1;
                if(monthYear.Length > 1)
                {
                    year = 2000 + Convert.ToInt32(monthYear[1]);
                    month = Convert.ToInt32(monthYear[0]);
                }
                booking.ExpiryDate = new DateTime(year, month ,1);
            }
            if (CVV == "")
            {
                this.CVV.BackgroundColor = Color.LightPink;
                return;
            }
            else
            {
                booking.Cvv = CVV;
            }

            savebooking(booking);
            this.Location.SelectedIndex = -1;
            this.Slots.Text = "";
            this.PhoneNo.Text = "";
            this.CardName.Text = "";
            this.CardNumber.Text = "";
            this.ExpireDate.Text = "";
            this.CVV.Text = "";
            await Navigation.PushAsync(new CountryPage1());
        }

        private void savebooking(BookingVM booking)
        {
            try
            {
                string url = "https://app.scalehouseai.com/api/BookingAPI/CreateBookingMobile";
                using (var client = new WebClient())
                {
                    var dataString = JsonConvert.SerializeObject(booking);
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    client.UploadString(new Uri(url), "POST", dataString);
                }
            }
            catch(Exception ex)
            { }            
        }
    }

}