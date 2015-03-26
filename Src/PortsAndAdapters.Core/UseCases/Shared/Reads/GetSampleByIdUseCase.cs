using System;
using PortsAndAdapters.Core.Ports.Secondary.StorageEngine.Queriers;
using PortsAndAdapters.Core.UseCaseInputs.Shared.Reads;
using PortsAndAdapters.Core.UtilityTypes;
using PortsAndAdapters.Core.Views;
using Seterlund.CodeGuard;

namespace PortsAndAdapters.Core.UseCases.Shared.Reads
{
    public class GetSampleByIdUseCase : IUseCase<ISampleIdInputs, ISampleView>
    {
        #region Fields

        private readonly ISampleQuerier _querier;

        #endregion Fields

        #region Constructors

        public GetSampleByIdUseCase(ISampleQuerier querier)
        {
            _querier = Guard.That(querier).IsNotNull().Value;
        }

        #endregion Constructors

        public ISampleView Execute(ISampleIdInputs input)
        {
            return _querier.GetWithId(input);
        }
    }
}