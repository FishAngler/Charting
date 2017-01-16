using Android.App;
using Android.Widget;
using Android.OS;
using FishAngler.Charting.Controls;

namespace FishAngler.Charting.Example
{
    [Activity(Label = "FishAngler.Charting.Example", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var chartContainer = new LinearLayout(this);
            chartContainer.Orientation = Orientation.Vertical;
            chartContainer.SetBackgroundColor(Android.Graphics.Color.White);

            var chart = new Chart(this);
            chart.Title1 = "Weather Forecast (F)";  
            chart.Title2 = "Hourly Forecast (time)";
            chart.NumberGridLines = 8;
            chart.NumberPoints = 6;
            chart.LayoutParameters = new Android.Views.ViewGroup.LayoutParams(Android.Views.ViewGroup.LayoutParams.MatchParent, (400).ToDIP(Resources));
            chartContainer.AddView(chart);


            var chart2 = new Chart(this);
            chart2.NumberGridLines = 3;
            chart2.NumberPoints = 12;
            chart2.Title1 = "Water Temp (C)";
            chart2.Title2 = "Water Temp is Changing A Lot";
            chart2.LayoutParameters = new Android.Views.ViewGroup.LayoutParams(Android.Views.ViewGroup.LayoutParams.MatchParent, (350).ToDIP(Resources));
            chartContainer.AddView(chart2);


            SetContentView(chartContainer);
        }
    }
}

