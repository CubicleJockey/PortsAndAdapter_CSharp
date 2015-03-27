using System;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using PortsAndAdapters.Core.Ports.Secondary.StorageEngine.Queriers;
using PortsAndAdapters.Core.UseCaseInputs.Shared.Reads;
using PortsAndAdapters.Core.Views;
using Seterlund.CodeGuard;

namespace PortsAndAdapters.StorageEngine.Queriers
{
    public class SampleQuerier : ISampleQuerier
    {
        #region Fields

        private static Func<IStorageEngineContext> _storageEngineContext;

        #endregion Fields

        #region Constructors

        public SampleQuerier(Func<IStorageEngineContext> storageEngineContext)
        {
            _storageEngineContext = Guard.That(storageEngineContext).IsNotNull().Value;
        }

        #endregion Constructors

        public ISampleView GetWithId(ISampleIdInputs inputs)
        {
            var sample = _storageEngineContext.Invoke()
                .Samples
                .Find(s => s.Id == inputs.Id);

            return sample.SingleAsync().Result.ToISampleView();
        }

        public IEnumerable<ISampleView> GetAll()
        {
            var samples = _storageEngineContext.Invoke()
                .Samples
                .Find(s => true);

            return samples.ToListAsync().Result.ConvertAll(sample => sample.ToISampleView());
        }
    }
}