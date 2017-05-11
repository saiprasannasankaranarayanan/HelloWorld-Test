
namespace HelloWorldAPI.Controllers
{
    using System.Configuration;
    using System.IO;
    using System.Net;
    using System.Web.Http;
    using HelloWorldInfrastructure.Attributes;
    using HelloWorldInfrastructure.Models;
    using HelloWorldInfrastructure.Services;

    /// <summary>
    ///     API controller for getting and setting today's value.
    /// </summary>
    [WebApiExceptionFilter]
    public class DataController : ApiController
    {
        /// <summary>
        ///     The data service
        /// </summary>
        private readonly IDataService dataService;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DataController" /> class.
        /// </summary>
        /// <param name="dataService">The injected data service</param>
        public DataController(IDataService dataService)
        {
            this.dataService = dataService;
        }

        
        [WebApiExceptionFilter(Type = typeof(IOException), Status = HttpStatusCode.ServiceUnavailable, Severity = SeverityCode.Error)]
        [WebApiExceptionFilter(Type = typeof(SettingsPropertyNotFoundException), Status = HttpStatusCode.ServiceUnavailable, Severity = SeverityCode.Error)]
        public TodaysData Get()
        {
            return this.dataService.GetTodaysData();
        }
    }
}