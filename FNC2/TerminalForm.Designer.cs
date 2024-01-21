namespace FNC2
{
    partial class TerminalForm
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
            this.ReceivedBox = new System.Windows.Forms.RichTextBox();
            this.SendBox = new System.Windows.Forms.TextBox();
            this.SendBtn = new System.Windows.Forms.Button();
            this.ABtn = new System.Windows.Forms.Button();
            this.limitsBtn = new System.Windows.Forms.Button();
            this.HZBtn = new System.Windows.Forms.Button();
            this.CMDBtn = new System.Windows.Forms.Button();
            this.EBtn = new System.Windows.Forms.Button();
            this.Xbtn = new System.Windows.Forms.Button();
            this.HYBtn = new System.Windows.Forms.Button();
            this.HXBtn = new System.Windows.Forms.Button();
            this.byeBtn = new System.Windows.Forms.Button();
            this.TBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.OpenTxtFileBtn = new System.Windows.Forms.Button();
            this.ClearBox = new System.Windows.Forms.CheckBox();
            this.SaveBox = new System.Windows.Forms.CheckBox();
            this.ClearOutputBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReceivedBox
            // 
            this.ReceivedBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ReceivedBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.ReceivedBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReceivedBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReceivedBox.ForeColor = System.Drawing.Color.Silver;
            this.ReceivedBox.Location = new System.Drawing.Point(12, 109);
            this.ReceivedBox.Name = "ReceivedBox";
            this.ReceivedBox.ReadOnly = true;
            this.ReceivedBox.Size = new System.Drawing.Size(675, 540);
            this.ReceivedBox.TabIndex = 0;
            this.ReceivedBox.Text = "";
            // 
            // SendBox
            // 
            this.SendBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SendBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.SendBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SendBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendBox.ForeColor = System.Drawing.Color.Silver;
            this.SendBox.Location = new System.Drawing.Point(12, 63);
            this.SendBox.Name = "SendBox";
            this.SendBox.Size = new System.Drawing.Size(675, 26);
            this.SendBox.TabIndex = 109;
            this.SendBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SendBox_KeyDown);
            // 
            // SendBtn
            // 
            this.SendBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.SendBtn.FlatAppearance.BorderSize = 0;
            this.SendBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendBtn.ForeColor = System.Drawing.Color.LightGray;
            this.SendBtn.Location = new System.Drawing.Point(704, 57);
            this.SendBtn.Margin = new System.Windows.Forms.Padding(4);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(157, 40);
            this.SendBtn.TabIndex = 110;
            this.SendBtn.Tag = "";
            this.SendBtn.Text = "SEND";
            this.SendBtn.UseVisualStyleBackColor = false;
            this.SendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // ABtn
            // 
            this.ABtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.ABtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.ABtn.FlatAppearance.BorderSize = 0;
            this.ABtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ABtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ABtn.ForeColor = System.Drawing.Color.LightGray;
            this.ABtn.Location = new System.Drawing.Point(0, 280);
            this.ABtn.Margin = new System.Windows.Forms.Padding(4);
            this.ABtn.Name = "ABtn";
            this.ABtn.Size = new System.Drawing.Size(158, 40);
            this.ABtn.TabIndex = 115;
            this.ABtn.Tag = "";
            this.ABtn.Text = "Alarm Codes";
            this.ABtn.UseVisualStyleBackColor = false;
            this.ABtn.Click += new System.EventHandler(this.ABtn_Click);
            // 
            // limitsBtn
            // 
            this.limitsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.limitsBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.limitsBtn.FlatAppearance.BorderSize = 0;
            this.limitsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.limitsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.limitsBtn.ForeColor = System.Drawing.Color.LightGray;
            this.limitsBtn.Location = new System.Drawing.Point(0, 320);
            this.limitsBtn.Margin = new System.Windows.Forms.Padding(4);
            this.limitsBtn.Name = "limitsBtn";
            this.limitsBtn.Size = new System.Drawing.Size(158, 40);
            this.limitsBtn.TabIndex = 114;
            this.limitsBtn.Tag = "";
            this.limitsBtn.Text = "Limits";
            this.limitsBtn.UseVisualStyleBackColor = false;
            this.limitsBtn.Click += new System.EventHandler(this.limitsBtn_Click);
            // 
            // HZBtn
            // 
            this.HZBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.HZBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.HZBtn.FlatAppearance.BorderSize = 0;
            this.HZBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HZBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HZBtn.ForeColor = System.Drawing.Color.LightGray;
            this.HZBtn.Location = new System.Drawing.Point(0, 80);
            this.HZBtn.Margin = new System.Windows.Forms.Padding(4);
            this.HZBtn.Name = "HZBtn";
            this.HZBtn.Size = new System.Drawing.Size(158, 40);
            this.HZBtn.TabIndex = 118;
            this.HZBtn.Tag = "";
            this.HZBtn.Text = "Home Z";
            this.HZBtn.UseVisualStyleBackColor = false;
            this.HZBtn.Click += new System.EventHandler(this.HZBtn_Click);
            // 
            // CMDBtn
            // 
            this.CMDBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.CMDBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.CMDBtn.FlatAppearance.BorderSize = 0;
            this.CMDBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CMDBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMDBtn.ForeColor = System.Drawing.Color.LightGray;
            this.CMDBtn.Location = new System.Drawing.Point(0, 160);
            this.CMDBtn.Margin = new System.Windows.Forms.Padding(4);
            this.CMDBtn.Name = "CMDBtn";
            this.CMDBtn.Size = new System.Drawing.Size(158, 40);
            this.CMDBtn.TabIndex = 117;
            this.CMDBtn.Tag = "";
            this.CMDBtn.Text = "Commands";
            this.CMDBtn.UseVisualStyleBackColor = false;
            this.CMDBtn.Click += new System.EventHandler(this.CMDBtn_Click);
            // 
            // EBtn
            // 
            this.EBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.EBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.EBtn.FlatAppearance.BorderSize = 0;
            this.EBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EBtn.ForeColor = System.Drawing.Color.LightGray;
            this.EBtn.Location = new System.Drawing.Point(0, 240);
            this.EBtn.Margin = new System.Windows.Forms.Padding(4);
            this.EBtn.Name = "EBtn";
            this.EBtn.Size = new System.Drawing.Size(158, 40);
            this.EBtn.TabIndex = 116;
            this.EBtn.Tag = "";
            this.EBtn.Text = "Error Codes";
            this.EBtn.UseVisualStyleBackColor = false;
            this.EBtn.Click += new System.EventHandler(this.EBtn_Click);
            // 
            // Xbtn
            // 
            this.Xbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.Xbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Xbtn.FlatAppearance.BorderSize = 0;
            this.Xbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Xbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Xbtn.ForeColor = System.Drawing.Color.LightGray;
            this.Xbtn.Location = new System.Drawing.Point(0, 120);
            this.Xbtn.Margin = new System.Windows.Forms.Padding(4);
            this.Xbtn.Name = "Xbtn";
            this.Xbtn.Size = new System.Drawing.Size(158, 40);
            this.Xbtn.TabIndex = 121;
            this.Xbtn.Tag = "";
            this.Xbtn.Text = "Unlock";
            this.Xbtn.UseVisualStyleBackColor = false;
            this.Xbtn.Click += new System.EventHandler(this.Xbtn_Click);
            // 
            // HYBtn
            // 
            this.HYBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.HYBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.HYBtn.FlatAppearance.BorderSize = 0;
            this.HYBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HYBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HYBtn.ForeColor = System.Drawing.Color.LightGray;
            this.HYBtn.Location = new System.Drawing.Point(0, 40);
            this.HYBtn.Margin = new System.Windows.Forms.Padding(4);
            this.HYBtn.Name = "HYBtn";
            this.HYBtn.Size = new System.Drawing.Size(158, 40);
            this.HYBtn.TabIndex = 120;
            this.HYBtn.Tag = "";
            this.HYBtn.Text = "Home Y";
            this.HYBtn.UseVisualStyleBackColor = false;
            this.HYBtn.Click += new System.EventHandler(this.HYBtn_Click);
            // 
            // HXBtn
            // 
            this.HXBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.HXBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.HXBtn.FlatAppearance.BorderSize = 0;
            this.HXBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HXBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HXBtn.ForeColor = System.Drawing.Color.LightGray;
            this.HXBtn.Location = new System.Drawing.Point(0, 0);
            this.HXBtn.Margin = new System.Windows.Forms.Padding(4);
            this.HXBtn.Name = "HXBtn";
            this.HXBtn.Size = new System.Drawing.Size(158, 40);
            this.HXBtn.TabIndex = 119;
            this.HXBtn.Tag = "";
            this.HXBtn.Text = "Home X";
            this.HXBtn.UseVisualStyleBackColor = false;
            this.HXBtn.Click += new System.EventHandler(this.HXBtn_Click);
            // 
            // byeBtn
            // 
            this.byeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.byeBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.byeBtn.FlatAppearance.BorderSize = 0;
            this.byeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.byeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.byeBtn.ForeColor = System.Drawing.Color.LightGray;
            this.byeBtn.Location = new System.Drawing.Point(0, 360);
            this.byeBtn.Margin = new System.Windows.Forms.Padding(4);
            this.byeBtn.Name = "byeBtn";
            this.byeBtn.Size = new System.Drawing.Size(158, 40);
            this.byeBtn.TabIndex = 124;
            this.byeBtn.Tag = "";
            this.byeBtn.Text = "Reboot";
            this.byeBtn.UseVisualStyleBackColor = false;
            this.byeBtn.Click += new System.EventHandler(this.ResetBtn_Click);
            // 
            // TBtn
            // 
            this.TBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.TBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.TBtn.FlatAppearance.BorderSize = 0;
            this.TBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBtn.ForeColor = System.Drawing.Color.LightGray;
            this.TBtn.Location = new System.Drawing.Point(0, 200);
            this.TBtn.Margin = new System.Windows.Forms.Padding(4);
            this.TBtn.Name = "TBtn";
            this.TBtn.Size = new System.Drawing.Size(158, 40);
            this.TBtn.TabIndex = 122;
            this.TBtn.Tag = "";
            this.TBtn.Text = "State";
            this.TBtn.UseVisualStyleBackColor = false;
            this.TBtn.Click += new System.EventHandler(this.TBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.byeBtn);
            this.panel1.Controls.Add(this.limitsBtn);
            this.panel1.Controls.Add(this.ABtn);
            this.panel1.Controls.Add(this.EBtn);
            this.panel1.Controls.Add(this.TBtn);
            this.panel1.Controls.Add(this.CMDBtn);
            this.panel1.Controls.Add(this.Xbtn);
            this.panel1.Controls.Add(this.HZBtn);
            this.panel1.Controls.Add(this.HYBtn);
            this.panel1.Controls.Add(this.HXBtn);
            this.panel1.Location = new System.Drawing.Point(704, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(158, 532);
            this.panel1.TabIndex = 130;
            // 
            // OpenTxtFileBtn
            // 
            this.OpenTxtFileBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.OpenTxtFileBtn.FlatAppearance.BorderSize = 0;
            this.OpenTxtFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenTxtFileBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenTxtFileBtn.ForeColor = System.Drawing.Color.LightGray;
            this.OpenTxtFileBtn.Location = new System.Drawing.Point(12, 9);
            this.OpenTxtFileBtn.Margin = new System.Windows.Forms.Padding(4);
            this.OpenTxtFileBtn.Name = "OpenTxtFileBtn";
            this.OpenTxtFileBtn.Size = new System.Drawing.Size(157, 40);
            this.OpenTxtFileBtn.TabIndex = 131;
            this.OpenTxtFileBtn.Tag = "";
            this.OpenTxtFileBtn.Text = "Open txt File";
            this.OpenTxtFileBtn.UseVisualStyleBackColor = false;
            this.OpenTxtFileBtn.Click += new System.EventHandler(this.OpenTxtFileBtn_Click);
            // 
            // ClearBox
            // 
            this.ClearBox.AutoSize = true;
            this.ClearBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearBox.ForeColor = System.Drawing.Color.Silver;
            this.ClearBox.Location = new System.Drawing.Point(375, 18);
            this.ClearBox.Name = "ClearBox";
            this.ClearBox.Size = new System.Drawing.Size(144, 24);
            this.ClearBox.TabIndex = 132;
            this.ClearBox.Text = "Clear after Send";
            this.ClearBox.UseVisualStyleBackColor = true;
            // 
            // SaveBox
            // 
            this.SaveBox.AutoSize = true;
            this.SaveBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBox.ForeColor = System.Drawing.Color.Silver;
            this.SaveBox.Location = new System.Drawing.Point(190, 18);
            this.SaveBox.Name = "SaveBox";
            this.SaveBox.Size = new System.Drawing.Size(171, 24);
            this.SaveBox.TabIndex = 133;
            this.SaveBox.Text = "Save Data to txt File";
            this.SaveBox.UseVisualStyleBackColor = true;
            // 
            // ClearOutputBtn
            // 
            this.ClearOutputBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.ClearOutputBtn.FlatAppearance.BorderSize = 0;
            this.ClearOutputBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearOutputBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearOutputBtn.ForeColor = System.Drawing.Color.LightGray;
            this.ClearOutputBtn.Location = new System.Drawing.Point(530, 9);
            this.ClearOutputBtn.Margin = new System.Windows.Forms.Padding(4);
            this.ClearOutputBtn.Name = "ClearOutputBtn";
            this.ClearOutputBtn.Size = new System.Drawing.Size(157, 40);
            this.ClearOutputBtn.TabIndex = 134;
            this.ClearOutputBtn.Tag = "";
            this.ClearOutputBtn.Text = "Clear Output";
            this.ClearOutputBtn.UseVisualStyleBackColor = false;
            this.ClearOutputBtn.Click += new System.EventHandler(this.ClearOutputBtn_Click);
            // 
            // TerminalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(27)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(983, 661);
            this.Controls.Add(this.ClearOutputBtn);
            this.Controls.Add(this.SaveBox);
            this.Controls.Add(this.ClearBox);
            this.Controls.Add(this.OpenTxtFileBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SendBtn);
            this.Controls.Add(this.SendBox);
            this.Controls.Add(this.ReceivedBox);
            this.Name = "TerminalForm";
            this.Text = "Terminal";
            this.Load += new System.EventHandler(this.Terminal_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox ReceivedBox;
        private System.Windows.Forms.TextBox SendBox;
        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.Button ABtn;
        private System.Windows.Forms.Button limitsBtn;
        private System.Windows.Forms.Button HZBtn;
        private System.Windows.Forms.Button CMDBtn;
        private System.Windows.Forms.Button EBtn;
        private System.Windows.Forms.Button Xbtn;
        private System.Windows.Forms.Button HYBtn;
        private System.Windows.Forms.Button HXBtn;
        private System.Windows.Forms.Button byeBtn;
        private System.Windows.Forms.Button TBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button OpenTxtFileBtn;
        private System.Windows.Forms.CheckBox ClearBox;
        private System.Windows.Forms.CheckBox SaveBox;
        private System.Windows.Forms.Button ClearOutputBtn;
    }
}