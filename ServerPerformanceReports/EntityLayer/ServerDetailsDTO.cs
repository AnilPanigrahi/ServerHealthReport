using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    /// <summary>
    /// Data transfer object containing ServerDetails
    /// </summary>
    public class ServerDetailsDTO
    {
        /// <summary>
        /// Defines server name
        /// </summary>
        public string serverName { get; set; }

        /// <summary>
        /// Defines servers CPU usage
        /// </summary>
        public string cpuUsage { get; set; }

        /// <summary>
        /// Defines servers memory usage
        /// </summary>
        public string memoryUsage { get; set; }

        /// <summary>
        /// defines servers disk space utilization
        /// </summary>
        public string diskSpace { get; set; }
    }
}
