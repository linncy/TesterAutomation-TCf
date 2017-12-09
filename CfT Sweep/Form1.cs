﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ivi.Visa;
using Ivi.Visa.FormattedIO;
using System.Collections;
using System.Windows.Forms.DataVisualization.Charting;

namespace TCf_Sweep
{
    public partial class Form1 : Form
    {
        //declare Global Var here
        string Func = "CpGpRp";
        bool GPIBstatus = false;
        bool PauseIsTrue = false;
        string[] Cp_Unit = { "F", "mF", "μF", "nF", "pF" };
        string[] Gp_Unit = { "S", "mS", "μS", "nS", "pS" };
        string[] Rp_Unit = { "Ω", "kΩ", "MΩ" };
        int Cp_Unit_order = 0;
        int Gp_Unit_order = 0;
        int Rp_Unit_order = 0;
        int i = 0;
        int iNumofLine;
        int iLoss = 0;
        int iExpectation = 0;
        int iCompletion = 0;
        float fRealtimeTemp;
        float fTargetTemp;
        float fStepTemp;
        float fStopTemp;
        float fError;
        float fStartf;
        float fStopf;
        float fStepf;
        List<float> listTCfx;
        List<IList> listTCfy;
        List<float> listLossT;
        DataTable dtTCf = new DataTable();
        System.Threading.ThreadStart TempMonitorThreadStart;
        System.Threading.Thread TempMonitorThread;
        System.Threading.ThreadStart CfThreadStart;
        System.Threading.Thread CfThread;
        System.Threading.ThreadStart plotThreadStart;
        System.Threading.Thread plotThread;
        System.DateTime UpTime = new System.DateTime(0);

        public enum RunState
        {
            noconnection,
            running,
            stop
        }
        RunState state = RunState.noconnection;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // GPIB instruments on the GPIB0 interface
        // Change this variable to the address of your instrument
        string LRC_VISA_ADDRESS = "GPIB0::25::INSTR";
        string TEMPCON_VISA_ADDRESS = "GPIB0::12::INSTR";

        // Create a connection (session) to the instrument
        IMessageBasedSession sessionLRC;
        IMessageBasedSession sessionTEMPCON;

        // Create a formatted I/O object which will help us format the data we want to send/receive to/from the instrument
        MessageBasedFormattedIO formattedIOLRC;
        MessageBasedFormattedIO formattedIOTEMPCON;

        private bool openGPIB()
        {
            try
            {
                sessionLRC = GlobalResourceManager.Open(LRC_VISA_ADDRESS, AccessModes.None, 50000) as IMessageBasedSession;
                formattedIOLRC = new MessageBasedFormattedIO(sessionLRC);
                sessionTEMPCON = GlobalResourceManager.Open(TEMPCON_VISA_ADDRESS, AccessModes.None, 50000) as IMessageBasedSession;
                formattedIOTEMPCON = new MessageBasedFormattedIO(sessionTEMPCON);
                MessageBox.Show("The instruments have been successfully connected on GPIB0::25 and GPIB0::12", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (NativeVisaException visaException)
            {
                MessageBox.Show("Failed to connect at least one instrument. Please check GPIB conncetion. GPIB port of the LRC Meter and Temperature Controller should be set as GPIB0::25 and GPIB0::12 respectively.", "Error: Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private string Inter()
        {
            string result = "";
            if (rbInterShort.Checked == true)
            {
                result = "SHOR,";
            }
            else if (rbInterMedium.Checked == true)
            {
                result = "MED,";
            }
            else if (rbInterLong.Checked == true)
            {
                result = "LONG,";
            }
            return result;
        }

        private string[] sendCommand(string comm,float value=1000)
        {
            string Comm;
            string idnResponse;
            string[] normalreturn = { DateTime.Now.ToString(), ":success" };
            try
            {
                switch (comm)
                {
                    case "APER":
                        Comm = comm + " " + Inter() + txtAveRate.Text;
                        formattedIOLRC.WriteLine(Comm);
                        formattedIOLRC.WriteLine("APER?");
                        idnResponse = formattedIOLRC.ReadLine().Replace("\n", "");
                        return normalreturn;
                    case "Volt":
                        Comm = comm + " " + txtOscVoltage.Text + "mV";
                        formattedIOLRC.WriteLine(Comm);
                        formattedIOLRC.WriteLine("VOLT?");
                        idnResponse = formattedIOLRC.ReadLine().Replace("\n", "");
                        return normalreturn;
                    case "Freq":
                        Comm = comm + " " + Convert.ToString(value) + "Hz";
                        formattedIOLRC.WriteLine(Comm);
                        formattedIOLRC.WriteLine("Freq?");
                        idnResponse = formattedIOLRC.ReadLine().Replace("\n", "");
                        return normalreturn;
                    case "Func:IMP CPG":
                        Comm = comm;
                        formattedIOLRC.WriteLine(Comm);
                        formattedIOLRC.WriteLine("Func:IMP?");
                        idnResponse = formattedIOLRC.ReadLine().Replace("\n", "");
                        return normalreturn;
                    case "Func:IMP CPRP":
                        Comm = comm;
                        formattedIOLRC.WriteLine(Comm);
                        formattedIOLRC.WriteLine("Func:IMP?");
                        idnResponse = formattedIOLRC.ReadLine().Replace("\n", "");
                        return normalreturn;
                    case "Func:IMP CSRS":
                        Comm = comm;
                        formattedIOLRC.WriteLine(Comm);
                        formattedIOLRC.WriteLine("Func:IMP?");
                        idnResponse = formattedIOLRC.ReadLine().Replace("\n", "");
                        return normalreturn;
                    case "BIAS:STAT 1":
                        Comm = comm;
                        formattedIOLRC.WriteLine(Comm);
                        formattedIOLRC.WriteLine("BIAS:STAT?");
                        idnResponse = formattedIOLRC.ReadLine().Replace("\n", "");
                        return normalreturn;
                    case "BIAS:STAT 0":
                        Comm = comm;
                        formattedIOLRC.WriteLine(Comm);
                        formattedIOLRC.WriteLine("BIAS:STAT?");
                        idnResponse = formattedIOLRC.ReadLine().Replace("\n", "");
                        return normalreturn;
                    case "Fetch?":
                        string[] idnResponseFetch;
                        Comm = comm;
                        formattedIOLRC.WriteLine(Comm);
                        idnResponse = formattedIOLRC.ReadLine().Replace("\n", "");
                        idnResponseFetch = idnResponse.Split(new string[] { "," }, StringSplitOptions.None);
                        return idnResponseFetch;

                    //Special Fetch
                    case "Fetch?[Special]":
                        string[] idnResponseFetchSpecial;
                        Comm = "Fetch?";
                        System.Threading.Thread.Sleep(1000);
                        formattedIOLRC.WriteLine(Comm);
                        while (1 == 1)
                        {
                            try
                            {
                                System.Threading.Thread.Sleep(1000);
                                idnResponse = formattedIOLRC.ReadLine().Replace("\n", "");
                                break;
                            }
                            catch
                            {

                            }
                        }
                        idnResponseFetchSpecial = idnResponse.Split(new string[] { "," }, StringSplitOptions.None);
                        return idnResponseFetchSpecial;

                    case "Fetch?[Special2]":
                        string[] idnResponseFetchSpecial2;
                        Comm = "Fetch?";
                        System.Threading.Thread.Sleep(100);
                        formattedIOLRC.WriteLine(Comm);
                        System.Threading.Thread.Sleep(100);
                        idnResponse = formattedIOLRC.ReadLine().Replace("\n", "");
                        idnResponseFetchSpecial2 = idnResponse.Split(new string[] { "," }, StringSplitOptions.None);
                        return idnResponseFetchSpecial2;
                }
            }
            catch (NativeVisaException visaException)
            {
                return null;
            }
            return null;
        }
        private void plot(Chart chart, List<string> tag, List<float> listx, List<IList> listy)
        {
        }

        private void plot_X_multiY(Chart chart, List<string> tag, List<float> listx, List<IList> listy)
        {
            chart.Series.Clear();
            List<Series> series = new List<Series>();
            for (int i = 0; i < iNumofLine; i++)
            {
                Series tempSeries = new Series(tag[i]);
                tempSeries.ChartType = SeriesChartType.Spline;
                tempSeries.Points.DataBindXY(listx, listy[i]);
                series.Add(tempSeries);
            }
            for (int i = 0; i < iNumofLine; i++)
            {
                chart.Series.Add(series[i]);
            }
        }
        public delegate void plot_X_multiYEventHandler(Chart chart, List<string> tag, List<float> listx, List<IList> listy);
        //Initialize LRC Meter and Temp Controller
        private void InitializeInstruments()
        {
            string Comm;
            if (!GPIBstatus)
            {
                MessageBox.Show("Please Connect Instrument.", "No GPIB Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // Initialize LRC Meter
            Comm = "Freq" + " " + "1000" + "Hz";
            formattedIOLRC.WriteLine(Comm);
            sendCommand("BIAS:STAT 1");
            Comm = "BIAS:VOLT " + txtMeasVoltage.Text + "V";
            formattedIOLRC.WriteLine(Comm);
            Comm = "Volt" + " " + txtOscVoltage.Text + "mV";
            formattedIOLRC.WriteLine(Comm);
            if (rbParallel.Checked == true)
            {
                sendCommand("Func:IMP CPG");
            }
            else if (rbSeries.Checked == true)
            {
                sendCommand("Func:IMP CSRS");
            }
            sendCommand("APER");

            //Initialize Temperature Controller
            Comm = "loop 1:source a";
            formattedIOTEMPCON.WriteLine(Comm);
            Comm = "loop 1:setpt " + txtStopTemp.Text;
            formattedIOTEMPCON.WriteLine(Comm);
            Comm = "loop 1:pgain 9.0";
            formattedIOTEMPCON.WriteLine(Comm);
            Comm = "loop 1:igain 90.0";
            formattedIOTEMPCON.WriteLine(Comm);
            Comm = "loop 1:dgain 0";
            formattedIOTEMPCON.WriteLine(Comm);
            Comm = "loop 1:pman 5";
            formattedIOTEMPCON.WriteLine(Comm);
            Comm = "loop 1:type rampp";
            formattedIOTEMPCON.WriteLine(Comm);
            Comm = "loop 1:range mid";
            formattedIOTEMPCON.WriteLine(Comm);
            Comm = "loop 1:rate 3";
            formattedIOTEMPCON.WriteLine(Comm);
            Comm = "loop 1:maxset 1000";
            formattedIOTEMPCON.WriteLine(Comm);
            Comm = "loop 1:maxpwr 100";
            formattedIOTEMPCON.WriteLine(Comm);
            Comm = "loop 1:autotune:mode pid";
            formattedIOTEMPCON.WriteLine(Comm);
        }

        private void TempMonitor()
        {
            string idnResponse;
            while (true)
            {
                System.Threading.Thread.Sleep(500);
                formattedIOTEMPCON.WriteLine("input? a");
                idnResponse = formattedIOTEMPCON.ReadLine().Replace("\n", "");
                labelRealTimeTemperature.Text = idnResponse;
                fRealtimeTemp = Convert.ToSingle(idnResponse);
            }
        }

        private void buttonConn_Click(object sender, EventArgs e)
        {
            if (openGPIB())
            {

                pictureConn.Image = global::CfT_Sweep.Properties.Resources.green;
                labelConn_Value.Text = "Success";
                GPIBstatus = true;
            }
            else
            {
                pictureConn.Image = global::CfT_Sweep.Properties.Resources.red;
                labelConn_Value.Text = "Fail";
                GPIBstatus = false;
                state = RunState.noconnection;
            }

        }

        private void labelVersion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("T-C-f Sweep \nDeveloped for Agilent 4284A Precision LCR Meter\nDeveloped for Cryo-con Model 22C\nVersion Origin0.1\nBuilt on 11/27/2017", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string Comm;
            if (!GPIBstatus)
            {
                MessageBox.Show("Please Connect Instrument.", "No GPIB Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            InitializeInstruments();//Initialize LRC Meter and Temp Controller
            timerUpTime.Interval = 1000; //Initialize UpTime timer
            UpTime = new System.DateTime(0); //Initialize UpTime timer
            timerUpTime.Start(); //UpTime timer Start
            dtTCf = new DataTable();
            dgvTCf.DataSource = dtTCf;
            listTCfy = new List<IList>();
            listLossT = new List<float>();
            state = RunState.running;
            //Temp Monitor Thread Start
            TempMonitorThreadStart = new System.Threading.ThreadStart(TempMonitor);
            TempMonitorThread = new System.Threading.Thread(TempMonitorThreadStart);
            TempMonitorThread.IsBackground = true;
            TempMonitorThread.Start();

            //Initialize Cf Parameter
            fTargetTemp = Convert.ToSingle(txtStartTemp.Text);
            fStepTemp = Convert.ToSingle(txtStepTemp.Text);
            fStopTemp = Convert.ToSingle(txtStopTemp.Text);
            fStartf = Convert.ToSingle(txtStartFreq.Text);
            fStopf = Convert.ToSingle(txtStopFreq.Text);
            fStepf = Convert.ToSingle(txtStepFreq.Text);
            iNumofLine = Convert.ToInt32((fStopf - fStartf) / fStepf) + 1;
            dtTCf.Columns.Add("T(K)", typeof(float));
            for (i=0;i<iNumofLine;i++)
            {
                List<double> listchild=new List<double>();
                listTCfy.Add(listchild);
                dtTCf.Columns.Add("f=10^"+Convert.ToString(fStartf+fStepf*i)+" Hz", typeof(float));
            }
            iExpectation = Convert.ToInt32(Math.Ceiling(fStopTemp - fTargetTemp) / fStepTemp + 1);
            labelExpectation.Text = Convert.ToString(iExpectation);
            iCompletion = 0;
            labelCompletion.Text = Convert.ToString(iCompletion);
            progressBarProgress.Maximum = iExpectation;
            progressBarProgress.Step = 1;
            progressBarProgress.Value = 0;
            //Run Cf Thread
            if (fTargetTemp>fRealtimeTemp-fStepTemp*fError)
            {
                CfThreadStart = new System.Threading.ThreadStart(RunCf);
                CfThread = new System.Threading.Thread(CfThreadStart);
                CfThread.IsBackground = true;
                CfThread.Start();
            }
            else
            {
                MessageBox.Show("Program failed to perform T-C-f Sweep, because \"Start Temperature\" was lower than \"Real Time Temperature\". Please lower temperature in the vacuum chamber or raise \"Start Temperature\". ", "Error: Parameter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                state = RunState.stop;
                TempMonitorThread.Abort();
            }

        }
        public delegate void RunCfEventHandler();
        public void RunCf()
        {
            string CommFreq;
            string strFreq;
            string[] FetchResult;
            DataRow aRow = dtTCf.NewRow();
            int iCorrectionCoefficient = 0;
            while (true)
            {
                if (fTargetTemp > fStopTemp)//Complete
                {
                    TempMonitorThread.Abort();
                    MessageBox.Show("Loss:" + Convert.ToString(iLoss), "T-C-f Sweep Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                }
                labelNextSetpoint.Text = fTargetTemp.ToString();

                System.Threading.Thread.Sleep(200);
                if (fTargetTemp >= fStopTemp)
                    break;
                if (((fTargetTemp - fStepTemp * fError) <= fRealtimeTemp) && (fRealtimeTemp <= (fTargetTemp + fStepTemp * fError)))
                {
                    listTCfx.Add(fRealtimeTemp);
                    aRow[0] = fRealtimeTemp;
                    for (int i = 0; i < iNumofLine; i++)
                    {
                        strFreq = Math.Pow(10, fStartf + fStepf * i).ToString("f4");
                        CommFreq = "Freq" + " " + strFreq + "Hz";
                        formattedIOLRC.WriteLine(CommFreq);
                        System.Threading.Thread.Sleep(1);
                        FetchResult = sendCommand("Fetch?");
                        listTCfy[i].Add(Convert.ToDouble(FetchResult[0]));
                        aRow[i + 1] = (Convert.ToDouble(FetchResult[0]));
                    }
                    dgvTCf.Rows.Add(aRow);
                    fTargetTemp += fStepTemp;
                    iCompletion++;
                    labelCompletion.Text = Convert.ToString(iCompletion);
                    progressBarProgress.Value += progressBarProgress.Step;
                }
                else if (fRealtimeTemp < fTargetTemp)
                {
                    //
                }
                else if (fRealtimeTemp > fTargetTemp)
                {
                    //Realtime Temp is bigger than Target Temp：1.Correct Target Temp 2. Record Loss Point 3. Loss Index
                    listLossT.Add(fTargetTemp);
                    iCorrectionCoefficient = Convert.ToInt32((Math.Ceiling((fRealtimeTemp - fTargetTemp) / fStepTemp)));
                    fTargetTemp = fTargetTemp + iCorrectionCoefficient * fStepTemp;
                    iLoss += iCorrectionCoefficient;
                    labelLoss.Text = Convert.ToString(iLoss);
                }
            }
        }

        private void Test1_Click(object sender, EventArgs e)
        {
            progressBarProgress.Maximum = 100;
            progressBarProgress.Value = 0;
            progressBarProgress.Step = 1;
            iNumofLine = 2;
            List<IList> listy = new List<IList>();
            List<float> x = new List<float>();
            List<float> y = new List<float>();
            List<float> y2 = new List<float>();
            List<string> tag = new List<string>();
            listy.Add(y); listy.Add(y2);
            x.Add(0); x.Add(1); x.Add(2);
            y.Add(0); y.Add(1); y.Add(2);
            y2.Add(0); y2.Add(-1); y2.Add(-2);
            tag.Add("f=1Hz"); tag.Add("f=10Hz");
            MessageBox.Show("Loss:" + Convert.ToString(iLoss), "T-C-f Sweep Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            timerUpTime.Interval = 1000; //Initialize UpTime timer
            UpTime = new System.DateTime(0); //Initialize UpTime timer
            timerUpTime.Start(); //UpTime timer Start
            listTCfy = new List<IList>();
            dtTCf = new DataTable();
            dgvTCf.DataSource = dtTCf;
            fTargetTemp = Convert.ToSingle(txtStartTemp.Text);
            fStepTemp = Convert.ToSingle(txtStepTemp.Text);
            fStopTemp = Convert.ToSingle(txtStopTemp.Text);
            fStartf = Convert.ToSingle(txtStartFreq.Text);
            fStopf = Convert.ToSingle(txtStopFreq.Text);
            fStepf = Convert.ToSingle(txtStepFreq.Text);
            iNumofLine = Convert.ToInt32((fStopf - fStartf) / fStepf) + 1;
            dtTCf.Columns.Add("T(K)", typeof(float));
            for (int i = 0; i < iNumofLine; i++)
            {
                List<double> listchild = new List<double>();
                listTCfy.Add(listchild);
                dtTCf.Columns.Add("f=10^" + Convert.ToString(fStartf + fStepf * i) + " Hz", typeof(float));
            }
            MessageBox.Show(Convert.ToString(iNumofLine), "Error: Parameter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            DataRow aRow = dtTCf.NewRow();
            aRow[0]=10.116F;
            for (int i = 0; i < iNumofLine; i++)
            {
                aRow[i+1]=i;
            }
            dtTCf.Rows.Add(aRow);
            iExpectation = Convert.ToInt32(Math.Ceiling(fStopTemp - fTargetTemp) / fStepTemp + 1);
            labelExpectation.Text = Convert.ToString(iExpectation);

        }

        private void timerUpTime_Tick(object sender, EventArgs e)
        {
            UpTime = UpTime.AddSeconds(1);
            labelUpTime.Text = UpTime.ToString("mm:ss");
            progressBarProgress.Value += progressBarProgress.Step;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            TempMonitorThread.Abort();
            CfThread.Abort();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataGridViewToCSV(dgvTCf);
        }
    }
}
