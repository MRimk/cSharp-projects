namespace cSharp_FileBrowser
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblPath = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDriveInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSorted = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSortedBy = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmbDrives = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lstBrowser = new System.Windows.Forms.ListBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNewFolder = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblPath,
            this.lblDriveInfo,
            this.lblSorted,
            this.lblSortedBy});
            this.statusStrip1.Location = new System.Drawing.Point(0, 538);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(974, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblPath
            // 
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(29, 17);
            this.lblPath.Text = "N/A";
            // 
            // lblDriveInfo
            // 
            this.lblDriveInfo.Name = "lblDriveInfo";
            this.lblDriveInfo.Size = new System.Drawing.Size(29, 17);
            this.lblDriveInfo.Text = "N/A";
            // 
            // lblSorted
            // 
            this.lblSorted.Name = "lblSorted";
            this.lblSorted.Size = new System.Drawing.Size(60, 17);
            this.lblSorted.Text = "Sorted By:";
            // 
            // lblSortedBy
            // 
            this.lblSortedBy.Name = "lblSortedBy";
            this.lblSortedBy.Size = new System.Drawing.Size(64, 17);
            this.lblSortedBy.Text = "Not Sorted";
            // 
            // cmbDrives
            // 
            this.cmbDrives.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDrives.FormattingEnabled = true;
            this.cmbDrives.Location = new System.Drawing.Point(124, 16);
            this.cmbDrives.Name = "cmbDrives";
            this.cmbDrives.Size = new System.Drawing.Size(121, 21);
            this.cmbDrives.TabIndex = 1;
            this.cmbDrives.SelectedIndexChanged += new System.EventHandler(this.cmbDrives_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select drive";
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 67);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Name";
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(543, 67);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(72, 13);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Date modified";
            // 
            // lblType
            // 
            this.lblType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(787, 67);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(31, 13);
            this.lblType.TabIndex = 5;
            this.lblType.Text = "Type";
            // 
            // lstBrowser
            // 
            this.lstBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstBrowser.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstBrowser.FormattingEnabled = true;
            this.lstBrowser.Location = new System.Drawing.Point(12, 83);
            this.lstBrowser.Name = "lstBrowser";
            this.lstBrowser.Size = new System.Drawing.Size(947, 446);
            this.lstBrowser.TabIndex = 6;
            this.lstBrowser.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstBrowser_DrawItem);
            this.lstBrowser.DoubleClick += new System.EventHandler(this.lstBrowser_DoubleClick);
            this.lstBrowser.Resize += new System.EventHandler(this.lstBrowser_Resize);
            // 
            // btnBack
            // 
            this.btnBack.Enabled = false;
            this.btnBack.Location = new System.Drawing.Point(280, 14);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNewFolder
            // 
            this.btnNewFolder.Enabled = false;
            this.btnNewFolder.Location = new System.Drawing.Point(374, 14);
            this.btnNewFolder.Name = "btnNewFolder";
            this.btnNewFolder.Size = new System.Drawing.Size(75, 23);
            this.btnNewFolder.TabIndex = 8;
            this.btnNewFolder.Text = "New Folder";
            this.btnNewFolder.UseVisualStyleBackColor = true;
            this.btnNewFolder.Click += new System.EventHandler(this.btnNewFolder_Click);
            // 
            // btnRename
            // 
            this.btnRename.Enabled = false;
            this.btnRename.Location = new System.Drawing.Point(479, 14);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(99, 23);
            this.btnRename.TabIndex = 9;
            this.btnRename.Text = "Rename Folder";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // cmbSort
            // 
            this.cmbSort.AutoCompleteCustomSource.AddRange(new string[] {
            "Name",
            "DateModified",
            "Type"});
            this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort.Enabled = false;
            this.cmbSort.FormattingEnabled = true;
            this.cmbSort.Items.AddRange(new object[] {
            "Name",
            "Date Modified",
            "Type"});
            this.cmbSort.Location = new System.Drawing.Point(124, 59);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(121, 21);
            this.cmbSort.TabIndex = 10;
            this.cmbSort.SelectedIndexChanged += new System.EventHandler(this.cmbSort_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Sort by: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 560);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbSort);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.btnNewFolder);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lstBrowser);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDrives);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Xtreme File Browser";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblPath;
        private System.Windows.Forms.ComboBox cmbDrives;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ListBox lstBrowser;
        private System.Windows.Forms.ToolStripStatusLabel lblDriveInfo;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNewFolder;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.ComboBox cmbSort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripStatusLabel lblSorted;
        private System.Windows.Forms.ToolStripStatusLabel lblSortedBy;
    }
}

