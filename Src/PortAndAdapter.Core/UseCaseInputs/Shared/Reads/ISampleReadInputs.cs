using System;
using Seterlund.CodeGuard;

namespace PortAndAdapter.Core.UseCaseInputs.Shared.Reads
{
    public interface ISampleReadInputs
    {
        Guid Id { get; }
    }

    public class SampleReadInputs : ISampleReadInputs
    {
        #region Constructors

        public SampleReadInputs(Guid id)
        {
            Id = Guard.That(id).IsNotEmpty().Value;
        }

        #endregion Constructors

        public Guid Id { get; private set; }
    }
}
