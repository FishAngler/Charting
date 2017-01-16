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
    public class ChartRegion
    {
        Paint _gridLinePaint;
        Paint _linePaint;
        Paint _circleOutline;
        Paint _circlePaint;
        Paint _bgPaint;

        public ChartRegion()
        {
            _bgPaint = new Paint();
            _bgPaint.SetStyle(Paint.Style.Fill);
            _bgPaint.SetARGB(30, 255, 255, 255);

            _gridLinePaint = new Paint();
            _gridLinePaint.SetStyle(Paint.Style.Fill);
            _gridLinePaint.SetARGB(127, 255, 255, 255);

            _circlePaint = new Paint();
            _circlePaint.SetStyle(Paint.Style.Fill);
            _circlePaint.SetARGB(255, 255, 255, 255);

            _linePaint = new Paint();
            
            _linePaint.SetStyle(Paint.Style.Stroke);
            _linePaint.SetARGB(255, 255, 255, 255);

            _circleOutline = new Paint();
            _circleOutline.SetStyle(Paint.Style.Stroke);
            _circleOutline.SetARGB(200, 22, 69, 93);

            NumberGridLines = 8;
        }

        public int NumberGridLines { get; set; }
        public int NumberPoints { get; set; }


        public void Draw(RectF rect, Canvas canvas, Android.Content.Res.Resources resources)
        {
            //canvas.DrawRect(rect, _bgPaint);

            _linePaint.StrokeWidth = (2).ToDIP(resources);
            _circleOutline.StrokeWidth = (2).ToDIP(resources);

            var sectionHeight = rect.Height() / NumberGridLines;
            var pointWidth = rect.Width() / NumberPoints;

            for(var idx =0; idx < NumberGridLines; ++idx)
            {
                var top = ((idx + 1) * sectionHeight) + rect.Top;
                var lineRect = new RectF(rect.Left, top, rect.Right, top + (2).ToDIP(resources));
                canvas.DrawRect(lineRect, _gridLinePaint);
            }

            var y = (rect.Bottom - rect.Top) / 2 + rect.Top;

            var rnd = new Random(DateTime.Now.Millisecond);

            for (var idx = 0; idx < NumberPoints; ++idx)
            {
                var x1 = idx * pointWidth + rect.Left;
                var x2 = (idx + 1) * pointWidth + rect.Left;
                var y1 = y;
                var y2 = rnd.Next((int)(rect.Top + sectionHeight), (int)rect.Bottom);
                y = y2;

                canvas.DrawLine(x1, y1, x2, y2, _linePaint);
                canvas.DrawCircle(x1, y1, (4).ToDIP(resources), _circlePaint);
                canvas.DrawCircle(x1, y1, (5).ToDIP(resources), _circleOutline);

                if(idx == NumberPoints - 1)
                {
                    canvas.DrawCircle(x2, y2, (4).ToDIP(resources), _circlePaint);
                    canvas.DrawCircle(x2, y2, (6).ToDIP(resources), _circleOutline);
                }
            }
        }

    }
}