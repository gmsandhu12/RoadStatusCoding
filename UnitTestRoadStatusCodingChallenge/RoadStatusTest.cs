using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoadStatusCodingChallenge;

namespace UnitTestRoadStatusCodingChallenge
{
    [TestClass]
    public class RoadStatusTest
    {
        public RoadStatus rd = new RoadStatus() { displayName ="Test",
            statusSeverity ="Good",
            statusSeverityDescription ="No delay",
            exitCode = 0 }; 

        [TestMethod]
        public void displayNameTest()
        {            
            Assert.AreEqual("Test", rd.displayName);
        }

        [TestMethod]
        public void statusSeverityTest()
        {
            Assert.AreEqual("Good", rd.statusSeverity);

        }

        [TestMethod]
        public void statusSeverityDescriptionTest()
        {
            Assert.AreEqual("No delay", rd.statusSeverityDescription);
        }

        [TestMethod]
        public void exitCodeTest()
        {
            Assert.AreEqual(0, rd.exitCode);
        }
    }
}
