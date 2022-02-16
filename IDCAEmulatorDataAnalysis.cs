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

            //read the file
            string[] dataLines = null;
            if (result == DialogResult.OK)
            {
                string fileName = tempCDT.FileName;
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

                    //start looking at power readings at the beginning of the list
                    if (lineCtr > 5)
                    {
                        float LastPwr = cdtTempLines[lineCtr];
                        float PrevPwr = cdtTempLines[lineCtr - 1];

                        //find the first instance of a trottleback
                        if ((LastPwr - PrevPwr) < -2)
                        {
                            //when trottleback detected, display time and power readings of the line.
                            string[]data_f = line.Split(",");
                            float temp = float.Parse(data_f[3]);
                            float time = float.Parse(data_f[4]);
                            txt_ThrottlebackTemp.Text = temp.ToString();
                            txt_ThrottlebackTime.Text = time.ToString();
                            foundThrottleback = true;
                        }
                    }
                }

            }


        }
    }
}
