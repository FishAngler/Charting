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
    public class TitleRight
    {

        Paint _bgPaint;

        public TitleRight()
        {
            _bgPaint = new Paint();
            _bgPaint.SetStyle(Paint.Style.Fill);
            _bgPaint.SetARGB(200, 255, 0, 0);
        }


        public void Draw(RectF rect, Canvas canvas, Android.Content.Res.Resources resources)
        {
            canvas.DrawRect(rect, _bgPaint);
        }
    }
}