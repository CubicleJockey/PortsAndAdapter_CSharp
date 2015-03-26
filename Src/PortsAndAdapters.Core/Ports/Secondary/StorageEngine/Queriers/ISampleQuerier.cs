using System;
using System.Collections.Generic;
using PortsAndAdapters.Core.UseCaseInputs.Shared.Reads;
using PortsAndAdapters.Core.Views;

namespace PortsAndAdapters.Core.Ports.Secondary.StorageEngine.Queriers
{
    public interface ISampleQuerier
    {
        #region Methods

        ISampleView GetWithId(ISampleIdInputs input);
        IEnumerable<ISampleView> GetAll();

        #endregion Methods
    }
}