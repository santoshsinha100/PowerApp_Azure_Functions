namespace Inventory
{
    using AutofacOnFunctions.Services.Ioc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Azure.WebJobs.Host;
    using System.Net.Http;
    using System.Threading.Tasks;

    public static class DisplayFunc
    {
        /// <summary>
        /// Azure functions for List Inventory functionality
        /// </summary>
        /// <param name="req"></param>
        /// <param name="log"></param>
        /// <param name="logHelper"></param>
        /// <param name="invoiceHelper"></param>
        /// <returns>returns response message</returns>
        [FunctionName("DisplayFunc")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req,
          TraceWriter log,
          [Inject] IInventoryHelper inventoryHelper,
          [Inject] ITable tableHelper)
        {
            var response = await inventoryHelper.Details();
            return response;
        }
    }
}
