using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyzer
{
    public class MoodAnalyserFactory
    {
        public static object CreateMoodAnalyseMethod(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className, pattern);

            if (result.Success)
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = assembly.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch (ArgumentNullException)
                {
                    throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NO_SUCH_CLASS, "Class not found");
                }
            }
            else
            {
                throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NO_SUCH_METHOD, "Constructor is not found");
            }
        }

        /// <summary>
        /// This method is for Use case - 5 : Using reflection to create mood analyser with parameterized constructor.
        /// </summary>
        /// <param name="className"></param>
        /// <param name="constructorName"></param>
        /// <param name="message1"></param>
        /// <returns></returns>
        public static object CreatedMoodAnalyserUsingParameterizedConstructor(string className, string constructorName, string message1)
        {
            Type type = typeof(MoodAnalyser);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo constructorInfo = type.GetConstructor(new[] { typeof(string) });
                    object instance = constructorInfo.Invoke(new object[] { message1 });
                    return instance;
                }
                else
                {
                    throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NO_SUCH_METHOD, "Constructor is not found");
                }
            }
            else
            {
                throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NO_SUCH_CLASS, "Class not found");
            }
        }

        /// <summary>
        /// Use Case 6 :
        /// Use Reflection to Invoke the method
        /// </summary>
        /// <param name="className"></param>
        /// <param name="methodName"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string InvokeTheMethod(string className, string methodName, string message)
        {
            Type type1 = typeof(MoodAnalyser);
            try
            {
                ConstructorInfo constructor = type1.GetConstructor(new[] { typeof(string) });
                object obj = MoodAnalyserFactory.CreatedMoodAnalyserUsingParameterizedConstructor(className, methodName, message);
                Assembly excutingAssambly = Assembly.GetExecutingAssembly();
                Type type = excutingAssambly.GetType(className);
                MethodInfo getMoodMethod = type.GetMethod(methodName);
                string msg = (string)getMoodMethod.Invoke(obj, null);
                return msg;
            }
            catch (Exception)
            {
                throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.INVALID_INPUT, "No Such Method");
            }
        }

        /// <summary>
        /// UC7 Use Reflection to change mood dynamically
        /// </summary>
        /// <param name="className"></param>
        /// <param name="mood"></param>
        /// <returns></returns>
        public static dynamic ChangeMoodDynamically(string className, string mood)
        {
            try
            {
                Type type = Type.GetType(className);
                dynamic change_mood = Activator.CreateInstance(type, mood);
                MethodInfo method = type.GetMethod("GetMood");
                dynamic value = method.Invoke(change_mood, new object[] { mood });
                return value;
            }
            catch (Exception e)
            {
                throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NULL_EXCEPTION, e.Message);
            }
        }
    }
}