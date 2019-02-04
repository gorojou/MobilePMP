using System;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Text;
using mobilePMP.Droid;
using mobilePMP.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomRenderer))] 
namespace mobilePMP.Droid
{
    
 
    public class CustomRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                GradientDrawable gd = new GradientDrawable();

                Control.BackgroundTintList = ColorStateList.ValueOf(global::Android.Graphics.Color.White);

                // The Above Line of Code is for making Entry Line with Any Color. Here I taken as WHITE

                //You can Change According to Ur Requirement’s

                Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
                Control.SetHintTextColor(ColorStateList.ValueOf(global::Android.Graphics.Color.White));

            }
        }
    }
}
