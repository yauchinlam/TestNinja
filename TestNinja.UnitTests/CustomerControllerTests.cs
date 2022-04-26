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
    public class CustomerControllerTests
    {
        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            //Arrange
            var controller = new CustomerController();

            //Act
            var result = controller.GetCustomer(0);

            //Assert NOT FOUND Object
            Assert.That(result, Is.TypeOf<NotFound>());
            
            //OR

            //Assert Not Found or one of its dervatives
            Assert.That(result, Is.InstanceOf<NotFound>());
        }

        [Test]
        public void GetCustomer_IdIsNotZero_RturnOk()
        {
            //Arrange
            var controller = new CustomerController();

            //Act
            var result = controller.GetCustomer(1);

            //Assert NOT FOUND Object
            Assert.That(result, Is.TypeOf<Ok>());

            //OR

            //Assert Not Found or one of its dervatives
            Assert.That(result, Is.InstanceOf<Ok>());
        }
    }
}
