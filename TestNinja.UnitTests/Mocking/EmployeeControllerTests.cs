using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        [Test]
        public void DeleteEmployee_WhenCalled_DeleteEmployeeFromDb()
        {
            //Arrange
            var storage = new Mock<IEmployeeStorage>();
            var controller = new EmployeeController(storage.Object);

            //Act
            controller.DeleteEmployee(1);

            //Assert
            storage.Verify(s => s.DeleteEmployee(1));
        }

        [Test]
        public void DeleteEmployee_WhenCalled_ReturnTypeRedirectResult()
        {
            //Arrange
            var storage = new Mock<IEmployeeStorage>();
            var controller = new EmployeeController(storage.Object);

            //Act
            var result = controller.DeleteEmployee(1);

            //Assert
            Assert.That(result, Is.TypeOf<RedirectResult>());
        }
    }
}
