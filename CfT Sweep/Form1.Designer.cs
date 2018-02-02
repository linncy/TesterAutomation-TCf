namespace TCf_Sweep
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBoxStatus = new System.Windows.Forms.GroupBox();
            this.pictureState = new System.Windows.Forms.PictureBox();
            this.buttonConn = new System.Windows.Forms.Button();
            this.pictureConn = new System.Windows.Forms.PictureBox();
            this.labelConn_Value = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelState_Value = new System.Windows.Forms.Label();
            this.labelState = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbSeries = new System.Windows.Forms.RadioButton();
            this.rbParallel = new System.Windows.Forms.RadioButton();
            this.txtAveRate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOscVoltage = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbInterLong = new System.Windows.Forms.RadioButton();
            this.rbInterMedium = new System.Windows.Forms.RadioButton();
            this.rbInterShort = new System.Windows.Forms.RadioButton();
            this.txtStartFreq = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtMeasVoltage = new System.Windows.Forms.TextBox();
            this.txtStopTemp = new System.Windows.Forms.TextBox();
            this.txtStepTemp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtStartTemp = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtStepFreq = new System.Windows.Forms.TextBox();
            this.txtStopFreq = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelCompletion = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.labelExpectation = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.labelLoss = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.progressBarProgress = new System.Windows.Forms.ProgressBar();
            this.label23 = new System.Windows.Forms.Label();
            this.labelUpTime = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.labelNextSetpoint = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.labelRealTimeTemperature = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.chartTCf = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvTCf = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.labelVersion = new System.Windows.Forms.Label();
            this.Test1 = new System.Windows.Forms.Button();
            this.timerUpTime = new System.Windows.Forms.Timer(this.components);
            this.test2 = new System.Windows.Forms.Button();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.groupBoxStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureConn)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTCf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTCf)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxStatus
            // 
            this.groupBoxStatus.Controls.Add(this.pictureState);
            this.groupBoxStatus.Controls.Add(this.buttonConn);
            this.groupBoxStatus.Controls.Add(this.pictureConn);
            this.groupBoxStatus.Controls.Add(this.labelConn_Value);
            this.groupBoxStatus.Controls.Add(this.label2);
            this.groupBoxStatus.Controls.Add(this.labelState_Value);
            this.groupBoxStatus.Controls.Add(this.labelState);
            this.groupBoxStatus.Location = new System.Drawing.Point(12, 11);
            this.groupBoxStatus.Name = "groupBoxStatus";
            this.groupBoxStatus.Size = new System.Drawing.Size(166, 108);
            this.groupBoxStatus.TabIndex = 4;
            this.groupBoxStatus.TabStop = false;
            this.groupBoxStatus.Text = "Status";
            // 
            // pictureState
            // 
            this.pictureState.Image = global::CfT_Sweep.Properties.Resources.red;
            this.pictureState.Location = new System.Drawing.Point(141, 79);
            this.pictureState.Name = "pictureState";
            this.pictureState.Size = new System.Drawing.Size(19, 16);
            this.pictureState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureState.TabIndex = 5;
            this.pictureState.TabStop = false;
            // 
            // buttonConn
            // 
            this.buttonConn.Location = new System.Drawing.Point(9, 18);
            this.buttonConn.Name = "buttonConn";
            this.buttonConn.Size = new System.Drawing.Size(151, 21);
            this.buttonConn.TabIndex = 4;
            this.buttonConn.Text = "Connect Instrument";
            this.buttonConn.UseVisualStyleBackColor = true;
            this.buttonConn.Click += new System.EventHandler(this.buttonConn_Click);
            // 
            // pictureConn
            // 
            this.pictureConn.Image = global::CfT_Sweep.Properties.Resources.red;
            this.pictureConn.Location = new System.Drawing.Point(141, 53);
            this.pictureConn.Name = "pictureConn";
            this.pictureConn.Size = new System.Drawing.Size(19, 16);
            this.pictureConn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureConn.TabIndex = 4;
            this.pictureConn.TabStop = false;
            // 
            // labelConn_Value
            // 
            this.labelConn_Value.AutoSize = true;
            this.labelConn_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelConn_Value.Location = new System.Drawing.Point(85, 53);
            this.labelConn_Value.Name = "labelConn_Value";
            this.labelConn_Value.Size = new System.Drawing.Size(30, 17);
            this.labelConn_Value.TabIndex = 4;
            this.labelConn_Value.Text = "Fail";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Connection:";
            // 
            // labelState_Value
            // 
            this.labelState_Value.AutoSize = true;
            this.labelState_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelState_Value.Location = new System.Drawing.Point(51, 79);
            this.labelState_Value.Name = "labelState_Value";
            this.labelState_Value.Size = new System.Drawing.Size(87, 17);
            this.labelState_Value.TabIndex = 2;
            this.labelState_Value.Text = "Not Running";
            // 
            // labelState
            // 
            this.labelState.AutoSize = true;
            this.labelState.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelState.Location = new System.Drawing.Point(6, 79);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(52, 17);
            this.labelState.TabIndex = 1;
            this.labelState.Text = "Status:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCalculate);
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.txtAveRate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtOscVoltage);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.txtStartFreq);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtMeasVoltage);
            this.groupBox1.Controls.Add(this.txtStopTemp);
            this.groupBox1.Controls.Add(this.txtStepTemp);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label32);
            this.groupBox1.Controls.Add(this.label33);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtStartTemp);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtStepFreq);
            this.groupBox1.Controls.Add(this.txtStopFreq);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(12, 125);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(166, 582);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "T-C-f Sweep";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(10, 495);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(81, 23);
            this.btnCalculate.TabIndex = 34;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(10, 552);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(81, 23);
            this.btnStop.TabIndex = 33;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(95, 291);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 12);
            this.label13.TabIndex = 54;
            this.label13.Text = "mV";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(10, 523);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(81, 23);
            this.btnStart.TabIndex = 32;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 215);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 12);
            this.label9.TabIndex = 48;
            this.label9.Text = "10E";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(95, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 30;
            this.label4.Text = "K";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(95, 251);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(11, 12);
            this.label14.TabIndex = 53;
            this.label14.Text = "V";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rbSeries);
            this.groupBox5.Controls.Add(this.rbParallel);
            this.groupBox5.Location = new System.Drawing.Point(8, 435);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(130, 56);
            this.groupBox5.TabIndex = 27;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Equivalent Circuit";
            // 
            // rbSeries
            // 
            this.rbSeries.AutoSize = true;
            this.rbSeries.Location = new System.Drawing.Point(6, 39);
            this.rbSeries.Name = "rbSeries";
            this.rbSeries.Size = new System.Drawing.Size(59, 16);
            this.rbSeries.TabIndex = 2;
            this.rbSeries.TabStop = true;
            this.rbSeries.Text = "Series";
            this.rbSeries.UseVisualStyleBackColor = true;
            // 
            // rbParallel
            // 
            this.rbParallel.AutoSize = true;
            this.rbParallel.Checked = true;
            this.rbParallel.Location = new System.Drawing.Point(6, 18);
            this.rbParallel.Name = "rbParallel";
            this.rbParallel.Size = new System.Drawing.Size(71, 16);
            this.rbParallel.TabIndex = 1;
            this.rbParallel.TabStop = true;
            this.rbParallel.Text = "Parallel";
            this.rbParallel.UseVisualStyleBackColor = true;
            // 
            // txtAveRate
            // 
            this.txtAveRate.Location = new System.Drawing.Point(9, 414);
            this.txtAveRate.Name = "txtAveRate";
            this.txtAveRate.Size = new System.Drawing.Size(81, 21);
            this.txtAveRate.TabIndex = 26;
            this.txtAveRate.Text = "4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 12);
            this.label3.TabIndex = 29;
            this.label3.Text = "Start Temperature";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 399);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 12);
            this.label17.TabIndex = 25;
            this.label17.Text = "Averaging Rate";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 12);
            this.label5.TabIndex = 38;
            this.label5.Text = "Start Frequency";
            // 
            // txtOscVoltage
            // 
            this.txtOscVoltage.Location = new System.Drawing.Point(8, 287);
            this.txtOscVoltage.Name = "txtOscVoltage";
            this.txtOscVoltage.Size = new System.Drawing.Size(81, 21);
            this.txtOscVoltage.TabIndex = 52;
            this.txtOscVoltage.Text = "25";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbInterLong);
            this.groupBox4.Controls.Add(this.rbInterMedium);
            this.groupBox4.Controls.Add(this.rbInterShort);
            this.groupBox4.Location = new System.Drawing.Point(6, 311);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(131, 83);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Intergration Time";
            // 
            // rbInterLong
            // 
            this.rbInterLong.AutoSize = true;
            this.rbInterLong.Location = new System.Drawing.Point(6, 62);
            this.rbInterLong.Name = "rbInterLong";
            this.rbInterLong.Size = new System.Drawing.Size(47, 16);
            this.rbInterLong.TabIndex = 2;
            this.rbInterLong.Text = "LONG";
            this.rbInterLong.UseVisualStyleBackColor = true;
            // 
            // rbInterMedium
            // 
            this.rbInterMedium.AutoSize = true;
            this.rbInterMedium.Checked = true;
            this.rbInterMedium.Location = new System.Drawing.Point(6, 41);
            this.rbInterMedium.Name = "rbInterMedium";
            this.rbInterMedium.Size = new System.Drawing.Size(59, 16);
            this.rbInterMedium.TabIndex = 1;
            this.rbInterMedium.TabStop = true;
            this.rbInterMedium.Text = "MEDIUM";
            this.rbInterMedium.UseVisualStyleBackColor = true;
            // 
            // rbInterShort
            // 
            this.rbInterShort.AutoSize = true;
            this.rbInterShort.Location = new System.Drawing.Point(6, 20);
            this.rbInterShort.Name = "rbInterShort";
            this.rbInterShort.Size = new System.Drawing.Size(53, 16);
            this.rbInterShort.TabIndex = 0;
            this.rbInterShort.Text = "SHORT";
            this.rbInterShort.UseVisualStyleBackColor = true;
            // 
            // txtStartFreq
            // 
            this.txtStartFreq.Location = new System.Drawing.Point(38, 140);
            this.txtStartFreq.Name = "txtStartFreq";
            this.txtStartFreq.Size = new System.Drawing.Size(36, 21);
            this.txtStartFreq.TabIndex = 37;
            this.txtStartFreq.Text = "3";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(95, 68);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(11, 12);
            this.label25.TabIndex = 22;
            this.label25.Text = "K";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 272);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(119, 12);
            this.label15.TabIndex = 51;
            this.label15.Text = "Oscillation Voltage";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(95, 108);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(11, 12);
            this.label24.TabIndex = 23;
            this.label24.Text = "K";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(81, 215);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 47;
            this.label11.Text = "Hz";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 234);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(119, 12);
            this.label16.TabIndex = 50;
            this.label16.Text = "Measurement Voltage";
            // 
            // txtMeasVoltage
            // 
            this.txtMeasVoltage.Location = new System.Drawing.Point(8, 248);
            this.txtMeasVoltage.Name = "txtMeasVoltage";
            this.txtMeasVoltage.Size = new System.Drawing.Size(81, 21);
            this.txtMeasVoltage.TabIndex = 49;
            this.txtMeasVoltage.Text = "0";
            // 
            // txtStopTemp
            // 
            this.txtStopTemp.Location = new System.Drawing.Point(8, 66);
            this.txtStopTemp.Name = "txtStopTemp";
            this.txtStopTemp.Size = new System.Drawing.Size(81, 21);
            this.txtStopTemp.TabIndex = 18;
            this.txtStopTemp.Text = "320";
            // 
            // txtStepTemp
            // 
            this.txtStepTemp.Location = new System.Drawing.Point(8, 104);
            this.txtStepTemp.Name = "txtStepTemp";
            this.txtStepTemp.Size = new System.Drawing.Size(81, 21);
            this.txtStepTemp.TabIndex = 21;
            this.txtStepTemp.Text = "0.4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 39;
            this.label1.Text = "Hz";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(6, 90);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(101, 12);
            this.label32.TabIndex = 20;
            this.label32.Text = "Temperature Step";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(6, 51);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(101, 12);
            this.label33.TabIndex = 19;
            this.label33.Text = "Stop Temperature";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 143);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 12);
            this.label10.TabIndex = 40;
            this.label10.Text = "10E";
            // 
            // txtStartTemp
            // 
            this.txtStartTemp.Location = new System.Drawing.Point(8, 30);
            this.txtStartTemp.Name = "txtStartTemp";
            this.txtStartTemp.Size = new System.Drawing.Size(81, 21);
            this.txtStartTemp.TabIndex = 28;
            this.txtStartTemp.Text = "10";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 12);
            this.label6.TabIndex = 44;
            this.label6.Text = "10E";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 198);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 12);
            this.label12.TabIndex = 46;
            this.label12.Text = "Frequency Step";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(81, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 43;
            this.label7.Text = "Hz";
            // 
            // txtStepFreq
            // 
            this.txtStepFreq.Location = new System.Drawing.Point(39, 212);
            this.txtStepFreq.Name = "txtStepFreq";
            this.txtStepFreq.Size = new System.Drawing.Size(36, 21);
            this.txtStepFreq.TabIndex = 45;
            this.txtStepFreq.Text = "0.5";
            // 
            // txtStopFreq
            // 
            this.txtStopFreq.Location = new System.Drawing.Point(39, 176);
            this.txtStopFreq.Name = "txtStopFreq";
            this.txtStopFreq.Size = new System.Drawing.Size(36, 21);
            this.txtStopFreq.TabIndex = 41;
            this.txtStopFreq.Text = "6";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 42;
            this.label8.Text = "Stop Frequency";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelCompletion);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.labelExpectation);
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Controls.Add(this.labelLoss);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.progressBarProgress);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.labelUpTime);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.labelNextSetpoint);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.labelRealTimeTemperature);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Location = new System.Drawing.Point(184, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(779, 84);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dashboard";
            // 
            // labelCompletion
            // 
            this.labelCompletion.AutoSize = true;
            this.labelCompletion.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.labelCompletion.Location = new System.Drawing.Point(449, 50);
            this.labelCompletion.Name = "labelCompletion";
            this.labelCompletion.Size = new System.Drawing.Size(24, 26);
            this.labelCompletion.TabIndex = 13;
            this.labelCompletion.Text = "0";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label28.Location = new System.Drawing.Point(412, 27);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(89, 20);
            this.label28.TabIndex = 12;
            this.label28.Text = "Completion";
            // 
            // labelExpectation
            // 
            this.labelExpectation.AutoSize = true;
            this.labelExpectation.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.labelExpectation.Location = new System.Drawing.Point(330, 50);
            this.labelExpectation.Name = "labelExpectation";
            this.labelExpectation.Size = new System.Drawing.Size(24, 26);
            this.labelExpectation.TabIndex = 11;
            this.labelExpectation.Text = "0";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label27.Location = new System.Drawing.Point(298, 27);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(93, 20);
            this.label27.TabIndex = 10;
            this.label27.Text = "Expectation";
            // 
            // labelLoss
            // 
            this.labelLoss.AutoSize = true;
            this.labelLoss.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.labelLoss.Location = new System.Drawing.Point(528, 50);
            this.labelLoss.Name = "labelLoss";
            this.labelLoss.Size = new System.Drawing.Size(24, 26);
            this.labelLoss.TabIndex = 9;
            this.labelLoss.Text = "0";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label22.Location = new System.Drawing.Point(686, 27);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(72, 20);
            this.label22.TabIndex = 7;
            this.label22.Text = "Progress";
            // 
            // progressBarProgress
            // 
            this.progressBarProgress.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.progressBarProgress.Location = new System.Drawing.Point(672, 53);
            this.progressBarProgress.Name = "progressBarProgress";
            this.progressBarProgress.Size = new System.Drawing.Size(100, 21);
            this.progressBarProgress.TabIndex = 6;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label23.Location = new System.Drawing.Point(518, 27);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(43, 20);
            this.label23.TabIndex = 8;
            this.label23.Text = "Loss";
            // 
            // labelUpTime
            // 
            this.labelUpTime.AutoSize = true;
            this.labelUpTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.labelUpTime.Location = new System.Drawing.Point(594, 50);
            this.labelUpTime.Name = "labelUpTime";
            this.labelUpTime.Size = new System.Drawing.Size(66, 26);
            this.labelUpTime.TabIndex = 5;
            this.labelUpTime.Text = "00:00";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label21.Location = new System.Drawing.Point(592, 27);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(68, 20);
            this.label21.TabIndex = 4;
            this.label21.Text = "Up Time";
            // 
            // labelNextSetpoint
            // 
            this.labelNextSetpoint.AutoSize = true;
            this.labelNextSetpoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.labelNextSetpoint.Location = new System.Drawing.Point(218, 50);
            this.labelNextSetpoint.Name = "labelNextSetpoint";
            this.labelNextSetpoint.Size = new System.Drawing.Size(24, 26);
            this.labelNextSetpoint.TabIndex = 3;
            this.labelNextSetpoint.Text = "0";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label20.Location = new System.Drawing.Point(187, 27);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(105, 20);
            this.label20.TabIndex = 2;
            this.label20.Text = "Next Setpoint";
            // 
            // labelRealTimeTemperature
            // 
            this.labelRealTimeTemperature.AutoSize = true;
            this.labelRealTimeTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.labelRealTimeTemperature.Location = new System.Drawing.Point(69, 50);
            this.labelRealTimeTemperature.Name = "labelRealTimeTemperature";
            this.labelRealTimeTemperature.Size = new System.Drawing.Size(24, 26);
            this.labelRealTimeTemperature.TabIndex = 1;
            this.labelRealTimeTemperature.Text = "0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label18.Location = new System.Drawing.Point(6, 27);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(175, 20);
            this.label18.TabIndex = 0;
            this.label18.Text = "Real Time Temperature";
            // 
            // chartTCf
            // 
            chartArea1.Name = "ChartArea1";
            this.chartTCf.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartTCf.Legends.Add(legend1);
            this.chartTCf.Location = new System.Drawing.Point(184, 101);
            this.chartTCf.Name = "chartTCf";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartTCf.Series.Add(series1);
            this.chartTCf.Size = new System.Drawing.Size(779, 371);
            this.chartTCf.TabIndex = 7;
            this.chartTCf.Text = "chart1";
            // 
            // dgvTCf
            // 
            this.dgvTCf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTCf.Location = new System.Drawing.Point(184, 477);
            this.dgvTCf.Name = "dgvTCf";
            this.dgvTCf.Size = new System.Drawing.Size(698, 230);
            this.dgvTCf.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(888, 477);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 21);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(888, 686);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 21);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F);
            this.labelVersion.Location = new System.Drawing.Point(12, 710);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(18, 7);
            this.labelVersion.TabIndex = 11;
            this.labelVersion.Text = "0.11";
            this.labelVersion.Click += new System.EventHandler(this.labelVersion_Click);
            // 
            // Test1
            // 
            this.Test1.Location = new System.Drawing.Point(888, 535);
            this.Test1.Name = "Test1";
            this.Test1.Size = new System.Drawing.Size(75, 21);
            this.Test1.TabIndex = 12;
            this.Test1.Text = "Test1";
            this.Test1.UseVisualStyleBackColor = true;
            this.Test1.Click += new System.EventHandler(this.Test1_Click);
            // 
            // timerUpTime
            // 
            this.timerUpTime.Tick += new System.EventHandler(this.timerUpTime_Tick);
            // 
            // test2
            // 
            this.test2.Location = new System.Drawing.Point(888, 595);
            this.test2.Name = "test2";
            this.test2.Size = new System.Drawing.Size(75, 21);
            this.test2.TabIndex = 13;
            this.test2.Text = "Test2";
            this.test2.UseVisualStyleBackColor = true;
            this.test2.Click += new System.EventHandler(this.test2_Click);
            // 
            // timerRefresh
            // 
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 721);
            this.Controls.Add(this.test2);
            this.Controls.Add(this.Test1);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvTCf);
            this.Controls.Add(this.chartTCf);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxStatus);
            this.Name = "Form1";
            this.Text = "T-C-f Sweep";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxStatus.ResumeLayout(false);
            this.groupBoxStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureConn)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTCf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTCf)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxStatus;
        private System.Windows.Forms.PictureBox pictureState;
        private System.Windows.Forms.Button buttonConn;
        private System.Windows.Forms.PictureBox pictureConn;
        private System.Windows.Forms.Label labelConn_Value;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelState_Value;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStartTemp;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbSeries;
        private System.Windows.Forms.RadioButton rbParallel;
        private System.Windows.Forms.TextBox txtAveRate;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbInterLong;
        private System.Windows.Forms.RadioButton rbInterMedium;
        private System.Windows.Forms.RadioButton rbInterShort;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtStepTemp;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox txtStopTemp;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOscVoltage;
        private System.Windows.Forms.TextBox txtStartFreq;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtMeasVoltage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtStepFreq;
        private System.Windows.Forms.TextBox txtStopFreq;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTCf;
        private System.Windows.Forms.DataGridView dgvTCf;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelNextSetpoint;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label labelRealTimeTemperature;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ProgressBar progressBarProgress;
        private System.Windows.Forms.Label labelUpTime;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button Test1;
        private System.Windows.Forms.Timer timerUpTime;
        private System.Windows.Forms.Label labelExpectation;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label labelLoss;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label labelCompletion;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button test2;
        private System.Windows.Forms.Timer timerRefresh;
    }
}

