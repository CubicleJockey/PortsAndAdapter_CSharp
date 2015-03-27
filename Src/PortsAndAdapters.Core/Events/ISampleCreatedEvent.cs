using System;
using PortsAndAdapters.Core.UseCaseInputs.Shared.Creates;
using Seterlund.CodeGuard;

namespace PortsAndAdapters.Core.Events
{
    public interface ISampleCreatedEvent
    {
        Guid Id { get; }
        string Name { get; }
        string Description { get; }
        DateTime CreatedOn { get; }
    }

    public class SampleCreatedEvent : ISampleCreatedEvent
    {
        #region Fields

        private readonly Guid _id;
        private readonly ISampleCreateInputs _inputs;
        private readonly DateTime _createdOn;

        #endregion Fields

        #region Constructors

        public SampleCreatedEvent(ISampleCreateInputs inputs)
        {
            _id = Guid.NewGuid();
            _inputs = Guard.That(inputs).IsNotNull().Value;
            _createdOn = DateTime.Now;
        }

        #endregion Constructors

        public Guid Id { get { return _id; } }
        public string Name { get { return _inputs.Name; }}
        public string Description { get { return _inputs.Description; } }
        public DateTime CreatedOn { get { return _createdOn; } }

    }
}