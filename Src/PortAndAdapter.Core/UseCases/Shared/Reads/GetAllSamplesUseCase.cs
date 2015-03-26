using System.Collections.Generic;
using PortAndAdapter.Core.Ports.Secondary.StorageEngine.Queriers;
using PortAndAdapter.Core.UseCaseInputs;
using PortAndAdapter.Core.UtilityTypes;
using PortAndAdapter.Core.Views;
using Seterlund.CodeGuard;

namespace PortAndAdapter.Core.UseCases.Shared.Reads
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
