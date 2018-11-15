using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    public interface ITable
    {
        /// <summary>
        /// the GetEntities to get CloudTable object
        /// </summary>    
        /// <param name="tableName"></param>   
        /// <returns>returns Cloud Table Object</returns>
        Task<CloudTable> GetEntities(string tableName);

        /// <summary>
        /// the AddEntities method to add into Inventory Table.
        /// </summary>
        /// <param name="model">The Inventory Model</param>
        /// <param name="tableName">string containing table name</param>
        /// <returns>returns true for succes and false for failure</returns>
        Task<bool> AddEntities(InventoryModel model,
            string tableName);

        /// <summary>
        ///  to get Table Results
        /// </summary>
        /// <typeparam name="T"> the type name</typeparam>
        /// <param name="tableName">string containing table name</param>
        /// <param name="partitionKey">the partition key</param>      
        /// <param name="rowkey">the rowkey</param>       
        /// <returns>returns collection of table results</returns>
        Task<ICollection<T>> GetTableResult<T>(string tableName, 
            string partitionKey,
            string rowkey = null) where T : ITableEntity, new();
    }
}
