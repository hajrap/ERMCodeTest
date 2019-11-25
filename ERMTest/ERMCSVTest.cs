using NUnit.Framework;
using ERMWebAPI.Services;
using Moq;
using ERMWebAPI.Controllers;

namespace ERMTest
{
    public class Tests
    {
        private  Mock<IERMLogic> _mockermplogic;


        [SetUp]
        public void Setup()
        {
            _mockermplogic = new Mock<IERMLogic>();
        }
        [Test]
        public  void TestCalculations() {
            //Arrange
            string date = "7/09/2018";
            string datatype = "Current Phase B Max";
            string filename = "LP_214612653_20180907T220027915";
            ERMController ermcontroller = new ERMController(_mockermplogic.Object);
            
            //Act
            var actionResult = ermcontroller.GetERMCalculations(date, datatype, filename);

            //Assert
            Assert. AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult).StatusCode, 200);
        }
    }
}