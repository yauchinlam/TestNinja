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
        //[Ignore("Because I wanted to!")]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            //Arrange
            
            //Act
            var result = _math.Add(1, 2);

            //Assert
            Assert.That(result, Is.EqualTo(3));
            //Assert.That(_math, Is.Not.Null);
            //When you write test after production create a bug to see if it fails. If it passes then did it wrong

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
        //MsTest does not have solution for parameterized test
        [Test]
        [TestCase(2,1,2)]
        [TestCase(1,2,2)]
        [TestCase(1,1,1)]
        public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedResult)
        {
            //Arrange

            //Act
            var result = _math.Max(a, b);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }


        //[Test]
        //public void Max_SecondArgumentIsGreater_ReturnTheSecondArgument()
        //{
        //    //Arrange
            
        //    //Act
        //    var result = _math.Max(1, 2);

        //    //Assert
        //    Assert.That(result, Is.EqualTo(2));
        //}

        //[Test]
        ////Black box testing
        //public void Max_ArgumentsAreEqual_ReturnTheSameArgument()
        //{
        //    //Arrange

        //    //Act
        //    var result = _math.Max(1, 1);

        //    //Assert
        //    Assert.That(result, Is.EqualTo(1));
        //}

        [Test]
        //Remember think blackbox three case for ngative number, 0 and positive numbers. Just use one case for example
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            //Always use array more than one item. try 3 or more

            //Act
            var result = _math.GetOddNumbers(5);

            //Assert
            //too general
            //Assert.That(result, Is.Not.Empty);

            //more specific
            //Assert.That(result.Count(), Is.EqualTo(3));

            //another examples
            Assert.That(result, Does.Contain(1));
            Assert.That(result, Does.Contain(3));
            Assert.That(result, Does.Contain(5));

            //Do not care about order unless you need your test to be specific
            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));
            //This is a set equivalent to writing the three separate lines

            //Other assertions to use for ordering and uniqueness
            //Assert.That(result, Is.Ordered);
            //Assert.That(result, Is.Unique);
            //find balance between general and specific
        }
    }
}
