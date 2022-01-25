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
    Config config;
    Config usconfig;
    DataBaseConnection db = new DataBaseConnection();
    MySqlDataAdapter adapter = new MySqlDataAdapter();

    public DataRow[] CPU;
    public DataRow[] GPU;
    public DataRow[] RAM;
    public DataRow[] Mother;
    public DataRow[] Power;
    public DataRow[] Case;
    public DataRow[] Hard;
    public DataRow[] SSD;
    public DataRow[] Cooler;

    private void FillCombos(Config config)
    {
      comboCPU.Text = config.CPU["Company"] + " " + config.CPU["Model"];

      if (config.idGPU != 0) comboGPU.Text = config.GPU["Company"] + " " + config.GPU["Model"] + " на " + config.GPU["Memory"] + " Гб";
      else comboGPU.Text = "Интегрированное графическое ядро процессора";

      comboMother.Text = config.Mother["Company"] + " " + config.Mother["Model"];
      comboRAM.Text = config.RAM["Company"] + " " + config.RAM["Model"] + " " + config.RAM["Memory"] + " Гб";
      comboNumOfRam.Text = config.numOfRam.ToString() + " шт.";
      comboPower.Text = config.Power["Company"] + " " + config.Power["Model"] + " " + config.Power["Power"] + " Вт";
      comboHard.Text = config.Hard["Company"] + " " + config.Hard["Model"] + " на " + config.Hard["Memory"] + " Гб";
      comboCooler.Text = config.Cooler["Company"] + " " + config.Cooler["Model"];
      comboCase.Text = config.Case["Company"] + " " + config.Case["Model"];

      if (config.idSSD != 0) comboSSD.Text = config.SSD["Company"] + " " + config.SSD["Model"] + " на " + config.SSD["Memory"] + " Гб";
      else comboSSD.Text = "Отсутствует";

      labelPrice.Text = config.GetCurrentPrice() + " руб.";
    }

    private void ChangeConfig_Load(object sender, EventArgs e)
    {
      usconfig = config;
      this.FillCombos(usconfig);
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
      DataTable table = new DataTable();
      MySqlCommand commandGetCPU = new MySqlCommand("SELECT * FROM `cpu` WHERE `Company` = @reqCom AND `Socket` = @reqSocket ORDER BY `Price`", db.getConnection());
      commandGetCPU.Parameters.Add("@reqCom", MySqlDbType.VarChar).Value = usconfig.CPU["Company"];
      commandGetCPU.Parameters.Add("@reqSocket", MySqlDbType.VarChar).Value = usconfig.CPU["Socket"];
      adapter.SelectCommand = commandGetCPU;
      adapter.Fill(table);
      CPU = table.Select();
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
      usconfig.idCPU = Convert.ToInt32(CPU[comboCPU.Items.IndexOf(comboCPU.Text)]["Id"]);
      labelPrice.Text = usconfig.GetCurrentPrice().ToString() + " руб.";
    }

    private void chbuttonGPU_Click(object sender, EventArgs e)
    {
      DataTable table = new DataTable();
      MySqlCommand commandGetGPU = new MySqlCommand("SELECT * FROM `gpu` WHERE `Company` = @reqParam ORDER BY `Price`", db.getConnection());
      commandGetGPU.Parameters.Add("@reqParam", MySqlDbType.VarChar).Value = usconfig.GPU["Company"];
      adapter.SelectCommand = commandGetGPU;
      adapter.Fill(table);
      GPU = table.Select();
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
      usconfig.idGPU = Convert.ToInt32(GPU[comboGPU.Items.IndexOf(comboGPU.Text)]["id"]);
      labelPrice.Text = usconfig.GetCurrentPrice().ToString() + " руб.";
    }

    private void chbuttonMother_Click(object sender, EventArgs e)
    {
      DataTable table = new DataTable();
      MySqlCommand commandGetMB = new MySqlCommand("SELECT * FROM `motherboard` WHERE `Socket` = @reqSocket AND `NumOfRam` > @nRam ORDER BY `Price`", db.getConnection());
      commandGetMB.Parameters.Add("@reqSocket", MySqlDbType.VarChar).Value = usconfig.CPU["Socket"];
      commandGetMB.Parameters.Add("@nRam", MySqlDbType.Int32).Value = usconfig.numOfRam;
      adapter.SelectCommand = commandGetMB;
      adapter.Fill(table);
      Mother = table.Select();
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
      usconfig.idMB = Convert.ToInt32(Mother[comboMother.Items.IndexOf(comboMother.Text)]["id"]);
      labelPrice.Text = usconfig.GetCurrentPrice().ToString() + " руб.";
    }

    private void chbuttonRam_Click(object sender, EventArgs e)
    {
      DataTable table = new DataTable();
      MySqlCommand commandGetRam = new MySqlCommand("SELECT * FROM `ram` ORDER BY `Price`", db.getConnection());
      adapter.SelectCommand = commandGetRam;
      adapter.Fill(table);
      RAM = table.Select();
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
      usconfig.idRAM = Convert.ToInt32(RAM[comboRAM.Items.IndexOf(comboRAM.Text)]["id"]);
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
      DataTable table = new DataTable();
      MySqlCommand commandGetPS = new MySqlCommand("SELECT * FROM `power` WHERE `Power` > @pow ORDER BY `Price`", db.getConnection());
      commandGetPS.Parameters.Add("@pow", MySqlDbType.Int32).Value = usconfig.GPU["recPower"];
      adapter.SelectCommand = commandGetPS;
      adapter.Fill(table);
      Power = table.Select();
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
      usconfig.idPS = Convert.ToInt32(Power[comboPower.Items.IndexOf(comboPower.Text)]["Id"]);
      labelPrice.Text = usconfig.GetCurrentPrice().ToString() + " руб.";
    }

    private void chbuttonHard_Click(object sender, EventArgs e)
    {
      DataTable table = new DataTable();
      MySqlCommand commandGetHD = new MySqlCommand("SELECT * FROM `harddrive` ORDER BY `Price`", db.getConnection());
      adapter.SelectCommand = commandGetHD;
      adapter.Fill(table);
      Hard = table.Select();
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
      usconfig.idHD = Convert.ToInt32(Hard[comboHard.Items.IndexOf(comboHard.Text)]["Id"]);
      labelPrice.Text = usconfig.GetCurrentPrice().ToString() + " руб.";
    }

    private void chbuttonCooler_Click(object sender, EventArgs e)
    {
      DataTable table = new DataTable();
      MySqlCommand commandGetCooler = new MySqlCommand("SELECT * FROM `cooler` WHERE `TDP` > @tdp ORDER BY `Price`", db.getConnection());
      commandGetCooler.Parameters.Add("@tdp", MySqlDbType.Int32).Value = usconfig.CPU["TDP"];
      adapter.SelectCommand = commandGetCooler;
      adapter.Fill(table);
      Cooler = table.Select();
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
      usconfig.idCooler = Convert.ToInt32(Cooler[comboCooler.Items.IndexOf(comboCooler.Text)]["Id"]);
      labelPrice.Text = usconfig.GetCurrentPrice().ToString() + " руб.";
    }

    private void chbuttonCase_Click(object sender, EventArgs e)
    {
      DataTable table = new DataTable();
      MySqlCommand commandGetCase = new MySqlCommand("SELECT * FROM `case` WHERE `Form` = @form ORDER BY `Price`", db.getConnection());
      commandGetCase.Parameters.Add("@form", MySqlDbType.VarChar).Value = usconfig.Mother["Form"];
      adapter.SelectCommand = commandGetCase;
      adapter.Fill(table);
      Case = table.Select();
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
      usconfig.idCase = Convert.ToInt32(Case[comboCase.Items.IndexOf(comboCase.Text)]["Id"]);
      labelPrice.Text = usconfig.GetCurrentPrice().ToString() + " руб.";
    }

    private void buttonSSD_Click(object sender, EventArgs e)
    {
      DataTable table = new DataTable();
      MySqlCommand commandGetSSD = new MySqlCommand("SELECT * FROM `ssd` ORDER BY `Price`", db.getConnection());
      adapter.SelectCommand = commandGetSSD;
      adapter.Fill(table);
      SSD = table.Select();
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
      usconfig.idSSD = Convert.ToInt32(SSD[comboSSD.Items.IndexOf(comboSSD.Text)]["Id"]);
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
