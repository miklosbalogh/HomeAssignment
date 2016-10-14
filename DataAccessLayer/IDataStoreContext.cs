using DomainModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IDataStoreContext : IDisposable
    {
        string ConnectionString { get; }
        Task<IEnumerable<Presentation>> GetPresentations();
    }
}
