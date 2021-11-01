using System;
using System.Collections.Generic;
using System.ComponentModel;
using TruckSlot.Models;
using TruckSlot.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruckSlot.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}