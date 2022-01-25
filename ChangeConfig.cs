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
		private SQLCommandManager cmdManager;

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
			comboCPU.Text = config.CPU["Company"] + " " + config.CPU["Model"];

			if (config.GPU != null) comboGPU.Text = config.GPU["Company"] + " " + config.GPU["Model"] + " на " + config.GPU["Memory"] + " Гб";
			else comboGPU.Text = "Интегрированное графическое ядро процессора";

			comboMother.Text = config.Mother["Company"] + " " + config.Mother["Model"];
			comboRAM.Text = config.RAM["Company"] + " " + config.RAM["Model"] + " " + config.RAM["Memory"] + " Гб";
			comboNumOfRam.Text = config.numOfRam.ToString() + " шт.";
			comboPower.Text = config.Power["Company"] + " " + config.Power["Model"] + " " + config.Power["Power"] + " Вт";
			comboHard.Text = config.Hard["Company"] + " " + config.Hard["Model"] + " на " + config.Hard["Memory"] + " Гб";
			comboCooler.Text = config.Cooler["Company"] + " " + config.Cooler["Model"];
			comboCase.Text = config.Case["Company"] + " " + config.Case["Model"];

			if (config.SSD != null) comboSSD.Text = config.SSD["Company"] + " " + config.SSD["Model"] + " на " + config.SSD["Memory"] + " Гб";
			else comboSSD.Text = "Отсутствует";

			labelPrice.Text = config.GetCurrentPrice() + " руб.";
		}

		private void ChangeConfig_Load(object sender, EventArgs e)
		{
			usconfig = config;
			FillCombos(usconfig);
		}

		private void buttonBack_Click(object sender, EventArgs e)
		{
			formAuto changedAuto = new formAuto(config);
			this.Hide();
			changedAuto.Show();
		}
		private void buttonClose_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			config = usconfig;
			formAuto changedAuto = new formAuto(config);
			this.Hide();
			changedAuto.Show();
		}

		private void chbuttonCPU_Click(object sender, EventArgs e)
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
			comboCPU.Items.Clear();
			comboCPU.Items.AddRange(listSt);
		}
		private void comboCPU_SelectedIndexChanged(object sender, EventArgs e)
		{
			usconfig.CPU = CPU[comboCPU.Items.IndexOf(comboCPU.Text)];
			labelPrice.Text = usconfig.GetCurrentPrice().ToString() + " руб.";
		}

		private void chbuttonGPU_Click(object sender, EventArgs e)
		{
			MySqlCommand commandGetGPU = new MySqlCommand("SELECT * FROM `gpu` WHERE `Company` = @reqParam ORDER BY `Price`");
			commandGetGPU.Parameters.Add("@reqParam", MySqlDbType.VarChar).Value = usconfig.GPU["Company"];

			GPU = cmdManager.GetTableByRequest(commandGetGPU).Select();
			string[] listSt = new string[GPU.Length];
			for (int i = 0; i < GPU.Length; i++)
			{
				listSt[i] = GPU[i]["Company"] + " " + GPU[i]["Model"] + " на " + GPU[i]["Memory"] + " Гб";
			}
			comboGPU.Items.Clear();
			comboGPU.Items.AddRange(listSt);
		}

		private void comboGPU_SelectedIndexChanged(object sender, EventArgs e)
		{
			usconfig.GPU = GPU[comboGPU.Items.IndexOf(comboGPU.Text)];
			labelPrice.Text = usconfig.GetCurrentPrice().ToString() + " руб.";
		}

		private void chbuttonMother_Click(object sender, EventArgs e)
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
			comboMother.Items.Clear();
			comboMother.Items.AddRange(listSt);
		}

		private void comboMother_SelectedIndexChanged(object sender, EventArgs e)
		{
			usconfig.Mother = Mother[comboMother.Items.IndexOf(comboMother.Text)];
			labelPrice.Text = usconfig.GetCurrentPrice().ToString() + " руб.";
		}

		private void chbuttonRam_Click(object sender, EventArgs e)
		{
			DataTable table = new DataTable();
			MySqlCommand commandGetRam = new MySqlCommand("SELECT * FROM `ram` ORDER BY `Price`");

			RAM = cmdManager.GetTableByRequest(commandGetRam).Select();
			string[] listSt = new string[RAM.Length];
			for (int i = 0; i < RAM.Length; i++)
			{
				listSt[i] = RAM[i]["Company"] + " " + RAM[i]["Model"] + " " + RAM[i]["Memory"] + " GB";
			}
			comboRAM.Items.Clear();
			comboRAM.Items.AddRange(listSt);
		}

		private void comboRAM_SelectedIndexChanged(object sender, EventArgs e)
		{
			usconfig.RAM = RAM[comboRAM.Items.IndexOf(comboRAM.Text)];
			labelPrice.Text = usconfig.GetCurrentPrice().ToString() + " руб.";
		}

		private void chbuttonNumOfRam_Click(object sender, EventArgs e)
		{
			comboRAM.Items.Clear();
			for (int i = 1; i <= Convert.ToInt32(usconfig.Mother["NumOfRam"]); i++)
			{
				comboNumOfRam.Items.Add(i + " шт.");
			}
		}

		private void comboNumOfRam_SelectedIndexChanged(object sender, EventArgs e)
		{
			string[] list = comboNumOfRam.Text.Split(' ');
			usconfig.numOfRam = Convert.ToInt32(list[0]);
			labelPrice.Text = usconfig.GetCurrentPrice().ToString() + " руб.";
		}

		private void chbuttonPower_Click(object sender, EventArgs e)
		{
			MySqlCommand commandGetPS = new MySqlCommand("SELECT * FROM `power` WHERE `Power` > @pow ORDER BY `Price`");
			commandGetPS.Parameters.Add("@pow", MySqlDbType.Int32).Value = usconfig.GPU["recPower"];
			
			Power = cmdManager.GetTableByRequest(commandGetPS).Select();
			string[] listSt = new string[Power.Length];
			for (int i = 0; i < Power.Length; i++)
			{
				listSt[i] = Power[i]["Company"] + " " + Power[i]["Model"] + " на " + Power[i]["Power"] + " Вт";
			}
			comboPower.Items.Clear();
			comboPower.Items.AddRange(listSt);
		}

		private void comboPower_SelectedIndexChanged(object sender, EventArgs e)
		{
			usconfig.Power = Power[comboPower.Items.IndexOf(comboPower.Text)];
			labelPrice.Text = usconfig.GetCurrentPrice().ToString() + " руб.";
		}

		private void chbuttonHard_Click(object sender, EventArgs e)
		{

			MySqlCommand commandGetHD = new MySqlCommand("SELECT * FROM `harddrive` ORDER BY `Price`");

			Hard = cmdManager.GetTableByRequest(commandGetHD).Select();
			string[] listSt = new string[Hard.Length];
			for (int i = 0; i < Hard.Length; i++)
			{
				listSt[i] = Hard[i]["Company"] + " " + Hard[i]["Model"] + " на " + Hard[i]["Memory"] + " Гб";
			}
			comboHard.Items.Clear();
			comboHard.Items.AddRange(listSt);
		}

		private void comboHard_SelectedIndexChanged(object sender, EventArgs e)
		{
			usconfig.Hard = Hard[comboHard.Items.IndexOf(comboHard.Text)];
			labelPrice.Text = usconfig.GetCurrentPrice().ToString() + " руб.";
		}

		private void chbuttonCooler_Click(object sender, EventArgs e)
		{
			MySqlCommand commandGetCooler = new MySqlCommand("SELECT * FROM `cooler` WHERE `TDP` > @tdp ORDER BY `Price`");
			commandGetCooler.Parameters.Add("@tdp", MySqlDbType.Int32).Value = usconfig.CPU["TDP"];
			
			Cooler = cmdManager.GetTableByRequest(commandGetCooler).Select();
			string[] listSt = new string[Cooler.Length];
			for (int i = 0; i < Cooler.Length; i++)
			{
				listSt[i] = Cooler[i]["Company"] + " " + Cooler[i]["Model"];
			}
			comboCooler.Items.Clear();
			comboCooler.Items.AddRange(listSt);
		}

		private void comboCooler_SelectedIndexChanged(object sender, EventArgs e)
		{
			usconfig.Cooler = Cooler[comboCooler.Items.IndexOf(comboCooler.Text)];
			labelPrice.Text = usconfig.GetCurrentPrice().ToString() + " руб.";
		}

		private void chbuttonCase_Click(object sender, EventArgs e)
		{
			MySqlCommand commandGetCase = new MySqlCommand("SELECT * FROM `case` WHERE `Form` = @form ORDER BY `Price`");
			commandGetCase.Parameters.Add("@form", MySqlDbType.VarChar).Value = usconfig.Mother["Form"];

			Case = cmdManager.GetTableByRequest(commandGetCase).Select();
			string[] listSt = new string[Case.Length];
			for (int i = 0; i < Case.Length; i++)
			{
				listSt[i] = Case[i]["Company"] + " " + Case[i]["Model"];
			}
			comboCase.Items.Clear();
			comboCase.Items.AddRange(listSt);
		}

		private void comboCase_SelectedIndexChanged(object sender, EventArgs e)
		{
			usconfig.Case = Case[comboCase.Items.IndexOf(comboCase.Text)];
			labelPrice.Text = usconfig.GetCurrentPrice().ToString() + " руб.";
		}

		private void buttonSSD_Click(object sender, EventArgs e)
		{
			MySqlCommand commandGetSSD = new MySqlCommand("SELECT * FROM `ssd` ORDER BY `Price`");
			
			SSD = cmdManager.GetTableByRequest(commandGetSSD).Select();
			string[] listSt = new string[SSD.Length];
			for (int i = 0; i < SSD.Length; i++)
			{
				listSt[i] = SSD[i]["Company"] + " " + SSD[i]["Model"] + " на " + SSD[i]["Memory"] + " Гб";
			}
			comboSSD.Items.Clear();
			comboSSD.Items.AddRange(listSt);
		}

		private void comboSSD_SelectedIndexChanged(object sender, EventArgs e)
		{
			usconfig.SSD = SSD[comboSSD.Items.IndexOf(comboSSD.Text)];
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
