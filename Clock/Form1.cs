using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class Form1 : Form
    {
        private float hourAngle;
        private float minuteAngle;
        private float secondAngle;
        private Bitmap hourHandImage;
        private Bitmap minuteHandImage;
        private Bitmap secondHandImage;
        float angle = 90;
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000; // 1 секунда
            timer1.Start();

            hourHandImage = new Bitmap("red_pointer.png");
            minuteHandImage = new Bitmap("white_pointer.png");
            secondHandImage = new Bitmap("yellow_pointer.png");
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int centerX = this.Width / 2;
            int centerY = this.Height / 2;
            int clockRadius = 210;
            Graphics g = e.Graphics;



            Image clock = Image.FromFile("clock.png");
            g.DrawImage(clock, new Point(centerX - clockRadius-2, centerY - clockRadius-2));
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
            g.DrawLine(hourPen, centerX, centerY, hourX, hourY);

            //Minutes
            int minute = currentTime.Minute;
            double minuteAngle = (minute - 15) * 6 + (currentTime.Second / 60.0) * 6;
            int minuteLength = 80;
            int minuteX = centerX + (int)(minuteLength * Math.Cos(minuteAngle * Math.PI / 180));
            int minuteY = centerY + (int)(minuteLength * Math.Sin(minuteAngle * Math.PI / 180));
            g.DrawLine(minutePen, centerX, centerY, minuteX, minuteY);

            //Seconds
            int second = currentTime.Second;
            double secondAngle = (second - 15) * 6;
            int secondLength = 80;
            int secondX = centerX + (int)(secondLength * Math.Cos(secondAngle * Math.PI / 180));
            int secondY = centerY + (int)(secondLength * Math.Sin(secondAngle * Math.PI / 180));
            g.DrawLine(secondPen, centerX, centerY, secondX, secondY);

            g.Dispose();
            hourPen.Dispose();
            minutePen.Dispose();
            secondPen.Dispose(); 

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }


    }
}
