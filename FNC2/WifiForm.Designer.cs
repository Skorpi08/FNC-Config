namespace FNC2
{
    partial class WifiForm
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
            this.ConnectWifiBtn = new System.Windows.Forms.Button();
            this.SSIDTxt = new System.Windows.Forms.TextBox();
            this.IPTxt = new System.Windows.Forms.TextBox();
            this.PasswordTxt = new System.Windows.Forms.TextBox();
            this.StatusTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CopyIPBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ConnectWifiBtn
            // 
            this.ConnectWifiBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.ConnectWifiBtn.FlatAppearance.BorderSize = 0;
            this.ConnectWifiBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConnectWifiBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectWifiBtn.ForeColor = System.Drawing.Color.LightGray;
            this.ConnectWifiBtn.Location = new System.Drawing.Point(105, 220);
            this.ConnectWifiBtn.Margin = new System.Windows.Forms.Padding(4);
            this.ConnectWifiBtn.Name = "ConnectWifiBtn";
            this.ConnectWifiBtn.Size = new System.Drawing.Size(157, 40);
            this.ConnectWifiBtn.TabIndex = 112;
            this.ConnectWifiBtn.Tag = "";
            this.ConnectWifiBtn.Text = "Connect Wifi";
            this.ConnectWifiBtn.UseVisualStyleBackColor = false;
            this.ConnectWifiBtn.Click += new System.EventHandler(this.ConnectWifiBtn_Click);
            // 
            // SSIDTxt
            // 
            this.SSIDTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.SSIDTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SSIDTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SSIDTxt.ForeColor = System.Drawing.Color.Silver;
            this.SSIDTxt.Location = new System.Drawing.Point(105, 12);
            this.SSIDTxt.Name = "SSIDTxt";
            this.SSIDTxt.Size = new System.Drawing.Size(333, 26);
            this.SSIDTxt.TabIndex = 111;
            // 
            // IPTxt
            // 
            this.IPTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.IPTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IPTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPTxt.ForeColor = System.Drawing.Color.Silver;
            this.IPTxt.Location = new System.Drawing.Point(105, 122);
            this.IPTxt.Name = "IPTxt";
            this.IPTxt.ReadOnly = true;
            this.IPTxt.Size = new System.Drawing.Size(333, 26);
            this.IPTxt.TabIndex = 113;
            // 
            // PasswordTxt
            // 
            this.PasswordTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.PasswordTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTxt.ForeColor = System.Drawing.Color.Silver;
            this.PasswordTxt.Location = new System.Drawing.Point(105, 67);
            this.PasswordTxt.Name = "PasswordTxt";
            this.PasswordTxt.PasswordChar = '*';
            this.PasswordTxt.Size = new System.Drawing.Size(333, 26);
            this.PasswordTxt.TabIndex = 114;
            this.PasswordTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PasswordTxt_KeyDown);
            // 
            // StatusTxt
            // 
            this.StatusTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.StatusTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StatusTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusTxt.ForeColor = System.Drawing.Color.Silver;
            this.StatusTxt.Location = new System.Drawing.Point(105, 177);
            this.StatusTxt.Name = "StatusTxt";
            this.StatusTxt.ReadOnly = true;
            this.StatusTxt.Size = new System.Drawing.Size(333, 26);
            this.StatusTxt.TabIndex = 115;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.096F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(46, 14);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 116;
            this.label2.Text = "SSID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.096F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(37, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 117;
            this.label1.Text = "Status:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.096F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(70, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 20);
            this.label3.TabIndex = 118;
            this.label3.Text = "IP:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.096F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(11, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 20);
            this.label4.TabIndex = 119;
            this.label4.Text = "Password:";
            // 
            // CopyIPBtn
            // 
            this.CopyIPBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.CopyIPBtn.FlatAppearance.BorderSize = 0;
            this.CopyIPBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CopyIPBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CopyIPBtn.ForeColor = System.Drawing.Color.LightGray;
            this.CopyIPBtn.Location = new System.Drawing.Point(281, 220);
            this.CopyIPBtn.Margin = new System.Windows.Forms.Padding(4);
            this.CopyIPBtn.Name = "CopyIPBtn";
            this.CopyIPBtn.Size = new System.Drawing.Size(157, 40);
            this.CopyIPBtn.TabIndex = 115;
            this.CopyIPBtn.Tag = "";
            this.CopyIPBtn.Text = "Copy IP";
            this.CopyIPBtn.UseVisualStyleBackColor = false;
            // 
            // WifiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(27)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(874, 661);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StatusTxt);
            this.Controls.Add(this.CopyIPBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IPTxt);
            this.Controls.Add(this.PasswordTxt);
            this.Controls.Add(this.ConnectWifiBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SSIDTxt);
            this.Controls.Add(this.label4);
            this.Name = "WifiForm";
            this.Text = "Wifi";
            this.Load += new System.EventHandler(this.WifiForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConnectWifiBtn;
        private System.Windows.Forms.TextBox SSIDTxt;
        private System.Windows.Forms.TextBox IPTxt;
        private System.Windows.Forms.TextBox PasswordTxt;
        private System.Windows.Forms.TextBox StatusTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CopyIPBtn;
    }
}