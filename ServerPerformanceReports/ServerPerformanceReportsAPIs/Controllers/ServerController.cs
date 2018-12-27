using EntityLayer;
using ServerPerformanceReportsBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerPerformanceReportsAPIs.Controllers
{
    /// <summary>
    /// Server controller which exposes necessary API methods to get Server Perf Reports
    /// </summary>
    /// <returns>A JSON list of all server details.</returns>
    public class ServerController : ApiController
    {
        #region member variables and Properties

        private static readonly string ModuleName = typeof(ServerController).Namespace;
        private static readonly string ClassName = typeof(ServerController).Name;

        private IServerReportsBO reportsBo = new ServerReportsBO();

        #endregion member variables and Properties

        /// <summary>
        /// Returns all server details.
        /// </summary>
        /// <returns>A JSON list of all server details.</returns>
        [Route("servers/GetAllServerDetails/{pgNum?}/{numOfRecords?}")]
        [HttpGet]
        public IHttpActionResult GetAllServerDetails(int? pgNum = null, int? numOfRecords = null)
        {
            IList<ServerDetailsDTO> serverDetails = new List<ServerDetailsDTO>();

            serverDetails = reportsBo.GetAllServerDetails();

            if (serverDetails.Count == 0)
            {
                return NotFound();
            }

            return Ok(serverDetails);
        }

        /// <summary>
        /// Returns matching server details for the given Id.
        /// </summary>
        /// <returns>A JSON containing server details for the Id.</returns>
        [Route("servers/get/{Id}")]
        [HttpGet]
        public IHttpActionResult GetServerDetailsById(int Id)
        {
            ServerDetailsDTO serverDetails = new ServerDetailsDTO();

            serverDetails = reportsBo.GetServerDetailsById(Id);

            if (string.IsNullOrEmpty(serverDetails.serverName))
            {
                return NotFound();
            }

            return Ok(serverDetails);
        }

        /// <summary>
        /// Returns all server details.
        /// </summary>
        /// <returns>A JSON list of all server details.</returns>
        [Route("servers/GetAvailableServers")]
        [HttpGet]
        public IHttpActionResult GetAvailableServers()
        {
            IList<ServerDTO> availableServers = new List<ServerDTO>();

            availableServers = reportsBo.GetAvailableServers();

            if (availableServers.Count == 0)
            {
                return NotFound();
            }

            return Ok(availableServers);
        }

    }
}

