using System;
using Seterlund.CodeGuard;

namespace PortsAndAdapters.Core.UseCaseInputs.Shared.Reads
{
    public interface ISampleIdInputs
    {
        Guid Id { get; }
    }

    public class SampleIdInputs : ISampleIdInputs
    {
        #region Constructors

        public SampleIdInputs(Guid id)
        {
            Id = Guard.That(id).IsNotEmpty().Value;
        }

        #endregion Constructors

        public Guid Id { get; private set; }
    }
}