using System;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortsAndAdapters.Core.Ports.Secondary.StorageEngine.Queriers;
using PortsAndAdapters.StorageEngine.Queriers;

namespace PortsAndAdapters.StorageEngine.Tests.Unit.Queriers
{
    public class SampleQuerierTests
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

                var querier = new SampleQuerier(fakeStorageEngineContext);

                #endregion Act

                #region Assert

                querier.Should().NotBeNull();
                querier.Should().BeAssignableTo<ISampleQuerier>();
                querier.Should().BeOfType<SampleQuerier>();

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

                var querier = new SampleQuerier(storageEngineContext);

                #endregion Act/Assert
            }
        }
    }
}
