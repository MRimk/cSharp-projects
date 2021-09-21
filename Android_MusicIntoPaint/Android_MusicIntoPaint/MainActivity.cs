using Android.App;
using Android.Widget;
using Android.OS;
using Android.Media;
using Android.Views;
using Android.Preferences;
using Android.Content;
using System;
using System.Threading;
using Android.Util;

namespace Android_MusicIntoPaint
{
    [Activity(Label = "Android_MusicIntoPaint", MainLauncher = true)]
    public class MainActivity : Activity
    {
        MediaRecorder mrecorder;
        AudioRecord arecorder;
        View drawing;
        LinearLayout mainLayout;
        Button prefButton;
        DisplayMetrics display;
        ISharedPreferences prefs;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            display = new DisplayMetrics();
            WindowManager.DefaultDisplay.GetRealMetrics(display);
             
            drawing = new MainDrawing(this, display.HeightPixels, display.WidthPixels);
            // Set our view from the "main" layout resource
            //SetContentView(Resource.Layout.Main);

            //mainLayout = new LinearLayout(this);

            //mainLayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
           // mainLayout = FindViewById<LinearLayout>(Resource.Id.MainLayout);
           // mainLayout.AddView(drawing);
            SetContentView(drawing);
            
            
            if (prefs == null)
            {
                prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            }
            //button'as kodiskai
            //createButton();

            //mainLayout.AddView(prefButton);
            RecordingClass.GiveSound();
            ThreadPool.QueueUserWorkItem(x => UpdateMyDrawing());

        }

        private void createButton()
        {
            prefButton = new Button(this);
            prefButton.SetHeight(40);
            prefButton.SetWidth(120);
            prefButton.SetText("Preferences",TextView.BufferType.Normal);
            prefButton.SetX(display.WidthPixels - 100);
            prefButton.SetY(10);
            prefButton.Click += PrefButton_Click;
        }

        private void PrefButton_Click(object sender, EventArgs e)
        {
            StartActivity(new Intent(this, typeof(MIPPreferenceActivity)));
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menuMain, menu); 
            return true;
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Resource.Id.action_settings)
            {
                StartActivity(new Intent(this, typeof(MIPPreferenceActivity)));
                return true;
            }
            return false;
        }

        private void UpdateMyDrawing()
        {
            //Toast.MakeText(this, "updatemydrawing works", ToastLength.Long).Show();
            
            
            while (true)
            {
                Thread.Sleep(50);
                RunOnUiThread(() => drawing.Invalidate());
                //RunOnUiThread(() => Toast.MakeText(this, "Works update", ToastLength.Short).Show());
                // RunOnUiThread(() => myLogo2.Invalidate());
            }
        }


    }
}

