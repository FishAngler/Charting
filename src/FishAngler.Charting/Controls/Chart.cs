using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace FishAngler.Charting.Controls
{
    public class Chart : View
    {
        private int _width;
        private int _height;

        private const int MARGIN = 10;
        private const int SECTION_MARGIN = 10;
        private const int RADIUS = 5;

        private int YLabelsAxisWidth = 30;
        private int TitleHeight = 20;
        private int XAxisLabelsHeight = 40;

        Paint _bgPaint;
        Title _title;
        TitleRight _titleRight;
        ChartRegion _chartRegion;
        XAxisLabels _xAxisLabels;
        YAxisLabels _yAxisLabels;

        public Chart(Context ctx) : base(ctx)
        {
            SetBackgroundColor(Android.Graphics.Color.Transparent);

            _bgPaint = new Paint();
            _bgPaint.SetStyle(Paint.Style.Fill);
            _bgPaint.SetARGB(200, 22, 69, 93);

            _chartRegion = new ChartRegion();
            _title = new Title();
            _titleRight = new TitleRight();
            _xAxisLabels = new XAxisLabels();
            _yAxisLabels = new YAxisLabels();
        }

        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            base.OnSizeChanged(w, h, oldw, oldh);

            _width = w;
            _height = h;
        }

        public int NumberGridLines
        {
            get { return _chartRegion.NumberGridLines; }
            set
            {
                _chartRegion.NumberGridLines = value;
                _yAxisLabels.NumberGridLines = value;
            }
        }

        public int NumberPoints
        {
            get { return _chartRegion.NumberPoints; }
            set
            {
                _chartRegion.NumberPoints = value;
                _xAxisLabels.NumberPoints = value;
            }
        }

        public String Title1
        {
            get { return _title.Title1; }
            set { _title.Title1 = value; }
        }

        public String Title2
        {
            get { return _title.Title2; }
            set { _title.Title2 = value; }
        }


        public override void Draw(Canvas canvas)
        {
            base.Draw(canvas);

            var sectionMarginPixels = (SECTION_MARGIN).ToDIP(Resources);

            var chartRect = new RectF((MARGIN).ToDIP(Resources), (MARGIN).ToDIP(Resources), (canvas.Width - (MARGIN * 2).ToDIP(Resources)), (canvas.Height - (MARGIN * 2).ToDIP(Resources)));

            canvas.DrawRoundRect(chartRect, (RADIUS).ToDIP(Resources), (RADIUS).ToDIP(Resources), _bgPaint);
            
            var chartRegionTop = (2 * sectionMarginPixels) + (TitleHeight).ToDIP(Resources) + chartRect.Top;
            var chartRegionBottom = chartRect.Bottom - ((2 * sectionMarginPixels) + (XAxisLabelsHeight).ToDIP(Resources));

            var yAxisRegion = new RectF(sectionMarginPixels + chartRect.Left, chartRegionTop, chartRect.Left + sectionMarginPixels + (YLabelsAxisWidth).ToDIP(Resources), chartRegionBottom );

            var titleRegion = new RectF(sectionMarginPixels + yAxisRegion.Right, sectionMarginPixels + chartRect.Top, chartRect.Right - sectionMarginPixels, chartRect.Top + sectionMarginPixels + (TitleHeight).ToDIP(Resources));

            var chartRegionRect = new RectF(yAxisRegion.Right + sectionMarginPixels, chartRegionTop, titleRegion.Right, chartRegionBottom);

            var xAxisRegion = new RectF(chartRegionRect.Left, yAxisRegion.Bottom + sectionMarginPixels,  chartRegionRect.Right, chartRect.Bottom - sectionMarginPixels);

            _yAxisLabels.Draw(yAxisRegion, canvas, Resources);
            _title.Draw(titleRegion, canvas, Resources);
            _chartRegion.Draw(chartRegionRect, canvas, Resources);
            _xAxisLabels.Draw(xAxisRegion, canvas, Resources);
        }
    }
}