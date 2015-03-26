using Seterlund.CodeGuard;

namespace PortAndAdapter.Core.UseCaseInputs.Shared.Creates
{
    public interface ISampleCreateInputs
    {
        string Name { get; }
        string Description { get; }
    }
    
    public class SampleCreateInputs : ISampleCreateInputs
    {
        #region Constructors

        public SampleCreateInputs(string name, string description)
        {
            Name = Guard.That(name).IsNotNullOrWhiteSpace().Value;
            Description = Guard.That(description).IsNotNullOrWhiteSpace().Value;
        }

        #endregion Constructors

        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}
