using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PortsAndAdapters.StorageEngine.Tests.Unit
{
    public class StorageEngineContextTests
    {
        [TestClass]
        public class Constructors
        {
            [TestMethod]
            public void Valid()
            {
                #region Arrange

                const string CONNECTIONSTRING = "mongo://localhost";
                const string DATABASENAME = "SampleThingy";

                #endregion Arrange

                #region Act

                var storageEngineContext = new StorageEngineContext(CONNECTIONSTRING, DATABASENAME);

                #endregion Act

                #region Assert

                storageEngineContext.Should().NotBeNull();
                storageEngineContext.Should().BeAssignableTo<IStorageEngineContext>();
                storageEngineContext.Should().BeOfType<StorageEngineContext>();

                #endregion Assert
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void Invallid_ConnectionStringIsNull()
            {
                #region Arrange

                const string CONNECTIONSTRING = null;
                const string DATABASENAME = "SampleThingy";

                #endregion Arrange

                #region Act/Assert

                var storageEngineContext = new StorageEngineContext(CONNECTIONSTRING, DATABASENAME);

                #endregion Act/Assert
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void Invallid_ConnectionStringIsEmptyString()
            {
                #region Arrange

                var CONNECTIONSTRING = string.Empty;
                const string DATABASENAME = "SampleThingy";

                #endregion Arrange

                #region Act/Assert

                var storageEngineContext = new StorageEngineContext(CONNECTIONSTRING, DATABASENAME);

                #endregion Act/Assert
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void Invallid_ConnectionStringIsWhitespace()
            {
                #region Arrange

                const string CONNECTIONSTRING = "          ";
                const string DATABASENAME = "SampleThingy";

                #endregion Arrange

                #region Act/Assert

                var storageEngineContext = new StorageEngineContext(CONNECTIONSTRING, DATABASENAME);

                #endregion Act/Assert
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void Invallid_DatabaseNameIsNull()
            {
                #region Arrange

                const string CONNECTIONSTRING = "mongo://localhost";
                const string DATABASENAME = null;

                #endregion Arrange

                #region Act/Assert

                var storageEngineContext = new StorageEngineContext(CONNECTIONSTRING, DATABASENAME);

                #endregion Act/Assert
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void Invallid_DatabaseNameIsEmptyString()
            {
                #region Arrange

                const string CONNECTIONSTRING = "mongo://localhost";
                var DATABASENAME = string.Empty;

                #endregion Arrange

                #region Act/Assert

                var storageEngineContext = new StorageEngineContext(CONNECTIONSTRING, DATABASENAME);

                #endregion Act/Assert
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void Invallid_DatabaseNameIsWhitespace()
            {
                #region Arrange

                const string CONNECTIONSTRING = "mongo://localhost";
                const string DATABASENAME = "     ";

                #endregion Arrange

                #region Act/Assert

                var storageEngineContext = new StorageEngineContext(CONNECTIONSTRING, DATABASENAME);

                #endregion Act/Assert
            }
        }
    }
}
