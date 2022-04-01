using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace IDCAEmulatorDataAnalysis
{
    public partial class IDCAEmulatorDataAnalysis : Form
    {
        public IDCAEmulatorDataAnalysis()
        {
            InitializeComponent();
        }

        private void IDCAEmulatorDataAnalysis_Load(object sender, EventArgs e)
        {

        }

        private void btn_selectFile_Click(object sender, EventArgs e)
        {
            //pick the file
            OpenFileDialog tempCDT = new OpenFileDialog();
            DialogResult result = tempCDT.ShowDialog();
            string fileName = "";

            //read the file
            string[] dataLines = null;
            if (result == DialogResult.OK)
            {
                fileName = tempCDT.FileName;
                try
                {
                    dataLines = File.ReadAllLines(fileName);
                }

                catch (IOException)
                { }
            }

            //analyze the file
            //initialize a list of floats to capture power readings
            List<float> cdtTempLines = new List<float>();
            List<float> pwrAcc = new List<float>();
            float pwr = 0;
            int lineCtr = -1;
            bool foundThrottleback = false;

            //look at each file line
            foreach (string line in dataLines)
            {
                //skip the header
                if (!line.Contains("Vout") && line != "" && !foundThrottleback)
                {
                    //tease out the power reading and keep track of reading vs # of line read.
                    lineCtr += 1;
                    string[] power = line.Split(',');
                    pwr = float.Parse(power[2]);
                    cdtTempLines.Add(pwr);
                    pwrAcc.Add(pwr);

                    //start looking at power readings at the beginning of the list
                    if (lineCtr > 5)
                    {
                        float LastPwr = cdtTempLines[lineCtr];
                        float PrevPwr = cdtTempLines[lineCtr - 1];

                        //find the first instance of a trottleback
                        if ((LastPwr - PrevPwr) < -  2) //2 watt detection
                        //if ((LastPwr - PrevPwr) < - 3) //3 watt detection
                        {
                            //when trottleback detected, display time and power readings of the line.
                            string[] data_f = line.Split(",");
                            float temp = float.Parse(data_f[3]);
                            float time = float.Parse(data_f[4]);
                            float averagePwr = pwrAcc.Average();
                            float energy = time * averagePwr;
                            txt_ThrottlebackTemp.Text = temp.ToString();
                            txt_ThrottlebackTime.Text = time.ToString();
                            txt_accEnergy.Text = energy.ToString();
                            foundThrottleback = true;

                            //create results file if it does not exist
                            //after creation, write the header
                           string  resultsFile = @"C:\IDCAEmulator\results.csv";//specify the results fileName

                            if (!File.Exists(resultsFile))
                            {
                                using (StreamWriter dataRec = File.CreateText(resultsFile))
                                {
                                    dataRec.WriteLine("File Name, " + "Meas. ThrottleBack(K), " + "Elapsed Time");
                                    dataRec.Close();
                                }
                            }

                            using (StreamWriter dataRecR = File.AppendText(resultsFile))
                            {
                                string filePath = tempCDT.FileName;
                                string[] ccc = filePath.Split(@"\");
                                dataRecR.Write(ccc[6] + "," + temp.ToString() + "," + time.ToString() + Environment.NewLine);
                                dataRecR.Close();                            
                            }
                        }
                    }
                }
            }
        }
    }
}

