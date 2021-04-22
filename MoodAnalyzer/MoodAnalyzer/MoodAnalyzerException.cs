using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzer
{
    public class MoodAnalyzerException : Exception
    {
        readonly string message;
        public MoodAnalyzerException(string message)
        {
            this.message = message;
        }
    }
}
