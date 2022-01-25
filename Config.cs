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
			SQLCommandManager cmdManager = new SQLCommandManager();

			numOfRam = Convert.ToInt32(Config["NumOfRam"]);
			price = Convert.ToInt32(Config["Price"]);

			MySqlCommand commandGetCPU = new MySqlCommand("SELECT * FROM `cpu` WHERE `Id` = @idCPU");
			commandGetCPU.Parameters.Add("@idCPU", MySqlDbType.Int32).Value = Convert.ToInt32(Config["idCPU"]);

			MySqlCommand commandGetGPU = new MySqlCommand("SELECT * FROM `gpu` WHERE `Id` = @idGPU");
			commandGetGPU.Parameters.Add("@idGPU", MySqlDbType.Int32).Value = Convert.ToInt32(Config["idGPU"]);

			MySqlCommand commandGetRAM = new MySqlCommand("SELECT * FROM `ram` WHERE `Id` = @idRAM");
			commandGetRAM.Parameters.Add("@idRAM", MySqlDbType.Int32).Value = Convert.ToInt32(Config["idRAM"]);

			MySqlCommand commandGetMB = new MySqlCommand("SELECT * FROM `motherboard` WHERE `Id` = @idMB");
			commandGetMB.Parameters.Add("@idMB", MySqlDbType.Int32).Value = Convert.ToInt32(Config["idMB"]);

			MySqlCommand commandGetPS = new MySqlCommand("SELECT * FROM `power` WHERE `Id` = @idPS");
			commandGetPS.Parameters.Add("@idPS", MySqlDbType.Int32).Value = Convert.ToInt32(Config["idPS"]);

			MySqlCommand commandGetHD = new MySqlCommand("SELECT * FROM `harddrive` WHERE `Id` = @idHD");
			commandGetHD.Parameters.Add("@idHD", MySqlDbType.Int32).Value = Convert.ToInt32(Config["idHD"]);

			MySqlCommand commandGetCooler = new MySqlCommand("SELECT * FROM `cooler` WHERE `Id` = @idCooler");
			commandGetCooler.Parameters.Add("@idCooler", MySqlDbType.Int32).Value = Convert.ToInt32(Config["idCooler"]);

			MySqlCommand commandGetCase = new MySqlCommand("SELECT * FROM `case` WHERE `Id` = @idCase");
			commandGetCase.Parameters.Add("@idCase", MySqlDbType.Int32).Value = Convert.ToInt32(Config["idCase"]);

			MySqlCommand commandGetSSD = new MySqlCommand("SELECT * FROM `ssd` WHERE `Id` = @idSSD");
			commandGetSSD.Parameters.Add("@idSSD", MySqlDbType.Int32).Value = Convert.ToInt32(Config["idSSD"]);


			
			CPU = cmdManager.GetTableByRequest(commandGetCPU).Select()[0];
			if (DBNull.Value.Equals(Config["idGPU"]) == false)
				GPU = cmdManager.GetTableByRequest(commandGetGPU).Select()[0];
			else 
				GPU = null;
			
			RAM = cmdManager.GetTableByRequest(commandGetRAM).Select()[0];
			Mother = cmdManager.GetTableByRequest(commandGetMB).Select()[0];
			Power = cmdManager.GetTableByRequest(commandGetPS).Select()[0];
			Hard = cmdManager.GetTableByRequest(commandGetHD).Select()[0];
			Cooler = cmdManager.GetTableByRequest(commandGetCooler).Select()[0];
			Case = cmdManager.GetTableByRequest(commandGetCase).Select()[0];
			if (DBNull.Value.Equals(Config["idSSD"]) == false)
				SSD = cmdManager.GetTableByRequest(commandGetSSD).Select()[0];
			else 
				SSD = null;
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
