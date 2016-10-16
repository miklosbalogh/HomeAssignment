using DomainModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IPresentationRepository
    {
        Task<IEnumerable<Presentation>> GetPresentations();
        string ConnectionString { get; set; }
    }
}
