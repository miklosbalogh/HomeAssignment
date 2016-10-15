using System.Threading.Tasks;
using DataAccessLayer;
using System.Web.Http;

namespace PresentationsService.Controllers
{
    public class HomeController : ApiController
    {
        private readonly IDataStoreContextFactory<IDataStoreContext> _dataStoreContextFactory;

        public HomeController(IDataStoreContextFactory<IDataStoreContext> dataStoreContextFactory)
        {
            _dataStoreContextFactory = dataStoreContextFactory;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetPrezis()
        {
            using (var dataStoreContext = _dataStoreContextFactory.CreateDataStoreContext())
            {
                var preziList = await dataStoreContext.GetPresentations();
                return Ok(preziList);
            }
        }
    }
}