using System;
using Seterlund.CodeGuard;

namespace PortsAndAdapters.Core.Events
{
    public interface ISampleCreatedEvent
    {
        Guid Id { get; }
        string Name { get; }
        string Description { get; }
    }

    public class SampleCreatedEvent : ISampleCreatedEvent
    {
        #region Constructors

        public SampleCreatedEvent(Guid id, string name, string description)
        {
            Id = Guard.That(id).IsNotEmpty().Value;
            Name = Guard.That(name).IsNotNullOrWhiteSpace().Value;
            Description = Guard.That(description).IsNotNullOrWhiteSpace().Value;
        }

        #endregion Constructors

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}