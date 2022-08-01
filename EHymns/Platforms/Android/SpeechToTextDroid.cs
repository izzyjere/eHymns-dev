using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Speech.Tts;
using Android.Speech;
using Android.Views;
using Android.Widget;
using EHymns.Shared;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plugin.CurrentActivity;
using EHymns.Platforms.Android;
using EHymns.Interfaces;

[assembly: Dependency(typeof(SpeechToTextDroid))]
namespace EHymns.Platforms.Android
{
    public class SpeechToTextDroid : ISpeechToText
    {
        private readonly int VOICE = 10;
        private Activity _activity;
        public SpeechToTextDroid()
        {
            _activity = CrossCurrentActivity.Current.Activity;
        }



        public void StartSpeechToText()
        {
            StartRecordingAndRecognizing();
        }

        private void StartRecordingAndRecognizing()
        {
            string rec = global::Android.Content.PM.PackageManager.FeatureMicrophone;
            if (rec == "android.hardware.microphone")
            {
                var voiceIntent = new Intent(RecognizerIntent.ActionRecognizeSpeech);
                voiceIntent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);


                voiceIntent.PutExtra(RecognizerIntent.ExtraPrompt, "Speak now");

                voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputCompleteSilenceLengthMillis, 1500);
                voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputPossiblyCompleteSilenceLengthMillis, 1500);
                voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputMinimumLengthMillis, 15000);
                voiceIntent.PutExtra(RecognizerIntent.ExtraMaxResults, 1);
                voiceIntent.PutExtra(RecognizerIntent.ExtraLanguage, Java.Util.Locale.Default);
                _activity.StartActivityForResult(voiceIntent, VOICE);
            }
        }


        public void StopSpeechToText()
        {

        }
    }
}