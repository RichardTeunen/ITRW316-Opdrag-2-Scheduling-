using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Threading
{
    public partial class Form1 : Form
    {
        List<ProgressBar> progressbarList = new List<ProgressBar>();

        List<NumericUpDown> numericUpDownList = new List<NumericUpDown>();
        List<int> startList = new List<int>();

        List<Label> labelList = new List<Label>();
        List<Label> startTimeLabelList = new List<Label>();

        List<List<int>> priorityClasses = new List<List<int>>();
        List<bool> classdone = new List<bool>();

        List<Queue<int>> multipleQueues;

        List<int> starttimes = new List<int>();

        int threadCount = 0,
            quantumsize = 4,
            newProcessCount = 0,
            itemsMovedToCurrentQueue = 0,
            previousProcessIndex = -1;

        int timervalue = 0;
        bool timerrunning = false;

        Thread thr;
        Thread timerthread;

        public Form1()
        {
            InitializeComponent();
        }

        //First Come First Served
        private void btnStart_Click(object sender, EventArgs e)
        {
            Roundrobin();
        }

        public void Roundrobin()
        {
            NudsEnabled(false);

            while (ThreadsRunning())
            {
                for (int i = 0; i < threadCount; i++)
                {
                    if (progressbarList[i].Value < progressbarList[i].Maximum && startList[i] <= timervalue)
                    {
                        HighlightCurrentProcess(i);

                        for (int x = 0; x < quantumsize; x++)
                        {
                            progressbarList[i].PerformStep();
                            Thread.Sleep(50);
                        }
                    }
                }
            }

            NudsEnabled(true);
            timerrunning = false;
        }

        public bool ThreadsRunning()
        {
            bool threadsleft = false;

            for (int i = 0; i < threadCount; i++)
            {
                if (progressbarList[i].Value < progressbarList[i].Maximum)
                {
                    threadsleft = true;
                    break;
                }
            }

            return threadsleft;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbxAlgorithm.SelectedIndex = 0;
            thr = new Thread(Roundrobin);
            timerthread = new Thread(timer);

            ProgressBar.CheckForIllegalCrossThreadCalls = false;
            NumericUpDown.CheckForIllegalCrossThreadCalls = false;
        }

        private void btnPriority_Click(object sender, EventArgs e)
        {
            Priority();
        }

        public void Priority()
        {
            NudsEnabled(false);
            priorityClasses = new List<List<int>>();
            priorityClasses.Clear();

            for (int i = 0; i < 4; i++)
                priorityClasses.Add(new List<int>());

            for (int i = 0; i < threadCount; i++)
            {
                priorityClasses[((int)numericUpDownList[i].Value) - 1].Add(i);
                classdone.Add(false);
            }

            while (!CheckClasses())
            {
                int runningpriority = identifyHighestPriorityclass();
                int temptimer = timervalue;

                while (timervalue == temptimer && timerrunning==true)
                {
                    for (int i = 0; i < priorityClasses[runningpriority].Count; i++)
                    {
                        if (!ClassDone(runningpriority, i) && (starttimes[priorityClasses[runningpriority][i]] <= timervalue))
                        {
                            HighlightCurrentProcess(priorityClasses[runningpriority][i]);

                            for (int x = 0; x < quantumsize; x++)
                            {
                                progressbarList[priorityClasses[runningpriority][i]].PerformStep();
                                Thread.Sleep(100);
                            }
                                
                        }
                    }
                }
            }
            NudsEnabled(true);
            timerrunning = false;
        }

        public bool ClassDone(int classnr)
        {
            bool done = true;

            for (int x = 0; x < priorityClasses[classnr].Count; x++)
            {
                if (progressbarList[priorityClasses[classnr][x]].Value < progressbarList[priorityClasses[classnr][x]].Maximum)
                {
                    done = false;
                    break;
                }
            }
            return done;
        }

        public bool ClassDone(int priorityClass, int processNum)
        {
            bool done = true;
            
            if (progressbarList[priorityClasses[priorityClass][processNum]].Value < progressbarList[priorityClasses[priorityClass][processNum]].Maximum)
                done = false;
            
            return done;
        }

        public bool CheckClasses()
        {
            for (int i = 0; i < priorityClasses.Count; i++)
            {
                for (int x = 0; x < priorityClasses[i].Count; x++)
                {
                    if (progressbarList[priorityClasses[i][x]].Value < progressbarList[priorityClasses[i][x]].Maximum)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void ExecuteNewProcessesMQ(int npc, int currentQueue)
        {
            int newProcessQueueIndex = -1;

            while (newProcessCount > 0)
            {
                newProcessQueueIndex = (int) numericUpDownList[progressbarList.Count - newProcessCount].Value;
                int quantumLength = Convert.ToInt32(Math.Pow(2, Convert.ToDouble(multipleQueues.Count - newProcessQueueIndex)));
                HighlightCurrentProcess(progressbarList.Count - newProcessCount);

                for (int z = 0; z < quantumLength; z++)
                {
                     if (progressbarList[progressbarList.Count - newProcessCount].Value < progressbarList[progressbarList.Count - newProcessCount].Maximum && startList[progressbarList.Count - newProcessCount] <= timervalue)
                     {
                         progressbarList[progressbarList.Count - newProcessCount].PerformStep();
                         Thread.Sleep(100);
                     }
                }

                if (newProcessQueueIndex > 1)
                {
                    multipleQueues[newProcessQueueIndex - 1].Enqueue(progressbarList.Count - newProcessCount);
                    numericUpDownList[progressbarList.Count - newProcessCount].Value = newProcessQueueIndex - 1;
                }
                else
                {
                    multipleQueues[newProcessQueueIndex].Enqueue(progressbarList.Count - newProcessCount);
                    numericUpDownList[progressbarList.Count - newProcessCount].Value = 1;
                }

                newProcessCount--;
            }
        }

        public void HighlightCurrentProcess(int index)
        {
            labelList[index].ForeColor = Color.Green;

            if (previousProcessIndex != -1)
                labelList[previousProcessIndex].ForeColor = Color.Black;

            previousProcessIndex = index;
        }

        public void MultipleQueues()
        {
            NudsEnabled(false);

            multipleQueues = new List<Queue<int>>();

            //Create priority class queues
            for (int x = 0; x < 4; x++)
                multipleQueues.Add(new Queue<int>());

            //Add processes to their respective priority class queues
            for (int x = 0; x < progressbarList.Count; x++)
                multipleQueues[(int)numericUpDownList[x].Value - 1].Enqueue(x);

            itemsMovedToCurrentQueue = 0;   

            newProcessCount = 0;

            //If there are still threads left
            while (ThreadsRunning())
            {
                //Go through each priority class queue
                for (int x = multipleQueues.Count - 1; x >= 0; x--)
                {
                    //Calculate the quantum length of each queue's processes
                    int quantumLength = Convert.ToInt32(Math.Pow(2, Convert.ToDouble(multipleQueues.Count - x)));

                    //Go through each individual process in each queue
                    int countBeforeChanges = multipleQueues[x].Count - itemsMovedToCurrentQueue;
                    itemsMovedToCurrentQueue = 0;

                    for (int y = 0; y < countBeforeChanges; y++)
                    {
                        //Get the process' ID
                        int progressbarIndex = multipleQueues[x].Dequeue();

                        //Execute for the length of their quantum
                        for (int z = 0; z < quantumLength; z++)
                        {
                            ExecuteNewProcessesMQ(newProcessCount, x); //Execute new processes with higher priority

                            if (progressbarList[progressbarIndex].Value < progressbarList[progressbarIndex].Maximum && startList[progressbarIndex] <= timervalue)
                            {
                                progressbarList[progressbarIndex].PerformStep();
                                HighlightCurrentProcess(progressbarIndex);
                                Thread.Sleep(100);
                            }
                        }

                        //Change their priority level
                        if (x > 1)
                        {
                            itemsMovedToCurrentQueue++;
                            multipleQueues[x - 1].Enqueue(progressbarIndex);
                            numericUpDownList[progressbarIndex].Value = x;
                        } 
                        else
                        {
                            multipleQueues[x].Enqueue(progressbarIndex);
                            numericUpDownList[progressbarIndex].Value = 1;
                        }
                            
                    }
                }
            }

            NudsEnabled(true);
            timerrunning = false;
        }

        private void btnStart_Click_1(object sender, EventArgs e)
        {
            btnStopped.Text = "Stop";
            
            if (thr.ThreadState == ThreadState.WaitSleepJoin || thr.ThreadState == ThreadState.Running)
                thr.Abort();

            if (timerthread.ThreadState == ThreadState.WaitSleepJoin || timerthread.ThreadState == ThreadState.Running)
                timerthread.Abort();

            if (cbxAlgorithm.SelectedIndex == 0)
                thr = new Thread(Roundrobin); 
            else if (cbxAlgorithm.SelectedIndex == 1)
                thr = new Thread(Priority);
            else
                thr = new Thread(MultipleQueues);

            timerthread = new Thread(timer);
            timerthread.Start();
            thr.Start();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            progressbarList.Add(new ProgressBar());
            int i = progressbarList.Count - 1;
            threadCount++;

            progressbarList[i].Minimum = 0;
            progressbarList[i].Maximum = (int) nudDuration.Value;
            progressbarList[i].Step = 1;
            progressbarList[i].Value = 0;
            progressbarList[i].Size = new Size(174, 20);
            progressbarList[i].Location = new Point(26, 10 + i * 26);

            pnlObjects.Controls.Add(progressbarList[i]);

            //
            numericUpDownList.Add(new NumericUpDown());

            numericUpDownList[i].Minimum = 1;
            numericUpDownList[i].Maximum = 4;
            numericUpDownList[i].Value = (int) nudPriorityLevel.Value;
            numericUpDownList[i].Size = new Size(37, 20);
            numericUpDownList[i].Location = new Point(206, 10 + i * 26);

            pnlObjects.Controls.Add(numericUpDownList[i]);

            //
            labelList.Add(new Label());

            labelList[i].Text = threadCount.ToString();
            labelList[i].Location = new Point(7, 12 + i * 26);

            pnlObjects.Controls.Add(labelList[i]);

            //
            startList.Add(Convert.ToInt32(NUDStarttime.Value));

            //
            startTimeLabelList.Add(new Label());
            startTimeLabelList[i].Location = new Point(283, 12 + i * 26);
            startTimeLabelList[i].Text = startList[i].ToString();

            pnlObjects.Controls.Add(startTimeLabelList[i]);

            starttimes.Add((int)NUDStarttime.Value);
            NUDStarttime.Value = 0;

            newProcessCount++;
        }

        private void btnStopped_Click(object sender, EventArgs e)
        {
            try
            {
                if (thr.ThreadState == ThreadState.WaitSleepJoin ||thr.ThreadState == ThreadState.Running)
                {
                    thr.Suspend();
                    btnStopped.Text = "Continue";
                    timerthread.Suspend();
                }
                else
                {
                    thr.Resume();
                    btnStopped.Text = "Stop";
                    timerthread.Resume();
                }   
            }
            catch { }   
        }

        public bool mayrun(int processnum)
        {
            if (starttimes[processnum] < timervalue)
                return false;
            else
                return true;
        }

        public int identifyHighestPriorityclass()
        {
            for (int i = priorityClasses.Count - 1; i >= 0; i--)
            {
                for (int x = 0; x < priorityClasses[i].Count; x++)
                {
                    if (starttimes[priorityClasses[i][x]] <= timervalue && !ClassDone(i, x))
                        return i;
                }
            }

            return 0;
        }

        public void NudsEnabled(bool enabled)
        {
            if (enabled)
            {
                foreach (NumericUpDown nud in numericUpDownList)
                    nud.Enabled = true;
            }
            else
            {
                foreach (NumericUpDown nud in numericUpDownList)
                    nud.Enabled = false;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnStopped.Text = "Stop";
            lblTimer.Text = "Time running: 0 sec";
            
            //Delete progressbars
            if (thr.ThreadState == ThreadState.Suspended)
            {
                thr.Resume();
                thr.Abort();

                timerthread.Resume();
                timerthread.Abort();
            }
            else
            {
                thr.Abort();
                timerthread.Abort();
            }

            foreach (ProgressBar pb in progressbarList)
               pnlObjects.Controls.Remove(pb);

            //Delete numericUpDowns (spinners)
            foreach (NumericUpDown nud in numericUpDownList)
                pnlObjects.Controls.Remove(nud);

            foreach (Label lbl in labelList)
                pnlObjects.Controls.Remove(lbl);

            foreach (Label lbl in startTimeLabelList)
                pnlObjects.Controls.Remove(lbl);

            numericUpDownList = new List<NumericUpDown>();
            progressbarList = new List<ProgressBar>();
            startList.Clear();
            labelList.Clear();

            threadCount = 0;
            timervalue = 0;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        { 
            Environment.Exit(Environment.ExitCode);
        }

        private void btnResetProgress_Click(object sender, EventArgs e)
        {
            foreach (ProgressBar pb in progressbarList)
                pb.Value = 0;

            timervalue = 0;
            timerrunning = false;
            lblTimer.Text = "Time running: 0 sec";
            labelList[previousProcessIndex].ForeColor = Color.Black;
        }


        public void timer()
        {
            timerrunning = true;

            while (timerrunning)
            {
                lblTimer.Text = "Time running: " + (timervalue++ + 1) +" sec";
                Thread.Sleep(1000);
            }
        }
    }
}
