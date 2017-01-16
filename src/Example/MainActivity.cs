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

            var scoller = new ScrollView(this);
            scoller.LayoutParameters = new Android.Views.ViewGroup.LayoutParams(Android.Views.ViewGroup.LayoutParams.MatchParent, Android.Views.ViewGroup.LayoutParams.MatchParent);

            var chartContainer = new LinearLayout(this);
            chartContainer.LayoutParameters = new Android.Views.ViewGroup.LayoutParams(Android.Views.ViewGroup.LayoutParams.MatchParent, Android.Views.ViewGroup.LayoutParams.WrapContent);
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
            chart2.NumberPoints = 8;
            chart2.Title1 = "Water Temp (C)";
            chart2.Title2 = "Water Temp is Changing A Lot";
            chart2.LayoutParameters = new Android.Views.ViewGroup.LayoutParams(Android.Views.ViewGroup.LayoutParams.MatchParent, (350).ToDIP(Resources));
            chartContainer.AddView(chart2);


            var chart3 = new Chart(this);
            chart3.NumberGridLines = 5;
            chart3.NumberPoints = 6;
            chart3.Title1 = "Fish Forecast (C)";
            chart3.Title2 = "Best time to catch fish";
            chart3.LayoutParameters = new Android.Views.ViewGroup.LayoutParams(Android.Views.ViewGroup.LayoutParams.MatchParent, (350).ToDIP(Resources));
            chartContainer.AddView(chart3);


            scoller.AddView(chartContainer);

            SetContentView(scoller);
        }
    }
}

