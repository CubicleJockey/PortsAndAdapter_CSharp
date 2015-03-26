using System;
using System.Collections.Generic;
using PortAndAdapter.Core.Views;

namespace PortAndAdapter.Core.Ports.Secondary.StorageEngine.Queriers
{
    public interface ISampleQuerier
    {
        #region Methods

        ISampleView GetWithId(Guid id);
        IEnumerable<ISampleView> GetAll();

        #endregion Methods
    }
}
