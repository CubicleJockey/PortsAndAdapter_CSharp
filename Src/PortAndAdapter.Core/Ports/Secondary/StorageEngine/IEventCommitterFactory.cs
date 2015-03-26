using PortAndAdapter.Core.Events;

namespace PortAndAdapter.Core.Ports.Secondary.StorageEngine
{
    /// <summary>
    /// The composition root for Plant Guild Storage Engine "Committers"
    /// </summary>
    public interface IEventCommitterFactory
    {
        IEventCommitter<ISampleCreatedEvent> SampleEventCreatedCommitter { get; }
    }
}