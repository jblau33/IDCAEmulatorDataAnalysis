
namespace IDCAEmulatorDataAnalysis
{
    partial class IDCAEmulatorDataAnalysis
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_selectFile = new System.Windows.Forms.Button();
            this.openFileIDCAData = new System.Windows.Forms.OpenFileDialog();
            this.lbl_throttleBackTemp = new System.Windows.Forms.Label();
            this.lbl_ThrottleBackTime = new System.Windows.Forms.Label();
            this.txt_ThrottlebackTemp = new System.Windows.Forms.TextBox();
            this.txt_ThrottlebackTime = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_selectFile
            // 
            this.btn_selectFile.Location = new System.Drawing.Point(14, 17);
            this.btn_selectFile.Name = "btn_selectFile";
            this.btn_selectFile.Size = new System.Drawing.Size(104, 26);
            this.btn_selectFile.TabIndex = 0;
            this.btn_selectFile.Text = "Select File";
            this.btn_selectFile.UseVisualStyleBackColor = true;
            this.btn_selectFile.Click += new System.EventHandler(this.btn_selectFile_Click);
            // 
            // openFileIDCAData
            // 
            this.openFileIDCAData.FileName = "openFileIDCAData";
            // 
            // lbl_throttleBackTemp
            // 
            this.lbl_throttleBackTemp.AutoSize = true;
            this.lbl_throttleBackTemp.Location = new System.Drawing.Point(14, 61);
            this.lbl_throttleBackTemp.Name = "lbl_throttleBackTemp";
            this.lbl_throttleBackTemp.Size = new System.Drawing.Size(105, 15);
            this.lbl_throttleBackTemp.TabIndex = 1;
            this.lbl_throttleBackTemp.Text = "Throttleback Temp";
            // 
            // lbl_ThrottleBackTime
            // 
            this.lbl_ThrottleBackTime.AutoSize = true;
            this.lbl_ThrottleBackTime.Location = new System.Drawing.Point(14, 95);
            this.lbl_ThrottleBackTime.Name = "lbl_ThrottleBackTime";
            this.lbl_ThrottleBackTime.Size = new System.Drawing.Size(99, 15);
            this.lbl_ThrottleBackTime.TabIndex = 2;
            this.lbl_ThrottleBackTime.Text = "ThrottlebackTime";
            // 
            // txt_ThrottlebackTemp
            // 
            this.txt_ThrottlebackTemp.Location = new System.Drawing.Point(140, 57);
            this.txt_ThrottlebackTemp.Name = "txt_ThrottlebackTemp";
            this.txt_ThrottlebackTemp.Size = new System.Drawing.Size(92, 23);
            this.txt_ThrottlebackTemp.TabIndex = 3;
            // 
            // txt_ThrottlebackTime
            // 
            this.txt_ThrottlebackTime.Location = new System.Drawing.Point(140, 92);
            this.txt_ThrottlebackTime.Name = "txt_ThrottlebackTime";
            this.txt_ThrottlebackTime.Size = new System.Drawing.Size(92, 23);
            this.txt_ThrottlebackTime.TabIndex = 4;
            // 
            // IDCAEmulatorDataAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 270);
            this.Controls.Add(this.txt_ThrottlebackTime);
            this.Controls.Add(this.txt_ThrottlebackTemp);
            this.Controls.Add(this.lbl_ThrottleBackTime);
            this.Controls.Add(this.lbl_throttleBackTemp);
            this.Controls.Add(this.btn_selectFile);
            this.Name = "IDCAEmulatorDataAnalysis";
            this.Text = "IDCAEmulatorDataAnalysis_Rev_0_1";
            this.Load += new System.EventHandler(this.IDCAEmulatorDataAnalysis_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_selectFile;
        private System.Windows.Forms.OpenFileDialog openFileIDCAData;
        private System.Windows.Forms.Label lbl_throttleBackTemp;
        private System.Windows.Forms.Label lbl_ThrottleBackTime;
        private System.Windows.Forms.TextBox txt_ThrottlebackTemp;
        private System.Windows.Forms.TextBox txt_ThrottlebackTime;
    }
}

