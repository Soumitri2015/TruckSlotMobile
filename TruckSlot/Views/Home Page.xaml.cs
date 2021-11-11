using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckSlot.Helpers;
using TruckSlot.Models;
using TruckSlot.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruckSlot.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home_Page : ContentPage
    {

        //protected void OnAppearing()
        //{
        //    GetLocation();
        //}

        private async Task<LocationVM> GetLocation()
        {
            LocationVM locationVM = new LocationVM();
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                var loc = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

                if (location != null)
                {
                    try
                    {
                        var lat = location.Latitude;
                        var lon = location.Longitude;

                        var placemarks = await Geocoding.GetPlacemarksAsync(lat, lon);

                        var placemark = placemarks?.FirstOrDefault();
                        if (placemark != null)
                        {


                            locationVM.longitude = (decimal)location.Longitude;
                            locationVM.lattitude = (decimal)location.Latitude;
                            locationVM.Location = placemark.SubLocality;
                            return locationVM;
                        }
                    }
                    catch (FeatureNotSupportedException fnsEx)
                    {
                        return locationVM;
                    }
                    catch (Exception ex)
                    {
                        return locationVM;
                    }
                    return locationVM;

                }
                return locationVM;
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await DisplayAlert("Faild", fnsEx.Message, "OK");
            }
            catch (PermissionException pEx)
            {
                await DisplayAlert("Faild", pEx.Message, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Faild", ex.Message, "OK");
            }
            return locationVM;
        }

        public Home_Page(string Locaion="",string Lat="",string Long="")
        {
            var data = Task.Run(async () => await GetLocation());
            var res = data.Result;

            if (res!=null)
            {
                BindingContext = new SitesListByLocation(res.lattitude.ToString(),res.longitude.ToString());
            //    //LocationName.Text = Locaion;
            //    APICall aPICall = new APICall();
            //    Uri url1 = new Uri("https://app.scalehouseai.com/api/SitesAPI/GetAllSitesList?Lat/" +res.lattitude + "&Lang=" + res.longitude);
            //    Task<string> task1 = Task.Run<string>(async () => await aPICall.GetURL(url1));
            //      List<SitesVM> sites = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SitesVM>>(task1.Result);
            //
            }
            InitializeComponent();

           

        }

        public async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var disp = new ScannerPage();
            await Navigation.PushAsync(disp);
        }
    }
}