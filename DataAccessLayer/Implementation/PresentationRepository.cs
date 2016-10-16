using System.Collections.Generic;
using DomainModel;
using System.Threading.Tasks;

namespace DataAccessLayer.Implementation
{
    public class PresentationRepository : IPresentationRepository
    {
        private string _connectionString;
        private readonly IDataStoreContextFactory<IDataStoreContext> _dataStoreContextFactory;

        public PresentationRepository(IDataStoreContextFactory<IDataStoreContext> dataStoreContextFactory)
        {
            _dataStoreContextFactory = dataStoreContextFactory;
            _dataStoreContextFactory.ConnectionString = ConnectionString;
        }

        public async Task<IEnumerable<Presentation>> GetPresentations()
        {
            using (var dataStoreContext = _dataStoreContextFactory.CreateDataStoreContext())
            {
                return await dataStoreContext.GetPresentations();
            }
        }

        public string ConnectionString
        {
            get { return _connectionString; }
            set
            {
                _connectionString = value;
                _dataStoreContextFactory.ConnectionString = _connectionString;
            }
        }
    }
}
