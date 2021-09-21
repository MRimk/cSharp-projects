using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views.InputMethods;
using Android.Content;
using Android.Hardware;
using Android.Net;
using Android.Views;
using System;

namespace Android_Weather_App_maybe_full
{
    [Activity(Label = "Weather App", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        TextView lblTemp;
        TextView lblTempMax;
        TextView lblTempMin;
        TextView lblHumidity;
        TextView lblPressure;
        TextView lblWindSpeed;
        TextView lblWindDeg;
        TextView lblDescr;
        TextView lblSunrise;
        TextView lblSunset;
        ImageView imgIcon;
        ConnectivityManager conMan;

        private void InitObjects()
        {
            lblDescr = FindViewById<TextView>(Resource.Id.descrWeather);
            lblTemp = FindViewById<TextView>(Resource.Id.temp);
            lblTempMin = FindViewById<TextView>(Resource.Id.tempMin);
            lblTempMax = FindViewById<TextView>(Resource.Id.tempMax);
            lblHumidity = FindViewById<TextView>(Resource.Id.humidity);
            lblPressure = FindViewById<TextView>(Resource.Id.pressure);
            lblSunrise = FindViewById<TextView>(Resource.Id.sunrise);
            lblSunset = FindViewById<TextView>(Resource.Id.sunset);
            lblWindDeg = FindViewById<TextView>(Resource.Id.windDeg);
            lblWindSpeed = FindViewById<TextView>(Resource.Id.windSpeed);
            imgIcon = FindViewById<ImageView>(Resource.Id.imgWeather);
        }


        private async void LoadData()
        {
            try
            {   //C => metric
                //F => imperial
                //K => ""
                string unit = "metric";
                WeatherInfo info = await ApiHelper.GetWeather("Vilnius", unit);
                lblTemp.Text = info.Temp.ToString()+info.TempUnit;
                lblDescr.Text = "Now in " + info.CityName + "("+info.Country+"):" + info.Descr;
                lblTempMax.Text = "Max: " + info.TempMax + info.TempUnit;
                lblTempMin.Text = "Min: " + info.TempMin + info.TempUnit;
                lblHumidity.Text = info.Humidity + "%";
                lblPressure.Text = info.Pressure + "hPa";
                lblWindSpeed.Text = info.WindSpeed.ToString() + info.WindUnit;
                lblWindDeg.Text = info.WindDir+"("+info.WindDegree +"°)";
                lblSunrise.Text = info.Sunrise.ToString();
                lblSunset.Text = info.Sunset.ToString();
                imgIcon.SetImageBitmap(info.Icon);
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "Error occured", ToastLength.Short).Show();
                Console.WriteLine(ex.Message);
            }
            
        }

        private bool ConnectionCheck()
        {
            if (conMan == null)
                conMan = GetSystemService(ConnectivityService) as ConnectivityManager;

            foreach (var item in conMan.GetAllNetworkInfo())
            {
                if ((item.Type == ConnectivityType.Mobile || item.Type == ConnectivityType.Wifi) && item.IsConnectedOrConnecting)
                {
                    return true;
                }
            }

            return false;
        }


        protected override void OnCreate(Bundle savedInstanceState)
        { 
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            if (!ConnectionCheck())
            {
                Toast.MakeText(this, "No internet connection", ToastLength.Short).Show();
                return;
            }
            InitObjects();
            LoadData();
        }
    }
}

