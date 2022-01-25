using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PCConfig
{
	public partial class MainForm : Form
	{
		public MainForm(string activePreset, string cpuName, string gpuName, Int64 minPrice, Int64 maxPrice)
		{
			InitializeComponent();
			this.activePreset = activePreset;
			this.cpuName = cpuName;
			this.gpuName = gpuName;
			this.minPrice = minPrice;
			this.maxPrice = maxPrice;
			this.activePresets = 1;
		}
		public MainForm()
		{
			InitializeComponent();
		}

		private string activePreset;
		private string cpuName;
		private string gpuName;
		private Int64 minPrice;
		private Int64 maxPrice;
		private int activePresets = 0;

		private bool IsAlpha(string str)
		{
			for (int i = 0; i < str.Length; i++)
			{
				if (char.IsDigit(str[i]) == false)
					return false;
			}
			return true;
		}
		private void AutoConfigButton_Click(object sender, EventArgs e)
		{
			if (activePresets != 1)
			{
				MessageBox.Show("Некрректное количество сборок");
				return;
			}
			if (IsAlpha(MaxPriceTextBox.Text) == false || IsAlpha(MinPriceTextBox.Text) == false)
			{
				MessageBox.Show("Некорректно введена цена");
				return;
			}
			if(string.IsNullOrWhiteSpace(MinPriceTextBox.Text))	
				minPrice = 0;
			if (string.IsNullOrWhiteSpace(MaxPriceTextBox.Text)) 
				maxPrice = Int64.MaxValue;
			if (minPrice > maxPrice)
			{
				MessageBox.Show("Минимальная цена должна быть меньше максимальной");
				return;
			}
			if (IsConfigsFounded() == false)
			{
				MessageBox.Show("К сожалению, сборок по заданным параметрам не существует");
				return;
			}

			AutoForm autoConfig = new AutoForm(activePreset, minPrice, maxPrice, cpuName, gpuName);
			this.Hide();
			autoConfig.Show();
		}

		private void UpdateFields()
		{
			if (GameCheckBox.Checked) activePreset = "game";
			else if (HomeCheckBox.Checked) activePreset = "home";
			else activePreset = "work";
			cpuName = CPUComboBox.Text;
			gpuName = GPUComboBox.Text;
			minPrice = string.IsNullOrWhiteSpace(MinPriceTextBox.Text)? 0 : Convert.ToInt64(MinPriceTextBox.Text);
			maxPrice = string.IsNullOrWhiteSpace(MaxPriceTextBox.Text) ? 0 : Convert.ToInt64(MaxPriceTextBox.Text);
		}
		private bool IsConfigsFounded()
		{
			UpdateFields();
			SQLCommandManager cmdManager = new SQLCommandManager();

			if (cpuName != "")
			{
				if (gpuName != "")
				{
					MySqlCommand commandSearchCurrent = new MySqlCommand("SELECT * FROM `configs` WHERE " +
						"`Type` = @aP AND `Price` < @maxP AND `Price` > @minP and `CPU` = @cpuName and `GPU` = @gpuName ORDER BY `Price`");
					commandSearchCurrent.Parameters.Add("@aP", MySqlDbType.VarChar).Value = activePreset;
					commandSearchCurrent.Parameters.Add("@minP", MySqlDbType.Int64).Value = minPrice;
					commandSearchCurrent.Parameters.Add("@maxP", MySqlDbType.Int64).Value = maxPrice;
					commandSearchCurrent.Parameters.Add("@cpuName", MySqlDbType.VarChar).Value = cpuName;
					commandSearchCurrent.Parameters.Add("@gpuName", MySqlDbType.VarChar).Value = gpuName;

					if (cmdManager.GetTableByRequest(commandSearchCurrent).Rows.Count > 0)
						return true;
					else
						return false;
				}
				else
				{
					MySqlCommand commandSearchCurrentCPU = new MySqlCommand("SELECT * FROM `configs` WHERE " +
						"`Type` = @aP AND `Price` < @maxP AND `Price` > @minP and `CPU` = @cpuName ORDER BY `Price`");
					commandSearchCurrentCPU.Parameters.Add("@aP", MySqlDbType.VarChar).Value = activePreset;
					commandSearchCurrentCPU.Parameters.Add("@minP", MySqlDbType.Int64).Value = minPrice;
					commandSearchCurrentCPU.Parameters.Add("@maxP", MySqlDbType.Int64).Value = maxPrice;
					commandSearchCurrentCPU.Parameters.Add("@cpuName", MySqlDbType.VarChar).Value = cpuName;

					if (cmdManager.GetTableByRequest(commandSearchCurrentCPU).Rows.Count > 0)
						return true;
					else
						return false;
				}
			}
			else
			{
				if (gpuName != "")
				{
					MySqlCommand commandSearchCurrentGPU = new MySqlCommand("SELECT * FROM `configs` WHERE " +
						"`Type` = @aP AND `Price` < @maxP AND `Price` > @minP and `GPU` = @gpuName ORDER BY `Price`");
					commandSearchCurrentGPU.Parameters.Add("@aP", MySqlDbType.VarChar).Value = activePreset;
					commandSearchCurrentGPU.Parameters.Add("@minP", MySqlDbType.Int64).Value = minPrice;
					commandSearchCurrentGPU.Parameters.Add("@maxP", MySqlDbType.Int64).Value = maxPrice;
					commandSearchCurrentGPU.Parameters.Add("@gpuName", MySqlDbType.VarChar).Value = gpuName;

					if (cmdManager.GetTableByRequest(commandSearchCurrentGPU).Rows.Count > 0)
						return true;
					else
						return false;
				}
				else
				{
					MySqlCommand commandSearchAll = new MySqlCommand("SELECT * FROM `configs` WHERE " +
						"`Type` = @aP AND `Price` < @maxP AND `Price` > @minP ORDER BY `Price`");
					commandSearchAll.Parameters.Add("@aP", MySqlDbType.VarChar).Value = activePreset;
					commandSearchAll.Parameters.Add("@minP", MySqlDbType.Int64).Value = minPrice;
					commandSearchAll.Parameters.Add("@maxP", MySqlDbType.Int64).Value = maxPrice;

					if (cmdManager.GetTableByRequest(commandSearchAll).Rows.Count > 0)
						return true;
					else
						return false;
				}
			}
		}

		private void ChangeCheckBoxColor(CheckBox obj)
		{
			if (obj.Checked)
			{
				activePresets++;
				obj.BackColor = Color.FromArgb(133, 133, 133);
			}
			else
			{
				activePresets--;
				obj.BackColor = Color.White;
			}
		}
		private void GameCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			ChangeCheckBoxColor(GameCheckBox);
		}
		private void WorkCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			ChangeCheckBoxColor(WorkCheckBox);
		}
		private void HomeCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			ChangeCheckBoxColor(HomeCheckBox);
		}
		private void CloseButton_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}


		Point lastPoint;
		private void MainForm_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.Left += e.X - lastPoint.X;
				this.Top += e.Y - lastPoint.Y;
			}
		}
		private void MainForm_MouseDown(object sender, MouseEventArgs e)
		{
			lastPoint = new Point(e.X, e.Y);
		}
	}
}
