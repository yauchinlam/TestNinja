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
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ThrowArgumentNullException(string error)
        {
            //Arrange
            var logger = new ErrorLogger();

            //Act

            //cannot do need to make a delegate
            //logger.Log(error);

            //Assert
            Assert.That(() => logger.Log(error), Throws.ArgumentNullException);
            //OR
            //Assert.That(() => logger.Log(error), Throws.Exception.TypeOf<ArgumentNullException>());

        }


        [Test]
        public void Log_ValidError_RaiseErrorLoggedEvent()
        {
            //Arrange
            var logger = new ErrorLogger();
            var id = Guid.Empty;
            //subscribe to event before acting
            logger.ErrorLogged += (sender, args) => { id = args; };


            //Act
            logger.Log("a");

            //Assert
            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }

        //Do NOT Test Private Methods
        //Tests bcome coupled to implementation details

        //Test for example of bad private tests that change from private to public for testing
        //[Test]
        //public void OnErrorLoged_WhenCalled_RaiseEvent()
        //{
        //    //changing private to public will break lot of tests
        //    var logger = new ErrorLogger();

        //    logger.OnErrorLogged();

        //    Assert.That(true);
        //}

        //Using too many private methods could be example of fixing and making to private
    }
}
