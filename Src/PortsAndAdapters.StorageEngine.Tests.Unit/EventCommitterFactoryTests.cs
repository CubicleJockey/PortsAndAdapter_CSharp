using System;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortsAndAdapters.Core.Events;
using PortsAndAdapters.Core.Ports.Secondary.StorageEngine;
using PortsAndAdapters.StorageEngine.EventComitters;

namespace PortsAndAdapters.StorageEngine.Tests.Unit
{
    public class EventCommitterFactoryTests
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

                var eventCommitterFacotry = new EventCommitterFactory(fakeStorageEngineContext);

                #endregion Act

                #region Assert

                eventCommitterFacotry.Should().NotBeNull();
                eventCommitterFacotry.Should().BeAssignableTo<IEventCommitterFactory>();
                eventCommitterFacotry.Should().BeOfType<EventCommitterFactory>();

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

                var eventCommitterFactory = new EventCommitterFactory(storageEngineContext);

                #endregion Act/Assert
            }
        }

        [TestClass]
        public class Properties
        {
            [TestMethod]
            public void SampleEventCreatedCommitter()
            {
                #region Arrange

                var fakeStorageEngineContext = A.Fake<Func<IStorageEngineContext>>();
                var eventCommitterFacotry = new EventCommitterFactory(fakeStorageEngineContext);
                eventCommitterFacotry.Should().NotBeNull();

                #endregion Arrange

                #region Act

                var sampleEventCreatedCommitter = eventCommitterFacotry.SampleEventCreatedCommitter;

                #endregion Act

                #region Assert

                sampleEventCreatedCommitter.Should().NotBeNull();
                sampleEventCreatedCommitter.Should().BeAssignableTo<IEventCommitter<ISampleCreatedEvent>>();
                sampleEventCreatedCommitter.Should().BeOfType<CreateSampleEventCommitter>();

                #endregion Assert
            }
        }
    }
}