﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace SAM_Server
{
    class VoiceRecognition
    {
        SpeechRecognitionEngine SAM = new SpeechRecognitionEngine();
        Grammar SAM_BasicGrammar;
        
        public VoiceRecognition(string setting = "basic")
        {
            SAM_BasicGrammar = SetupGrammar(setting);
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
            synth.Speak(GetResponse(e.Result.Text.ToString()));
            //TODO: Get the response of the recognized speech of database
            
        }

        private Grammar SetupGrammar(string setting)
        {
            Choices choices = new Choices();
            switch (setting)
            {
                case "basic":
                    choices.Add("Sam"/* TODO: get commands of database*/);
                    break;
                case "advanced":
                    choices.Add(GetChoises());
                    break;
            }
            
            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(choices);
            
            return new Grammar(gb);
        }

        private string GetResponse(string input)
        {
            string result = "Response not found.";

            for (int i = 0; i < Program.commands.Length; i++)
            {
                if (Program.devices[i].ip + " " + Program.commands[i].request == input || Program.devices[i].name + " " + Program.commands[i].request == input)
                {
                    result = Program.commands[i].response;
                    break;
                }
            }

            return result;
        }

        private string[] GetChoises()
        {
            int commandsCount = Program.commands.Length;
            int devicesCount = Program.devices.Length;
            string[] output = new string[commandsCount];

            for (int j = 0; j < devicesCount; j++)
            {
                for (int i = 0; i < commandsCount; i++)
                {
                    output[i] = Program.devices[j].ip + " " + Program.commands[i].request;
                    output[i] = Program.devices[j].name + " " + Program.commands[i].request;
                }
            }

            return output;
        }
    }
}
