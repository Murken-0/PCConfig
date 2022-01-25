using MySql.Data.MySqlClient;
using System.Data;

namespace PCConfig
{
	public class SQLCommandManager
	{
		MySqlDataAdapter adapter = new MySqlDataAdapter();
		DataBaseConnection connection = new DataBaseConnection();
		MySqlCommand command;

		public DataTable GetTableByRequest(MySqlCommand requestCommand)
		{
			DataTable table = new DataTable();
			command = requestCommand;
			command.Connection = connection.getConnection();

			connection.openConnection();

			adapter.SelectCommand = command;
			adapter.Fill(table);

			connection.closeConnection();

			return table;
		}
	}
}
