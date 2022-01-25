using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace PCConfig
{
	public class Config
	{
		public bool isFilled;
		public int numOfRam;
		public int price;

		public DataRow CPU;
		public DataRow GPU;
		public DataRow RAM;
		public DataRow Mother;
		public DataRow Power;
		public DataRow Case;
		public DataRow Hard;
		public DataRow SSD;
		public DataRow Cooler;

		public void Fill(DataRow Config)
		{
			isFilled = true;

			DataBaseConnection db = new DataBaseConnection();
			db.openConnection();
			MySqlDataAdapter adapter = new MySqlDataAdapter();

			numOfRam = Convert.ToInt32(Config["NumOfRam"]);
			price = Convert.ToInt32(Config["Price"]);

			MySqlCommand commandGetCPU = new MySqlCommand("SELECT * FROM `cpu` WHERE `Id` = @idCPU", db.getConnection());
			commandGetCPU.Parameters.Add("@idCPU", MySqlDbType.Int32).Value = Convert.ToInt32(Config["idCPU"]);

			MySqlCommand commandGetGPU = new MySqlCommand("SELECT * FROM `gpu` WHERE `Id` = @idGPU", db.getConnection());
			commandGetGPU.Parameters.Add("@idGPU", MySqlDbType.Int32).Value = Convert.ToInt32(Config["idGPU"]);

			MySqlCommand commandGetRAM = new MySqlCommand("SELECT * FROM `ram` WHERE `Id` = @idRAM", db.getConnection());
			commandGetRAM.Parameters.Add("@idRAM", MySqlDbType.Int32).Value = Convert.ToInt32(Config["idRAM"]);

			MySqlCommand commandGetMB = new MySqlCommand("SELECT * FROM `motherboard` WHERE `Id` = @idMB", db.getConnection());
			commandGetMB.Parameters.Add("@idMB", MySqlDbType.Int32).Value = Convert.ToInt32(Config["idMB"]);

			MySqlCommand commandGetPS = new MySqlCommand("SELECT * FROM `power` WHERE `Id` = @idPS", db.getConnection());
			commandGetPS.Parameters.Add("@idPS", MySqlDbType.Int32).Value = Convert.ToInt32(Config["idPS"]);

			MySqlCommand commandGetHD = new MySqlCommand("SELECT * FROM `harddrive` WHERE `Id` = @idHD", db.getConnection());
			commandGetHD.Parameters.Add("@idHD", MySqlDbType.Int32).Value = Convert.ToInt32(Config["idHD"]);

			MySqlCommand commandGetCooler = new MySqlCommand("SELECT * FROM `cooler` WHERE `Id` = @idCooler", db.getConnection());
			commandGetCooler.Parameters.Add("@idCooler", MySqlDbType.Int32).Value = Convert.ToInt32(Config["idCooler"]);

			MySqlCommand commandGetCase = new MySqlCommand("SELECT * FROM `case` WHERE `Id` = @idCase", db.getConnection());
			commandGetCase.Parameters.Add("@idCase", MySqlDbType.Int32).Value = Convert.ToInt32(Config["idCase"]);

			MySqlCommand commandGetSSD = new MySqlCommand("SELECT * FROM `ssd` WHERE `Id` = @idSSD", db.getConnection());
			commandGetSSD.Parameters.Add("@idSSD", MySqlDbType.Int32).Value = Convert.ToInt32(Config["idSSD"]);


			DataTable tableCPU = new DataTable();
			adapter.SelectCommand = commandGetCPU;
			adapter.Fill(tableCPU);
			CPU = tableCPU.Select()[0];

			if (DBNull.Value.Equals(Config["idGPU"]) == false)
			{
				DataTable tableGPU = new DataTable();
				adapter.SelectCommand = commandGetGPU;
				adapter.Fill(tableGPU);
				GPU = tableGPU.Select()[0];
			}
			else GPU = null;

			DataTable tableRAM = new DataTable();
			adapter.SelectCommand = commandGetRAM;
			adapter.Fill(tableRAM);
			RAM = tableRAM.Select()[0];

			DataTable tableMB = new DataTable();
			adapter.SelectCommand = commandGetMB;
			adapter.Fill(tableMB);
			Mother = tableMB.Select()[0];

			DataTable tablePS = new DataTable();
			adapter.SelectCommand = commandGetPS;
			adapter.Fill(tablePS);
			Power = tablePS.Select()[0];

			DataTable tableHD = new DataTable();
			adapter.SelectCommand = commandGetHD;
			adapter.Fill(tableHD);
			Hard = tableHD.Select()[0];

			DataTable tableCooler = new DataTable();
			adapter.SelectCommand = commandGetCooler;
			adapter.Fill(tableCooler);
			Cooler = tableCooler.Select()[0];

			DataTable tableCase = new DataTable();
			adapter.SelectCommand = commandGetCase;
			adapter.Fill(tableCase);
			Case = tableCase.Select()[0];

			if (DBNull.Value.Equals(Config["idSSD"]) == false)
			{
				DataTable tableSSD = new DataTable();
				adapter.SelectCommand = commandGetSSD;
				adapter.Fill(tableSSD);
				SSD = tableSSD.Select()[0];
			}
			else SSD = null;
			db.closeConnection();
		}

		public int GetCurrentPrice()
		{
			int currentPrice = (int)CPU["Price"] + (int)RAM["Price"] * numOfRam + (int)Mother["Price"] + (int)Hard["Price"]
			  + (int)Cooler["Price"] + (int)Case["Price"];
			if (GPU == null) currentPrice += (int)GPU["Price"];
			if (SSD == null) currentPrice += (int)SSD["Price"];
			return currentPrice;
		}
	}
}
