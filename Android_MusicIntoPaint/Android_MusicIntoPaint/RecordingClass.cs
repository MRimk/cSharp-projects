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
using Android.Media;
using Urho.Audio;
//using System.IO;
using Java.IO;
using System.Threading.Tasks;
using System.Threading;
using Android.Graphics;



namespace Android_MusicIntoPaint
{
    class RecordingClass
    {
        static MediaRecorder mRecorder;
        static string path = "/sdcard/Music/temp.mp3";
        static bool deleted = false;
        private static int amplitude; 
        public static Color color { get; set; }
        static bool started = false;
        

        
        public static async void GiveSound()
        {
            Toast.MakeText(Application.Context, "GiveSound started", ToastLength.Long).Show();
            if (started) return;
            //if (!deleted) return;
            if (color == null) color = new Color();
            started = true;
            mRecorder = new MediaRecorder();
            
            mRecorder.SetAudioSource(AudioSource.Mic);
            mRecorder.SetAudioChannels(1);
            mRecorder.SetOutputFormat(OutputFormat.ThreeGpp);
            mRecorder.SetAudioEncoder(AudioEncoder.AmrNb);
            mRecorder.SetAudioEncodingBitRate(16000);
            mRecorder.SetAudioSamplingRate(8000);
            mRecorder.SetOutputFile(path);
            deleted = true;
            mRecorder.SetMaxFileSize(8000000);
            
            try
            {
                mRecorder.Prepare();
            }
            catch (Exception ex)
            {
                System.Console.Write("\n\n\n\n" + ex.StackTrace + "\n\n\n\n\n");
                Toast.MakeText(Application.Context, ex.Message, ToastLength.Long).Show();
            }
            
            mRecorder.Start();
            //Thread th = new Thread((x => ));
            //ThreadPool.QueueUserWorkItem(x => amplitudes());
            while (true)
            {
                if (mRecorder != null)
                {
                    await AmpTask();
                    AmpTask().Wait(1000);                               //WHAT TO DO HERE??????????????????????????????????????????
                }
            }
            
        }

        public static async Task AmpTask()
        {
            //System.Console.Write("\n\n\n\n\n" + "amplitudes started" + "\n\n\n\n\n\n\n\n\n\n");
            

                try
                {
                    amplitude = mRecorder.MaxAmplitude;
                    System.Console.WriteLine("AMPLITUDE= \t" + amplitude.ToString());
                    //color = Color.Argb(amplitude, amplitude % 10000, amplitude / 100, amplitude * 4);

                    color = Color.Argb(0, 1, 1, 0);
                    System.Console.WriteLine("COLOR= \t" + color.ToString());
                  
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.StackTrace);
                }


            
        }






        public static void amplitudes()
        {
            System.Console.Write("\n\n\n\n\n" + "amplitudes started" + "\n\n\n\n\n\n\n\n\n\n");
            while (true)
            {

                try
                {
                    Thread.Sleep(300);
                    if (mRecorder != null)
                    {
                        amplitude = mRecorder.MaxAmplitude;
                        System.Console.WriteLine("AMPLITUDE= \t"+amplitude.ToString());
                        //color = Color.Argb(amplitude, amplitude % 10000, amplitude / 100, amplitude * 4);
                        
                        color = Color.Argb(0, 1, 1, 0);
                        System.Console.WriteLine("COLOR= \t"+color.ToString());
                    }
                    else
                    {
                        continue;
                    }
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.StackTrace);
                }
                

            }
        }





        public void StopRecording()
        {
            mRecorder.Stop();
            mRecorder.Dispose();
            File file = new File(path);
            deleted = file.Delete();
        }

        
    }
}