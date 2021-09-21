using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using Android.Graphics;


namespace Android_Weather_App_maybe_full
{
    class ApiHelper
    {

        public static async Task<WeatherInfo> GetWeather(string city, string unit)
        {
            string key = "e66f115c6a7e9b44254877a977b72e3f";
            string source = "http://api.openweathermap.org/data/2.5/weather?q=" + city + "&units="+unit+"&appid=" + key;
            JContainer result =await HttpHelper.GetData(source);
            if (result == null) return null;

            try
            {
                WeatherInfo info = new WeatherInfo();

                if (result["weather"] == null) return null;
                info.Descr = result["weather"][0]["description"].ToString();
                info.Temp = (float)result["main"]["temp"];
                info.TempMin = (float)result["main"]["temp_min"];
                info.TempMax = (float)result["main"]["temp_max"];
                info.Pressure = (float)result["main"]["pressure"];
                info.Humidity = (byte)result["main"]["humidity"];
                info.WindSpeed = (float)result["wind"]["speed"];
                info.WindDegree = (float)result["wind"]["deg"];
                info.Cloudiness = (byte)result["clouds"]["all"];
                info.Country = result["sys"]["country"].ToString();
                info.CityName = result["name"].ToString();
                info.Sunrise = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds((double)result["sys"]["sunrise"]);
                info.Sunset = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds((double)result["sys"]["sunset"]);
                info.WindDir = DegToDir(info.WindDegree);
                if (unit=="metric")
                {
                    info.TempUnit = "°C";
                    info.WindUnit = "m/s";
                }
                else if (unit=="imperial")
                {
                    info.TempUnit = "°F";
                    info.WindUnit = "mi/h";
                }
                else if(unit=="")
                {
                    info.TempUnit = "K";
                    info.WindUnit = "m/s";
                }

                
                Task tsk = Task.Run(() =>
                {
                    var url = new Java.Net.URL("http://openweathermap.org/img/w/" + result["weather"][0]["icon"] + ".png");
                    var img = BitmapFactory.DecodeStream(url.OpenConnection().InputStream);
                    info.Icon = img;
                });
                tsk.Wait();
                return info;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n\n\nError:" + ex.Message + "\n\n\n");
                Toast.MakeText(Application.Context, ex.Message, ToastLength.Short).Show();
                return null;
            }
        }

        private static string DegToDir(float deg)
        {
            if ((deg >= 348.75 && deg < 360) || (deg >= 0 && deg < 11.25))
                return "N";
            else if ((deg >= 11.25 && deg < 33.75))
                return "NNE";
            else if ((deg >= 33.75 && deg < 56.25))
                return "NE";
            else if ((deg >= 56.25 && deg < 78.75))
                return "ENE";
            else if ((deg >= 78.75 && deg < 101.25))
                return "E";
            else if ((deg >= 101.25 && deg < 123.75))
                return "ESE";
            else if ((deg >= 123.75 && deg < 146.25))
                return "SE";
            else if ((deg >= 146.25 && deg < 168.75))
                return "SSE";
            else if ((deg >= 168.75 && deg < 191.25))
                return "S";
            else if ((deg >= 191.25 && deg < 213.75))
                return "SSW";
            else if ((deg >= 213.75 && deg < 236.25))
                return "SW";
            else if ((deg >= 236.25 && deg < 258.75))
                return "WSW";
            else if ((deg >= 258.75 && deg < 281.25))
                return "W";
            else if ((deg >= 281.25 && deg < 303.75))
                return "WNW";
            else if ((deg >= 303.75 && deg < 326.25))
                return "NW";
            else if ((deg >= 326.25 && deg < 348.75))
                return "NNW";
            return "";
        }

    }
}