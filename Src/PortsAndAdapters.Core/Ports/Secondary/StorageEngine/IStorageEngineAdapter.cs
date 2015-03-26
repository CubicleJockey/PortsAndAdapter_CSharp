namespace PortsAndAdapters.Core.Ports.Secondary.StorageEngine
{
    /// <summary>
    ///     The composition root of the Plant Guild "Storage Engine" dependency
    /// </summary>
    public interface IStorageEngineAdapter
    {
        #region Properties

        IQuerierFactory QuerierFactory { get; }
        IEventCommitterFactory EventCommitterFactory { get; }

        #endregion Properties
    }
}