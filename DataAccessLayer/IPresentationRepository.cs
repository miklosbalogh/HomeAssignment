using DomainModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    interface IPresentationRepository
    {
        Task<IEnumerable<Presentation>> GetPresentations();
    }
}
