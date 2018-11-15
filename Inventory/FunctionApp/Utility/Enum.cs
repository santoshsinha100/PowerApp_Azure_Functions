using System.Diagnostics.CodeAnalysis;

namespace Inventory
{
    public enum ActionType
    {
        Get =0,
        Post=1
    }

    /// <summary>
    /// the log type enum 
    /// </summary>
    public enum LogType
    {
        None = 0,
        Information = 1,
        Error = 2,
        Warning = 3,
    }

    /// <summary>
    /// the tracing event configuration.
    /// </summary>
    public enum TrackingEvent
    { 
        GetStatus = 141,
        GetStatusError = 142,
        StatusExecuter = 143,
        StatusExecuterError = 144,
        GetInventoryDetailsSuccess = 145,
        GetInventoryDetailsFailure = 146,
        GetInventoryDetailsError = 147
    }    
}
