using System;
using System.Data;
using System.Data.SQLite;
using System.Reflection;

namespace Automator.DataAccess
{
    // ReSharper disable once InconsistentNaming
    public class DBHelper: IDisposable
    {
        private SQLiteConnection _connection;

        public DBHelper()
        {
            Intialize();
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }

        public DataTable ExecuteQuery(string commandText)
        {
            Open();
            var command = new SQLiteCommand(commandText, _connection);
            var da = new SQLiteDataAdapter();
            var dt = new DataTable();

            da.SelectCommand = command;
            da.Fill(dt);
            command.Dispose();

            return dt;
        }

        public int ExecuteNonQuery(string commandText)
        {
            Open();
            var command = _connection.CreateCommand();
            command.CommandText = commandText;
            var result = command.ExecuteNonQuery();

            return result;
        }

        private void Open()
        {
            if (_connection != null && _connection.State != ConnectionState.Closed)
            {
                return;
            }

            _connection = new SQLiteConnection { ConnectionString = DBLocation() };
            _connection.Open();
        }
        
        private void Intialize()
        {
            ExecuteNonQuery("CREATE TABLE IF NOT EXISTS Functions (Function Name, Param TEXT);");
            ExecuteNonQuery("CREATE TABLE IF NOT EXISTS TrainingData (Function TEXT, Data TEXT);");
        }

        // ReSharper disable once InconsistentNaming
        private static string DBLocation()
        {
            var dir = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            return "Data Source=" + dir + "\\AutomationDB.db;";
        }
    }
}