using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PCConfig
{
	public partial class formMain : Form
	{
		public formMain(string activePreset, string cpuName, string gpuName, Int64 minPrice, Int64 maxPrice)
		{
			InitializeComponent();
			this.activePreset = activePreset;
			this.cpuName = cpuName;
			this.gpuName = gpuName;
			this.minPrice = minPrice;
			this.maxPrice = maxPrice;
			this.activePresets = 1;
		}
		public formMain()
		{
			InitializeComponent();
		}

		private string activePreset;
		private string cpuName;
		private string gpuName;
		private Int64 minPrice = 0;
		private Int64 maxPrice = Int64.MaxValue;
		private int activePresets = 0;

		private void buttonAutoConfig_Click(object sender, EventArgs e)
		{
			if (activePresets != 1)
			{
				MessageBox.Show("Некрректное количество сборок");
				return;
			}
			if (IsAlpha(textMax.Text) == false || IsAlpha(textMin.Text) == false)
			{
				MessageBox.Show("Некорректно введена цена");
				return;
			}
			if (Convert.ToInt64(textMin.Text) > Convert.ToInt64(textMax.Text))
			{
				MessageBox.Show("Минимальная цена должна быть меньше максимальной");
				return;
			}
			if (IsConfigsFounded() == false)
			{
				MessageBox.Show("К сожалению, сборок по заданным параметрам не существует");
				return;
			}

			formAuto autoConfig = new formAuto(activePreset, minPrice, maxPrice, cpuName, gpuName);
			this.Hide();
			autoConfig.Show();
		}

		private void UpdateFields()
		{
			if (checkGame.Checked) activePreset = "game";
			else if (checkHome.Checked) activePreset = "home";
			else activePreset = "work";
			cpuName = comboCPU.Text;
			gpuName = comboGPU.Text;
			minPrice = Convert.ToInt64(textMin.Text);
			maxPrice = Convert.ToInt64(textMax.Text);
		}

		private bool IsConfigsFounded()
		{
			UpdateFields();

			DataBaseConnection db = new DataBaseConnection();
			db.openConnection();
			MySqlDataAdapter adapter = new MySqlDataAdapter();

			MySqlCommand commandSearchCurrent = new MySqlCommand("SELECT * FROM `configs` WHERE " +
				"`Type` = @aP AND `Price` < @maxP AND `Price` > @minP and `CPU` = @cpuName and `GPU` = @gpuName", db.getConnection());
			commandSearchCurrent.Parameters.Add("@aP", MySqlDbType.VarChar).Value = activePreset;
			commandSearchCurrent.Parameters.Add("@minP", MySqlDbType.Int64).Value = minPrice;
			commandSearchCurrent.Parameters.Add("@maxP", MySqlDbType.Int64).Value = maxPrice;
			commandSearchCurrent.Parameters.Add("@cpuName", MySqlDbType.VarChar).Value = cpuName;
			commandSearchCurrent.Parameters.Add("@gpuName", MySqlDbType.VarChar).Value = gpuName;

			MySqlCommand commandSearchCurrentCPU = new MySqlCommand("SELECT * FROM `configs` WHERE " +
			  "`Type` = @aP AND `Price` < @maxP AND `Price` > @minP and `CPU` = @cpuName", db.getConnection());
			commandSearchCurrentCPU.Parameters.Add("@aP", MySqlDbType.VarChar).Value = activePreset;
			commandSearchCurrentCPU.Parameters.Add("@minP", MySqlDbType.Int64).Value = minPrice;
			commandSearchCurrentCPU.Parameters.Add("@maxP", MySqlDbType.Int64).Value = maxPrice;
			commandSearchCurrentCPU.Parameters.Add("@cpuName", MySqlDbType.VarChar).Value = cpuName;

			MySqlCommand commandSearchCurrentGPU = new MySqlCommand("SELECT * FROM `configs` WHERE " +
			  "`Type` = @aP AND `Price` < @maxP AND `Price` > @minP and `GPU` = @gpuName", db.getConnection());
			commandSearchCurrentGPU.Parameters.Add("@aP", MySqlDbType.VarChar).Value = activePreset;
			commandSearchCurrentGPU.Parameters.Add("@minP", MySqlDbType.Int64).Value = minPrice;
			commandSearchCurrentGPU.Parameters.Add("@maxP", MySqlDbType.Int64).Value = maxPrice;
			commandSearchCurrentGPU.Parameters.Add("@gpuName", MySqlDbType.VarChar).Value = gpuName;

			MySqlCommand commandSearchAll = new MySqlCommand("SELECT * FROM `configs` WHERE " +
			  "`Type` = @aP AND `Price` < @maxP AND `Price` > @minP", db.getConnection());
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

			if (table.Rows.Count > 0) return true;
			else return false;
		}

		private bool IsAlpha(string str)
		{
			for (int i = 0; i < str.Length; i++)
			{
				if (char.IsLetter(str[i]) == false)
					return false;
			}
			return true;
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
		private void checkGame_CheckedChanged(object sender, EventArgs e)
		{
			ChangeCheckBoxColor(checkGame);
		}
		private void checkWork_CheckedChanged(object sender, EventArgs e)
		{
			ChangeCheckBoxColor(checkWork);
		}
		private void checkHome_CheckedChanged(object sender, EventArgs e)
		{
			ChangeCheckBoxColor(checkHome);
		}

		private void buttonClose_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}


		Point lastPoint;
		private void formMain_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.Left += e.X - lastPoint.X;
				this.Top += e.Y - lastPoint.Y;
			}
		}

		private void formMain_MouseDown(object sender, MouseEventArgs e)
		{
			lastPoint = new Point(e.X, e.Y);
		}

	}
}
