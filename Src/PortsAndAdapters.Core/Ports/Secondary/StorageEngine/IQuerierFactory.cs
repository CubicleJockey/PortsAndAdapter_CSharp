using PortsAndAdapters.Core.Ports.Secondary.StorageEngine.Queriers;

namespace PortsAndAdapters.Core.Ports.Secondary.StorageEngine
{
    /// <summary>
    ///     Getters for your Querier objects
    /// </summary>
    public interface IQuerierFactory
    {
        #region Properties

        ISampleQuerier SampleQuerier { get; }

        #endregion Properties
    }
}