using APE.ApplicationServices.Interfaces;
using System.Configuration;
using System;

namespace APE.ApplicationServices.Implementations
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        public string GetConnectionString()
        {
            // Get the connection string from 
            return Environment.GetEnvironmentVariable("APE_CONNECTION_STRING")
                ?? ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
    }
}
