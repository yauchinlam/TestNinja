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
    public class HtmlFormatterTests
    {
        [Test]
        public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement()
        {
            //Arrange
            var formatter = new HtmlFormatter();

            //Act
            var result = formatter.FormatAsBold("abc");

            //Assert tpp specific
            //IgnoreCase to ignore case sensistive
            Assert.That(result, Is.EqualTo("<strong>abc</strong>").IgnoreCase);

            //more general
            //Assert.That(result, Does.StartWith("<strong>"));

            //A little more specific
            //Assert.That(result, Does.StartWith("</strong>"));

            //Assert.That(result, Does.Contain("abc"));

            //When testing strings better to be a little more general but not too general

            //Assert is case sensitive
        }
    }
}
