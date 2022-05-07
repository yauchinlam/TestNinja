using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Fundamentals;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    class VideoServiceTests
    {
        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            //Arrange
            var service = new VideoService();

            //Act
            var result = service.ReadVideoTitle(new FakeFileReader());

            //Assert
            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
    }
}
