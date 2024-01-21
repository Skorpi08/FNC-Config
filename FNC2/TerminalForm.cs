using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FNC2
{
    public partial class TerminalForm : Form
    {
        StreamWriter objStreamWriter;
        string filePath;
        bool limits = true;

        public TerminalForm()
        {
            InitializeComponent();
            filePath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            filePath += @"\SerialData.txt";

        }

        private void Terminal_Load(object sender, EventArgs e)
        {

        }
        private void SaveDataToTxtFile(string dataReceived)
        {
            if (SaveBox.Checked)
            {
                try
                {
                    objStreamWriter = new StreamWriter(filePath, true);
                    objStreamWriter.Write(dataReceived);
                    objStreamWriter.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }



        private void SendBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendData(); // Rufe die Sendefunktion auf, wenn Enter gedrückt wird
                e.SuppressKeyPress = true; // Verhindere den Standard-Tastendruck, um ein weiteres Ereignis zu verhindern
            }
        }

        public void SendData(string text = null)
        {
            if (MainForm.IsSerialPortOpen)
            {
                try
                {
                    string dataToSend = text ?? SendBox.Text;
                   
                        DisplayReceivedData(dataToSend + "\r\n");
                        MainForm.serialPort.Write(dataToSend + "\r\n");
                 
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please connect.");
            }
            if (ClearBox.Checked)
            {
                SendBox.Clear();
            }

        }

        public void DisplayReceivedData(string receivedData)
        {
            ReceivedBox.AppendText(receivedData);
            ReceivedBox.ScrollToCaret();
            MarkMsg();
            SaveDataToTxtFile(receivedData);
        }

   


        private void MarkMsg()
        {
            string[] searchStrings = { "[MSG:INFO:", "[MSG:ERR:", "[MSG:INFO: ALARM:" };
            foreach (var searchString in searchStrings)
            {
                int startIndex = 0;
                int index;

                while ((index = ReceivedBox.Text.IndexOf(searchString, startIndex)) != -1)
                {
                    ReceivedBox.Select(index, searchString.Length);
                    if (searchString == "[MSG:INFO:")
                        ReceivedBox.SelectionColor = Color.Green;
                    else if (searchString == "[MSG:ERR:")
                        ReceivedBox.SelectionColor = Color.Red;
                    else if (searchString == "[MSG:INFO: ALARM:")
                        ReceivedBox.SelectionColor = Color.GreenYellow;

                    startIndex = index + searchString.Length;
                }
            }
        }
        #region Buttons
        private void SendBtn_Click(object sender, EventArgs e)
        {
            SendData();
        }

        private void OpenTxtFileBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("notepad.exe", filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Öffnen der Datei: " + ex.Message);
            }
        }

        private void ClearOutputBtn_Click(object sender, EventArgs e)
        {
            ReceivedBox.Clear();
        }

        private void HXBtn_Click(object sender, EventArgs e)
        {
            SendData("$HX");
        }

        private void HYBtn_Click(object sender, EventArgs e)
        {
            SendData("$HY");
        }

        private void HZBtn_Click(object sender, EventArgs e)
        {
            SendData("$HZ");
        }

        private void Xbtn_Click(object sender, EventArgs e)
        {
            SendData("$X");
        }

        private void CMDBtn_Click(object sender, EventArgs e)
        {
            SendData("$CMD");
        }

        private void TBtn_Click(object sender, EventArgs e)
        {
            SendData("?");
        }

        private void EBtn_Click(object sender, EventArgs e)
        {
            SendData("$E");
        }

        private void ABtn_Click(object sender, EventArgs e)
        {
            SendData("$A");
        }
        
        private void limitsBtn_Click(object sender, EventArgs e)
        {
            if (MainForm.IsSerialPortOpen)
            {
                if (limits)
                {
                    limits = false;
                    SendData("$limits");
                    limitsBtn.Text = "exit limits";
                }
                else
                {
                    limitsBtn.Text = "Limits";
                    limits = true;
                    SendData("!");
                }
            }
            else
            {
                limits = true;
                SendData("$limits");
                limitsBtn.Text = "Limits";
            }

        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            SendData("$bye");
        }


        #endregion Buttons
    }
}
