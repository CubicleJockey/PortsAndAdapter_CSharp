using System;
using PortsAndAdapters.Core.Ports.Secondary.StorageEngine;
using PortsAndAdapters.Core.Ports.Secondary.StorageEngine.Queriers;
using PortsAndAdapters.StorageEngine.Queriers;
using Seterlund.CodeGuard;

namespace PortsAndAdapters.StorageEngine
{
    public class QueryFactory : IQuerierFactory
    {
        #region Fields

        private readonly Func<IStorageEngineContext> _storageEngineContext;

        #endregion Fields

        #region Constructors

        public QueryFactory(Func<IStorageEngineContext> storageEngineContext)
        {
            _storageEngineContext = Guard.That(storageEngineContext).IsNotNull().Value;
        }

        #endregion Constructors

        public ISampleQuerier SampleQuerier
        {
            get { return new SampleQuerier(_storageEngineContext); }
        }
    }
}