namespace PCConfig
{
  partial class AutoForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoForm));
			this.buttonClose = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureCase = new System.Windows.Forms.PictureBox();
			this.labelCPU = new System.Windows.Forms.Label();
			this.labelCase = new System.Windows.Forms.Label();
			this.labelCooler = new System.Windows.Forms.Label();
			this.labelHardDrive = new System.Windows.Forms.Label();
			this.labelPower = new System.Windows.Forms.Label();
			this.labelRAM = new System.Windows.Forms.Label();
			this.labelMotherboard = new System.Windows.Forms.Label();
			this.labelGPU = new System.Windows.Forms.Label();
			this.NextConfigButton = new System.Windows.Forms.Button();
			this.PreviousConfigButton = new System.Windows.Forms.Button();
			this.SaveAsFileButton = new System.Windows.Forms.Button();
			this.BackButton = new System.Windows.Forms.Button();
			this.labelPrice = new System.Windows.Forms.Label();
			this.labelSSD = new System.Windows.Forms.Label();
			this.ChangeConfigButton = new System.Windows.Forms.Button();
			this.tipCPU = new System.Windows.Forms.ToolTip(this.components);
			this.tipGPU = new System.Windows.Forms.ToolTip(this.components);
			this.tipMB = new System.Windows.Forms.ToolTip(this.components);
			this.tipRAM = new System.Windows.Forms.ToolTip(this.components);
			this.tipPS = new System.Windows.Forms.ToolTip(this.components);
			this.tipHD = new System.Windows.Forms.ToolTip(this.components);
			this.tipCooler = new System.Windows.Forms.ToolTip(this.components);
			this.tipCase = new System.Windows.Forms.ToolTip(this.components);
			this.tipSSD = new System.Windows.Forms.ToolTip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.pictureCase)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClose.BackColor = System.Drawing.SystemColors.Control;
			this.buttonClose.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonClose.Location = new System.Drawing.Point(1178, 35);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(50, 50);
			this.buttonClose.TabIndex = 19;
			this.buttonClose.Text = "X";
			this.buttonClose.UseVisualStyleBackColor = false;
			this.buttonClose.Click += new System.EventHandler(this.CloseButton_Click);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.SystemColors.Control;
			this.label1.Font = new System.Drawing.Font("Segoe Print", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(168, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(250, 50);
			this.label1.TabIndex = 20;
			this.label1.Text = "Готовая сборка";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pictureCase
			// 
			this.pictureCase.Location = new System.Drawing.Point(50, 110);
			this.pictureCase.Name = "pictureCase";
			this.pictureCase.Size = new System.Drawing.Size(368, 368);
			this.pictureCase.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureCase.TabIndex = 21;
			this.pictureCase.TabStop = false;
			// 
			// labelCPU
			// 
			this.labelCPU.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelCPU.AutoSize = true;
			this.labelCPU.BackColor = System.Drawing.Color.White;
			this.labelCPU.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelCPU.Location = new System.Drawing.Point(468, 110);
			this.labelCPU.Name = "labelCPU";
			this.labelCPU.Size = new System.Drawing.Size(88, 23);
			this.labelCPU.TabIndex = 22;
			this.labelCPU.Text = "Процессор: ";
			// 
			// labelCase
			// 
			this.labelCase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelCase.AutoSize = true;
			this.labelCase.BackColor = System.Drawing.Color.White;
			this.labelCase.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelCase.Location = new System.Drawing.Point(468, 410);
			this.labelCase.Name = "labelCase";
			this.labelCase.Size = new System.Drawing.Size(71, 23);
			this.labelCase.TabIndex = 23;
			this.labelCase.Text = "Корпус: ";
			// 
			// labelCooler
			// 
			this.labelCooler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelCooler.AutoSize = true;
			this.labelCooler.BackColor = System.Drawing.Color.White;
			this.labelCooler.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelCooler.Location = new System.Drawing.Point(468, 367);
			this.labelCooler.Name = "labelCooler";
			this.labelCooler.Size = new System.Drawing.Size(71, 23);
			this.labelCooler.TabIndex = 24;
			this.labelCooler.Text = "Куллер: ";
			// 
			// labelHardDrive
			// 
			this.labelHardDrive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelHardDrive.AutoSize = true;
			this.labelHardDrive.BackColor = System.Drawing.Color.White;
			this.labelHardDrive.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelHardDrive.Location = new System.Drawing.Point(468, 324);
			this.labelHardDrive.Name = "labelHardDrive";
			this.labelHardDrive.Size = new System.Drawing.Size(116, 23);
			this.labelHardDrive.TabIndex = 25;
			this.labelHardDrive.Text = "Жесткий диск: ";
			// 
			// labelPower
			// 
			this.labelPower.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelPower.AutoSize = true;
			this.labelPower.BackColor = System.Drawing.Color.White;
			this.labelPower.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelPower.Location = new System.Drawing.Point(468, 280);
			this.labelPower.Name = "labelPower";
			this.labelPower.Size = new System.Drawing.Size(116, 23);
			this.labelPower.TabIndex = 26;
			this.labelPower.Text = "Блок питания: ";
			// 
			// labelRAM
			// 
			this.labelRAM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelRAM.AutoSize = true;
			this.labelRAM.BackColor = System.Drawing.Color.White;
			this.labelRAM.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelRAM.Location = new System.Drawing.Point(468, 236);
			this.labelRAM.Name = "labelRAM";
			this.labelRAM.Size = new System.Drawing.Size(174, 23);
			this.labelRAM.TabIndex = 27;
			this.labelRAM.Text = "Оперативная память: ";
			// 
			// labelMotherboard
			// 
			this.labelMotherboard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelMotherboard.AutoSize = true;
			this.labelMotherboard.BackColor = System.Drawing.Color.White;
			this.labelMotherboard.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelMotherboard.Location = new System.Drawing.Point(468, 193);
			this.labelMotherboard.Name = "labelMotherboard";
			this.labelMotherboard.Size = new System.Drawing.Size(164, 23);
			this.labelMotherboard.TabIndex = 28;
			this.labelMotherboard.Text = "Материнская плата: ";
			// 
			// labelGPU
			// 
			this.labelGPU.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelGPU.AutoSize = true;
			this.labelGPU.BackColor = System.Drawing.Color.White;
			this.labelGPU.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelGPU.Location = new System.Drawing.Point(468, 151);
			this.labelGPU.Name = "labelGPU";
			this.labelGPU.Size = new System.Drawing.Size(102, 23);
			this.labelGPU.TabIndex = 29;
			this.labelGPU.Text = "Видеокарта: ";
			// 
			// NextConfigButton
			// 
			this.NextConfigButton.BackColor = System.Drawing.SystemColors.Control;
			this.NextConfigButton.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.NextConfigButton.Location = new System.Drawing.Point(50, 515);
			this.NextConfigButton.Name = "NextConfigButton";
			this.NextConfigButton.Size = new System.Drawing.Size(368, 43);
			this.NextConfigButton.TabIndex = 30;
			this.NextConfigButton.Text = "Следующая сборка";
			this.NextConfigButton.UseVisualStyleBackColor = false;
			this.NextConfigButton.Click += new System.EventHandler(this.NextConfigButton_Click);
			// 
			// PreviousConfigButton
			// 
			this.PreviousConfigButton.BackColor = System.Drawing.SystemColors.Control;
			this.PreviousConfigButton.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.PreviousConfigButton.Location = new System.Drawing.Point(50, 594);
			this.PreviousConfigButton.Name = "PreviousConfigButton";
			this.PreviousConfigButton.Size = new System.Drawing.Size(368, 43);
			this.PreviousConfigButton.TabIndex = 31;
			this.PreviousConfigButton.Text = "Предыдущая сборка";
			this.PreviousConfigButton.UseVisualStyleBackColor = false;
			this.PreviousConfigButton.Click += new System.EventHandler(this.PreviousConfigButton_Click);
			// 
			// SaveAsFileButton
			// 
			this.SaveAsFileButton.BackColor = System.Drawing.SystemColors.Control;
			this.SaveAsFileButton.Font = new System.Drawing.Font("Segoe Print", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.SaveAsFileButton.Location = new System.Drawing.Point(880, 571);
			this.SaveAsFileButton.Name = "SaveAsFileButton";
			this.SaveAsFileButton.Size = new System.Drawing.Size(348, 66);
			this.SaveAsFileButton.TabIndex = 33;
			this.SaveAsFileButton.Text = "Сохранить в файл";
			this.SaveAsFileButton.UseVisualStyleBackColor = false;
			this.SaveAsFileButton.Click += new System.EventHandler(this.SaveAsFileButton_Click);
			// 
			// BackButton
			// 
			this.BackButton.AutoSize = true;
			this.BackButton.BackColor = System.Drawing.SystemColors.Control;
			this.BackButton.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.BackButton.Location = new System.Drawing.Point(50, 35);
			this.BackButton.Name = "BackButton";
			this.BackButton.Size = new System.Drawing.Size(103, 50);
			this.BackButton.TabIndex = 34;
			this.BackButton.Text = "←";
			this.BackButton.UseVisualStyleBackColor = false;
			this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
			// 
			// labelPrice
			// 
			this.labelPrice.BackColor = System.Drawing.Color.White;
			this.labelPrice.Font = new System.Drawing.Font("Segoe Print", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelPrice.Location = new System.Drawing.Point(468, 515);
			this.labelPrice.Name = "labelPrice";
			this.labelPrice.Size = new System.Drawing.Size(365, 122);
			this.labelPrice.TabIndex = 35;
			this.labelPrice.Text = "Примерная стоимость:\r\n";
			this.labelPrice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// labelSSD
			// 
			this.labelSSD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelSSD.AutoSize = true;
			this.labelSSD.BackColor = System.Drawing.Color.White;
			this.labelSSD.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelSSD.Location = new System.Drawing.Point(468, 455);
			this.labelSSD.Name = "labelSSD";
			this.labelSSD.Size = new System.Drawing.Size(45, 23);
			this.labelSSD.TabIndex = 36;
			this.labelSSD.Text = "SSD: ";
			// 
			// ChangeConfigButton
			// 
			this.ChangeConfigButton.BackColor = System.Drawing.SystemColors.Control;
			this.ChangeConfigButton.Font = new System.Drawing.Font("Segoe Print", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ChangeConfigButton.Location = new System.Drawing.Point(468, 35);
			this.ChangeConfigButton.Name = "ChangeConfigButton";
			this.ChangeConfigButton.Size = new System.Drawing.Size(365, 50);
			this.ChangeConfigButton.TabIndex = 37;
			this.ChangeConfigButton.Text = "Изменить сборку";
			this.ChangeConfigButton.UseVisualStyleBackColor = false;
			this.ChangeConfigButton.Click += new System.EventHandler(this.ChangeConfigButton_Click);
			// 
			// tipCPU
			// 
			this.tipCPU.AutoPopDelay = 160000;
			this.tipCPU.InitialDelay = 500;
			this.tipCPU.ReshowDelay = 100;
			// 
			// tipGPU
			// 
			this.tipGPU.AutoPopDelay = 160000;
			this.tipGPU.InitialDelay = 500;
			this.tipGPU.ReshowDelay = 100;
			// 
			// tipMB
			// 
			this.tipMB.AutoPopDelay = 160000;
			this.tipMB.InitialDelay = 500;
			this.tipMB.ReshowDelay = 100;
			// 
			// tipRAM
			// 
			this.tipRAM.AutoPopDelay = 160000;
			this.tipRAM.InitialDelay = 500;
			this.tipRAM.ReshowDelay = 100;
			// 
			// tipPS
			// 
			this.tipPS.AutoPopDelay = 160000;
			this.tipPS.InitialDelay = 500;
			this.tipPS.ReshowDelay = 100;
			// 
			// tipHD
			// 
			this.tipHD.AutoPopDelay = 160000;
			this.tipHD.InitialDelay = 500;
			this.tipHD.ReshowDelay = 100;
			// 
			// tipCooler
			// 
			this.tipCooler.AutoPopDelay = 160000;
			this.tipCooler.InitialDelay = 500;
			this.tipCooler.ReshowDelay = 100;
			// 
			// tipCase
			// 
			this.tipCase.AutoPopDelay = 160000;
			this.tipCase.InitialDelay = 500;
			this.tipCase.ReshowDelay = 100;
			// 
			// tipSSD
			// 
			this.tipSSD.AutoPopDelay = 160000;
			this.tipSSD.InitialDelay = 500;
			this.tipSSD.ReshowDelay = 100;
			// 
			// AutoForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(1264, 681);
			this.Controls.Add(this.ChangeConfigButton);
			this.Controls.Add(this.labelSSD);
			this.Controls.Add(this.labelPrice);
			this.Controls.Add(this.BackButton);
			this.Controls.Add(this.SaveAsFileButton);
			this.Controls.Add(this.PreviousConfigButton);
			this.Controls.Add(this.NextConfigButton);
			this.Controls.Add(this.labelGPU);
			this.Controls.Add(this.labelMotherboard);
			this.Controls.Add(this.labelRAM);
			this.Controls.Add(this.labelPower);
			this.Controls.Add(this.labelHardDrive);
			this.Controls.Add(this.labelCooler);
			this.Controls.Add(this.labelCase);
			this.Controls.Add(this.labelCPU);
			this.Controls.Add(this.pictureCase);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonClose);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "AutoForm";
			this.Text = "AutoConfig";
			this.Load += new System.EventHandler(this.AutoForm_Load);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AutoForm_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AutoForm_MouseMove);
			((System.ComponentModel.ISupportInitialize)(this.pictureCase)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button buttonClose;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.PictureBox pictureCase;
    private System.Windows.Forms.Label labelCPU;
    private System.Windows.Forms.Label labelCase;
    private System.Windows.Forms.Label labelCooler;
    private System.Windows.Forms.Label labelHardDrive;
    private System.Windows.Forms.Label labelPower;
    private System.Windows.Forms.Label labelRAM;
    private System.Windows.Forms.Label labelMotherboard;
    private System.Windows.Forms.Label labelGPU;
    private System.Windows.Forms.Button NextConfigButton;
    private System.Windows.Forms.Button PreviousConfigButton;
    private System.Windows.Forms.Button SaveAsFileButton;
    private System.Windows.Forms.Button BackButton;
    private System.Windows.Forms.Label labelPrice;
		private System.Windows.Forms.Label labelSSD;
		private System.Windows.Forms.Button ChangeConfigButton;
		private System.Windows.Forms.ToolTip tipCPU;
		private System.Windows.Forms.ToolTip tipGPU;
		private System.Windows.Forms.ToolTip tipMB;
		private System.Windows.Forms.ToolTip tipRAM;
		private System.Windows.Forms.ToolTip tipPS;
		private System.Windows.Forms.ToolTip tipHD;
		private System.Windows.Forms.ToolTip tipCooler;
		private System.Windows.Forms.ToolTip tipCase;
		private System.Windows.Forms.ToolTip tipSSD;
	}
}