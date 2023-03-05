﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Castle.Core.Smtp;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class HouseKeeperServiceTests
    {
        private HousekeeperService _service;
        private Mock<IStatementGenerator> _statementGenerator;
        private Mock<IEmailSender> _emailSender;
        private Mock<IXtraMessageBox> _messageBox;
        private DateTime _statementDate = new DateTime(2017, 1, 1);
        private Housekeeper _houseKeeper;
        private readonly string _statementFileName = "fileName";

        [SetUp]
        public void SetUp()
        {
            _houseKeeper = new Housekeeper
            {
                Email = "a",
                FullName = "b",
                Oid = 1,
                StatementEmailBody = "c"
            };
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(uow => uow.Query<Housekeeper>()).Returns(new List<Housekeeper>
            {
              _houseKeeper  
            }.AsQueryable());

            
            _statementGenerator = new Mock<IStatementGenerator>();
            _emailSender = new Mock<IEmailSender>();
            _messageBox = new Mock<IXtraMessageBox>();

            _service = new HousekeeperService(
                unitOfWork.Object,
                _statementGenerator.Object,
                _emailSender.Object,
                _messageBox.Object);
        }
        [Test]
        public void SendStatementEmails_WhenCalled_GenerateStatements()
        {
            _service.SendStatementEmails(_statementDate);

            _statementGenerator.Verify(sg => 
            sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, _statementDate));


        }

        [Test]
        public void SendStatementEmails_HouseKeeperEmailIsNull_ShouldNotGenerateStatements()
        {
            _houseKeeper.Email = null;
            _service.SendStatementEmails(_statementDate);

            _statementGenerator.Verify(sg =>
            sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, _statementDate), Times.Never);
        }

        [Test]
        public void SendStatementEmails_HouseKeeperEmailIsWhiteSpace_ShouldNotGenerateStatements()
        {
            _houseKeeper.Email = " ";
            _service.SendStatementEmails(_statementDate);

            _statementGenerator.Verify(sg =>
            sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, _statementDate), Times.Never);
        }

        [Test]
        public void SendStatementEmails_HouseKeeperEmailIsEmpty_ShouldNotGenerateStatements()
        {
            _houseKeeper.Email = "";
            _service.SendStatementEmails(_statementDate);

            _statementGenerator.Verify(sg =>
            sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, _statementDate), Times.Never);
        }

        [Test]
        public void SendStatementEmails_WhenCalled_EmailTheStatement()
        {
            _statementGenerator
                .Setup(sg => 
                    sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, _statementDate))
                .Returns(_statementFileName);

            _service.SendStatementEmails(_statementDate);

            _emailSender.Verify(es => es.
            EmailFile(
                _houseKeeper.Email, 
                _houseKeeper.StatementEmailBody, 
                _statementFileName,
                It.IsAny<string>()));
        }

        [Test]
        public void SendStatementEmails_StatmentFileNameIsNull_ShouldNotEmailTheStatement()
        {
            _statementGenerator
                .Setup(sg =>
                    sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, _statementDate))
                .Returns(() => null);

            _service.SendStatementEmails(_statementDate);

            _emailSender.Verify(es => es.
            EmailFile(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()),
                Times.Never);
        }

        [Test]
        public void SendStatementEmails_StatmentFileNameIsEmptyString_ShouldNotEmailTheStatement()
        {
            _statementGenerator
                .Setup(sg =>
                    sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, _statementDate))
                .Returns("");

            _service.SendStatementEmails(_statementDate);

            _emailSender.Verify(es => es.
            EmailFile(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()),
                Times.Never);
        }

        [Test]
        public void SendStatementEmails_StatmentFileNameIsWhiteSpace_ShouldNotEmailTheStatement()
        {
            _statementGenerator
                .Setup(sg =>
                    sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, _statementDate))
                .Returns(" ");

            _service.SendStatementEmails(_statementDate);

            _emailSender.Verify(es => es.
            EmailFile(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()),
                Times.Never);
        }
    }
}
