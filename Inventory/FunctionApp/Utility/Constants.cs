namespace Inventory
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The constant file.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Constants
    {
        /// <summary>
        /// the inventory
        /// </summary>
        public const string Inventory = "inventory";
        
        /// <summary>
        /// To update Status for API
        /// </summary>
        public const string StatusExecuter = "Status update for API";

        /// <summary>
        /// status update failure
        /// </summary>
        public const string StatusExecuterFailure = "Failed to update status";
        
        /// <summary>
        /// Failuring in getting status
        /// </summary>
        public const string GetStatusFailure = "Failed to retrive api status details.";

        /// <summary>
        /// Failuring in getting Inventory
        /// </summary>
        public const string GetInventoryDetailsFailure = "Failed to retrive Inventory details.";
    }
}
