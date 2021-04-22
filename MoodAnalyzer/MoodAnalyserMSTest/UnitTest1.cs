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
                MoodAnalyser moodAnalyserMain = new MoodAnalyser("I am in any mood");
                //Act
                string mood = moodAnalyserMain.AnalyzeMood();
                //Assert
                Assert.AreEqual("HAPPY", mood);
            }

            [TestMethod]
            public void GivenMood_WhenSadMessageConstructor_ShouldReturnSAD()
            {
               //Arrange
               MoodAnalyser moodAnalyserMain = new MoodAnalyser();
               //Act
               string mood = moodAnalyserMain.AnalyzeMood("I am in sad mood");
               //Assert
               Assert.AreEqual("SAD", mood);
            }

            /// <summary>
            /// Test for HAPPY  Message constructor
            /// </summary>
            [TestMethod]
            public void GivenMood_WhenAnyMessageConstructor_ShouldReturnHAPPY()
            {
                //Arrange
                MoodAnalyser moodAnalyserMain = new MoodAnalyser();
                //Act
                string mood = moodAnalyserMain.AnalyzeMood("I am in any mood");
                //Assert
                Assert.AreEqual("HAPPY", mood);
            }

            /// <summary>
            /// Test case for handle null exception
            /// </summary>
            [TestMethod]
            public void GivenNullMessage_ShouldReturnHappy()
            {
                //Arrange
                MoodAnalyser moodAnalyserMain = new MoodAnalyser();
                //Act
                string mood = moodAnalyserMain.AnalyzeMood("NULL");
                //Assert
                Assert.AreEqual("HAPPY", mood);
            }
    }
}