using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Clock
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Start();

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int centerX = this.Width / 2;
            int centerY = this.Height / 2;
            int clockRadius = 210;
            using (Graphics g = e.Graphics)
            {
                GraphicsPath clockPath = new GraphicsPath();
                clockPath.AddEllipse(centerX - clockRadius, centerY - clockRadius, 2 * clockRadius, 2 * clockRadius);


                Region clockRegion = new Region(clockPath);


                this.Region = clockRegion;

                Image clock = Image.FromFile("clock.png");
                g.DrawImage(clock, new Point(centerX - clockRadius - 10, centerY - clockRadius - 33));
                clock.Dispose();

                DateTime currentTime = DateTime.Now;

                Pen hourPen = new Pen(Color.Black, 6);
                Pen minutePen = new Pen(Color.Black, 6);
                Pen secondPen = new Pen(Color.Red, 3);

                //Hours
                int hour = currentTime.Hour % 12;
                double hourAngle = (hour - 3) * 30 + (currentTime.Minute / 60.0) * 30;
                int hourLength = 60;
                int hourX = centerX + (int)(hourLength * Math.Cos(hourAngle * Math.PI / 180));
                int hourY = centerY + (int)(hourLength * Math.Sin(hourAngle * Math.PI / 180));
                g.DrawLine(hourPen, centerX - 5, centerY - 30, hourX, hourY);

                //Minutes
                int minute = currentTime.Minute;
                double minuteAngle = (minute - 15) * 6 + (currentTime.Second / 60.0) * 6;
                int minuteLength = 80;
                int minuteX = centerX + (int)(minuteLength * Math.Cos(minuteAngle * Math.PI / 180));
                int minuteY = centerY + (int)(minuteLength * Math.Sin(minuteAngle * Math.PI / 180));
                g.DrawLine(minutePen, centerX - 5, centerY - 30, minuteX, minuteY);

                //Seconds
                int second = currentTime.Second;
                double secondAngle = (second - 15) * 6;
                int secondLength = 80;
                int secondX = centerX + (int)(secondLength * Math.Cos(secondAngle * Math.PI / 180));
                int secondY = centerY + (int)(secondLength * Math.Sin(secondAngle * Math.PI / 180));
                g.DrawLine(secondPen, centerX - 5, centerY - 30, secondX, secondY);

                hourPen.Dispose();
                minutePen.Dispose();
                secondPen.Dispose();
            }


           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
