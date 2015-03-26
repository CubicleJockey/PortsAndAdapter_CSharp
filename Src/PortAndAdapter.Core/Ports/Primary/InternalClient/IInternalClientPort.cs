using System;
using System.Collections.Generic;
using PortAndAdapter.Core.UseCaseInputs;
using PortAndAdapter.Core.Views;
using Seterlund.CodeGuard;

namespace PortAndAdapter.Core.Ports.Primary.InternalClient
{
    public interface IInternalClientPort
    {
        #region SampleView

        IEnumerable<ISampleView> GetAllGuildFunctions();
        ISampleView GetGuildFunctionById(Guid input);

        #endregion SampleView
    }


    public class InternalClientPort : IInternalClientPort
    {
        #region Fields

        private readonly IUseCaseFactory _useCaseFactory;

        #endregion Fields

        #region Constructors

        public InternalClientPort(IUseCaseFactory useCaseFactory)
        {
            _useCaseFactory = Guard.That(useCaseFactory).IsNotNull().Value;
        }

        #endregion Constructors

        #region Properties

        public IEnumerable<ISampleView> GetAllGuildFunctions()
        {
            return _useCaseFactory.GetAllSamplesUseCase.Execute(EmptyInput.Instance);
        }

        public ISampleView GetGuildFunctionById(Guid input)
        {
            return _useCaseFactory.GetSampleByIdUseCase.Execute(input);
        }

        #endregion Properties
    }
}