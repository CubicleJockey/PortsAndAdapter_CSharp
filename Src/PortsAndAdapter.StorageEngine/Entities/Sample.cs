using System;
using PortAndAdapter.Core.Views;
using Seterlund.CodeGuard;

namespace PortsAndAdapter.StorageEngine.Entities
{
    public class Sample : MongoEntity
    {
        #region Fields

        public string Name { get; set; }
        public string Description { get; set; }

        #endregion Fields

        #region Constructors

        public Sample(Guid id, string name, string description)
        {
            Id = Guard.That(id).IsNotEmpty().Value;
            Name = Guard.That(name).IsNotNullOrWhiteSpace().Value;
            Description = Guard.That(description).IsNotNullOrWhiteSpace().Value;
        }

        #endregion Constructors

        #region Properties

        public ISampleView ToISampleView()
        {
            return new SampleView(Id, Name, Description);
        }

        #endregion Properties
    }
}
