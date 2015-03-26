using System;
using MongoDB.Driver;
using PortsAndAdapters.StorageEngine.Entities;
using Seterlund.CodeGuard;

namespace PortsAndAdapters.StorageEngine
{
    public interface IStorageEngineContext
    {
        IMongoCollection<Sample> Samples { get; }
    }

    public class StorageEngineContext : IStorageEngineContext
    {
        #region Fields

        private readonly Lazy<IMongoDatabase> _storage;

        #endregion Fields

        #region Constructors

        public StorageEngineContext(string connection, string databaseName)
        {
            Guard.That(connection).IsNotNullOrWhiteSpace();
            Guard.That(databaseName).IsNotNullOrWhiteSpace();

            _storage = new Lazy<IMongoDatabase>(() =>
            {
                var client = new MongoClient(connection);
                return client.GetDatabase(databaseName);
            });
        }

        #endregion Constructros

        public IMongoCollection<Sample> Samples
        {
            get { return _storage.Value.GetCollection<Sample>(typeof (Sample).Name); }
        }
    }
}