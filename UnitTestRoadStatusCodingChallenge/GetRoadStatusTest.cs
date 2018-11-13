using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoadStatusCodingChallenge;

namespace UnitTestRoadStatusCodingChallenge
{
    [TestClass]
    public class GetRoadStatusTest
    {
        public RoadStatus rd = new RoadStatus();
        public GetRoadStatus getRoadStatus = new GetRoadStatus();
        public RoadProgram program = new RoadProgram();

        [TestMethod]
        public void ExitCodeIsOneWhenNoRoadnameIsFoundTest()
        {
            program.
            rd = getRoadStatus.Start("");
            Assert.AreEqual(1, rd.exitCode);
        }
    }
}
