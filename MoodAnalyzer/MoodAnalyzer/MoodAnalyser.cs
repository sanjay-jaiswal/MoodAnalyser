using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzer
{
    public class MoodAnalyser
    {
        readonly string message;

        /// <summary>
        /// Take mood message in constructor
        /// </summary>
        public MoodAnalyser()
        {
        }

        /// <summary>
        /// Parameterised constructor
        /// </summary>
        /// <param name="message"></param>
        public MoodAnalyser(string message)
        {
            this.message = message;
        }

        /// <summary>
        /// UC 1
        /// Ability to analyse and respond Sad or Happy Mood
        /// </summary>
        /// <returns></returns>
        public string AnalyzeMood(string message)
        {
            try
            {
                if (message.Contains("I am in sad mood"))
                {
                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }
            }
            catch (MoodAnalyzerException)
            {
                throw new MoodAnalyzerException("HAPPY");
            }
        }
        public string AnalyzeMood()
        {
            return AnalyzeMood(this.message);
        }
    }
}