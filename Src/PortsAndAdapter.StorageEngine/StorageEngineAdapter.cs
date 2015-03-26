using System;
using PortAndAdapter.Core.Ports.Secondary.StorageEngine;
using Seterlund.CodeGuard;

namespace PortsAndAdapter.StorageEngine
{
    public class StorageEngineAdapter : IStorageEngineAdapter
    {
        #region Fields

        private readonly Func<IStorageEngineContext> _storageEngineContext; 

        #endregion Fields

        #region Constructors

        public StorageEngineAdapter(string connectionString, string databaseName)
        {
            Guard.That(connectionString).IsNotNullOrWhiteSpace();
            Guard.That(databaseName).IsNotNullOrWhiteSpace();

            _storageEngineContext = () => new StorageEngineContext(connectionString, databaseName);
        }

        #endregion Constructors

        public IQuerierFactory QuerierFactory
        {
            get { return new QueryFactory(_storageEngineContext); }
        }

        public IEventCommitterFactory EventCommitterFactory
        {
            get { return new EventCommitterFactory(_storageEngineContext); }
        }
    }
}
