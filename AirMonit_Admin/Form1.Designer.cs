namespace AirMonit_Admin
{
    partial class Form1
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
            this.gbSensors = new System.Windows.Forms.GroupBox();
            this.cbO3 = new System.Windows.Forms.CheckBox();
            this.cbCO = new System.Windows.Forms.CheckBox();
            this.cbNO2 = new System.Windows.Forms.CheckBox();
            this.gbParameters = new System.Windows.Forms.GroupBox();
            this.cbHourlyStats = new System.Windows.Forms.CheckBox();
            this.dtpDate2 = new System.Windows.Forms.DateTimePicker();
            this.dtpDate1 = new System.Windows.Forms.DateTimePicker();
            this.cbDate2 = new System.Windows.Forms.CheckBox();
            this.cbDate1 = new System.Windows.Forms.CheckBox();
            this.lbCity = new System.Windows.Forms.Label();
            this.cbCity = new System.Windows.Forms.ComboBox();
            this.lbSensorsInfo = new System.Windows.Forms.Label();
            this.lbAlarmsInfo = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblSensorTest = new System.Windows.Forms.Label();
            this.lblCityTest = new System.Windows.Forms.Label();
            this.lblDateTest = new System.Windows.Forms.Label();
            this.lstAlarmsInfo = new System.Windows.Forms.ListBox();
            this.lstSensorsInfo = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonSearch_Alarms = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lstHourlyInfo = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gbSensors.SuspendLayout();
            this.gbParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSensors
            // 
            this.gbSensors.Controls.Add(this.cbO3);
            this.gbSensors.Controls.Add(this.cbCO);
            this.gbSensors.Controls.Add(this.cbNO2);
            this.gbSensors.Location = new System.Drawing.Point(13, 13);
            this.gbSensors.Name = "gbSensors";
            this.gbSensors.Size = new System.Drawing.Size(166, 111);
            this.gbSensors.TabIndex = 0;
            this.gbSensors.TabStop = false;
            this.gbSensors.Text = "Sensors";
            // 
            // cbO3
            // 
            this.cbO3.AutoSize = true;
            this.cbO3.Location = new System.Drawing.Point(7, 68);
            this.cbO3.Name = "cbO3";
            this.cbO3.Size = new System.Drawing.Size(80, 17);
            this.cbO3.TabIndex = 2;
            this.cbO3.Text = "Ozone (O3)";
            this.cbO3.UseVisualStyleBackColor = true;
            // 
            // cbCO
            // 
            this.cbCO.AutoSize = true;
            this.cbCO.Location = new System.Drawing.Point(7, 44);
            this.cbCO.Name = "cbCO";
            this.cbCO.Size = new System.Drawing.Size(133, 17);
            this.cbCO.TabIndex = 1;
            this.cbCO.Text = "Carbon Monoxide (CO)";
            this.cbCO.UseVisualStyleBackColor = true;
            // 
            // cbNO2
            // 
            this.cbNO2.AutoSize = true;
            this.cbNO2.Location = new System.Drawing.Point(7, 20);
            this.cbNO2.Name = "cbNO2";
            this.cbNO2.Size = new System.Drawing.Size(135, 17);
            this.cbNO2.TabIndex = 0;
            this.cbNO2.Text = "Nitrogen Dioxide (NO2)";
            this.cbNO2.UseVisualStyleBackColor = true;
            // 
            // gbParameters
            // 
            this.gbParameters.Controls.Add(this.cbHourlyStats);
            this.gbParameters.Controls.Add(this.dtpDate2);
            this.gbParameters.Controls.Add(this.dtpDate1);
            this.gbParameters.Controls.Add(this.cbDate2);
            this.gbParameters.Controls.Add(this.cbDate1);
            this.gbParameters.Controls.Add(this.lbCity);
            this.gbParameters.Controls.Add(this.cbCity);
            this.gbParameters.Location = new System.Drawing.Point(217, 13);
            this.gbParameters.Name = "gbParameters";
            this.gbParameters.Size = new System.Drawing.Size(356, 155);
            this.gbParameters.TabIndex = 1;
            this.gbParameters.TabStop = false;
            this.gbParameters.Text = "Parameters";
            // 
            // cbHourlyStats
            // 
            this.cbHourlyStats.AutoSize = true;
            this.cbHourlyStats.Location = new System.Drawing.Point(19, 122);
            this.cbHourlyStats.Name = "cbHourlyStats";
            this.cbHourlyStats.Size = new System.Drawing.Size(103, 17);
            this.cbHourlyStats.TabIndex = 6;
            this.cbHourlyStats.Text = "Get Hourly Stats";
            this.cbHourlyStats.UseVisualStyleBackColor = true;
            // 
            // dtpDate2
            // 
            this.dtpDate2.Location = new System.Drawing.Point(188, 80);
            this.dtpDate2.Name = "dtpDate2";
            this.dtpDate2.Size = new System.Drawing.Size(156, 20);
            this.dtpDate2.TabIndex = 5;
            // 
            // dtpDate1
            // 
            this.dtpDate1.Location = new System.Drawing.Point(9, 80);
            this.dtpDate1.Name = "dtpDate1";
            this.dtpDate1.Size = new System.Drawing.Size(157, 20);
            this.dtpDate1.TabIndex = 4;
            // 
            // cbDate2
            // 
            this.cbDate2.AutoSize = true;
            this.cbDate2.Location = new System.Drawing.Point(188, 59);
            this.cbDate2.Name = "cbDate2";
            this.cbDate2.Size = new System.Drawing.Size(55, 17);
            this.cbDate2.TabIndex = 3;
            this.cbDate2.Text = "Date2";
            this.cbDate2.UseVisualStyleBackColor = true;
            // 
            // cbDate1
            // 
            this.cbDate1.AutoSize = true;
            this.cbDate1.Location = new System.Drawing.Point(9, 59);
            this.cbDate1.Name = "cbDate1";
            this.cbDate1.Size = new System.Drawing.Size(55, 17);
            this.cbDate1.TabIndex = 2;
            this.cbDate1.Text = "Date1";
            this.cbDate1.UseVisualStyleBackColor = true;
            // 
            // lbCity
            // 
            this.lbCity.AutoSize = true;
            this.lbCity.Location = new System.Drawing.Point(6, 24);
            this.lbCity.Name = "lbCity";
            this.lbCity.Size = new System.Drawing.Size(24, 13);
            this.lbCity.TabIndex = 1;
            this.lbCity.Text = "City";
            // 
            // cbCity
            // 
            this.cbCity.FormattingEnabled = true;
            this.cbCity.Location = new System.Drawing.Point(36, 21);
            this.cbCity.Name = "cbCity";
            this.cbCity.Size = new System.Drawing.Size(121, 21);
            this.cbCity.TabIndex = 0;
            // 
            // lbSensorsInfo
            // 
            this.lbSensorsInfo.AutoSize = true;
            this.lbSensorsInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSensorsInfo.Location = new System.Drawing.Point(9, 284);
            this.lbSensorsInfo.Name = "lbSensorsInfo";
            this.lbSensorsInfo.Size = new System.Drawing.Size(119, 24);
            this.lbSensorsInfo.TabIndex = 2;
            this.lbSensorsInfo.Text = "Sensors Info:";
            // 
            // lbAlarmsInfo
            // 
            this.lbAlarmsInfo.AutoSize = true;
            this.lbAlarmsInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAlarmsInfo.Location = new System.Drawing.Point(502, 284);
            this.lbAlarmsInfo.Name = "lbAlarmsInfo";
            this.lbAlarmsInfo.Size = new System.Drawing.Size(108, 24);
            this.lbAlarmsInfo.TabIndex = 3;
            this.lbAlarmsInfo.Text = "Alarms Info:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(34, 130);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(135, 65);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search Sensors";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblSensorTest
            // 
            this.lblSensorTest.AutoSize = true;
            this.lblSensorTest.Location = new System.Drawing.Point(96, 217);
            this.lblSensorTest.Name = "lblSensorTest";
            this.lblSensorTest.Size = new System.Drawing.Size(0, 13);
            this.lblSensorTest.TabIndex = 7;
            // 
            // lblCityTest
            // 
            this.lblCityTest.AutoSize = true;
            this.lblCityTest.Location = new System.Drawing.Point(96, 239);
            this.lblCityTest.Name = "lblCityTest";
            this.lblCityTest.Size = new System.Drawing.Size(0, 13);
            this.lblCityTest.TabIndex = 8;
            // 
            // lblDateTest
            // 
            this.lblDateTest.AutoSize = true;
            this.lblDateTest.Location = new System.Drawing.Point(96, 261);
            this.lblDateTest.Name = "lblDateTest";
            this.lblDateTest.Size = new System.Drawing.Size(0, 13);
            this.lblDateTest.TabIndex = 9;
            // 
            // lstAlarmsInfo
            // 
            this.lstAlarmsInfo.FormattingEnabled = true;
            this.lstAlarmsInfo.Location = new System.Drawing.Point(506, 311);
            this.lstAlarmsInfo.Name = "lstAlarmsInfo";
            this.lstAlarmsInfo.Size = new System.Drawing.Size(473, 303);
            this.lstAlarmsInfo.TabIndex = 10;
            // 
            // lstSensorsInfo
            // 
            this.lstSensorsInfo.FormattingEnabled = true;
            this.lstSensorsInfo.Location = new System.Drawing.Point(12, 311);
            this.lstSensorsInfo.Name = "lstSensorsInfo";
            this.lstSensorsInfo.Size = new System.Drawing.Size(478, 303);
            this.lstSensorsInfo.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Air Parameter:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "City:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 261);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Date:";
            // 
            // buttonSearch_Alarms
            // 
            this.buttonSearch_Alarms.Location = new System.Drawing.Point(239, 187);
            this.buttonSearch_Alarms.Name = "buttonSearch_Alarms";
            this.buttonSearch_Alarms.Size = new System.Drawing.Size(135, 65);
            this.buttonSearch_Alarms.TabIndex = 15;
            this.buttonSearch_Alarms.Text = "Search Alarms";
            this.buttonSearch_Alarms.UseVisualStyleBackColor = true;
            this.buttonSearch_Alarms.Click += new System.EventHandler(this.buttonSearch_Alarms_click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(579, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 24);
            this.label4.TabIndex = 16;
            this.label4.Text = "Hourly Statistics";
            // 
            // lstHourlyInfo
            // 
            this.lstHourlyInfo.FormattingEnabled = true;
            this.lstHourlyInfo.Location = new System.Drawing.Point(579, 36);
            this.lstHourlyInfo.Name = "lstHourlyInfo";
            this.lstHourlyInfo.Size = new System.Drawing.Size(400, 225);
            this.lstHourlyInfo.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label5.Location = new System.Drawing.Point(715, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 24);
            this.label5.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 626);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lstHourlyInfo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonSearch_Alarms);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstSensorsInfo);
            this.Controls.Add(this.lstAlarmsInfo);
            this.Controls.Add(this.lblDateTest);
            this.Controls.Add(this.lblCityTest);
            this.Controls.Add(this.lblSensorTest);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lbAlarmsInfo);
            this.Controls.Add(this.lbSensorsInfo);
            this.Controls.Add(this.gbParameters);
            this.Controls.Add(this.gbSensors);
            this.Name = "Form1";
            this.Text = "AirMonit Admin";
            this.gbSensors.ResumeLayout(false);
            this.gbSensors.PerformLayout();
            this.gbParameters.ResumeLayout(false);
            this.gbParameters.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSensors;
        private System.Windows.Forms.CheckBox cbO3;
        private System.Windows.Forms.CheckBox cbCO;
        private System.Windows.Forms.CheckBox cbNO2;
        private System.Windows.Forms.GroupBox gbParameters;
        private System.Windows.Forms.CheckBox cbHourlyStats;
        private System.Windows.Forms.DateTimePicker dtpDate2;
        private System.Windows.Forms.DateTimePicker dtpDate1;
        private System.Windows.Forms.CheckBox cbDate2;
        private System.Windows.Forms.CheckBox cbDate1;
        private System.Windows.Forms.Label lbCity;
        private System.Windows.Forms.ComboBox cbCity;
        private System.Windows.Forms.Label lbSensorsInfo;
        private System.Windows.Forms.Label lbAlarmsInfo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblSensorTest;
        private System.Windows.Forms.Label lblCityTest;
        private System.Windows.Forms.Label lblDateTest;
        private System.Windows.Forms.ListBox lstAlarmsInfo;
        private System.Windows.Forms.ListBox lstSensorsInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonSearch_Alarms;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstHourlyInfo;
        private System.Windows.Forms.Label label5;
    }
}

