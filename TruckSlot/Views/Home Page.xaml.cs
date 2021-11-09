using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckSlot.Helpers;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruckSlot.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home_Page : ContentPage
    {

        protected override async void OnAppearing()
        {
            base.OnAppearing();
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
                            var disp = new Home_Page(placemark.SubLocality, lat.ToString(),lon.ToString());
                            await Navigation.PushAsync(disp);
                           
                        }
                    }
                    catch (FeatureNotSupportedException fnsEx)
                    {
                        // Feature not supported on device
                    }
                    catch (Exception ex)
                    {
                        // Handle exception that may have occurred in geocoding
                    }
                    //var revposition = new Xamarin.Forms.Maps.Position(location.Latitude, location.Longitude);
                    //var possibleAddresses = await Xamarin.Forms.Maps.Geocoder.GetAddressesForPositionAsync(revposition);


                }

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


        }
        
        public Home_Page(string Locaion="",string Lat="",string Long="")
        {
            if(Locaion!=null && Locaion!="")
            {
                //LocationName.Text = Locaion;
                APICall aPICall = new APICall();
                Uri url1 = new Uri("https://app.scalehouseai.com/api/SitesAPI/GetAllSitesList?Lat/" + Lat + "&Lang=" + Long);
                Task<string> task1 = Task.Run<string>(async () => await aPICall.GetURL(url1));
                
               
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