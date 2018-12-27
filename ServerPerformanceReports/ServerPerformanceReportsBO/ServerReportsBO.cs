using System;
using System.Collections.Generic;
using System.Text;
using EntityLayer;
using ServerPerformanceReportsDAO;

namespace ServerPerformanceReportsBO
{
    public class ServerReportsBO : IServerReportsBO
    {
        #region member variables and Properties

        private static readonly string ModuleName = typeof(ServerReportsBO).Namespace;
        private static readonly string ClassName = typeof(ServerReportsBO).Name;

        private IServerReportsDAO reportsDAO = new ServerReportsDAO();

        #endregion member variables and Properties

        #region privateMethods

        #endregion privateMethods

        #region public Methods

        /// <summary>
        /// Gets all server details.
        /// </summary>
        /// <returns>A list of ServerDetailsDTO.</returns>
        public IList<ServerDetailsDTO> GetAllServerDetails()
        {
            return reportsDAO.GetAllServerDetails();
        }

        /// <summary>
        /// Gets all available server names and Id.
        /// </summary>
        /// <returns>A list of ServerDTO.</returns>
        public IList<ServerDTO> GetAvailableServers()
        {
            return reportsDAO.GetAvailableServers();
        }

        /// <summary>
        /// Gets server details for the given server Id.
        /// </summary>
        /// <returns>A ServerDetailsDTO object.</returns>
        public ServerDetailsDTO GetServerDetailsById(int serverId)
        {
            return reportsDAO.GetServerDetailsById(serverId);
        }

        #endregion public Methods
    }
}
