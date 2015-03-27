using System;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortsAndAdapters.Core.Events;
using PortsAndAdapters.Core.Ports.Secondary.StorageEngine;
using PortsAndAdapters.StorageEngine.EventComitters;

namespace PortsAndAdapters.StorageEngine.Tests.Unit.EventCommitters
{
    public class CreateSampleEventCommitterTests
    {
        [TestClass]
        public class Constructors
        {
            [TestMethod]
            public void Valid()
            {
                #region Arrange

                var fakeStorageEngineContext = A.Fake<Func<IStorageEngineContext>>();

                #endregion Arrange

                #region Act

                var eventCommitter = new CreateSampleEventCommitter(fakeStorageEngineContext);

                #endregion Act

                #region Assert

                eventCommitter.Should().NotBeNull();
                eventCommitter.Should().BeAssignableTo<IEventCommitter<ISampleCreatedEvent>>();
                eventCommitter.Should().BeOfType<CreateSampleEventCommitter>();

                #endregion Assert
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            public void Invalid()
            {
                #region Arrange

                Func<IStorageEngineContext> storageEngineContext = null;

                #endregion Arrange

                #region Act/Assert

                var eventCommitter = new CreateSampleEventCommitter(storageEngineContext);

                #endregion Act/Assert
            }
        }
    }
}
