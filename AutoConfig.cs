using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Security.Principal;

namespace PCConfig
{
	public partial class formAuto : Form
	{
		public formAuto(Config config)
		{
			InitializeComponent();
			this.config = config;
		}
		public formAuto(string activePreset, Int64 minPrice, Int64 maxPrice, string cpuName, string gpuName)
		{
			InitializeComponent();
			this.activePreset = activePreset;
			this.minPrice = minPrice;
			this.maxPrice = maxPrice;
			this.cpuName = cpuName;
			this.gpuName = gpuName;
			config = new Config();
		}

		public string activePreset;
		public int activeConfig = 0;
		public Int64 minPrice;
		public Int64 maxPrice;
		public string cpuName;
		public string gpuName;

		Config config;
		DataRow[] Configs;

		private void UpdateTips(Config config)
		{
			tipCPU.SetToolTip(labelCPU, Convert.ToString(config.CPU["Description"]));
			if (config.GPU != null) tipGPU.SetToolTip(labelGPU, Convert.ToString(config.GPU["Description"]));
			tipMB.SetToolTip(labelMotherboard, Convert.ToString(config.Mother["Description"]));
			tipRAM.SetToolTip(labelRAM, Convert.ToString(config.RAM["Description"]));
			tipPS.SetToolTip(labelPower, Convert.ToString(config.Power["Description"]));
			tipHD.SetToolTip(labelHardDrive, Convert.ToString(config.Hard["Description"]));
			tipCooler.SetToolTip(labelCooler, Convert.ToString(config.Cooler["Description"]));
			tipCase.SetToolTip(labelCase, Convert.ToString(config.Case["Description"]));
			if (config.SSD != null) tipSSD.SetToolTip(labelSSD, Convert.ToString(config.SSD["Description"]));
		}
		public DataTable GetConfigs()
		{
			DataBaseConnection db = new DataBaseConnection();
			db.openConnection();
			MySqlDataAdapter adapter = new MySqlDataAdapter();

			MySqlCommand commandSearchCurrent = new MySqlCommand("SELECT * FROM `configs` WHERE " +
				"`Type` = @aP AND `Price` < @maxP AND `Price` > @minP and `CPU` = @cpuName and `GPU` = @gpuName ORDER BY `Price`", db.getConnection());
			commandSearchCurrent.Parameters.Add("@aP", MySqlDbType.VarChar).Value = activePreset;
			commandSearchCurrent.Parameters.Add("@minP", MySqlDbType.Int64).Value = minPrice;
			commandSearchCurrent.Parameters.Add("@maxP", MySqlDbType.Int64).Value = maxPrice;
			commandSearchCurrent.Parameters.Add("@cpuName", MySqlDbType.VarChar).Value = cpuName;
			commandSearchCurrent.Parameters.Add("@gpuName", MySqlDbType.VarChar).Value = gpuName;

			MySqlCommand commandSearchCurrentCPU = new MySqlCommand("SELECT * FROM `configs` WHERE " +
			  "`Type` = @aP AND `Price` < @maxP AND `Price` > @minP and `CPU` = @cpuName ORDER BY `Price`", db.getConnection());
			commandSearchCurrentCPU.Parameters.Add("@aP", MySqlDbType.VarChar).Value = activePreset;
			commandSearchCurrentCPU.Parameters.Add("@minP", MySqlDbType.Int64).Value = minPrice;
			commandSearchCurrentCPU.Parameters.Add("@maxP", MySqlDbType.Int64).Value = maxPrice;
			commandSearchCurrentCPU.Parameters.Add("@cpuName", MySqlDbType.VarChar).Value = cpuName;

			MySqlCommand commandSearchCurrentGPU = new MySqlCommand("SELECT * FROM `configs` WHERE " +
			  "`Type` = @aP AND `Price` < @maxP AND `Price` > @minP and `GPU` = @gpuName ORDER BY `Price`", db.getConnection());
			commandSearchCurrentGPU.Parameters.Add("@aP", MySqlDbType.VarChar).Value = activePreset;
			commandSearchCurrentGPU.Parameters.Add("@minP", MySqlDbType.Int64).Value = minPrice;
			commandSearchCurrentGPU.Parameters.Add("@maxP", MySqlDbType.Int64).Value = maxPrice;
			commandSearchCurrentGPU.Parameters.Add("@gpuName", MySqlDbType.VarChar).Value = gpuName;

			MySqlCommand commandSearchAll = new MySqlCommand("SELECT * FROM `configs` WHERE " +
			  "`Type` = @aP AND `Price` < @maxP AND `Price` > @minP ORDER BY `Price`", db.getConnection());
			commandSearchAll.Parameters.Add("@aP", MySqlDbType.VarChar).Value = activePreset;
			commandSearchAll.Parameters.Add("@minP", MySqlDbType.Int64).Value = minPrice;
			commandSearchAll.Parameters.Add("@maxP", MySqlDbType.Int64).Value = maxPrice;

			if (cpuName != "")
			{
				if (gpuName != "")
					adapter.SelectCommand = commandSearchCurrent;
				else
					adapter.SelectCommand = commandSearchCurrentCPU;
			}
			else
			{
				if (gpuName != "")
					adapter.SelectCommand = commandSearchCurrentGPU;
				else
					adapter.SelectCommand = commandSearchAll;
			}
			DataTable table = new DataTable();
			adapter.Fill(table);
			db.closeConnection();
			return table;
		}

		private void FillLables(Config config)
		{
			labelCPU.Text = "Процессор: " + config.CPU["Company"] + " " + config.CPU["Model"];

			if (config.GPU != null) labelGPU.Text = "Видеокарта: " + config.GPU["Company"] + " " + config.GPU["Model"] + " на " + config.GPU["Memory"] + " Гб";
			else labelGPU.Text = "Видеокарта: интегрированное графическое ядро процессора";

			labelMotherboard.Text = "Материнская плата: " + config.Mother["Company"] + " " + config.Mother["Model"];
			labelRAM.Text = "Оперативная память: " + config.RAM["Company"] + " " + config.RAM["Model"] + " " + config.RAM["Memory"] + " Гб (" + config.numOfRam + " шт.)";
			labelPower.Text = "Блок питания: " + config.Power["Company"] + " " + config.Power["Model"] + " " + config.Power["Power"] + " Вт";
			labelHardDrive.Text = "Жесткий диск: " + config.Hard["Company"] + " " + config.Hard["Model"] + " на " + config.Hard["Memory"] + " Гб";
			labelCooler.Text = "Куллер: " + config.Cooler["Company"] + " " + config.Cooler["Model"];
			labelCase.Text = "Корпус: " + config.Case["Company"] + " " + config.Case["Model"];

			if (config.SSD != null) labelSSD.Text = "SSD: " + config.SSD["Company"] + " " + config.SSD["Model"] + " на " + config.SSD["Memory"] + " Гб";
			else labelSSD.Text = "SSD: отсутствует";

			labelPrice.Text = "Примерная стоимость: " + config.GetCurrentPrice() + " руб.";
			string path = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + "\\Resources\\" + Convert.ToString(config.Case["Id"]) + ".jpg";
			pictureCase.ImageLocation = path;
		}

		private void formAuto_Load(object sender, EventArgs e)
		{
			Configs = GetConfigs().Select();
			if (!config.isFilled)
			{
				config.Fill(Configs[activeConfig]);
			}
			this.FillLables(config);

			UpdateTips(config);
		}


		private void buttonNextConfig_Click(object sender, EventArgs e)
		{
			if ((activeConfig + 1) <= Configs.Length - 1)
			{
				activeConfig++;
				config.Fill(Configs[activeConfig]);
				this.FillLables(config);
				UpdateTips(config);
			}
		}

		private void buttonPrevConfig_Click(object sender, EventArgs e)
		{
			if ((activeConfig - 1) >= 0)
			{
				activeConfig--;
				config.Fill(Configs[activeConfig]);
				this.FillLables(config);
				UpdateTips(config);
			}
		}

		private void buttonSaveAsFile_Click(object sender, EventArgs e)
		{
			WindowsIdentity wi = WindowsIdentity.GetCurrent();
			string Desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
			StreamWriter sr = new StreamWriter(Desktop + "\\PCConfig.txt");
			sr.WriteLine(labelCPU.Text);
			sr.WriteLine(labelGPU.Text);
			sr.WriteLine(labelRAM.Text);
			sr.WriteLine(labelMotherboard.Text);
			sr.WriteLine(labelPower.Text);
			sr.WriteLine(labelHardDrive.Text);
			sr.WriteLine(labelCooler.Text);
			sr.WriteLine(labelCase.Text);
			sr.WriteLine(labelSSD.Text);
			sr.WriteLine();
			sr.WriteLine(labelPrice.Text);
			sr.Close();
			MessageBox.Show("Ваш файл с кофигурацией \nсохранен на рабочий стол");
		}

		private void buttonChangeConfig_Click(object sender, EventArgs e)
		{
			ChangeConfig changeConfig = new ChangeConfig(config);
			this.Hide();
			changeConfig.Show();
		}
		private void buttonBack_Click(object sender, EventArgs e)
		{
			this.Hide();
			formMain MainForm = new formMain(activePreset, cpuName, gpuName, minPrice, maxPrice);
			MainForm.Show();
		}
		private void buttonClose_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		Point lastPoint;
		private void formAuto_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.Left += e.X - lastPoint.X;
				this.Top += e.Y - lastPoint.Y;
			}
		}

		private void formAuto_MouseDown(object sender, MouseEventArgs e)
		{
			lastPoint = new Point(e.X, e.Y);
		}
	}
}
