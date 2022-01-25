using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PCConfig
{
	public partial class ChangeConfig : Form
	{
		public ChangeConfig(Config config)
		{
			InitializeComponent();
			this.config = config;
		}

		private Config config;
		private Config usconfig;
		private readonly SQLCommandManager cmdManager = new SQLCommandManager();

		private DataRow[] CPU;
		private DataRow[] GPU;
		private DataRow[] RAM;
		private DataRow[] Mother;
		private DataRow[] Power;
		private DataRow[] Case;
		private DataRow[] Hard;
		private DataRow[] SSD;
		private DataRow[] Cooler;

		private void FillCombos(Config config)
		{
			CPUComboBox.Text = config.CPU["Company"] + " " + config.CPU["Model"];

			if (config.GPU != null) GPUComboBox.Text = config.GPU["Company"] + " " + config.GPU["Model"] + " на " + config.GPU["Memory"] + " Гб";
			else GPUComboBox.Text = "Интегрированное графическое ядро процессора";

			MotherComboBox.Text = config.Mother["Company"] + " " + config.Mother["Model"];
			RAMComboBox.Text = config.RAM["Company"] + " " + config.RAM["Model"] + " " + config.RAM["Memory"] + " Гб";
			NumOfRamComboBox.Text = config.numOfRam.ToString() + " шт.";
			PowerComboBox.Text = config.Power["Company"] + " " + config.Power["Model"] + " " + config.Power["Power"] + " Вт";
			HardComboBox.Text = config.Hard["Company"] + " " + config.Hard["Model"] + " на " + config.Hard["Memory"] + " Гб";
			CoolerComboBox.Text = config.Cooler["Company"] + " " + config.Cooler["Model"];
			CaseComboBox.Text = config.Case["Company"] + " " + config.Case["Model"];

			if (config.SSD != null) SSDComboBox.Text = config.SSD["Company"] + " " + config.SSD["Model"] + " на " + config.SSD["Memory"] + " Гб";
			else SSDComboBox.Text = "Отсутствует";

			labelPrice.Text = config.GetCurrentPrice() + " руб.";
		}

		private void ChangeConfig_Load(object sender, EventArgs e)
		{
			usconfig = config;
			FillCombos(usconfig);
		}

		private void BackButton_Click(object sender, EventArgs e)
		{
			AutoForm changedAuto = new AutoForm(config);
			this.Hide();
			changedAuto.Show();
		}
		private void CloseButton_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			config = usconfig;
			AutoForm changedAuto = new AutoForm(config);
			this.Hide();
			changedAuto.Show();
		}

		private void ChangeCPUButton_Click(object sender, EventArgs e)
		{
			MySqlCommand commandGetCPU = new MySqlCommand("SELECT * FROM `cpu` WHERE `Company` = @reqCom AND `Socket` = @reqSocket ORDER BY `Price`");
			commandGetCPU.Parameters.Add("@reqCom", MySqlDbType.VarChar).Value = usconfig.CPU["Company"];
			commandGetCPU.Parameters.Add("@reqSocket", MySqlDbType.VarChar).Value = usconfig.CPU["Socket"];
			
			CPU = cmdManager.GetTableByRequest(commandGetCPU).Select();
			string[] listSt = new string[CPU.Length];
			for (int i = 0; i < CPU.Length; i++)
			{
				listSt[i] = CPU[i]["Company"] + " " + CPU[i]["Model"];
			}
			CPUComboBox.Items.Clear();
			CPUComboBox.Items.AddRange(listSt);
		}
		private void ComboCPU_SelectedIndexChanged(object sender, EventArgs e)
		{
			usconfig.CPU = CPU[CPUComboBox.Items.IndexOf(CPUComboBox.Text)];
			labelPrice.Text = usconfig.GetCurrentPrice().ToString() + " руб.";
		}

		private void ChbuttonGPU_Click(object sender, EventArgs e)
		{
			MySqlCommand commandGetGPU = new MySqlCommand("SELECT * FROM `gpu` WHERE `Company` = @reqParam ORDER BY `Price`");
			commandGetGPU.Parameters.Add("@reqParam", MySqlDbType.VarChar).Value = usconfig.GPU["Company"];

			GPU = cmdManager.GetTableByRequest(commandGetGPU).Select();
			string[] listSt = new string[GPU.Length];
			for (int i = 0; i < GPU.Length; i++)
			{
				listSt[i] = GPU[i]["Company"] + " " + GPU[i]["Model"] + " на " + GPU[i]["Memory"] + " Гб";
			}
			GPUComboBox.Items.Clear();
			GPUComboBox.Items.AddRange(listSt);
		}

		private void ComboGPU_SelectedIndexChanged(object sender, EventArgs e)
		{
			usconfig.GPU = GPU[GPUComboBox.Items.IndexOf(GPUComboBox.Text)];
			labelPrice.Text = usconfig.GetCurrentPrice().ToString() + " руб.";
		}

		private void ChbuttonMother_Click(object sender, EventArgs e)
		{
			MySqlCommand commandGetMB = new MySqlCommand("SELECT * FROM `motherboard` WHERE `Socket` = @reqSocket AND `NumOfRam` > @nRam ORDER BY `Price`");
			commandGetMB.Parameters.Add("@reqSocket", MySqlDbType.VarChar).Value = usconfig.CPU["Socket"];
			commandGetMB.Parameters.Add("@nRam", MySqlDbType.Int32).Value = usconfig.numOfRam;

			Mother = cmdManager.GetTableByRequest(commandGetMB).Select();
			string[] listSt = new string[Mother.Length];
			for (int i = 0; i < Mother.Length; i++)
			{
				listSt[i] = Mother[i]["Company"] + " " + Mother[i]["Model"];
			}
			MotherComboBox.Items.Clear();
			MotherComboBox.Items.AddRange(listSt);
		}

		private void ComboMother_SelectedIndexChanged(object sender, EventArgs e)
		{
			usconfig.Mother = Mother[MotherComboBox.Items.IndexOf(MotherComboBox.Text)];
			labelPrice.Text = usconfig.GetCurrentPrice().ToString() + " руб.";
		}

		private void ChbuttonRam_Click(object sender, EventArgs e)
		{
			MySqlCommand commandGetRam = new MySqlCommand("SELECT * FROM `ram` ORDER BY `Price`");

			RAM = cmdManager.GetTableByRequest(commandGetRam).Select();
			string[] listSt = new string[RAM.Length];
			for (int i = 0; i < RAM.Length; i++)
			{
				listSt[i] = RAM[i]["Company"] + " " + RAM[i]["Model"] + " " + RAM[i]["Memory"] + " GB";
			}
			RAMComboBox.Items.Clear();
			RAMComboBox.Items.AddRange(listSt);
		}

		private void ComboRAM_SelectedIndexChanged(object sender, EventArgs e)
		{
			usconfig.RAM = RAM[RAMComboBox.Items.IndexOf(RAMComboBox.Text)];
			labelPrice.Text = usconfig.GetCurrentPrice().ToString() + " руб.";
		}

		private void ChbuttonNumOfRam_Click(object sender, EventArgs e)
		{
			RAMComboBox.Items.Clear();
			for (int i = 1; i <= Convert.ToInt32(usconfig.Mother["NumOfRam"]); i++)
			{
				NumOfRamComboBox.Items.Add(i + " шт.");
			}
		}

		private void ComboNumOfRam_SelectedIndexChanged(object sender, EventArgs e)
		{
			string[] list = NumOfRamComboBox.Text.Split(' ');
			usconfig.numOfRam = Convert.ToInt32(list[0]);
			labelPrice.Text = usconfig.GetCurrentPrice().ToString() + " руб.";
		}

		private void ChbuttonPower_Click(object sender, EventArgs e)
		{
			MySqlCommand commandGetPS = new MySqlCommand("SELECT * FROM `power` WHERE `Power` > @pow ORDER BY `Price`");
			commandGetPS.Parameters.Add("@pow", MySqlDbType.Int32).Value = usconfig.GPU["recPower"];
			
			Power = cmdManager.GetTableByRequest(commandGetPS).Select();
			string[] listSt = new string[Power.Length];
			for (int i = 0; i < Power.Length; i++)
			{
				listSt[i] = Power[i]["Company"] + " " + Power[i]["Model"] + " на " + Power[i]["Power"] + " Вт";
			}
			PowerComboBox.Items.Clear();
			PowerComboBox.Items.AddRange(listSt);
		}

		private void ComboPower_SelectedIndexChanged(object sender, EventArgs e)
		{
			usconfig.Power = Power[PowerComboBox.Items.IndexOf(PowerComboBox.Text)];
			labelPrice.Text = usconfig.GetCurrentPrice().ToString() + " руб.";
		}

		private void ChbuttonHard_Click(object sender, EventArgs e)
		{

			MySqlCommand commandGetHD = new MySqlCommand("SELECT * FROM `harddrive` ORDER BY `Price`");

			Hard = cmdManager.GetTableByRequest(commandGetHD).Select();
			string[] listSt = new string[Hard.Length];
			for (int i = 0; i < Hard.Length; i++)
			{
				listSt[i] = Hard[i]["Company"] + " " + Hard[i]["Model"] + " на " + Hard[i]["Memory"] + " Гб";
			}
			HardComboBox.Items.Clear();
			HardComboBox.Items.AddRange(listSt);
		}

		private void ComboHard_SelectedIndexChanged(object sender, EventArgs e)
		{
			usconfig.Hard = Hard[HardComboBox.Items.IndexOf(HardComboBox.Text)];
			labelPrice.Text = usconfig.GetCurrentPrice().ToString() + " руб.";
		}

		private void ChbuttonCooler_Click(object sender, EventArgs e)
		{
			MySqlCommand commandGetCooler = new MySqlCommand("SELECT * FROM `cooler` WHERE `TDP` > @tdp ORDER BY `Price`");
			commandGetCooler.Parameters.Add("@tdp", MySqlDbType.Int32).Value = usconfig.CPU["TDP"];
			
			Cooler = cmdManager.GetTableByRequest(commandGetCooler).Select();
			string[] listSt = new string[Cooler.Length];
			for (int i = 0; i < Cooler.Length; i++)
			{
				listSt[i] = Cooler[i]["Company"] + " " + Cooler[i]["Model"];
			}
			CoolerComboBox.Items.Clear();
			CoolerComboBox.Items.AddRange(listSt);
		}

		private void ComboCooler_SelectedIndexChanged(object sender, EventArgs e)
		{
			usconfig.Cooler = Cooler[CoolerComboBox.Items.IndexOf(CoolerComboBox.Text)];
			labelPrice.Text = usconfig.GetCurrentPrice().ToString() + " руб.";
		}

		private void ChbuttonCase_Click(object sender, EventArgs e)
		{
			MySqlCommand commandGetCase = new MySqlCommand("SELECT * FROM `case` WHERE `Form` = @form ORDER BY `Price`");
			commandGetCase.Parameters.Add("@form", MySqlDbType.VarChar).Value = usconfig.Mother["Form"];

			Case = cmdManager.GetTableByRequest(commandGetCase).Select();
			string[] listSt = new string[Case.Length];
			for (int i = 0; i < Case.Length; i++)
			{
				listSt[i] = Case[i]["Company"] + " " + Case[i]["Model"];
			}
			CaseComboBox.Items.Clear();
			CaseComboBox.Items.AddRange(listSt);
		}

		private void ComboCase_SelectedIndexChanged(object sender, EventArgs e)
		{
			usconfig.Case = Case[CaseComboBox.Items.IndexOf(CaseComboBox.Text)];
			labelPrice.Text = usconfig.GetCurrentPrice().ToString() + " руб.";
		}

		private void ButtonSSD_Click(object sender, EventArgs e)
		{
			MySqlCommand commandGetSSD = new MySqlCommand("SELECT * FROM `ssd` ORDER BY `Price`");
			
			SSD = cmdManager.GetTableByRequest(commandGetSSD).Select();
			string[] listSt = new string[SSD.Length];
			for (int i = 0; i < SSD.Length; i++)
			{
				listSt[i] = SSD[i]["Company"] + " " + SSD[i]["Model"] + " на " + SSD[i]["Memory"] + " Гб";
			}
			SSDComboBox.Items.Clear();
			SSDComboBox.Items.AddRange(listSt);
		}

		private void ComboSSD_SelectedIndexChanged(object sender, EventArgs e)
		{
			usconfig.SSD = SSD[SSDComboBox.Items.IndexOf(SSDComboBox.Text)];
			labelPrice.Text = usconfig.GetCurrentPrice().ToString() + " руб.";
		}


		Point lastPoint;
		private void ChangeConfig_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.Left += e.X - lastPoint.X;
				this.Top += e.Y - lastPoint.Y;
			}
		}

		private void ChangeConfig_MouseDown(object sender, MouseEventArgs e)
		{
			lastPoint = new Point(e.X, e.Y);
		}
	}
}
