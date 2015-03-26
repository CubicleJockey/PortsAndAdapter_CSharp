using System;
using PortAndAdapter.Core.Ports.Secondary.StorageEngine.Queriers;
using PortAndAdapter.Core.UtilityTypes;
using PortAndAdapter.Core.Views;
using Seterlund.CodeGuard;

namespace PortAndAdapter.Core.UseCases.Shared.Reads
{
    public class GetSampleByIdUseCase : IUseCase<Guid, ISampleView>
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


        public ISampleView Execute(Guid input)
        {
            return _querier.GetWithId(input);
        }
    }
}
