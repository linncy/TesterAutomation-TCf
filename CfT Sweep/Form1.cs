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
using System.Collections;
using System.Windows.Forms.DataVisualization.Charting;
using LogRecord;

namespace TCf_Sweep
{
    public partial class Form1 : Form
    {
        //declare Global Var here
        string Func = "CpGpRp";
        bool GPIBstatus = false;
        bool PauseIsTrue = false;
        bool tempRun = false;
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
        float fError=0.1F;
        float fStartf;
        float fStopf;
        float fStepf;
        List<float> listTCfx;
        List<IList> listTCfy;
        List<float> listLossT;
        List<string> tag;
        List<float> listx;
        List<IList> listy;
        DataTable dtTCf = new DataTable();
        System.Threading.ThreadStart TempMonitorThreadStart;
        System.Threading.Thread TempMonitorThread;
        System.Threading.ThreadStart CfThreadStart;
        System.Threading.Thread CfThread;
        System.Threading.ThreadStart plotThreadStart;
        System.Threading.Thread plotThread;
        System.DateTime UpTime = new System.DateTime(0);
        bool signal=true;
        static object locker = new object();
        LogClass logfile = new LogClass();

        Random rd = new Random();

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
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
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

        private void changeWidget()
        {
            bool state;
            state = txtStartTemp.Enabled;
            txtStartTemp.Enabled=!state;
            txtStopTemp.Enabled = !state;
            txtStepTemp.Enabled = !state;
            txtStartFreq.Enabled = !state;
            txtStopFreq.Enabled = !state;
            txtStepFreq.Enabled = !state;
            txtMeasVoltage.Enabled = !state;
            txtOscVoltage.Enabled = !state;
            groupBox4.Enabled = !state;
            groupBox5.Enabled = !state;
            btnCalculate.Enabled = !state;
            btnStart.Enabled = !state;
            btnStop.Enabled = state;
            txtAveRate.Enabled = !state;
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
        private delegate void Plot(List<string> tag, List<float> listx, List<IList> listy);

        private void plot_X_multiY(List<string> tag, List<float> listx, List<IList> listy)
        {
            if(this.InvokeRequired)
            {
                Plot plot = new Plot(plot_X_multiY);
                if (listx.Count == listy[listy.Count - 1].Count)
                {
                    this.Invoke(plot, new object[] {tag, listx, listy });
                }
            }
            else
            {
                List<float> tempListX = new List<float>();
                tempListX = listx;
                List<IList> tempListY = new List<IList>();
                tempListY = listy;
                this.chartTCf.Series.Clear();
                List<Series> series = new List<Series>();
                for (int i = 0; i < iNumofLine; i++)
                {
                    Series tempSeries = new Series(tag[i]);
                    tempSeries.ChartType = SeriesChartType.Spline;
                    tempSeries.Points.DataBindXY(tempListX, tempListY[i]);
                    series.Add(tempSeries);
                }
                for (int i = 0; i < iNumofLine; i++)
                {
                    this.chartTCf.Series.Add(series[i]);
                }

            }
        }
        private void ploter()
        {
            while(true)
            {
                System.Threading.Thread.Sleep(1000);// refresh graph per second
                lock (locker)
                {
                    if (signal == true)
                    {
                        plot_X_multiY(tag, listx, listy);
                    }
                }
            }
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
            //string idnResponse;
            //while (tempRun)
            //{
            //    System.Threading.Thread.Sleep(500);
            //    formattedIOTEMPCON.WriteLine("input? a");
            //    idnResponse = formattedIOTEMPCON.ReadLine().Replace("\n", "");
            //    labelRealTimeTemperature.Text = idnResponse;
            //    fRealtimeTemp = Convert.ToSingle(idnResponse);
            //}
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
            MessageBox.Show("T-C-f Sweep \nDeveloped for Agilent 4284A Precision LCR Meter\nDeveloped for Cryo-con Model 22C\nVersion Origin0.1\nBuilt on 2/2/2018", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string Comm, saveData;
            if (!GPIBstatus)
            {
                MessageBox.Show("Please Connect Instrument.", "No GPIB Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            InitializeInstruments();//Initialize LRC Meter and Temp Controller
            timerUpTime.Interval = 1000; //Initialize UpTime timer
            UpTime = new System.DateTime(0); //Initialize UpTime timer
            timerUpTime.Start(); //UpTime timer Start
            timerRefresh.Interval = 500;//Initialize Refresh timer
            timerRefresh.Start(); // Refresh timer start
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
            //dtTCf.Columns.Add("T(K)", typeof(float));
            listy = new List<IList>();
            listx = new List<float>();
            tag = new List<string>();
            for (i=0;i<iNumofLine;i++)
            {
                List<float> listchild=new List<float>();
                listy.Add(listchild);
                tag.Add("f=10^" + Convert.ToString(fStartf + fStepf * i) + " Hz");
                //dtTCf.Columns.Add("f=10^"+Convert.ToString(fStartf+fStepf*i)+" Hz", typeof(float));
            }
            iExpectation = Convert.ToInt32(Math.Ceiling(fStopTemp - fTargetTemp) / fStepTemp + 1);
            labelExpectation.Text = Convert.ToString(iExpectation);
            iCompletion = 0;
            labelCompletion.Text = Convert.ToString(iCompletion);
            progressBarProgress.Maximum = iExpectation+1;
            progressBarProgress.Step = 1;
            progressBarProgress.Value = 0;
            //Run Cf Thread
            if (fTargetTemp>fRealtimeTemp-fStepTemp*fError)
            {
                //Cf Thread
                CfThreadStart = new System.Threading.ThreadStart(RunCf);
                CfThread = new System.Threading.Thread(CfThreadStart);
                CfThread.IsBackground = true;
                CfThread.Start();
                //Plot Thread
                plotThreadStart = new System.Threading.ThreadStart(ploter);
                plotThread = new System.Threading.Thread(plotThreadStart);
                plotThread.IsBackground = true;
                plotThread.Start();
            }
            else
            {
                MessageBox.Show("Program failed to perform T-C-f Sweep, because \"Start Temperature\" was lower than \"Real Time Temperature\". Please lower temperature in the vacuum chamber or raise \"Start Temperature\". ", "Error: Parameter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                state = RunState.stop;
                TempMonitorThread.Abort();
            }
            logfile.CreateFile("");
            saveData = "T(K)";
            for (int i = 0; i < tag.Count; i++)
            {
                saveData += "," + tag[i];
            }
            logfile.WriteLogFile(saveData);
            changeWidget();
        }
        public delegate void RunCfEventHandler();
        public void RunCf()
        {
            string CommFreq, idnResponse, saveData;
            string strFreq;
            string[] FetchResult;
            //DataRow aRow = dtTCf.NewRow();
            int iCorrectionCoefficient = 0;
            while (true)
            {
                //if (fTargetTemp > fStopTemp)//Complete
                //{
                //    TempMonitorThread.Abort();
                //    MessageBox.Show("Loss:" + Convert.ToString(iLoss), "T-C-f Sweep Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    break;
                //}
                //labelNextSetpoint.Text = fTargetTemp.ToString();
                saveData = ",";
                System.Threading.Thread.Sleep(200);
                if (fTargetTemp >= fStopTemp)
                    break;
                //if (((fTargetTemp - fStepTemp * fError) <= fRealtimeTemp) && (fRealtimeTemp <= (fTargetTemp + fStepTemp * fError)))
                //{

                //lock (locker)
                //{
                formattedIOTEMPCON.WriteLine("input? a");
                idnResponse = formattedIOTEMPCON.ReadLine().Replace("\n", "");
                labelRealTimeTemperature.Text = idnResponse;
                fRealtimeTemp = Convert.ToSingle(idnResponse);
                listx.Add(fRealtimeTemp);
                for (int i = 0; i < iNumofLine; i++)
                {
                    strFreq = Math.Pow(10, fStartf + fStepf * i).ToString("f4");
                    CommFreq = "Freq" + " " + strFreq + "Hz";
                    formattedIOLRC.WriteLine(CommFreq);
                    System.Threading.Thread.Sleep(100);
                    FetchResult = sendCommand("Fetch?");
                    listy[i].Add(Convert.ToSingle(Convert.ToDouble(FetchResult[0])));
                    //aRow[i + 1] = (Convert.ToDouble(FetchResult[0]));
                    if (i==Math.Floor(iNumofLine/2.0))
                    {
                        formattedIOTEMPCON.WriteLine("input? a");
                        idnResponse = formattedIOTEMPCON.ReadLine().Replace("\n", "");
                        labelRealTimeTemperature.Text = idnResponse;
                        fRealtimeTemp = Convert.ToSingle(idnResponse);
                        listx[listx.Count-1]= fRealtimeTemp;
                        saveData = idnResponse + saveData;
                        //aRow[0] = fRealtimeTemp;
                    }
                    saveData += FetchResult[0] + ",";
                }
                //}
                //((DataTable)dgvTCf.DataSource).Rows.Add(aRow.ItemArray);
                fTargetTemp += fStepTemp;
                iCompletion++;
                labelCompletion.Text = Convert.ToString(iCompletion);
                saveData = saveData.Substring(0, saveData.Length - 1);
                logfile.WriteLogFile(saveData);
                    //progressBarProgress.Value += progressBarProgress.Step; //2018-2-2 8:12:08 Temporarily disable Progressbar (to be fixed)
                //}
                //else if (fRealtimeTemp < fTargetTemp)
                //{
                //    //
                //}
                //else if (fRealtimeTemp > fTargetTemp)
                //{
                //    //Realtime Temp is bigger than Target Temp：1.Correct Target Temp 2. Record Loss Point 3. Loss Index
                //    listLossT.Add(fTargetTemp);
                //    iCorrectionCoefficient = Convert.ToInt32((Math.Ceiling((fRealtimeTemp - fTargetTemp) / fStepTemp)));
                //    fTargetTemp = fTargetTemp + iCorrectionCoefficient * fStepTemp;
                //    iLoss += iCorrectionCoefficient;
                //    labelLoss.Text = Convert.ToString(iLoss);
                //}
            }
        }
        private delegate void labelchange(string str);
        private void lab(string str)
        {
            if(this.InvokeRequired)
            {
                labelchange ll = new labelchange(lab);
                this.Invoke(ll, new object[] { str });
            }
            else
            {
                this.labelUpTime.Text = str;
            }
        }
    
        private void threadtest()
        {
            while(true)
            {
                for(int k = 3; k <= 10000; k++)
                {
                    lock(locker)
                    {
                        System.Threading.Thread.Sleep(250);
                        signal = false;
                        listx.Add(k + 1);
                        listy[0].Add(Convert.ToSingle(rd.Next())*fError);
                        listy[1].Add(Convert.ToSingle(-rd.Next()));
                        listy[2].Add(Convert.ToSingle(-rd.Next() + 1));
                        listy[3].Add(Convert.ToSingle(-rd.Next() * 0.8));
                        listy[4].Add(Convert.ToSingle(-rd.Next() * 0.2 + 1));
                        listy[5].Add(Convert.ToSingle(-rd.Next() - 1));
                        listy[6].Add(Convert.ToSingle(-rd.Next() * 0.034 + 2));
                        signal = true;
                    }
                }
            }
        }

        private void Test1_Click(object sender, EventArgs e)
        {
            dtTCf = new DataTable();
            dgvTCf.DataSource = dtTCf;
            fStartf = Convert.ToSingle(txtStartFreq.Text);
            fStopf = Convert.ToSingle(txtStopFreq.Text);
            fStepf = Convert.ToSingle(txtStepFreq.Text);
            timerUpTime.Interval = 1000; //Initialize UpTime timer
            UpTime = new System.DateTime(0); //Initialize UpTime timer
            timerUpTime.Start(); //UpTime timer Start
            timerRefresh.Interval = 500; 
            timerRefresh.Start(); 
            progressBarProgress.Maximum = 10000;
            progressBarProgress.Value = 0;
            progressBarProgress.Step = 1;
            iNumofLine = 7;
            listy = new List<IList>();
            listx = new List<float>();
            List<float> y = new List<float>();
            List<float> y2 = new List<float>();
            tag = new List<string>();
            for (i = 0; i < iNumofLine; i++)
            {
                List<float> listchild = new List<float>();
                listy.Add(listchild);
                tag.Add("f=10^" + Convert.ToString(fStartf + fStepf * i) + " Hz");
                //dtTCf.Columns.Add("f=10^" + Convert.ToString(fStartf + fStepf * i) + " Hz", typeof(float));
            }
            plotThreadStart = new System.Threading.ThreadStart(ploter);
            plotThread = new System.Threading.Thread(plotThreadStart);
            plotThread.IsBackground = true;
            plotThread.Start();
            chartTCf.ChartAreas[0].AxisY.IsStartedFromZero = false;
            System.Threading.Thread threadtestthread = new System.Threading.Thread(new System.Threading.ThreadStart(threadtest));
            threadtestthread.IsBackground = true;
            threadtestthread.Start();
            //dtTCf.Rows.Add(1.0F, 2.0F, 2.0F, 2.0F, 2.0F, 2.0F, 2.0F);
            //for (int j=0;j<=10000;j++)
            //{
            // listx.Add(j);
            //  listy[0].Add(Convert.ToSingle(j));
            //  listy[1].Add(Convert.ToSingle(-j));
            // }
            //plot_X_multiY( tag, listx, listy);
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
            changeWidget();
            timerUpTime.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //DataGridViewToCSV(dgvTCf);
        }

        private void writer()
        {
            //while(true)
            //{
            //    System.Threading.Thread.Sleep(1000);
            //    dtTCf.Rows.Add(1.0F, 2.0F, 2.0F, 2.0F, 2.0F, 2.0F, 2.0F);        
            //}
        }

        private void test2_Click(object sender, EventArgs e)
        {
            System.Threading.ThreadStart writeThreadStart;
            System.Threading.Thread writeThread;
            writeThreadStart = new System.Threading.ThreadStart(writer);
            writeThread = new System.Threading.Thread(writeThreadStart);
            writeThread.IsBackground = true;
            writeThread.Start();
        }

        private void timerRefresh_Tick(object sender, EventArgs e)//Refresh progressbar and datagridview
        {
            //timerRefresh.Enabled = false;
            //progressBarProgress.Value += progressBarProgress.Step;
            //dgvTCf.Refresh();
        }
    }
}
