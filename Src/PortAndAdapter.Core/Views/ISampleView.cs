using System;
namespace PortAndAdapter.Core.Views
{
    public interface ISampleView
    {
        Guid Id { get; }
        string Name { get; }
        string Description { get; }
    }

    public class SampleView : ISampleView
    {
        public SampleView(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}