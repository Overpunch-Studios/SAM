using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace SAM_Server
{
    class VoiceRecognition
    {
        SpeechRecognitionEngine SAM = new SpeechRecognitionEngine();
        Grammar SAM_BasicGrammar;
        
        public VoiceRecognition()
        {
            SAM_BasicGrammar = SetupGrammar();
            SAM.LoadGrammar(SAM_BasicGrammar);
            SAM.SetInputToDefaultAudioDevice();
            SAM.SpeechRecognized += Recognized;
        }

        public void Recognize()
        {
            SAM.Recognize();
        }

        void Recognized(object sender, SpeechRecognizedEventArgs e)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.SetOutputToDefaultAudioDevice();
            synth.Speak("Yes?");
            //TODO: Get the response of the recognized speech of database
            
        }

        private Grammar SetupGrammar()
        {
            Choices choices = new Choices();
            choices.Add("Sam"/* TODO: get commands of database*/);

            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(choices);
            
            return new Grammar(gb);
        }

    }
}
