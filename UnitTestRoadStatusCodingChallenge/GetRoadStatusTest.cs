using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RoadStatusCodingChallenge;

namespace UnitTestRoadStatusCodingChallenge
{
    [TestClass]
    public class GetRoadStatusTest
    {
        public RoadStatus rd = new RoadStatus();
        
        public RoadProgram program = new RoadProgram();
        

        [TestMethod]
        public void GetRequestURLTest()
        {
         var getRoadStatus = new GetRoadStatus();
            getRoadStatus.APIKey = "apikey";
            getRoadStatus.AppId = "AppId";
            getRoadStatus.address = "baseAddress/";            
            var address = getRoadStatus.getRequestString("abc");
            Assert.AreEqual("baseAddress/abc?app_id=AppId&app_key=apikey", address);
        }

        [TestMethod]
        public void ExitCodeIsOneWhenNoRoadnameIsFoundTest()
        {
            var getRoadStatus = new Mock<GetRoadStatus>();
            var roadStatusNotFound = new RoadStatus();          
            roadStatusNotFound.exitCode = 1;
            getRoadStatus.Setup(x => x.Start("A567890")).Returns(roadStatusNotFound);
            Assert.AreEqual(1, roadStatusNotFound.exitCode);           
        }

        [TestMethod]
        public void ExitCode0Test()
        {           
            var getRoadStatusMock = new Mock<GetRoadStatus>();                     
            rd.exitCode = 0;           
            
            getRoadStatusMock.Setup(x => x.SecureCertificateBypass());
            getRoadStatusMock.Setup(x => x.Start("A2")).Returns(rd);
            program.getRoadStatus = getRoadStatusMock.Object;
            Assert.AreEqual(0, program.getRoadStatus.resultRoad.exitCode);        
        }

    }
}
