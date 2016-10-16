using System.Threading.Tasks;
using DataAccessLayer;
using System.Web.Http;

namespace PresentationsService.Controllers
{
    public class HomeController : ApiController
    {
        //TODO: GET IT FROM CONFIG FILE
        private const string _relativePathToDataStore = @"~/App_Data/prezis.json";
        private readonly IPresentationRepository _presentationRepository;

        public HomeController(IPresentationRepository presentationRepository)
        {
            _presentationRepository = presentationRepository;
            _presentationRepository.ConnectionString = System.Web.Hosting.HostingEnvironment.MapPath(_relativePathToDataStore);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetPrezis()
        {
            return Ok(await _presentationRepository.GetPresentations());
        }
    }
}