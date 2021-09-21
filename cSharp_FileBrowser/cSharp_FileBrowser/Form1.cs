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
using Microsoft.VisualBasic;

namespace cSharp_FileBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DirectoryInfo temp;
        private void GetDrives()
        {
            //cmbDrives.DataSource =  Environment.GetLogicalDrives();
            var drives = DriveInfo.GetDrives();
            foreach (var item in drives)
            {
                cmbDrives.Items.Add(item);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbDrives.DropDownStyle = ComboBoxStyle.DropDownList;
            GetDrives();
        }

        private void cmbDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDrives.Text == "")
            {
                lblPath.Text = "N/A";
                lblDriveInfo.Text = "N/A";
                btnBack.Enabled = false;
                btnNewFolder.Enabled = false;                       
                btnRename.Enabled = false;
                cmbSort.Enabled = false;
                return;
            }
            lblPath.Text = cmbDrives.Text;
            btnBack.Enabled = true;
            btnNewFolder.Enabled = true;
            btnRename.Enabled = true;
            cmbSort.Enabled = true;
            //get drive info

            DriveInfo drive = new DriveInfo(cmbDrives.Text);
            //check if drive ready
            if (!drive.IsReady)
            {
                MessageBox.Show("Device is not ready");
                lblDriveInfo.Text = "N/A";
                return;
            }
            lblDriveInfo.Text = string.Format("Total Size: {0}GB  Free Space: {1}GB", drive.TotalSize/1024.0f/1024/1024, drive.TotalFreeSpace / 1024.0f / 1024 / 1024);

            ListFolder(drive.Name);
        }

        private void ListFolder(string path)
        {
            lstBrowser.Items.Clear();
            DirectoryInfo folder = new DirectoryInfo(path);
            
            var obje = new BrowserItem();
            obje.Name = "[...]";
            obje.FullName = lblPath.Text;
            obje.DateModified = DateAndTime.Now;
            obje.Type = FileAttributes.Directory;
            lstBrowser.Items.Add(obje);
            foreach (var item in folder.GetFileSystemInfos())
            { 
                if (item.Attributes.HasFlag(FileAttributes.Hidden))                 
                {
                    continue;
                }
                //create object
                var obj = new BrowserItem()
                {
                    Name = item.Name,
                    FullName = item.FullName,
                    DateModified = item.LastWriteTime,
                    Type = item.Attributes
                };

                lstBrowser.Items.Add(obj);
            }
            lblPath.Text = folder.FullName;
        }

        private void lstBrowser_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1) return; // if nothing to draw
            BrowserItem item; // get curr item properties
            Brush myBrush;
            if ((e.State & DrawItemState.Selected) != 0 )
            {
                myBrush = SystemBrushes.HighlightText;
            }
            else
            {
                myBrush = SystemBrushes.WindowText;
            }
            e.DrawBackground();

            // get curr item
            item = lstBrowser.Items[e.Index] as BrowserItem;
            e.Graphics.DrawString(item.Name, e.Font, myBrush, new Rectangle(lblName.Left, e.Bounds.Top, lblDate.Left - lblName.Left, e.Bounds.Height));
            e.Graphics.DrawString(item.DateModified.ToString(), e.Font, myBrush, new Rectangle(lblDate.Left, e.Bounds.Top, lblType.Left - lblDate.Left, e.Bounds.Height));
            e.Graphics.DrawString(item.Type.ToString(), e.Font, myBrush, new Rectangle(lblType.Left, e.Bounds.Top, lstBrowser.Right - lblType.Left, e.Bounds.Height));
            
        }

        private void lstBrowser_DoubleClick(object sender, EventArgs e)
        {

            //if nothing selected
            if (lstBrowser.SelectedIndex == -1) return;

           
            lblDriveInfo.Text = string.Empty;
            //get selected item
            
            BrowserItem item = lstBrowser.SelectedItem as BrowserItem;
            if (lstBrowser.SelectedIndex == 0)
            {
                temp = new DirectoryInfo(lblPath.Text);
                if (temp.FullName != cmbDrives.Text)
                {
                    ListFolder(temp.Parent.FullName);
                }
                else
                {
                    return;
                }
            }
            // check id select item is directory
            if (item.Type.HasFlag(FileAttributes.Directory))
            {
                cmbSort.Text = "";
                lblSortedBy.Text = "Not Sorted";
                // add selected to path
                ListFolder(item.FullName);
            }
            else // if file or archive
            {
                System.Diagnostics.Process.Start(item.FullName);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            temp = new DirectoryInfo(lblPath.Text);// get curr place
            if (temp.FullName != cmbDrives.Text)
            {
                ListFolder(temp.Parent.FullName);
            }


        }

        private void btnNewFolder_Click(object sender, EventArgs e)
        {
            string folderName = Interaction.InputBox("Enter Folder Name", "Create Folder", "New Folder");
            if (!string.IsNullOrWhiteSpace(folderName))
            {
                if (!Directory.Exists(lblPath.Text + @"\" + folderName))
                {
                    Directory.CreateDirectory(lblPath.Text + @"\" + folderName);
                    ListFolder(lblPath.Text);
                    return;
                }
                //if new folder exists the count how many add to folderName end
                temp = new DirectoryInfo(lblPath.Text);
                int count = temp.GetDirectories("New Folder*", SearchOption.TopDirectoryOnly).Length;
                Directory.CreateDirectory(lblPath.Text + @"\New Folder" + count);
                ListFolder(lblPath.Text);

            }

        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            string oldname = (lstBrowser.SelectedItem as BrowserItem).FullName;
            
            string folderName = Interaction.InputBox("Enter Folder Name", "Rename Folder", "New Folder");
            Directory.Move(oldname, lblPath.Text + @"\" + folderName);
            ListFolder(lblPath.Text);
        }

        private void lstBrowser_Resize(object sender, EventArgs e)
        {
            //ListFolder(lblPath.Text);
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSort.Text == "")
            {
                lblSortedBy.Text = "Not Sorted";
                return;
            }
            lblSortedBy.Text = cmbSort.Text;
            List<BrowserItem> item = new List<BrowserItem>();

            for (int i = 1; i < lstBrowser.Items.Count; i++)
            {
                item.Add(lstBrowser.Items[i] as BrowserItem);

                //item[i].Name = (lstBrowser.Items[i] as BrowserItem).Name;
                
            }
            List<BrowserItem> SortedItem = new List<BrowserItem>();
            if (cmbSort.Text == "Name")
            {
                SortedItem = item.OrderBy(o => o.Name).ToList();
            }
            else if (cmbSort.Text == "Date Modified")
            {
                SortedItem = item.OrderBy(o => o.DateModified).ToList();
            }
            else if (cmbSort.Text == "Type")
            {
                SortedItem = item.OrderBy(o => o.Type).ToList();
            }
            lstBrowser.Items.Clear();

            foreach (var obj in SortedItem)
            {
                lstBrowser.Items.Add(obj);
            }


        }

        
    }
}
