using System;
using PortAndAdapter.Core.Events;
using PortAndAdapter.Core.Ports.Secondary.StorageEngine;
using Seterlund.CodeGuard;

namespace PortsAndAdapter.StorageEngine
{
    public class EventCommitterFactory : IEventCommitterFactory
    {
        #region Fields

        private readonly Func<IStorageEngineContext> _storageEngineContext;

        #endregion Fields

        public EventCommitterFactory(Func<IStorageEngineContext> storageEngineContext)
        {
            _storageEngineContext = Guard.That(storageEngineContext).IsNotNull().Value;
        }

        public IEventCommitter<ISampleCreatedEvent> SampleEventCreatedCommitter
        {
            get { throw new NotImplementedException(); }
        }
    }
}
