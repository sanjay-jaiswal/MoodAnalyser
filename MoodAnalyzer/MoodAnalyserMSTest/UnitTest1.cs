using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzer;

namespace MoodAnalyserMSTest
{
    [TestClass]
    public class UnitTest1
    {
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
            /// Test for happy mood
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
    }
}