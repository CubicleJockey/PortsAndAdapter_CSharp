using PortAndAdapter.Core.Ports.Secondary.StorageEngine.Queriers;

namespace PortAndAdapter.Core.Ports.Secondary.StorageEngine
{
    /// <summary>
    /// Getters for your Querier objects
    /// </summary>
    public interface IQuerierFactory
    {
        #region Properties
        
        ISampleQuerier SampleQuerier { get; }

        #endregion Properties
    }
}