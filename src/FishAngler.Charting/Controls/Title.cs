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
    class Title
    {
        Paint _bgPaint;
        Paint _title1Paint;
        Paint _title2Paint;

        public Title()
        {
            _bgPaint = new Paint();
            _bgPaint.SetStyle(Paint.Style.Fill);
            _bgPaint.SetARGB(200, 0, 255, 255);

            _title1Paint = new Paint();
            _title1Paint.TextSize = 18;
            _title1Paint.SetStyle(Paint.Style.Fill);
            _title1Paint.SetARGB(255, 255, 255, 255);

            _title2Paint = new Paint();
            
            _title2Paint.SetStyle(Paint.Style.Fill);
            _title2Paint.SetARGB(255, 255, 255, 255);
        }

        public String Title1 { get; set; }
        public String Title2 { get; set; }


        public void Draw(RectF rect, Canvas canvas, Android.Content.Res.Resources resources)
        {
            //canvas.DrawRect(rect, _bgPaint);

            _title1Paint.TextSize = (16).ToDIP(resources);
            _title1Paint.FakeBoldText = true;
            _title2Paint.TextSize = (12).ToDIP(resources);
            _title2Paint.FakeBoldText = true;

            canvas.DrawText(Title1, rect.Left, rect.Top + (10).ToDIP(resources), _title1Paint);
            canvas.DrawText(Title2, rect.Left, rect.Top + (30).ToDIP(resources), _title2Paint);
        }
    }
}