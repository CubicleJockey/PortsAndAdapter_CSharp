using System;
using PortAndAdapter.Core.Ports.Secondary.StorageEngine;
using PortAndAdapter.Core.Ports.Secondary.StorageEngine.Queriers;
using Seterlund.CodeGuard;

namespace PortsAndAdapter.StorageEngine
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
            get { throw new NotImplementedException(); }
        }
    }
}
