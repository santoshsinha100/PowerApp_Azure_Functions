using Inventory.Utility;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Threading.Tasks;

namespace Inventory
{
    /// <summary>
    /// the AzureTable Operation
    /// </summary>
    public class AzureTableOperation : ITable
    {        
        ///Represent the Cloud Storage Account, this will be instantiated based on the appsettings values
        private CloudStorageAccount storageAccount;

        ///The Table Service Client object used to perform operations on the Table
        private CloudTableClient tableClient;

        /// <summary>
        /// the partitionKey
        /// </summary>
        private const string PartitionKey = "1";

        /// <summary>
        /// The storage table name
        /// </summary>
        private static string storageTableName = string.Empty;

        /// <summary>
        /// cloud table
        /// </summary>
        private CloudTable table = null;

        /// <summary>
        ///  to get Table Results
        /// </summary>
        /// <typeparam name="T"> the type name</typeparam>
        /// <param name="tableName">string containing table name</param>       
        /// <param name="model">the configuration model</param>
        /// <returns>returns collection of table results</returns>
        public async Task<CloudTable> GetEntities(string tableName)
        {
            ////Get the Storage Account from the conenction string
            storageAccount = CloudStorageAccount.Parse(CommonUtils.TableStorageConnectionString);

            //// get the storage table name
            storageTableName = tableName;

            ////Create a Table Client Object
            tableClient = storageAccount.CreateCloudTableClient();

            ///Create Table if it does not exist
            table = tableClient.GetTableReference(storageTableName);

            table.CreateIfNotExists();

            return table;
        }

        /// <summary>
        ///  to get Table Results
        /// </summary>
        /// <typeparam name="T"> the type name</typeparam>
        /// <param name="tableName">string containing table name</param>       
        /// <param name="model">the configuration model</param>
        /// <returns>returns collection of table results</returns>
        public async Task<ICollection<T>> GetTableResult<T>(string tableName,
            string partitionKey,
            string rowkey = null
            ) where T : ITableEntity, new()
        {
            CloudTable table = await GetEntities(tableName);

            TableQuery<T> query = null;

            if (string.IsNullOrEmpty(rowkey))
                query = new TableQuery<T>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey));
            else
                query = new TableQuery<T>().Where(TableQuery.CombineFilters(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey), TableOperators.And, TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, rowkey)));

            var entities = new Collection<T>();

            foreach (var item in table.ExecuteQuery(query))
            {
                entities.Add(item);
            }

            return entities;
        }

        /// <summary>
        /// the AddEntities method to add into Inventory Table.
        /// </summary>
        /// <param name="model">The Inventory Model</param>
        /// <param name="tableName">string containing table name</param>
        /// <returns>returns true for succes and false for failure</returns>
        public async Task<bool> AddEntities(InventoryModel model, string tableName)
        {
            var result = false;
            try
            {
                model.PartitionKey = PartitionKey;
                model.RowKey = model.ItemTitle;

                CloudTable table = await GetEntities(tableName);

                /// Create the TableOperation that inserts the customer entity.
                TableOperation insertOperation = TableOperation.Insert(model);

                /// Execute the insert operation.
                await table.ExecuteAsync(insertOperation);

                result = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.Write(ex.Message);
                result = false;
            }

            return result;
        }
    }
}
