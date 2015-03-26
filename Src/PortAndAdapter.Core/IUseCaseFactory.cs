using System;
using System.Collections.Generic;
using PortAndAdapter.Core.Ports.Secondary.StorageEngine;
using PortAndAdapter.Core.UseCaseInputs;
using PortAndAdapter.Core.UseCases.Shared.Reads;
using PortAndAdapter.Core.UtilityTypes;
using PortAndAdapter.Core.Views;
using Seterlund.CodeGuard;

namespace PortAndAdapter.Core
{
    public interface IUseCaseFactory
    {
        #region IGuildFunction... UseCases

        IUseCase<IEmptyInput, IEnumerable<ISampleView>> GetAllSamplesUseCase { get; }
        IUseCase<Guid, ISampleView> GetSampleByIdUseCase { get; }

        #endregion IGuildFunciton... UseCases
    }

    public class UseCaseFactory : IUseCaseFactory
    {
        #region Fields

        private readonly IStorageEngineAdapter _storageEngineAdapter;

        #endregion Fields

        #region Constructors

        public UseCaseFactory(IStorageEngineAdapter storageEngineAdapter)
        {
            _storageEngineAdapter = Guard.That(storageEngineAdapter).IsNotNull().Value;
        }

        #endregion Constructors

        #region Properties

       public IUseCase<IEmptyInput, IEnumerable<ISampleView>> GetAllSamplesUseCase
        {
            get
            {
                return new GetAllSamplesUseCase(_storageEngineAdapter.QuerierFactory.SampleQuerier);
            }
        }

        public IUseCase<Guid, ISampleView> GetSampleByIdUseCase
        {
            get
            {
                return new GetSampleByIdUseCase(_storageEngineAdapter.QuerierFactory.SampleQuerier);
            }
        }

        #endregion Properties
    }
}