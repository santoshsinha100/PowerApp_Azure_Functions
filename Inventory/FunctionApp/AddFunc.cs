namespace Inventory
{
    using AutofacOnFunctions.Services.Ioc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Azure.WebJobs.Host;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public static class AddFunc
    {   
        /// <summary>
        /// Azure functions for Invoice functionality
        /// </summary>
        /// <param name="req"></param>
        /// <param name="log"></param>      
        /// <param name="invoiceHelper"></param>
        /// <returns>returns response message</returns>
        [FunctionName("AddFunc")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]HttpRequestMessage req,
          TraceWriter log,
          [Inject] IInventoryHelper inventoryHelper,
          [Inject] ITable tableHelper)            
        {
            string userEmail = ClaimsPrincipal.Current.Identity.Name;
            var queryString = req.GetQueryNameValuePairs().ToDictionary(x => x.Key, x => x.Value);
            var success = await inventoryHelper.AddEntities(queryString);
            var response = req.CreateResponse(HttpStatusCode.OK);
            return response;
        }
    }
}
