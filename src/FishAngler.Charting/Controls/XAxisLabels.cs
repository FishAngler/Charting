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
    class XAxisLabels
    {
        Paint _bgPaint;
        Paint _title1Paint;

        public XAxisLabels()
        {
            _bgPaint = new Paint();
            _bgPaint.SetStyle(Paint.Style.Fill);
            _bgPaint.SetARGB(255, 255, 0, 0);


            _title1Paint = new Paint();
            _title1Paint.TextSize = 18;
            _title1Paint.SetStyle(Paint.Style.Fill);
            _title1Paint.SetARGB(255, 255, 255, 255);
        }

        public int NumberPoints { get; set; }


        public void Draw(RectF rect, Canvas canvas, Android.Content.Res.Resources resources)
        {
            var pointWidth = rect.Width() / NumberPoints;

            _title1Paint.TextSize = (12).ToDIP(resources);
            _title1Paint.FakeBoldText = true;

            for (var idx = 0; idx < NumberPoints; ++idx)
            {
                var x1 = idx * pointWidth + rect.Left;
                var x2 = (idx + 1) * pointWidth + rect.Left;

                if(idx == 0)
                    canvas.DrawText($"Now", x1, rect.Top + (10).ToDIP(resources), _title1Paint);
                else
                    canvas.DrawText($"{idx}:00", x1, rect.Top + (10).ToDIP(resources), _title1Paint);
            }
        }
    }
}