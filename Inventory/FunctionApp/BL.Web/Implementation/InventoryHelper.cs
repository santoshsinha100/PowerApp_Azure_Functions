namespace Inventory
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class InventoryHelper : IInventoryHelper
    {
        /// <summary>
        /// the table helper
        /// </summary>
        private ITable tableHelper = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceHelper"/> class.
        /// </summary>
        /// <param name="logHelper">The log helper.</param>
        public InventoryHelper(ITable tableHelper)
        {   
            this.tableHelper = tableHelper;
        }

        /// <summary>
        /// to Add Inventory details
        /// </summary>
        /// <param name="queryString">object containing querystring to be passed by function</param>      
        /// <returns>returns Http Response Message</returns>
        public async Task<HttpResponseMessage> AddEntities(Dictionary<string, string> queryString)
        {
            /// Item Title, price, quantity and description
            if (queryString!=null)                
            {
                using (var model = new InventoryModel())
                {
                    model.ItemTitle = queryString.ContainsKey("itemtitle") ? queryString["itemtitle"] : null;
                    model.Price = queryString.ContainsKey("price") ? queryString["price"] : null;
                    model.Quantity = queryString.ContainsKey("quantity") ? queryString["quantity"] : null;
                    model.Description = queryString.ContainsKey("description") ? queryString["description"] : null;

                    await this.tableHelper.AddEntities(model, Constants.Inventory);
                }
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        /// <summary>
        /// to display Inventory List
        /// </summary>      
        /// <returns>returns Http Response Message</returns>
        public async Task<HttpResponseMessage> Details()
        {             
            var response = new HttpResponseMessage();
            var resultSummary = new List<string>();
            var invoicelst = new Dictionary<string, int?>();
            try
            {
                var result = await this.tableHelper.GetTableResult<InventoryModel>(Constants.Inventory, "1");

                response.Content = new StringContent(result.ToJson());
            }
            catch
            {
                 response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            return response;
        }
    }
}
