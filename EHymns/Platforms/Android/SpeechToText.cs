using Android.Content;
using Android.Speech;


namespace EHymns.Interfaces;

public class SpeechToText : ISpeechToText
{
    private readonly int VOICE = 10;      


    public void StartSpeechToText()
    {
        StartRecordingAndRecognizing();
    }

    private void StartRecordingAndRecognizing()
    {
        string rec = Android.Content.PM.PackageManager.FeatureMicrophone;
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
            
            Platform.CurrentActivity.StartActivityForResult(voiceIntent, VOICE);
        }
    }


    public void StopSpeechToText()
    {

    }
}