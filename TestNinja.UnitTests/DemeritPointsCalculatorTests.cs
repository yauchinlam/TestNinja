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
    public class DemeritPointsCalculatorTests
    {
        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedIsOutofRange_ThrowArgumentOutofRangeException(int speed)
        {
            //Arrange
            var calculator = new DemeritPointsCalculator();

            //Act/Assert
            Assert.That(() => calculator.CalculateDemeritPoints(speed),
                Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(0,0)]
        [TestCase(64, 0)]
        [TestCase(65, 0)]
        [TestCase(66, 0)]
        [TestCase(70, 1)]
        [TestCase(75, 2)]

        public void CalculateDemeritPoints_WhenCalled_ReturnDeMeritPoints(int speed, int points)
        {
            //Arrange
            var calculator = new DemeritPointsCalculator();

            //Act
            var result = calculator.CalculateDemeritPoints(speed);

            //Assert
            Assert.That(points, Is.EqualTo(result));
        }
    }
}
