using PortAndAdapter.Core.Ports.Primary.InternalClient;
using PortAndAdapter.Core.Ports.Secondary.StorageEngine;
using Seterlund.CodeGuard;

namespace PortAndAdapter.Core
{
    /// <summary>
    /// Hosts the Plant Guild core and provides an api for interacting with it
    /// </summary>
    public interface IPortsAndAdaptersHost
    {
        #region Properties

        IInternalClientPort InternalClientPort { get; }

        #endregion Properties
    }

    public class PortsAndAdaptersHost : IPortsAndAdaptersHost
    {
        public IInternalClientPort InternalClientPort { get; private set; }

        #region Constructors

        public PortsAndAdaptersHost(IStorageEngineAdapter storageEngineAdapter)
        {
            Guard.That(storageEngineAdapter).IsNotNull();
            var useCaseFactory = new UseCaseFactory(storageEngineAdapter);
            InternalClientPort = new InternalClientPort(useCaseFactory);
        }

        #endregion Constructors
    }
}