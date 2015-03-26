using System.Collections.Generic;
using PortsAndAdapters.Core.Ports.Secondary.StorageEngine.Queriers;
using PortsAndAdapters.Core.UseCaseInputs;
using PortsAndAdapters.Core.UtilityTypes;
using PortsAndAdapters.Core.Views;
using Seterlund.CodeGuard;

namespace PortsAndAdapters.Core.UseCases.Shared.Reads
{
    public class GetAllSamplesUseCase : IUseCase<IEmptyInput, IEnumerable<ISampleView>>
    {
        private readonly ISampleQuerier _querier;

        public GetAllSamplesUseCase(ISampleQuerier querier)
        {
            _querier = Guard.That(querier).IsNotNull().Value;
        }

        public IEnumerable<ISampleView> Execute(IEmptyInput input)
        {
            return _querier.GetAll();
        }
    }
}