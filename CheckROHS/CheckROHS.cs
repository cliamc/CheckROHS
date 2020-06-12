using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBHelper.SQLTable;

namespace CheckROHS
{
    public partial class CheckRoHS : Form
    {
        public CheckRoHS()
        {
            InitializeComponent();
            this.Text = this.Text + " (Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + ")";

            string path = System.Environment.CurrentDirectory;
            System.Drawing.Image myImage = Image.FromFile(path + @"\rohs_icon.ico");
            imageList1.Images.Add("RoHS_Complied", myImage);
            myImage = Image.FromFile(path + @"\rohs_Not_icon.ico");
            imageList1.Images.Add("RoHS_NotComplied", myImage);
            treeView1.ImageList = imageList1;

            chkBtn.Enabled = false;
            resetBtn.Enabled = false;
        }

        private void jobText_KeyUp(object sender, KeyEventArgs e)
        {
            //if ( (e.KeyCode == Keys.Enter) || _TabKey )
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Tab))
            {
                string tlsn = jobText.Text.ToString();

                // handle input content
                if (tlsn.Length == 10)
                {
                    if (DBHelper.Util.ValidateSerialNum(tlsn))
                    {
                        jobText.Text = tlsn.Substring(0, 5);
                        tlsn = jobText.Text.ToString();
                    }
                }

                if (tlsn.Length != 5 || !tlsn.All(char.IsNumber))
                {
                    MessageBox.Show("Please input 5 digits");
                    jobText.Text = "";
                    return;
                }

                chkBtn.Enabled = true;
                chkBtn.Select();
                resetBtn.Enabled = true;
                jobText.Enabled = false;
                //partText.Enabled = false;
                //verUD.Enabled = false;
            }
        }

        //private void partText_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Tab))
        //    {
        //        chkBtn.Enabled = true;
        //        chkBtn.Select();
        //        resetBtn.Enabled = true;
        //        jobText.Enabled = false;
        //        partText.Enabled = false;
        //        verUD.Enabled = false;
        //    }
        //}

        private void chkBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Process input
                bool goodToGo = false;
                MfgDataJob checkJob = new MfgDataJob();

                if (jobText.Text.Length == 5)
                {                    
                    DataTable dt = checkJob.SelectTbl(jobText.Text.ToString());

                    if (dt.Rows.Count != 0)
                    {
                        DataRow dr = dt.Rows[0];
                        partText.Text = dr["PartNumber"].ToString();
                        //verUD.Value = Convert.ToDecimal(dr["PartVersion"].ToString());
                        verText.Text = dr["PartVersion"].ToString();
                        goodToGo = true;
                    }
                    else
                    {
                        MessageBox.Show("Cannot find the job " + jobText.Text + " in SQL Job table");
                    }
                }
                //else if (partText.Text.Length > 0)
                //{
                //    string tmp = checkJob.GetJobWithPart(partText.Text, verUD.Value.ToString());

                //    if (!string.IsNullOrEmpty(tmp))
                //    {
                //        jobText.Text = tmp;
                //        goodToGo = true;
                //    }
                //    else
                //    {
                //        MessageBox.Show("Cannot find the job with the Part Number and the Version provided in SQL Job table");
                //    }
                //}

                if (goodToGo)
                {
                    // application logic start here

                    ///PartBOM pb = new PartBOM(partText.Text, verUD.Value.ToString());
                    PartBOM pb = new PartBOM(partText.Text, verText.Text.ToString());
                    bool rohsYorn = pb.GetBomRohsFlag();

                    // Save the checking result to Job table
                    checkJob.UpdateROHS(jobText.Text, rohsYorn);

                    string msg = string.Format("This job BOM is ROHS complied - {0}", rohsYorn.ToString());
                    toolStripStatusLabel1.Text = msg;
                    //MessageBox.Show(msg);

                    DisplayBOMtree(pb, null);
                }

                chkBtn.Enabled = false;
            }
            catch (Exception ee)
            {
                string tmp = DBHelper.Util.RemoveSingleQuote(ee.ToString());
                //MfgDataTraceRecord.LogRecord(tmp);
                MessageBox.Show(ee.ToString());
            }
        }

        private void DisplayBOMtree(PartBOM pb, TreeNode parentNode = null)
        {
            TreeNode treeNodeRt = new TreeNode(pb.PartNum);
            //
            if (pb.bomRohs)
            {
                treeNodeRt.ImageIndex = 0;
                treeNodeRt.SelectedImageIndex = 0;
            }
            else
            {
                treeNodeRt.ImageIndex = 1;
                treeNodeRt.SelectedImageIndex = 1;
            }

            if (parentNode == null)
            {
                treeView1.Nodes.Add(treeNodeRt);
            }
            else
            {
                treeView1.SelectedNode = parentNode;
                treeView1.SelectedNode.Nodes.Add(treeNodeRt);
            }

            treeView1.SelectedNode = treeNodeRt;
            foreach (MtlRohs anItem in pb.endMtls)
            {
                TreeNode treeNode = new TreeNode(anItem.PartNum);
                if (anItem.Rohs)
                {
                    treeNode.ImageIndex = 0;
                    treeNode.SelectedImageIndex = 0;
                }
                else
                {
                    treeNode.ImageIndex = 1;
                    treeNode.SelectedImageIndex = 1;
                }
                treeView1.SelectedNode.Nodes.Add(treeNode);
            }

            // Display List<PartBOM> subs recursively
            foreach (PartBOM aBom in pb.subs)
            {
                DisplayBOMtree(aBom, treeNodeRt);
            }
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            jobText.Text = "";
            verText.Text = "";
            partText.Text = "";
            ///verUD.Value = .01M;

            chkBtn.Enabled = false;
            resetBtn.Enabled = false;
            toolStripStatusLabel1.Text = "Please input either a Job number or a Part Number and select a Version, then press Enter";

            treeView1.Nodes.Clear();
            jobText.Enabled = true;
            this.ActiveControl = jobText;
            //partText.Enabled = true;
            //verUD.Enabled = true;
        }


        private void jobText_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                e.IsInputKey = true;
        }

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    if (keyData == Keys.Tab)
        //    {
        //        _TabKey = true;
        //    }
        //    return base.ProcessCmdKey(ref msg, keyData);
        //}

        //protected override bool IsInputKey(Keys keyData)
        //{
        //    if (keyData == Keys.Tab)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return base.IsInputKey(keyData);
        //    }
        //}


    } // class
}
