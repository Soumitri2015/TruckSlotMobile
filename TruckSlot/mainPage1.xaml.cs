using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckSlot.MenuItems;
using TruckSlot.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruckSlot
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class mainPage1 : MasterDetailPage
    {
        public List<MasterPageItem> menuList{get;set;}  
   
        public mainPage1()
        {
            InitializeComponent();
            menuList = new List<MasterPageItem>();
           
            menuList.Add(new MasterPageItem()
            {
                Title = "login Page",
                Icon = "homeicon.png",
                TargetType = typeof(LoginPage)
            });
            menuList.Add(new MasterPageItem()
            {
                Title = "Scanner",
                Icon = "contacticon.png",
                TargetType = typeof(ScannerPage)
            });
            menuList.Add(new MasterPageItem()
            {
                Title = "CreditCard",
                Icon = "abouticon.png",
                TargetType = typeof(CreditCardPage)
            });
            menuList.Add(new MasterPageItem()
            {
                Title = "DriverInformation",
                Icon = "icon.png",
                TargetType = typeof(DriverInformation)
            });
            // Setting our list to be ItemSource for ListView in MainPage.xaml  
            navigationDrawerList.ItemsSource = menuList;
            // Initial navigation, this can be used for our home page  
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(ScannerPage)));
        }
        // Event for Menu Item selection, here we are going to handle navigation based  
        // on user selection in menu ListView  
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;
           
            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;

          

        }
    }
}
   