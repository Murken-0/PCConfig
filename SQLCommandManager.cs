using MySql.Data.MySqlClient;
using System.Data;

namespace PCConfig
{
	public class SQLCommandManager
	{
		private readonly MySqlDataAdapter adapter = new MySqlDataAdapter();
		private readonly MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;database=pcconfig");

		private void OpenConnection()
		{
			if (connection.State == System.Data.ConnectionState.Closed)
				connection.Open();
		}
		private void CloseConnection()
		{
			if (connection.State == System.Data.ConnectionState.Open)
				connection.Close();
		}

		public DataTable GetTableByRequest(MySqlCommand requestCommand)
		{
			DataTable table = new DataTable();
			MySqlCommand command = requestCommand;
			command.Connection = connection;

			OpenConnection();

			adapter.SelectCommand = command;
			adapter.Fill(table);

			CloseConnection();

			return table;
		}
	}
}
