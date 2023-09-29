using AVFoundation;

using Foundation;

using Speech;


namespace EHymns.Interfaces;

public class SpeechToText : ISpeechToText
{
    private AVAudioEngine _audioEngine = new AVAudioEngine();
    private SFSpeechRecognizer _speechRecognizer = new SFSpeechRecognizer();
    private SFSpeechAudioBufferRecognitionRequest _recognitionRequest;
    private SFSpeechRecognitionTask _recognitionTask;
    private string _recognizedString;
    private NSTimer _timer;
    private bool isNotContinious;
    public SpeechToText()
    {
        AskForSpeechPermission();
    }
    public void StartSpeechToText()
    {
        if (_audioEngine.Running)
        {
            StopRecordingAndRecognition();

        }
        StartRecordingAndRecognizing();
    }
    private void DidFinishTalk()
    {
        MessagingCenter.Send<ISpeechToText>(this, "Final");
        if (_timer != null)
        {
            _timer.Invalidate();
            _timer = null;
        }


        if (_audioEngine.Running)
        {
            StopRecordingAndRecognition();
        }

    }
    private void StartRecordingAndRecognizing()
    {
        if (isNotContinious)
        {
            _timer = NSTimer.CreateRepeatingScheduledTimer(5, delegate
            {
                DidFinishTalk();
            });
        }


        _recognitionTask?.Cancel();
        _recognitionTask = null;

        var audioSession = AVAudioSession.SharedInstance();
        NSError nsError;
        nsError = audioSession.SetCategory(AVAudioSessionCategory.Record);
        audioSession.SetMode(AVAudioSession.ModeMeasurement, out nsError);
        nsError = audioSession.SetActive(true, AVAudioSessionSetActiveOptions.NotifyOthersOnDeactivation);

        _recognitionRequest = new SFSpeechAudioBufferRecognitionRequest();

        var inputNode = _audioEngine.InputNode;
        if (inputNode == null)
        {
            throw new Exception();
        }

        var recordingFormat = inputNode.GetBusOutputFormat(0);
        inputNode.InstallTapOnBus(0, 1024, recordingFormat, (buffer, when) =>
        {
            _recognitionRequest?.Append(buffer);
        });

        _audioEngine.Prepare();
        _audioEngine.StartAndReturnError(out nsError);

        _recognitionTask = _speechRecognizer.GetRecognitionTask(_recognitionRequest, (result, error) =>
        {
            var isFinal = false;
            if (result != null)
            {
                _recognizedString = result.BestTranscription.FormattedString;
                MessagingCenter.Send<ISpeechToText, string>(this, "STT", _recognizedString);
                Console.WriteLine("result");
                if (isNotContinious)
                {
                    _timer.Invalidate();
                    _timer = null;
                    _timer = NSTimer.CreateRepeatingScheduledTimer(3, delegate
                    {
                        DidFinishTalk();
                    });
                }

            }
            if (error != null || isFinal)
            {
                MessagingCenter.Send<ISpeechToText>(this, "Final");
                StopRecordingAndRecognition();
            }
        });

    }
    private void StopRecordingAndRecognition(AVAudioSession aVAudioSession = null)
    {
        if (_audioEngine.Running)
        {
            _audioEngine.Stop();
            _audioEngine.InputNode.RemoveTapOnBus(0);
            _recognitionTask?.Cancel();
            _recognitionRequest.EndAudio();
            _recognitionRequest = null;
            _recognitionTask = null;
        }


    }

    public void StopSpeechToText()
    {
        StopRecordingAndRecognition();
    }

    private void AskForSpeechPermission()
    {
        SFSpeechRecognizer.RequestAuthorization((status) =>
        {
            switch (status)
            {
                case SFSpeechRecognizerAuthorizationStatus.Authorized:
                    MessagingCenter.Send<ISpeechToText>(this, "Authorized");
                    break;
                case SFSpeechRecognizerAuthorizationStatus.Denied:
                    throw new Exception("Audio permission denied");

                case SFSpeechRecognizerAuthorizationStatus.NotDetermined:
                    throw new Exception("Audio permission not available");
                case SFSpeechRecognizerAuthorizationStatus.Restricted:
                    throw new Exception("Audio permission denied");
            }
        });
    }
}