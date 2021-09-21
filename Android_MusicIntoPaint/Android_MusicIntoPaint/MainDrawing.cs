using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Graphics;

namespace Android_MusicIntoPaint
{
    public class MainDrawing : View
    {
        internal Context context;
        internal Point startPoint;
        internal Random srand;
        internal int height;
        internal int width;
        internal Point p1;
        internal Point p2;
        internal Paint paint;


        public MainDrawing(Context context,int height, int width) :
            base(context)
        {
            this.context = context;
            this.height = height;
            this.width = width;
        }

        protected override void OnDraw(Canvas canvas)
        {
            srand = new Random();
            randStartPoint();
            justDraw(canvas);
            
            
            //canvas.Draw

        }

        private void justDraw(Canvas canvas)
        {
            if (paint==null)
            {
                paint = new Paint();
                paint.Color = Color.White;
                paint.StrokeWidth = 5;
            }
            else
            {
                paint.Color = RecordingClass.color;
            }
            if (p2==null)
            {
                p2 = new Point();
            }
            if (p1 == null)
            {
                p1 = new Point(startPoint);
            }
            else
            {
                p1.X = p2.X;
                p1.Y = p2.Y;
            }
            p2.X = srand.Next(width);
            p2.Y = srand.Next(height);
            Console.WriteLine("p1 x: " + p1.X + "\t p1 Y: " + p1.Y);
            Console.WriteLine("p2 x: " + p2.X + "\t p2 Y: " + p2.Y);
            canvas.DrawLine(p1.X, p1.Y, p2.X, p2.Y, paint);

        }

        private void randStartPoint()
        {
            startPoint = new Point(srand.Next(width), srand.Next(height));
        }

        

    }
}