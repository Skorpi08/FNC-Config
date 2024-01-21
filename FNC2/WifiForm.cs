using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FNC2
{
    public partial class WifiForm : Form
    {
        public WifiForm()
        {
            InitializeComponent();
        }

        private void WifiForm_Load(object sender, EventArgs e)
        {

        }

        private void ConnectWifiBtn_Click(object sender, EventArgs e)
        {
            if (MainForm.IsSerialPortOpen)
            {
                MainForm.serialPort.WriteLine("$Sta/SSID=" + SSIDTxt.Text);
                MainForm.serialPort.WriteLine("$Sta/Password=" + PasswordTxt.Text);
                MainForm.serialPort.WriteLine("$bye");
            }
            else
            {
                MessageBox.Show("Please connect.");
            }

        }

        private void PasswordTxt_KeyDown(object sender, KeyEventArgs e)
        {
            
                if (e.KeyCode == Keys.Enter)
                {
                    ConnectWifiBtn_Click(null, EventArgs.Empty);
                    e.SuppressKeyPress = true; // Verhindere den Standard-Tastendruck, um ein weiteres Ereignis zu verhindern
                }
            
        }
    }
}
