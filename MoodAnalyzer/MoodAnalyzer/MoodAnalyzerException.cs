using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzer
{
    public class MoodAnalyzerException : Exception
    {
        public enum ExceptionType
        {
            NULL_EXCEPTION,
            EMPTY_EXCEPTION, 
            NO_SUCH_METHOD_PRESENT,
            NO_SUCH_FIELD_PRESENT,
            INVALID_INPUT
        }
        ExceptionType type;
        readonly string message;

        /// <summary>
        /// Parameterized constructor for exception type
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        public MoodAnalyzerException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
            this.message = message;
        }
    }
}
