using System;
using System.Collections.Generic;
using PortsAndAdapters.Core.Ports.Secondary.StorageEngine;
using PortsAndAdapters.Core.UseCaseInputs;
using PortsAndAdapters.Core.UseCaseInputs.Shared.Reads;
using PortsAndAdapters.Core.UseCases.Shared.Reads;
using PortsAndAdapters.Core.UtilityTypes;
using PortsAndAdapters.Core.Views;
using Seterlund.CodeGuard;

namespace PortsAndAdapters.Core
{
    public interface IUseCaseFactory
    {
        #region IGuildFunction... UseCases

        IUseCase<IEmptyInput, IEnumerable<ISampleView>> GetAllSamplesUseCase { get; }
        IUseCase<ISampleIdInputs, ISampleView> GetSampleByIdUseCase { get; }

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
            get { return new GetAllSamplesUseCase(_storageEngineAdapter.QuerierFactory.SampleQuerier); }
        }

        public IUseCase<ISampleIdInputs, ISampleView> GetSampleByIdUseCase
        {
            get { return new GetSampleByIdUseCase(_storageEngineAdapter.QuerierFactory.SampleQuerier); }
        }

        #endregion Properties
    }
}