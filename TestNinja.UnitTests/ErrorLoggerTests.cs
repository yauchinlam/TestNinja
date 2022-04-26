using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;
using NUnit.Framework;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ErrorLoggerTests
    {
        [Test]
        public void Log_WhenCalled_SetTheLastErrorProperty()
        {
            //Arrange
            var logger = new ErrorLogger();

            //Act
            logger.Log("a");

            //Assert
            Assert.That(logger.LastError, Is.EqualTo("a"));
        }
    }
}
