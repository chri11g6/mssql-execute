using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.IO;
using System.Net;
using System.Threading;

namespace mssql_execute {
    class Program {
        private static readonly string username = Environment.GetEnvironmentVariable("USERNAME");
        private static readonly string password = Environment.GetEnvironmentVariable("PASSWORD");
        private static readonly string serverurl = Environment.GetEnvironmentVariable("SERVERURL");
        private static readonly string port = Environment.GetEnvironmentVariable("PORT");
        private static readonly string database = Environment.GetEnvironmentVariable("DATABASE");
        private static readonly string delay = Environment.GetEnvironmentVariable("DELAY");

        private static SqlConnection connection;

        static void Main(string[] arg) {
            TestHostName();

            Console.WriteLine($"Delay --> {delay}ms");
            Thread.Sleep(Int32.Parse(delay));

            OpenSqlConnection();

            string sqlCmd = ReadSqlFile();

            ExecuteCmd(sqlCmd);

            connection.Close();

            Console.WriteLine("Don");
        }

        private static void TestHostName() {
            try {
                IPAddress[] addr = Dns.GetHostAddresses(serverurl);
                string ip = addr[addr.Length - 1].ToString();

                Console.WriteLine($"[DNS] {serverurl} ---> {ip}");
            } catch {
                Console.WriteLine("[DNS] Could not run DNS check");
            }
        }

        private static string ReadSqlFile() {
            const string filePath = "./execute.sql";

            return File.ReadAllText(filePath);
        }

        private static void ExecuteCmd(string executeCmd) {
            Server server = new Server(new ServerConnection(connection));

            server.ConnectionContext.ExecuteNonQuery(executeCmd);
        }

        private static void OpenSqlConnection() {
            connection = new SqlConnection($"User ID= {username};" +
                                       $"Password={password};Data Source={serverurl},{port};" +
                                       $"Initial Catalog={database};");

            Console.WriteLine($"Connection to {serverurl}");
            connection.Open();
        }

    }
}
