using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Diagnostics;

namespace SuperAssistent_v1
{
    class Program
    {
        private static bool assistentEnabled = false;

        static void Main(string[] args)
        {
            Open open = new Open();
            open.Run("discord");

            Console.Read();

            //Choices choices = new Choices("Aurora", "open", "nothing", "lock");
            //SpeechRecognitionEngine Engine = new SpeechRecognitionEngine();
            //DictationGrammar Grammar = new DictationGrammar();
            //SpeechRecognitionEngine rec = new SpeechRecognitionEngine();

            //rec.LoadGrammar(new Grammar(new GrammarBuilder(choices))); // load grammar
            //// rec.GrammarBuilder.Append(string);
            ////DictationGrammar grammar = new DictationGrammar();
            ////rec.LoadGrammar(grammar);
            //rec.SpeechRecognized += CheckSpeech;
            //Engine.BabbleTimeout = TimeSpan.FromSeconds(10.0);
            //Engine.EndSilenceTimeout = TimeSpan.FromSeconds(10.0);
            //Engine.EndSilenceTimeoutAmbiguous = TimeSpan.FromSeconds(10.0);
            //Engine.InitialSilenceTimeout = TimeSpan.FromSeconds(10.0);

            //rec.SetInputToDefaultAudioDevice(); // set input to default audio device
            //while (true)
            //{
            //    rec.Recognize(); // recognize speech
            //}
        }

        private static void CheckSpeech(object sender, SpeechRecognizedEventArgs e)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.SelectVoice("Microsoft Zira Desktop");
            
            

            if (e.Result.Words[0].Text == "Aurora")
            {
                synth.SpeakAsync("Yes?");
                ToggleAssistent(true);
            }

            if (assistentEnabled)
            {
                switch (e.Result.Words[0].Text)
                {
                    case "lock":
                        synth.Speak("Locking Workstation and disabling myself.");
                        Process.Start("cmd.exe", "/k rundll32.exe user32.dll,LockWorkStation && EXIT");
                        ToggleAssistent(false);
                        Environment.Exit(0);
                        break;

                    case "nothing":
                        synth.SpeakAsync("Hope you need my services soon again.");
                        ToggleAssistent(false);
                        break;

                    case "open":
                        synth.SpeakAsync("What do you want me to open?");

                        break;
                }
            }

            Console.WriteLine(e.Result.Words[0].Text);
        }

        private static void ToggleAssistent(bool mode)
        {
            assistentEnabled = mode;
        }
    }
}
