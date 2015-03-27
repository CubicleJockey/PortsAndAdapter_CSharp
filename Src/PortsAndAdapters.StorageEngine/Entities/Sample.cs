using System;
using PortsAndAdapters.Core.Views;
using Seterlund.CodeGuard;

namespace PortsAndAdapters.StorageEngine.Entities
{
    public class Sample : MongoEntity
    {
        #region Constructors

        public Sample(Guid id, string name, string description, DateTime createdOn)
        {
            Id = Guard.That(id).IsNotEmpty().Value;
            Name = Guard.That(name).IsNotNullOrWhiteSpace().Value;
            Description = Guard.That(description).IsNotNullOrWhiteSpace().Value;
            CreatedOn = createdOn;

        }

        #endregion Constructors

        #region Methods

        public ISampleView ToISampleView()
        {
            return new SampleView(Id, Name, Description, CreatedOn);
        }

        #endregion Methods

        #region Properties

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }

        #endregion Properties
    }
}