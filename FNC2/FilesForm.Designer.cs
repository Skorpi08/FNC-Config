namespace FNC2
{
    partial class FilesForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.TotalTxt = new System.Windows.Forms.Label();
            this.FreeTxt = new System.Windows.Forms.Label();
            this.UsedTxt = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.RunBtn = new System.Windows.Forms.Button();
            this.RenameBtn = new System.Windows.Forms.Button();
            this.SelectConfigBtn = new System.Windows.Forms.Button();
            this.StorageSelectBtn = new System.Windows.Forms.Button();
            this.RebootBtn = new System.Windows.Forms.Button();
            this.BackupFilesToSDBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.DownloadBtn = new System.Windows.Forms.Button();
            this.UploadBtn = new System.Windows.Forms.Button();
            this.RefreshBtn = new System.Windows.Forms.Button();
            this.EditBtn = new System.Windows.Forms.Button();
            this.RenameBox = new System.Windows.Forms.TextBox();
            this.OKBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.TotalTxt);
            this.panel1.Controls.Add(this.FreeTxt);
            this.panel1.Controls.Add(this.UsedTxt);
            this.panel1.Location = new System.Drawing.Point(12, 572);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 39);
            this.panel1.TabIndex = 127;
            // 
            // TotalTxt
            // 
            this.TotalTxt.AutoSize = true;
            this.TotalTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalTxt.ForeColor = System.Drawing.Color.Silver;
            this.TotalTxt.Location = new System.Drawing.Point(3, 11);
            this.TotalTxt.Name = "TotalTxt";
            this.TotalTxt.Size = new System.Drawing.Size(41, 16);
            this.TotalTxt.TabIndex = 118;
            this.TotalTxt.Text = "Total:";
            // 
            // FreeTxt
            // 
            this.FreeTxt.AutoSize = true;
            this.FreeTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FreeTxt.ForeColor = System.Drawing.Color.Silver;
            this.FreeTxt.Location = new System.Drawing.Point(289, 11);
            this.FreeTxt.Name = "FreeTxt";
            this.FreeTxt.Size = new System.Drawing.Size(38, 16);
            this.FreeTxt.TabIndex = 117;
            this.FreeTxt.Text = "Free:";
            // 
            // UsedTxt
            // 
            this.UsedTxt.AutoSize = true;
            this.UsedTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsedTxt.ForeColor = System.Drawing.Color.Silver;
            this.UsedTxt.Location = new System.Drawing.Point(145, 11);
            this.UsedTxt.Name = "UsedTxt";
            this.UsedTxt.Size = new System.Drawing.Size(43, 16);
            this.UsedTxt.TabIndex = 115;
            this.UsedTxt.Text = "Used:";
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.ForeColor = System.Drawing.Color.Silver;
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.LabelWrap = false;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(682, 554);
            this.listView1.TabIndex = 118;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.RunBtn);
            this.panel2.Controls.Add(this.RenameBtn);
            this.panel2.Controls.Add(this.SelectConfigBtn);
            this.panel2.Controls.Add(this.StorageSelectBtn);
            this.panel2.Controls.Add(this.RebootBtn);
            this.panel2.Controls.Add(this.BackupFilesToSDBtn);
            this.panel2.Controls.Add(this.DeleteBtn);
            this.panel2.Controls.Add(this.DownloadBtn);
            this.panel2.Controls.Add(this.UploadBtn);
            this.panel2.Controls.Add(this.RefreshBtn);
            this.panel2.Controls.Add(this.EditBtn);
            this.panel2.Location = new System.Drawing.Point(700, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(161, 554);
            this.panel2.TabIndex = 128;
            // 
            // RunBtn
            // 
            this.RunBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.RunBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.RunBtn.FlatAppearance.BorderSize = 0;
            this.RunBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RunBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunBtn.ForeColor = System.Drawing.Color.Silver;
            this.RunBtn.Location = new System.Drawing.Point(0, 400);
            this.RunBtn.Margin = new System.Windows.Forms.Padding(4);
            this.RunBtn.Name = "RunBtn";
            this.RunBtn.Size = new System.Drawing.Size(161, 40);
            this.RunBtn.TabIndex = 143;
            this.RunBtn.Text = "Run";
            this.RunBtn.UseVisualStyleBackColor = false;
            this.RunBtn.Click += new System.EventHandler(this.RunBtn_Click);
            // 
            // RenameBtn
            // 
            this.RenameBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.RenameBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.RenameBtn.FlatAppearance.BorderSize = 0;
            this.RenameBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RenameBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RenameBtn.ForeColor = System.Drawing.Color.Silver;
            this.RenameBtn.Location = new System.Drawing.Point(0, 360);
            this.RenameBtn.Margin = new System.Windows.Forms.Padding(4);
            this.RenameBtn.Name = "RenameBtn";
            this.RenameBtn.Size = new System.Drawing.Size(161, 40);
            this.RenameBtn.TabIndex = 142;
            this.RenameBtn.Text = "Rename";
            this.RenameBtn.UseVisualStyleBackColor = false;
            this.RenameBtn.Click += new System.EventHandler(this.RenameBtn_Click);
            // 
            // SelectConfigBtn
            // 
            this.SelectConfigBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.SelectConfigBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.SelectConfigBtn.FlatAppearance.BorderSize = 0;
            this.SelectConfigBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectConfigBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectConfigBtn.ForeColor = System.Drawing.Color.Silver;
            this.SelectConfigBtn.Location = new System.Drawing.Point(0, 320);
            this.SelectConfigBtn.Margin = new System.Windows.Forms.Padding(4);
            this.SelectConfigBtn.Name = "SelectConfigBtn";
            this.SelectConfigBtn.Size = new System.Drawing.Size(161, 40);
            this.SelectConfigBtn.TabIndex = 141;
            this.SelectConfigBtn.Text = "Select as config";
            this.SelectConfigBtn.UseVisualStyleBackColor = false;
            this.SelectConfigBtn.Click += new System.EventHandler(this.SelectConfigBtn_Click);
            // 
            // StorageSelectBtn
            // 
            this.StorageSelectBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.StorageSelectBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.StorageSelectBtn.FlatAppearance.BorderSize = 0;
            this.StorageSelectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StorageSelectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StorageSelectBtn.ForeColor = System.Drawing.Color.Silver;
            this.StorageSelectBtn.Location = new System.Drawing.Point(0, 280);
            this.StorageSelectBtn.Margin = new System.Windows.Forms.Padding(4);
            this.StorageSelectBtn.Name = "StorageSelectBtn";
            this.StorageSelectBtn.Size = new System.Drawing.Size(161, 40);
            this.StorageSelectBtn.TabIndex = 140;
            this.StorageSelectBtn.Text = "SD Card";
            this.StorageSelectBtn.UseVisualStyleBackColor = false;
            this.StorageSelectBtn.Click += new System.EventHandler(this.StorageSelectBtn_Click);
            // 
            // RebootBtn
            // 
            this.RebootBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.RebootBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.RebootBtn.FlatAppearance.BorderSize = 0;
            this.RebootBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RebootBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RebootBtn.ForeColor = System.Drawing.Color.Silver;
            this.RebootBtn.Location = new System.Drawing.Point(0, 240);
            this.RebootBtn.Margin = new System.Windows.Forms.Padding(4);
            this.RebootBtn.Name = "RebootBtn";
            this.RebootBtn.Size = new System.Drawing.Size(161, 40);
            this.RebootBtn.TabIndex = 138;
            this.RebootBtn.Text = "Reboot";
            this.RebootBtn.UseVisualStyleBackColor = false;
            this.RebootBtn.Click += new System.EventHandler(this.RebootBtn_Click);
            // 
            // BackupFilesToSDBtn
            // 
            this.BackupFilesToSDBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.BackupFilesToSDBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.BackupFilesToSDBtn.FlatAppearance.BorderSize = 0;
            this.BackupFilesToSDBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackupFilesToSDBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackupFilesToSDBtn.ForeColor = System.Drawing.Color.Silver;
            this.BackupFilesToSDBtn.Location = new System.Drawing.Point(0, 200);
            this.BackupFilesToSDBtn.Margin = new System.Windows.Forms.Padding(4);
            this.BackupFilesToSDBtn.Name = "BackupFilesToSDBtn";
            this.BackupFilesToSDBtn.Size = new System.Drawing.Size(161, 40);
            this.BackupFilesToSDBtn.TabIndex = 136;
            this.BackupFilesToSDBtn.Text = "Backup Files to SD";
            this.BackupFilesToSDBtn.UseVisualStyleBackColor = false;
            this.BackupFilesToSDBtn.Click += new System.EventHandler(this.BackupFilesToSDBtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.DeleteBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.DeleteBtn.FlatAppearance.BorderSize = 0;
            this.DeleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteBtn.ForeColor = System.Drawing.Color.Silver;
            this.DeleteBtn.Location = new System.Drawing.Point(0, 160);
            this.DeleteBtn.Margin = new System.Windows.Forms.Padding(4);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(161, 40);
            this.DeleteBtn.TabIndex = 129;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = false;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // DownloadBtn
            // 
            this.DownloadBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.DownloadBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.DownloadBtn.FlatAppearance.BorderSize = 0;
            this.DownloadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DownloadBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownloadBtn.ForeColor = System.Drawing.Color.Silver;
            this.DownloadBtn.Location = new System.Drawing.Point(0, 120);
            this.DownloadBtn.Margin = new System.Windows.Forms.Padding(4);
            this.DownloadBtn.Name = "DownloadBtn";
            this.DownloadBtn.Size = new System.Drawing.Size(161, 40);
            this.DownloadBtn.TabIndex = 130;
            this.DownloadBtn.Text = "Download File";
            this.DownloadBtn.UseVisualStyleBackColor = false;
            this.DownloadBtn.Click += new System.EventHandler(this.DownloadBtn_Click);
            // 
            // UploadBtn
            // 
            this.UploadBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.UploadBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.UploadBtn.FlatAppearance.BorderSize = 0;
            this.UploadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UploadBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UploadBtn.ForeColor = System.Drawing.Color.Silver;
            this.UploadBtn.Location = new System.Drawing.Point(0, 80);
            this.UploadBtn.Margin = new System.Windows.Forms.Padding(4);
            this.UploadBtn.Name = "UploadBtn";
            this.UploadBtn.Size = new System.Drawing.Size(161, 40);
            this.UploadBtn.TabIndex = 131;
            this.UploadBtn.Text = "Upload File";
            this.UploadBtn.UseVisualStyleBackColor = false;
            this.UploadBtn.Click += new System.EventHandler(this.UploadBtn_Click);
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.RefreshBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.RefreshBtn.FlatAppearance.BorderSize = 0;
            this.RefreshBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshBtn.ForeColor = System.Drawing.Color.Silver;
            this.RefreshBtn.Location = new System.Drawing.Point(0, 40);
            this.RefreshBtn.Margin = new System.Windows.Forms.Padding(4);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(161, 40);
            this.RefreshBtn.TabIndex = 132;
            this.RefreshBtn.Text = "Refresh";
            this.RefreshBtn.UseVisualStyleBackColor = false;
            this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // EditBtn
            // 
            this.EditBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.EditBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.EditBtn.FlatAppearance.BorderSize = 0;
            this.EditBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditBtn.ForeColor = System.Drawing.Color.Silver;
            this.EditBtn.Location = new System.Drawing.Point(0, 0);
            this.EditBtn.Margin = new System.Windows.Forms.Padding(4);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(161, 40);
            this.EditBtn.TabIndex = 133;
            this.EditBtn.Text = "Edit";
            this.EditBtn.UseVisualStyleBackColor = false;
            this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // RenameBox
            // 
            this.RenameBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RenameBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.RenameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RenameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RenameBox.ForeColor = System.Drawing.Color.Silver;
            this.RenameBox.Location = new System.Drawing.Point(448, 572);
            this.RenameBox.Name = "RenameBox";
            this.RenameBox.Size = new System.Drawing.Size(246, 26);
            this.RenameBox.TabIndex = 129;
            // 
            // OKBtn
            // 
            this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OKBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.OKBtn.FlatAppearance.BorderSize = 0;
            this.OKBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OKBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKBtn.ForeColor = System.Drawing.Color.LightGray;
            this.OKBtn.Location = new System.Drawing.Point(448, 613);
            this.OKBtn.Margin = new System.Windows.Forms.Padding(4);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(112, 35);
            this.OKBtn.TabIndex = 130;
            this.OKBtn.Tag = "";
            this.OKBtn.Text = "OK";
            this.OKBtn.UseVisualStyleBackColor = false;
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CancelBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.CancelBtn.FlatAppearance.BorderSize = 0;
            this.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelBtn.ForeColor = System.Drawing.Color.LightGray;
            this.CancelBtn.Location = new System.Drawing.Point(580, 613);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(4);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(112, 35);
            this.CancelBtn.TabIndex = 131;
            this.CancelBtn.Tag = "";
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 617);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(430, 23);
            this.progressBar1.TabIndex = 132;
            // 
            // FilesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(27)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(983, 661);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.RenameBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listView1);
            this.Name = "FilesForm";
            this.Text = "FilesForm";
            this.Load += new System.EventHandler(this.FilesForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label TotalTxt;
        private System.Windows.Forms.Label FreeTxt;
        private System.Windows.Forms.Label UsedTxt;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button SelectConfigBtn;
        private System.Windows.Forms.Button StorageSelectBtn;
        private System.Windows.Forms.Button RebootBtn;
        private System.Windows.Forms.Button BackupFilesToSDBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button DownloadBtn;
        private System.Windows.Forms.Button UploadBtn;
        private System.Windows.Forms.Button RefreshBtn;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.Button RenameBtn;
        private System.Windows.Forms.TextBox RenameBox;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button RunBtn;
    }
}