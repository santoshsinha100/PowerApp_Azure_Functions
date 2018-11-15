using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    public interface IInventoryHelper
    {
        /// <summary>
        /// to Add Inventory details
        /// </summary>
        /// <param name="queryString">object containing querystring to be passed by function</param>      
        /// <returns>returns Http Response Message</returns>
        Task<HttpResponseMessage> AddEntities(Dictionary<string, string> queryString);

        /// <summary>
        /// to display Inventory List
        /// </summary>     
        /// <returns>returns Http Response Message</returns>
        Task<HttpResponseMessage> Details();
    }
}
