namespace PortAndAdapter.Core.Ports.Secondary.StorageEngine
{
    public interface IEventCommitter<in TEvent>
    {
        #region Methods

        void Commit(TEvent @event);

        #endregion Methods
    }
}