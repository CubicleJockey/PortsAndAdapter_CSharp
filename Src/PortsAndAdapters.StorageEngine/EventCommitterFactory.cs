using System;
using PortsAndAdapters.Core.Events;
using PortsAndAdapters.Core.Ports.Secondary.StorageEngine;
using PortsAndAdapters.StorageEngine.EventComitters;
using Seterlund.CodeGuard;

namespace PortsAndAdapters.StorageEngine
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

        #region Properties

        public IEventCommitter<ISampleCreatedEvent> SampleEventCreatedCommitter
        {
            get { return new CreateSampleEventCommitter(_storageEngineContext); }
        }

        #endregion Properties
    }
}