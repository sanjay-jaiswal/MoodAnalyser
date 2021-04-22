using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzer
{
    public class MoodAnalyser
    {
        private string message;

        /// <summary>
        /// Take the mood message in constructor
        /// </summary>
        public MoodAnalyser()
        {
        }

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
            if (this.message.Contains("I am in sad mood"))
            {
                return "SAD";
            }
            else
            {
                return "HAPPY";
            }
        }
        public string AnalyzeMood()
        {
            return AnalyzeMood(this.message);
        }
    }
}