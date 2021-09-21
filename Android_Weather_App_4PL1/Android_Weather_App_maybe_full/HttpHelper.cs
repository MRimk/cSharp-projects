using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Android_Weather_App_maybe_full
{
    class HttpHelper
    {
        public static async Task<JContainer> GetData(string source)
        {
            JContainer data=null;
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(source);
            if(response!=null)
            {
                data = JsonConvert.DeserializeObject(response) as JContainer;
            }
            return data;
        }
    }
}