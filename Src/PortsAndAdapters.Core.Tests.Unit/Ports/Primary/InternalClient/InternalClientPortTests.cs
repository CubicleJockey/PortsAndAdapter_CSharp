using System;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortsAndAdapters.Core.Ports.Primary.InternalClient;

namespace PortsAndAdapters.Core.Tests.Unit.Ports.Primary.InternalClient
{
    public class InternalClientPortTests
    {
        [TestClass]
        public class Constructors
        {
            [TestMethod]
            public void Valid()
            {
                #region Arrange

                var fakeUseCaseFactory = A.Fake<IUseCaseFactory>();

                #endregion Arrange

                #region Act

                var internalClientPort = new InternalClientPort(fakeUseCaseFactory);

                #endregion Act

                #region Assert

                internalClientPort.Should().NotBeNull();
                internalClientPort.Should().BeAssignableTo<IInternalClientPort>();
                internalClientPort.Should().BeOfType<InternalClientPort>();

                #endregion Assert
            }

            [TestMethod]
            [ExpectedException(typeof (ArgumentNullException))]
            public void Invalid()
            {
                #region Arrange

                IUseCaseFactory useCaseFactory = null;

                #endregion Arrange

                #region Act/Assert

                var internalClientPort = new InternalClientPort(useCaseFactory);

                #endregion Act/Assert
            }
        }
    }
}