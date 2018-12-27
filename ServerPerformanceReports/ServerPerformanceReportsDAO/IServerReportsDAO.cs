using EntityLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerPerformanceReportsDAO
{
    /// <summary>
    /// Interface for the Server Reports DAO
    /// Exposes methods necessary to get the Server Reports 
    /// </summary>
    public interface IServerReportsDAO
    {
        /// <summary>
        /// Gets all server details.
        /// </summary>
        /// <returns>A list of ServerDetailsDTO.</returns>
        IList<ServerDetailsDTO> GetAllServerDetails();

        /// <summary>
        /// Gets server details for the given server Id.
        /// </summary>
        /// <returns>A ServerDetailsDTO object.</returns>
        ServerDetailsDTO GetServerDetailsById(int serverId);

        /// <summary>
        /// Gets all available server names and Id.
        /// </summary>
        /// <returns>A list of ServerDTO.</returns>
        IList<ServerDTO> GetAvailableServers();
    }
}
