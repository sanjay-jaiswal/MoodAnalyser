using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzer;

namespace MoodAnalyserMSTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Passing sad mood shoult return sad.
        /// </summary>
            [TestMethod]
            public void GivenSadMood_ShouldReturnSAD()
            {
            //Arrange
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am in sad mood");
            //Act

            string mood = moodAnalyser.AnalyzeMood();
                //Assert
                Assert.AreEqual("SAD", mood);
            }

            /// <summary>
            /// Passing happy mood should return happy
            /// </summary>
            [TestMethod]
            public void GivenAnyMood_ShouldReturnHAPPY()
            {
                //Arrange
                MoodAnalyser moodAnalyser = new MoodAnalyser("I am in any mood");
                //Act
                string mood = moodAnalyser.AnalyzeMood();
                //Assert
                Assert.AreEqual("HAPPY", mood);
            }

            [TestMethod]
            public void GivenMood_IfSadMessageAre_PassingToConstructor_ShouldReturn_SAD()
            {
               //Arrange
               MoodAnalyser moodAnalyser = new MoodAnalyser();
               //Act
               string mood = moodAnalyser.AnalyzeMood("I am in sad mood");
               //Assert
               Assert.AreEqual("SAD", mood);
            }

            /// <summary>
            /// Test for HAPPY  Message constructor
            /// </summary>
            [TestMethod]
            public void GivenMood_IfAnyMessagePassing_ToConstructor_ShouldReturn_HAPPY()
            {
                //Arrange
                MoodAnalyser moodAnalyserMain = new MoodAnalyser();
                //Act
                string mood = moodAnalyserMain.AnalyzeMood("I am in any mood");
                //Assert
                Assert.AreEqual("HAPPY", mood);
            }

            [TestMethod]
            public void GivenMood_IfNull_ShouldReturn_Happy()
            {
                //Arrange
                MoodAnalyser moodAnalyserMain = new MoodAnalyser();
                //Act
                string mood = moodAnalyserMain.AnalyzeMood("NULL");
                //Assert
                Assert.AreEqual("HAPPY", mood);
            }

            [TestMethod]
            public void GivenMood_IfNull_ShouldThrowException()
            {
                try
                {
                    MoodAnalyser moodAnalyser = new MoodAnalyser();
                    string mood = moodAnalyser.AnalyzeMood("NULL");
                }
                catch (MoodAnalyzerException e)
                {
                    Assert.AreEqual("Mood should not be NULL", e.Message);
                }
            }

            [TestMethod]
            public void GivenMood_IfEmpty_ShouldThrowException()
            {
                try
                {
                    MoodAnalyser moodAnalyser = new MoodAnalyser();
                    string mood = moodAnalyser.AnalyzeMood(" ");
                }
                catch (MoodAnalyzerException e)
                {
                    Assert.AreEqual("Mood should not be EMPTY", e.Message);
                }
            }

            [TestMethod]
            public void Given_MoodAnalyser_ClassName_ShouldReturn_MoodAnalyseObject()
            {
                object expected = new MoodAnalyser("NULL");
                object obj = MoodAnalyserFactory.CreateMoodAnalyseMethod("MoodAnalyzer.MoodAnalyser", "MoodAnalyser");
                expected.Equals(obj);
            }

            [TestMethod]
            public void GivenInvalidClassName_ShouldThrow_MoodAnalyserException()
            {
                string expected = "Class not found";
                try
                {
                    object obj = MoodAnalyserFactory.CreateMoodAnalyseMethod ("MoodAnalyzer.sampleClass", "MoodAnalyser");
                }
                catch (MoodAnalyzerException e)
                {
                    Assert.AreEqual(expected, e.Message);
                }
            }

            [TestMethod]
            public void GivenClass_WhenNotProper_Constructor_ShouldThrow_MoodAnalyserException()
            {
                string expected = "Constructor is not found";
                try
                {
                    object obj = MoodAnalyserFactory.CreateMoodAnalyseMethod("MoodAnalyzer.MoodAnalyser", "sampleClass");
                }
                catch (MoodAnalyzerException e)
                {
                    Assert.AreEqual(expected, e.Message);
                }
            }

        
            [TestMethod]
            public void GivenMoodAnalyser_WhenCorrect_Return_MoodAnalyseObject()
            {
                object expected = new MoodAnalyser("HAPPY");
                object obj = MoodAnalyserFactory.CreatedMoodAnalyserUsingParameterizedConstructor("MoodAnalyzer.MoodAnalyser", "MoodAnalyser", "HAPPY");
                expected.Equals(obj);
            }

            [TestMethod]
            public void GivenInvalidClassName_ShouldThrow_MoodAnalyserException_Of_ParameterisedConstructor()
            {
                string expected = "Class not found";
                try
                {
                    object obj = MoodAnalyserFactory.CreatedMoodAnalyserUsingParameterizedConstructor("MoodAnalyzer.sampleClass", "MoodAnalyser", "HAPPY");
                }
                catch (MoodAnalyzerException e)
                {
                    Assert.AreEqual(expected, e.Message);
                }
            }

            // <summary>
            /// This test case is for Invalid
            /// TC 5.3 Given Invalid constructor name should throw MoodAnalyserException.
            /// </summary>
            [TestMethod]
            public void GivenInvalidConstructorName_ShouldThrow_MoodAnalyserException_Of_ParameterizedConstructor()
            {
                string expected = "Constructor is not found";
                try
                {
                    object obj = MoodAnalyserFactory.CreatedMoodAnalyserUsingParameterizedConstructor("MoodAnalyzer.MoodAnalyser", "sampleClass", "HAPPY");
                }
                catch (MoodAnalyzerException e)
                {
                    Assert.AreEqual(expected, e.Message);
                }
            }

            /// <summary>
            /// Test Case 6.1 
            /// Happy message passing using Reflection when correct
            /// should return HAPPY Mood
            /// </summary>
            [TestMethod]
            public void GivenHappyMessage_UsingReflection_IfCorrect_Should_ReturnHappy()
            {
                string message = MoodAnalyserFactory.InvokeMethod("MoodAnalyzer.MoodAnalyser", "GetMood", "HAPPY");
                Assert.AreEqual("HAPPY", message);
            }

            /// <summary>
            /// Test Case 6.2 
            /// Given Happy message when incorrect method 
            /// should throw MoodAnalyserException
            /// </summary>
            [TestMethod]
            public void GivenHappyMessage_UsingReflection_WhenIncorrectMethod_shouldThrow_MoodAnayserException()
            {
                try
                {
                    string message = MoodAnalyserFactory.InvokeMethod("MoodAnalyzer.MoodAnalyser", "getMethod", "HAPPY");
                }
                catch (MoodAnalyzerException e)
                {
                    Assert.AreEqual(MoodAnalyzerException.ExceptionType.INVALID_INPUT, e.Message);
                }
            }
    }
}