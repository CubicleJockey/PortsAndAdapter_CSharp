using System;
using System.Collections.Generic;
using System.Linq;
using PortAndAdapter.Core.Events;
using PortAndAdapter.Core.Ports.Secondary.StorageEngine;
using PortsAndAdapter.StorageEngine.Entities;
using Seterlund.CodeGuard;

namespace PortsAndAdapter.StorageEngine.EventComitters
{
    public class CreateSampleEventCommitter : IEventCommitter<ISampleCreatedEvent>
    {
        #region Fields

        private readonly Func<IStorageEngineContext> _storageEngineContext; 

        #endregion Fields

        #region Constructors

        public CreateSampleEventCommitter(Func<IStorageEngineContext> storageEngineContext)
        {
            _storageEngineContext = Guard.That(storageEngineContext).IsNotNull().Value;
        }

        #endregion Constructors

        public void Commit(ISampleCreatedEvent @event)
        {
            Guard.That(@event).IsNotNull();

            var sampleEntity = new Sample(@event.Id, @event.Name, @event.Description);
            var samplesCollection = _storageEngineContext.Invoke().Samples;
            samplesCollection.InsertOneAsync(sampleEntity);
        }
    }
}
