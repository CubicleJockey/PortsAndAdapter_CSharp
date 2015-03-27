using System;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortsAndAdapters.Core.Ports.Secondary.StorageEngine;
using PortsAndAdapters.Core.Ports.Secondary.StorageEngine.Queriers;
using PortsAndAdapters.StorageEngine.Queriers;

namespace PortsAndAdapters.StorageEngine.Tests.Unit
{
    public class QueryFactoryTests
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

                var querierFactory = new QueryFactory(fakeStorageEngineContext);

                #endregion Act

                #region Assert

                querierFactory.Should().NotBeNull();
                querierFactory.Should().BeAssignableTo<IQuerierFactory>();
                querierFactory.Should().BeOfType<QueryFactory>();

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

                var querierFactory = new QueryFactory(storageEngineContext);

                #endregion Act/Assert
            }
        }

        [TestClass]
        public class Properties
        {
            [TestMethod]
            public void SampleQuerier()
            {
                #region Arrange

                var fakeStorageEngineContext = A.Fake<Func<IStorageEngineContext>>();
                var querierFactory = new QueryFactory(fakeStorageEngineContext);
                querierFactory.Should().NotBeNull();

                #endregion Arrange

                #region Act

                var sampleQuerier = querierFactory.SampleQuerier;

                #endregion Act

                #region Assert

                sampleQuerier.Should().NotBeNull();
                sampleQuerier.Should().BeAssignableTo<ISampleQuerier>();
                sampleQuerier.Should().BeOfType<SampleQuerier>();

                #endregion Assert
            }           
        }
    }
}
