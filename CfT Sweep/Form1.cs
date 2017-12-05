using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ivi.Visa;
using Ivi.Visa.FormattedIO;

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
        float fRealtimeTemp;
        float fTargetTemp;
        float fStepTemp;
        float fStopTemp;
        float fError;
        
        System.Threading.ThreadStart TempMonitorThreadStart;
        System.Threading.Thread TempMonitorThread;
        System.Threading.ThreadStart CfThreadStart;
        System.Threading.Thread CfThread;
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

            state = RunState.running;
            //Temp Monitor Thread Start
            TempMonitorThreadStart = new System.Threading.ThreadStart(TempMonitor);
            TempMonitorThread = new System.Threading.Thread(TempMonitorThreadStart);
            TempMonitorThread.IsBackground = true;
            TempMonitorThread.Start();

            //Cf 
            fTargetTemp = Convert.ToSingle(txtStartTemp.Text);
            if(fTargetTemp>fRealtimeTemp-fStepTemp*fError)
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
            while(true)
            {
                System.Threading.Thread.Sleep(200);
                if(((fTargetTemp-fStepTemp*fError)<=fRealtimeTemp)&&(fRealtimeTemp<=(fTargetTemp+fStepTemp*fError)))
                {
                    // C-f Sweep
                    //for(i<=x) 1. x=? 2.datalist 3.datagridview 

                    //
                    fTargetTemp += fStepTemp;
                    labelNextSetpoint.Text = fTargetTemp.ToString();
                }
                else if(fRealtimeTemp<fTargetTemp)
                {
                    //
                }
                else if(fRealtimeTemp>fTargetTemp)
                {
                    //实时温度大于目标采集点温度：1、修正目标采集点温度 2、Loss数据记录
                }
            }
        }

        private void Test1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Program failed to perform T-C-f Sweep, because \"Start Temperature\" was lower than \"Real Time Temperature\". Please lower temperature in the vacuum chamber or raise \"Start Temperature\". ", "Error: Parameter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void timerUpTime_Tick(object sender, EventArgs e)
        {
            UpTime = UpTime.AddSeconds(1);
            labelUpTime.Text = UpTime.ToString("mm:ss");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            TempMonitorThread.Abort();
            CfThread.Abort();
        }
    }
}
