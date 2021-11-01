using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TruckSlot.Droid.Custom_Render;
using TruckSlot.Models;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using DatePicker = Xamarin.Forms.DatePicker;

//[assembly: ExportRenderer(typeof(DatePickerCtrl), typeof(DatePickerCtrlRenderer))]
namespace TruckSlot.Droid.Custom_Render
{
    // public class DatePickerCtrlRenderer: DatePickerRenderer
    //{
    //    public static void Init() { }
    //    protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
    //    {
    //        base.OnElementChanged(e);
    //        if (e.OldElement == null)
    //        {
    //            Control.Background = null;

    //            var layoutParams = new MarginLayoutParams(Control.LayoutParameters);
    //            layoutParams.SetMargins(0, 0, 0, 0);
    //            LayoutParameters = layoutParams;
    //            Control.LayoutParameters = layoutParams;
    //            Control.SetPadding(0, 0, 0, 0);
    //            SetPadding(0, 0, 0, 0);
    //        }
    //    }

    //}
}