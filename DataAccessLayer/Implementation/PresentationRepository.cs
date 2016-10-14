using System;
using System.Collections.Generic;
using DomainModel;
using System.Threading.Tasks;

namespace DataAccessLayer.Implementation
{
    public class PresentationRepository : IPresentationRepository
    {
        private readonly IDataStoreContextFactory<IDataStoreContext> _dataStoreContextFactory;

        public PresentationRepository(IDataStoreContextFactory<IDataStoreContext> dataStoreContextFactory)
        {
            _dataStoreContextFactory = dataStoreContextFactory;
        }

        public async Task<IEnumerable<Presentation>> GetPresentations()
        {
            using (var dataStoreContext = _dataStoreContextFactory.CreateDataStoreContext())
            {
                return await dataStoreContext.GetPresentations();
            }
        }
    }
}
