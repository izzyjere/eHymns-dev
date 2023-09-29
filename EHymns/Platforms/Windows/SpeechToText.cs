using Windows.Media.SpeechRecognition;
using EHymns.Interfaces;

namespace EHymns.Interfaces;

public class SpeechToText : ISpeechToText
{
    private SpeechRecognizer speechRecognizer; // The speech recognizer object

    public void StartSpeechToText()
    {
        InitializeSpeechRecognizer(); // Initialize the speech recognizer
        StartListening(); // Start listening for speech input
    }

    private async void InitializeSpeechRecognizer()
    {
        // Create an instance of SpeechRecognizer
        speechRecognizer = new SpeechRecognizer();

        // Compile the default dictation grammar
        await speechRecognizer.CompileConstraintsAsync();

        // Register for events
        speechRecognizer.StateChanged += SpeechRecognizer_StateChanged;
        speechRecognizer.RecognitionQualityDegrading += SpeechRecognizer_RecognitionQualityDegrading;
        speechRecognizer.HypothesisGenerated += SpeechRecognizer_HypothesisGenerated;
        speechRecognizer.ContinuousRecognitionSession.ResultGenerated += ContinuousRecognitionSession_ResultGenerated;
        speechRecognizer.ContinuousRecognitionSession.Completed += ContinuousRecognitionSession_Completed;
    }

    private async void StartListening()
    {
        // Start the continuous recognition session
        await speechRecognizer.ContinuousRecognitionSession.StartAsync();
    }

    public async void StopSpeechToText()
    {
        // Stop the continuous recognition session
        await speechRecognizer.ContinuousRecognitionSession.StopAsync();
    }

    private void SpeechRecognizer_StateChanged(SpeechRecognizer sender, SpeechRecognizerStateChangedEventArgs args)
    {
        // Handle the state changes of the speech recognizer
        // For example, you can update the UI or provide feedback to the user
    }

    private void SpeechRecognizer_RecognitionQualityDegrading(SpeechRecognizer sender, SpeechRecognitionQualityDegradingEventArgs args)
    {
        // Handle the quality degrading events of the speech recognizer
        // For example, you can warn the user about the poor audio quality or suggest a better microphone position
    }

    private void SpeechRecognizer_HypothesisGenerated(SpeechRecognizer sender, SpeechRecognitionHypothesisGeneratedEventArgs args)
    {
        // Handle the hypothesis generated events of the speech recognizer
        // For example, you can display the partial recognition results to the user as they speak
    }

    private void ContinuousRecognitionSession_ResultGenerated(SpeechContinuousRecognitionSession sender, SpeechContinuousRecognitionResultGeneratedEventArgs args)
    {
        // Handle the result generated events of the continuous recognition session
        // For example, you can get the recognized text and confidence level from the args.Result object
        string text = args.Result.Text; // The recognized text
        SpeechRecognitionConfidence confidence = args.Result.Confidence; // The confidence level
        Console.WriteLine("Speech confindence {0}", confidence);
        MessagingCenter.Send<ISpeechToText, string>(this, "STT", text ?? "No Text.");

    }

    private void ContinuousRecognitionSession_Completed(SpeechContinuousRecognitionSession sender, SpeechContinuousRecognitionCompletedEventArgs args)
    {
        // Handle the completed events of the continuous recognition session
        // For example, you can check the args.Status property for any errors or cancellation reasons
    }
}