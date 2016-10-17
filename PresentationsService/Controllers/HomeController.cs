using System;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Web.Http;

namespace PresentationsService.Controllers
{
    /// <summary>
    /// Default Controller to get Prezis.
    /// For bigger Data Sets we can implement Actions to get subset of the Data Set, using pagination or dynamic loading with ajax requests after scrolling
    /// on the Web UI. 
    /// </summary>
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
            try
            {
                return Ok(await _presentationRepository.GetPresentations());
            }
            catch (Exception)
            {
                return Ok("Service not available! Fix is on the way!");
            }
        }
    }
}