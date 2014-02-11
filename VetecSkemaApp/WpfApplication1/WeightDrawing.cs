using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApplication1
{
    class WeightDrawing
    {
        Canvas canvas;
        int canvasSizeX;
        int canvasSizeY;

        public WeightDrawing(Canvas canvas)
        {
            this.canvas = canvas;
            canvasSizeX = 350;
            canvasSizeY = 225;
        }

        public void DrawWeight(uint A, uint B, uint C, uint D, uint E, uint F, uint G, uint H)
        {
            canvas.Children.Clear();

            double scaleFactorX = (double)canvasSizeX / ((double)A + (double)B + (double)C + (double)D + (double)E + (double)10);
            double scaleFactorY = (double)canvasSizeY / (Math.Max((double)G, (double)F));
            drawWeight(A, B, C, D, E, F, G, H, scaleFactorX, scaleFactorY);
            scaleCanvas(scaleFactorX, scaleFactorY);
        }

        private void drawWeight(uint A, uint B, uint C, uint D, uint E, uint F, uint G, uint H, double scaleFactorX, double scaleFactorY)
        {
            uint SP = 10;

            Dictionary<string, Point> points = calculateCoordinates(A, B, C, D, E, F, G, SP);

            drawLines(points["p1"], points["p2"], points["p8"], points["p9"], Brushes.Green, scaleFactorX); // G
            drawLines(points["p2"], points["p3"], points["p1"], points["p16"], Brushes.Orange, scaleFactorY); // D
            drawLines(points["p15"], points["p16"], points["p13"], points["p14"], Brushes.Purple, scaleFactorX); // F
            drawLines(points["p3"], points["p4"], points["p14"], points["p15"], Brushes.Blue, scaleFactorY); // E
            drawLines(points["p4"], points["p5"], points["p13"], points["p12"], Brushes.PaleTurquoise, scaleFactorY); // C
            drawLines(points["p5"], points["p6"], points["p12"], points["p11"], Brushes.Red, scaleFactorY); // A
            drawLines(points["p6"], points["p7"], points["p11"], points["p10"], Brushes.Black, scaleFactorY); // B
            drawLines(points["p7"], points["p8"], points["p10"], points["p9"], Brushes.Gold, scaleFactorY); // SP
            drawLines(points["p7"], points["p8"], points["p10"], points["p9"], Brushes.Gold, scaleFactorY); // SP

            drawLine(points["p6"], points["p11"], Brushes.Black, scaleFactorX, true);
            drawLine(points["p7"], points["p10"], Brushes.Black, scaleFactorX, true);
            drawLine(points["p3"], points["p16"], Brushes.Black, scaleFactorX, true);
            drawLine(points["p4"], points["p14"], Brushes.Black, scaleFactorX, true);

            Point p17 = new Point(points["p6"].X - A/2 - H/2, 0);
            Point p18 = new Point(points["p6"].X - A/2 + H/2, 0);

            drawLine(p17, p18, Brushes.Green, scaleFactorY, false);
        }

        private Dictionary<string, Point> calculateCoordinates(uint A, uint B, uint C, uint D, uint E, uint F, uint G, uint SP)
        {
            Dictionary<string, Point> points = new Dictionary<string, Point>
            {
                {"p1", new Point(0, 0)},
                {"p2", new Point(0, G)},
                {"p3", new Point(D, G)},
                {"p4", new Point(D + E, G)},
                {"p5", new Point(D + E + C, G)},
                {"p6", new Point(D + E + C + A, G)},
                {"p7", new Point(D + E + C + A + B, G)},
                {"p8", new Point(D + E + C + A + B + SP, G)},
                {"p9", new Point(D + E + C + A + B + SP, 0)},
                {"p10", new Point(D + E + C + A + B, 0)},
                {"p11", new Point(D + E + C + A, 0)},
                {"p12", new Point(D + E + C, 0)},
                {"p13", new Point(D + E, 0)},
                {"p14", new Point(D + E, F)},
                {"p15", new Point(D, F)},
                {"p16", new Point(D, 0)}
            };

            return points;
        }

        private void drawLine(Point p1, Point p2, SolidColorBrush color, double scaleFactor, bool dashed)
        {
            Line line = new Line();
            line.Stroke = color;
            line.StrokeThickness = 3 * (1d / scaleFactor);
            if (dashed == true)
            {
                line.StrokeDashArray = new DoubleCollection() { 2 * scaleFactor, 2 * scaleFactor };
                line.StrokeThickness *= 0.5;
            }
            else
            {
                line.StrokeThickness *= 1.5;
            }

            line.X1 = p1.X;
            line.Y1 = p1.Y;
            line.X2 = p2.X;
            line.Y2 = p2.Y;

            canvas.Children.Add(line);
        }

        private void drawLines(Point p1, Point p2, Point p3, Point p4, SolidColorBrush color, double scaleFactor)
        {
            Line line1 = new Line();
            line1.Stroke = color;
            line1.StrokeThickness = 3 * (1d / scaleFactor);

            line1.X1 = p1.X;
            line1.Y1 = p1.Y;
            line1.X2 = p2.X;
            line1.Y2 = p2.Y;

            Line line2 = new Line();
            line2.Stroke = color;
            line2.StrokeThickness = 3 * (1d / scaleFactor);

            line2.X1 = p3.X;
            line2.Y1 = p3.Y;
            line2.X2 = p4.X;
            line2.Y2 = p4.Y;

            canvas.Children.Add(line1);
            canvas.Children.Add(line2);
        }

        private void scaleCanvas(double scaleFactorX, double scaleFactorY)
        {
            ScaleTransform st = new ScaleTransform();

            st.ScaleX *= scaleFactorX;
            st.ScaleY *= scaleFactorY;

            canvas.RenderTransform = st;
        }

    }
}
