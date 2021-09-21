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

namespace Android_Weather_App_maybe_full
{
    class WeatherInfo
    {
        public string Descr { get; set; }
        public Bitmap Icon { get; set; }
        public float Temp { get; set; }
        public float TempMin{ get; set; }
        public float TempMax { get; set; }
        public float Pressure { get; set; }
        public byte Humidity { get; set; }
        public float WindSpeed { get; set; }
        public float WindDegree { get; set; }
        public byte Cloudiness { get; set; }
        public string Country { get; set; }
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }
        public string CityName { get; set; }
        public string TempUnit { get; set; }
        public string WindUnit { get; set; }
        public string WindDir { get; set; }
    }
}