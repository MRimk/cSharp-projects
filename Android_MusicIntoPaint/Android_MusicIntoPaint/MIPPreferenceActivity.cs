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
using Android.Preferences;

namespace Android_MusicIntoPaint
{
    [Activity(Label = "MIPPreferenceActivity")]
    public class MIPPreferenceActivity : PreferenceActivity, ISharedPreferencesOnSharedPreferenceChangeListener
    {
        ISharedPreferences prefs;
        Preference colors;
        

        public void OnSharedPreferenceChanged(ISharedPreferences sharedPreferences, string key)
        {
            if (key == "col_key")
            {
                colors.Summary = "Current: " + sharedPreferences.GetString(key, "Default Color Space");
            }
            
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            AddPreferencesFromResource(Resource.Layout.PreferenceLayout);

            prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            colors = PreferenceScreen.FindPreference("col_key");
            colors.Summary = "Current: " + prefs.GetString("col_key", "Default Color Space");

            colors.PreferenceChange += Colors_PreferenceChange;
            

            

            
        }

        private void Colors_PreferenceChange(object sender, Preference.PreferenceChangeEventArgs e)
        {
            var editor = prefs.Edit();
            editor.PutString(e.Preference.Key, e.NewValue.ToString());
            editor.Commit();
            colors.Summary = "Current: " + prefs.GetString(e.Preference.Key, "Default Color Space");
        }
    }
}