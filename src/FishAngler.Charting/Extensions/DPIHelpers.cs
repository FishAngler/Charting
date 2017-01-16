using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Util;

namespace FishAngler.Charting
{
    public static class DIPHelpers
    {
        public static int ToDIP(this int value, Android.Content.Res.Resources resource)
        {
            return Convert.ToInt32(TypedValue.ApplyDimension(ComplexUnitType.Dip, value, resource.DisplayMetrics));
        }

        public static int Pixel2Dp(this int value, Android.Content.Res.Resources resources)
        {
            DisplayMetrics metrics = resources.DisplayMetrics;
            int dp = value * (int)DisplayMetricsDensity.Default / (int)metrics.DensityDpi;
            return dp;
        }
    }
}