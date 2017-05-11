

namespace ConsoleApp.Services
{
    using HelloWorldInfrastructure.Models;

    /// <summary>
    ///     Service for communicating with the Hello World Web API
    /// </summary>
    public interface IHelloWorldWebService
    {
        /// <summary>
        ///     Gets today's data from the web API
        /// </summary>
        /// <returns>A TodaysData model containing today's data</returns>
        TodaysData GetTodaysData();
    }
}