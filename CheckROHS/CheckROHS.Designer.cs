using System.Windows.Forms;

namespace CheckROHS
{
    partial class CheckRoHS
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckRoHS));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.verText = new System.Windows.Forms.TextBox();
            this.resetBtn = new System.Windows.Forms.Button();
            this.chkBtn = new System.Windows.Forms.Button();
            this.verLabel = new System.Windows.Forms.Label();
            this.partText = new System.Windows.Forms.TextBox();
            this.pnLabel = new System.Windows.Forms.Label();
            this.orLabel = new System.Windows.Forms.Label();
            this.jobText = new System.Windows.Forms.TextBox();
            this.jobLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.verText);
            this.groupBox1.Controls.Add(this.resetBtn);
            this.groupBox1.Controls.Add(this.chkBtn);
            this.groupBox1.Controls.Add(this.verLabel);
            this.groupBox1.Controls.Add(this.partText);
            this.groupBox1.Controls.Add(this.pnLabel);
            this.groupBox1.Controls.Add(this.orLabel);
            this.groupBox1.Controls.Add(this.jobText);
            this.groupBox1.Controls.Add(this.jobLabel);
            this.groupBox1.Location = new System.Drawing.Point(34, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(504, 167);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input and Check";
            // 
            // verText
            // 
            this.verText.BackColor = System.Drawing.Color.White;
            this.verText.Location = new System.Drawing.Point(130, 122);
            this.verText.Name = "verText";
            this.verText.ReadOnly = true;
            this.verText.Size = new System.Drawing.Size(100, 20);
            this.verText.TabIndex = 10;
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(378, 120);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(75, 23);
            this.resetBtn.TabIndex = 8;
            this.resetBtn.Text = "Reset";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // chkBtn
            // 
            this.chkBtn.Location = new System.Drawing.Point(378, 63);
            this.chkBtn.Name = "chkBtn";
            this.chkBtn.Size = new System.Drawing.Size(75, 23);
            this.chkBtn.TabIndex = 7;
            this.chkBtn.Text = "Check";
            this.chkBtn.UseVisualStyleBackColor = true;
            this.chkBtn.Click += new System.EventHandler(this.chkBtn_Click);
            // 
            // verLabel
            // 
            this.verLabel.AutoSize = true;
            this.verLabel.Location = new System.Drawing.Point(25, 130);
            this.verLabel.Name = "verLabel";
            this.verLabel.Size = new System.Drawing.Size(42, 13);
            this.verLabel.TabIndex = 5;
            this.verLabel.Text = "Version";
            // 
            // partText
            // 
            this.partText.BackColor = System.Drawing.Color.White;
            this.partText.Location = new System.Drawing.Point(130, 89);
            this.partText.Name = "partText";
            this.partText.ReadOnly = true;
            this.partText.Size = new System.Drawing.Size(197, 20);
            this.partText.TabIndex = 4;
            // 
            // pnLabel
            // 
            this.pnLabel.AutoSize = true;
            this.pnLabel.Location = new System.Drawing.Point(25, 96);
            this.pnLabel.Name = "pnLabel";
            this.pnLabel.Size = new System.Drawing.Size(66, 13);
            this.pnLabel.TabIndex = 3;
            this.pnLabel.Text = "Part Number";
            // 
            // orLabel
            // 
            this.orLabel.AutoSize = true;
            this.orLabel.Location = new System.Drawing.Point(53, 63);
            this.orLabel.Name = "orLabel";
            this.orLabel.Size = new System.Drawing.Size(148, 13);
            this.orLabel.TabIndex = 2;
            this.orLabel.Text = "-----------------------------------------------";
            // 
            // jobText
            // 
            this.jobText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.jobText.Location = new System.Drawing.Point(130, 27);
            this.jobText.Name = "jobText";
            this.jobText.Size = new System.Drawing.Size(100, 20);
            this.jobText.TabIndex = 1;
            this.jobText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.jobText_KeyUp);
            this.jobText.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.jobText_PreviewKeyDown);
            // 
            // jobLabel
            // 
            this.jobLabel.AutoSize = true;
            this.jobLabel.Location = new System.Drawing.Point(25, 30);
            this.jobLabel.Name = "jobLabel";
            this.jobLabel.Size = new System.Drawing.Size(88, 13);
            this.jobLabel.TabIndex = 0;
            this.jobLabel.Text = "Job (Work Order)";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 827);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(572, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "Running Status";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(525, 17);
            this.toolStripStatusLabel1.Text = "Welcome, please input either a Job number or a Part Number and select a Version, " +
    "then press Enter";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(34, 206);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(504, 602);
            this.treeView1.TabIndex = 2;
            // 
            // CheckRoHS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 849);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CheckRoHS";
            this.Text = "Check RoHS";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox jobText;
        private System.Windows.Forms.Label jobLabel;
        private System.Windows.Forms.TextBox partText;
        private System.Windows.Forms.Label pnLabel;
        private System.Windows.Forms.Label orLabel;
        private System.Windows.Forms.Button chkBtn;
        private System.Windows.Forms.Label verLabel;
        private System.Windows.Forms.Button resetBtn;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ImageList imageList1;
        private TreeView treeView1;
        private TextBox verText;
    }
}

