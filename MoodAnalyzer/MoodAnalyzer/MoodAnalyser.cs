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
        /// Ability to analyse and respond Sad or Happy Mood
        /// </summary>
        /// <returns></returns>
        public string AnalyzeMood(string message)
        {
            try
            {
                ///UC 3 Inform user if he entered Invalid Mood
                ///Here TC 3.2 Given Empty Mood should throw MoodAnalyserException and return Empty Mood should not be empty.
                if (message.Equals(string.Empty))
                {
                    throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.EMPTY_EXCEPTION, "Mood should not be EMPTY");
                }
                ///This is for TC 1.1 Given "I am in sad mood" message should return SAD, if above part is  not executed
                if (message.Contains("I am in sad mood"))
                {
                    return "SAD";
                }
                ///And this is for TC 1.2 Check AnalyzeMood method for SAD or else return HAPPY,this part is executed If above test case is failed.
                else
                {
                    return "HAPPY";
                }
            }
            ///TC 3.1 Given NULL Mood should throw MoodAnalyserException indicating that mood is NULL.
            catch (MoodAnalyzerException e)
            {
                throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NULL_EXCEPTION, "Mood should not be NULL");
            }
        }
        public string AnalyzeMood()
        {
            return AnalyzeMood(this.message);
        }
    }
}