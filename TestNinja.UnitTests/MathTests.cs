using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        [Test]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            //Arrange
            var math = new Fundamentals.Math();

            //Act
            var result = math.Add(1, 2);

            Assert.That(result, Is.EqualTo(3));
        }

        //>= number of execution paths
        //It is not recommended to use a private Math and repeat it. Should use a clean fresh state each time for each test so setup
        private Fundamentals.Math _math;
        //Setup
        [SetUp]
        public void SetUp()
        {
            _math = new Fundamentals.Math();
        }

        //Teardown. You need this a lot for the future integration tests!!!
        [Test]
        public void Max_FirstArgumentIsGreater_ReturnTheFirstArgument()
        {
            //Arrange

            //Act
            var result = _math.Max(2, 1);

            //Assert
            Assert.That(result, Is.EqualTo(2));
        }


        [Test]
        public void Max_SecondArgumentIsGreater_ReturnTheSecondArgument()
        {
            //Arrange
            
            //Act
            var result = _math.Max(1, 2);

            //Assert
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        //Black box testing
        public void Max_ArgumentsAreEqual_ReturnTheSameArgument()
        {
            //Arrange

            //Act
            var result = _math.Max(1, 1);

            //Assert
            Assert.That(result, Is.EqualTo(1));
        }
    }
}
