using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Data;
using EntityLayer;

namespace ServerPerformanceReportsDAO
{
    public class ServerReportsDAO : IServerReportsDAO
    {
        #region member variables and Properties

        private static readonly string ModuleName = typeof(ServerReportsDAO).Namespace;
        private static readonly string ClassName = typeof(ServerReportsDAO).Name;

        private SQLiteConnection sql_connection;
        private SQLiteCommand sql_command;
        private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();

        #endregion member variables and Properties

        #region private Methods

        /// <summary>
        /// Sets the connection to the SQLLite DB
        /// </summary>
        private void SetConnection()
        {
            
            sql_connection = new SQLiteConnection("Data Source=C:\\Users\\Vijay\\Desktop\\SourceCode\\ServerPerformanceReports\\ServerPerformanceReportsDAO\\Database\\ServerReports.db;Version=3;"); // connection string will be moved config file
        }

        /// <summary>
        /// generic function to ExecuteQuery
        /// </summary>
        private DataTable ExecuteQuery(string sqlStatement)
        {
            SetConnection();
            sql_connection.Open();
            sql_command = sql_connection.CreateCommand();
            DB = new SQLiteDataAdapter(sqlStatement, sql_connection);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            sql_connection.Close();

            return DT;
        }

        private IList<ServerDetailsDTO> ServerDetailsDataMapper(DataTable dt)
        {
            IList<ServerDetailsDTO> dataMapper = new List<ServerDetailsDTO>();

            foreach (DataRow dataRow in dt.Rows)
            {
                dataMapper.Add(new ServerDetailsDTO()
                {
                    serverName = Convert.ToString(dataRow["serverName"]),
                    cpuUsage = Convert.ToString( dataRow["cpuUsage"]),
                    diskSpace = Convert.ToString(dataRow["diskSpace"]),
                    memoryUsage = Convert.ToString(dataRow["memoryUsage"])
                });
            }
                         
            return dataMapper;
        }

        private IList<ServerDTO> ServersDataMapper(DataTable dt)
        {
            IList<ServerDTO> dataMapper = new List<ServerDTO>();

            foreach (DataRow dataRow in dt.Rows)
            {
                dataMapper.Add(new ServerDTO()
                {
                    serverName = Convert.ToString(dataRow["serverName"]),
                    serverId = Convert.ToInt32(dataRow["serverId"])
                });
            }

            return dataMapper;
        }

        #endregion private Methods

        #region public Methods

        /// <summary>
        /// Gets all server details.
        /// </summary>
        /// <returns>A list of ServerDetailsDTO.</returns>
        public IList<ServerDetailsDTO> GetAllServerDetails()
        {
            IList<ServerDetailsDTO> serverDetails = new List<ServerDetailsDTO>();
            string sqlStatement = @"select s.server_Name as 'serverName',SR.cpu_usage as 'cpuUsage', SR.disk_usage as 'diskSpace',SR.memory_usage as 'memoryUsage' from ServerReports SR
                                    inner join servers s on s.server_Id = SR.Server_Id";
            try
            {
                DataTable dt = ExecuteQuery(sqlStatement);
                serverDetails = ServerDetailsDataMapper(dt);                   
            }
            catch (Exception ex)
            {
                // Loggin into Event VWR \ Splunk;
            }
            
            return serverDetails;
        }

        /// <summary>
        /// Gets all available server names and Id.
        /// </summary>
        /// <returns>A list of ServerDTO.</returns>
        public IList<ServerDTO> GetAvailableServers()
        {
            IList<ServerDTO> servers = new List<ServerDTO>();
            string sqlStatement = "select s.server_Name as 'serverName', s.server_id as 'serverId' from servers s";
            try
            {
                DataTable dt = ExecuteQuery(sqlStatement);
                servers = ServersDataMapper(dt);
            }
            catch (Exception ex)
            {
                // Loggin into Event VWR \ Splunk;
            }

            return servers;
        }

        /// <summary>
        /// Gets server details for the given server Id.
        /// </summary>
        /// <returns>A ServerDetailsDTO object.</returns>
        public ServerDetailsDTO GetServerDetailsById(int serverId)
        {
            IList<ServerDetailsDTO> serverDetails = new List<ServerDetailsDTO>();
            string sqlStatement = @"select s.server_Name as 'serverName',SR.cpu_usage as 'cpuUsage', SR.disk_usage as 'diskSpace',SR.memory_usage as 'memoryUsage' from ServerReports SR
                                    inner join servers s on s.server_Id = SR.Server_Id
                                    Where S.Server_Id = @serverId";
            try
            {
                sqlStatement = sqlStatement.Replace("@serverId", serverId.ToString());
                DataTable dt = ExecuteQuery(sqlStatement);
                serverDetails = ServerDetailsDataMapper(dt);
            }
            catch (Exception ex)
            {
                // Loggin into Event VWR \ Splunk;
            }

            return serverDetails[0];
        }

        #endregion public Methods


    }
}
