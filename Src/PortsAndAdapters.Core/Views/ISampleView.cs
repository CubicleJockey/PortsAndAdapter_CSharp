using System;

namespace PortsAndAdapters.Core.Views
{
    public interface ISampleView
    {
        Guid Id { get; }
        string Name { get; }
        string Description { get; }
        DateTime CreatedOn { get; }
    }

    public class SampleView : ISampleView
    {
        public SampleView(Guid id, string name, string description, DateTime createdOn)
        {
            Id = id;
            Name = name;
            Description = description;
            CreatedOn = createdOn;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedOn { get; private set; }
    }
}