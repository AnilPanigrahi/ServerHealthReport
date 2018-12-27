using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    /// <summary>
    /// Data transfer object containing serverName And Id
    /// </summary>
    public class ServerDTO
    {
        public string serverName { get; set; }

        public int serverId { get; set; }
    }
}
