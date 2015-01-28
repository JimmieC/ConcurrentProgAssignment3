namespace ConcurrentAsng3
{
    partial class FrmMain
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtReplacewith = new System.Windows.Forms.TextBox();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbSource = new System.Windows.Forms.TabPage();
            this.rchTextboxSource = new System.Windows.Forms.RichTextBox();
            this.tbDestination = new System.Windows.Forms.TabPage();
            this.rchTextBoxDestination = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblNumber = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tbSource.SuspendLayout();
            this.tbDestination.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtReplacewith);
            this.groupBox1.Controls.Add(this.txtFind);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 89);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Find and Replace";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Replace with";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Find";
            // 
            // txtReplacewith
            // 
            this.txtReplacewith.Location = new System.Drawing.Point(83, 55);
            this.txtReplacewith.Name = "txtReplacewith";
            this.txtReplacewith.Size = new System.Drawing.Size(155, 20);
            this.txtReplacewith.TabIndex = 1;
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(83, 27);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(155, 20);
            this.txtFind.TabIndex = 0;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(280, 45);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(153, 30);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Find words";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbSource);
            this.tabControl1.Controls.Add(this.tbDestination);
            this.tabControl1.Location = new System.Drawing.Point(12, 130);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(421, 350);
            this.tabControl1.TabIndex = 3;
            // 
            // tbSource
            // 
            this.tbSource.Controls.Add(this.rchTextboxSource);
            this.tbSource.Location = new System.Drawing.Point(4, 22);
            this.tbSource.Name = "tbSource";
            this.tbSource.Padding = new System.Windows.Forms.Padding(3);
            this.tbSource.Size = new System.Drawing.Size(413, 324);
            this.tbSource.TabIndex = 0;
            this.tbSource.Text = "Source";
            this.tbSource.UseVisualStyleBackColor = true;
            // 
            // rchTextboxSource
            // 
            this.rchTextboxSource.Location = new System.Drawing.Point(0, 0);
            this.rchTextboxSource.Name = "rchTextboxSource";
            this.rchTextboxSource.Size = new System.Drawing.Size(413, 324);
            this.rchTextboxSource.TabIndex = 0;
            this.rchTextboxSource.Text = "Load a file or just type in text here";
            // 
            // tbDestination
            // 
            this.tbDestination.Controls.Add(this.rchTextBoxDestination);
            this.tbDestination.Location = new System.Drawing.Point(4, 22);
            this.tbDestination.Name = "tbDestination";
            this.tbDestination.Padding = new System.Windows.Forms.Padding(3);
            this.tbDestination.Size = new System.Drawing.Size(413, 324);
            this.tbDestination.TabIndex = 1;
            this.tbDestination.Text = "Output";
            this.tbDestination.UseVisualStyleBackColor = true;
            // 
            // rchTextBoxDestination
            // 
            this.rchTextBoxDestination.Location = new System.Drawing.Point(0, 0);
            this.rchTextBoxDestination.Name = "rchTextBoxDestination";
            this.rchTextBoxDestination.ReadOnly = true;
            this.rchTextBoxDestination.Size = new System.Drawing.Size(413, 324);
            this.rchTextBoxDestination.TabIndex = 0;
            this.rchTextBoxDestination.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(280, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 30);
            this.button1.TabIndex = 4;
            this.button1.Text = "Clear All\r\n";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblNumber
            // 
            this.lblNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumber.Location = new System.Drawing.Point(141, 104);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(38, 23);
            this.lblNumber.TabIndex = 1;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(280, 9);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(153, 30);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "Load Text File";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(280, 81);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(153, 29);
            this.button2.TabIndex = 6;
            this.button2.Text = "Save to Text File";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 492);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmMain";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tbSource.ResumeLayout(false);
            this.tbDestination.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReplacewith;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbSource;
        private System.Windows.Forms.TabPage tbDestination;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox rchTextboxSource;
        private System.Windows.Forms.RichTextBox rchTextBoxDestination;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button button2;
    }
}

