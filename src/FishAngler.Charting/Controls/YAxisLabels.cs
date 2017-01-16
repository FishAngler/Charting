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
using Android.Graphics;

namespace FishAngler.Charting.Controls
{
    class YAxisLabels
    {
        Paint _bgPaint;
        Paint _title1Paint;

        public YAxisLabels()
        {
            _bgPaint = new Paint();
            _bgPaint.SetStyle(Paint.Style.Fill);
            _bgPaint.SetARGB(200, 0, 255, 0);

            _title1Paint = new Paint();
            _title1Paint.TextSize = 18;
            _title1Paint.SetStyle(Paint.Style.Fill);
            _title1Paint.SetARGB(255, 255, 255, 255);
        }

        public int NumberGridLines { get; set; }


        public void Draw(RectF rect, Canvas canvas, Android.Content.Res.Resources resources)
        {
            var sectionHeight = rect.Height() / NumberGridLines;

            _title1Paint.TextSize = (16).ToDIP(resources);
            _title1Paint.FakeBoldText = true;

            for (var idx = 0; idx < NumberGridLines; ++idx)
            {
                var top = ((idx + 1) * sectionHeight) + rect.Top;
                canvas.DrawText((80-idx).ToString(), rect.Left, top + (8).ToDIP(resources), _title1Paint);
            }
        }
    }
}