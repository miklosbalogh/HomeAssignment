using System;
using System.Collections.Generic;
using DomainModel;
using System.Threading.Tasks;
using DataAccessLayer.Logger;

namespace DataAccessLayer.Implementation
{
    /// <summary>
    /// Repository implementation that use any DataStore to retrieve the data from.
    /// Currently this is at the top of the Business Logic layer.
    /// For a more complex applicaton Application Service layer should be introduced!!!
    /// </summary>
    public class PresentationRepository : IPresentationRepository
    {
        private string _connectionString;
        private readonly IDataStoreContextFactory<IDataStoreContext> _dataStoreContextFactory;
        private readonly ILogger _logger;

        public PresentationRepository(IDataStoreContextFactory<IDataStoreContext> dataStoreContextFactory, ILogger logger)
        {
            _dataStoreContextFactory = dataStoreContextFactory;
            _logger = logger;
            _dataStoreContextFactory.ConnectionString = ConnectionString;
        }

        public async Task<IEnumerable<Presentation>> GetPresentations()
        {
            using (var dataStoreContext = _dataStoreContextFactory.CreateDataStoreContext())
            {
                try
                {
                    return await dataStoreContext.GetPresentations();
                }
                catch (Exception ex)
                {
                    //This is too general, not every exception needs to be logged as an Error.
                    //However, till now we have only error exceptions
                    _logger.Error(ex.Message);
                    throw;
                }
            }
        }

        public string ConnectionString
        {
            get { return _connectionString; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    return;

                _connectionString = value;
                _dataStoreContextFactory.ConnectionString = _connectionString;
            }
        }
    }
}
