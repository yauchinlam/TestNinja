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
    }
}
