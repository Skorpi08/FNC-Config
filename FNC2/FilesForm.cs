using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace FNC2
{
    public partial class FilesForm : Form
    {
        string fileNameConfig = "";
        string currentDIR = "";
        private const byte SOH = 0x01;
        private const byte STX = 0x02;
        private const byte EOT = 0x04;
        private const byte ACK = 0x06;
        private const byte NAK = 0x15;
        private const byte CAN = 0x18;
        private const byte CTRLZ = 0x1A;
        private const int DLY_1S = 1000;
        private const int MAXRETRANS = 6;
        private const int BlockSize = 1024;

        public FilesForm()
        {
            InitializeComponent();

        }

        private void FilesForm_Load(object sender, EventArgs e)
        {
            EditBtn.Visible = false;
            DownloadBtn.Visible = false;
            
            RefreshData();
            listView1.View = View.Details;
            listView1.Columns.Add("Name", 500);
            listView1.Columns.Add("Size", 100);
            listView1.Columns.Add("Selected", 80);
        }

        public void ParseFS(string matcher)
        {
            string fileconfig = @"\$Config/Filename=(.*)";
            Match fileConfigMatch = Regex.Match(matcher, fileconfig);
            if (fileConfigMatch.Success)
            {
                fileNameConfig = fileConfigMatch.Groups[1].Value;
            }

            
            bool isSDCard = (StorageSelectBtn.Text == "SD Card");

            string currentDirectory = @"\[DIR:(.*?)\]";
            Match currentDirectoryMatch = Regex.Match(matcher, currentDirectory);
            if (currentDirectoryMatch.Success)
            {
                currentDIR = currentDirectoryMatch.Groups[1].Value;
            }
           

            string filePattern = @"\[FILE:(\s{1,2})(.*?)\|SIZE:(.*?)\]";
            MatchCollection fileMatches = Regex.Matches(matcher, filePattern, RegexOptions.Multiline);

            if (fileMatches.Count > 0)
            {
                foreach (Match fileMatch in fileMatches)
                {
                    string spaces = fileMatch.Groups[1].Value;
                    string fileName = fileMatch.Groups[2].Value;
                    string fileSize = fileMatch.Groups[3].Value;

                    if (spaces.Equals("  "))
                    {
                        ListViewItem item = new ListViewItem(currentDIR + "/" + fileName);
                        item.SubItems.Add(fileSize);
                        Invoke(new Action(() =>
                        {
                            listView1.Items.Add(item);
                        }));
                    }
                    else
                    {

                        ListViewItem item = new ListViewItem( fileName);
                        item.SubItems.Add(fileSize);

                        // Speichern zusätzlicher Daten im ListViewItem.Tag für zukünftige Verwendung
                        item.Tag = new { IsSDCard = isSDCard };

                        Invoke(new Action(() =>
                        {
                            listView1.Items.Add(item);
                        }));
                       
                    }
                }

                if (StorageSelectBtn.Text == "SD Card")
                {
                    Invoke(new Action(() =>
                    {
                        // Überprüfe außerhalb der Schleife, ob der Dateiname mit dem fileConfig übereinstimmt
                        foreach (ListViewItem item in listView1.Items)
                        {
                            if (item.Text.Trim().Equals(fileNameConfig.Trim()))
                            {
                                // Füge "x" in die dritte Spalte ein
                                item.SubItems.Add("X");
                            }
                        }
                    }));
                }
            }


            string[] spacePatterns = new string[]
{
        @"\[LocalFS Free:(.*?) Used:(.*?) Total:(.*?)\]",
        @"\[/littlefs/ Free:(.*?) Used:(.*?) Total:(.*?)\]",
        @"\[/spiffs/ Free:(.*?) Used:(.*?) Total:(.*?)\]",
        @"\[SD Free:(.*?) Used:(.*?) Total:(.*?)\]",
        @"\[/sd/ Free:(.*?) Used:(.*?) Total:(.*?)\]"
};

            foreach (string pattern in spacePatterns)
            {

                Match spaceMatch = Regex.Match(matcher, pattern);
                if (spaceMatch.Success)
                {
                    string free = spaceMatch.Groups[1].Value;
                    string used = spaceMatch.Groups[2].Value;
                    string total = spaceMatch.Groups[3].Value;
                    Invoke(new Action(() =>
                    {
                        TotalTxt.Text = "Total: " + total;
                        UsedTxt.Text = "Used: " + used;
                        FreeTxt.Text = "Free: " + free;
                    }));
                   
                    break;
                }
            }

        }

        private void RefreshData()
        {
            HideProgressBar();
            HideRenameControls();
            listView1.Items.Clear();
            TotalTxt.Text = "Total: ";
            UsedTxt.Text = "Used: ";
            FreeTxt.Text = "Free: ";

            TerminalForm form1Instance = Application.OpenForms["TerminalForm"] as TerminalForm;
            form1Instance?.SendData("$Config/Filename");

            if (MainForm.IsSerialPortOpen)
            {
                string command = (StorageSelectBtn.Text == "SD Card") ? "$LocalFS/List" : "$SD/List";
                SelectConfigBtn.Visible = (StorageSelectBtn.Text == "SD Card");

                form1Instance?.SendData(command);
            }
        }
        #region Buttons
        private void EditBtn_Click(object sender, EventArgs e)
        {

        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private async void UploadBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            //fileDialog.Filter = "FNC config|*.yaml";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                ShowProgressBar(); // Zeige die ProgressBar vor dem Upload an

                string fileName = Path.GetFileName(fileDialog.FileName);
                string formattedDate = DateTime.Now.ToString("HH:mm_dd.MM.yy");
                string newFileName = $"{fileName}_{formattedDate}";

                try
                {
                    MainForm.serialPort.ReadTimeout = 5000;
                    TerminalForm form1Instance = Application.OpenForms["TerminalForm"] as TerminalForm;
                    string command = (StorageSelectBtn.Text == "SD Card") ? "$XR=" + fileName : "$XR=/sd/" + fileName;
                    SelectConfigBtn.Visible = (StorageSelectBtn.Text == "SD Card");
                    form1Instance?.SendData(command);
                    await Task.Run(() => {  TransmitFile(fileDialog.FileName); });
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    RefreshData(); // Verstecke die ProgressBar nach dem Upload
                }
            }
        }

        private void DownloadBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void RebootBtn_Click(object sender, EventArgs e)
        {
            TerminalForm form1Instance = Application.OpenForms["TerminalForm"] as TerminalForm;
            form1Instance?.SendData("$bye");
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string fileName = selectedItem.SubItems[0].Text;
                TerminalForm form1Instance = Application.OpenForms["TerminalForm"] as TerminalForm;
                if (StorageSelectBtn.Text == "SD Card")
                {
                    form1Instance?.SendData("$LocalFS/Delete=/" + fileName);
                }
                else
                {
                    form1Instance?.SendData("$SD/Delete=/" + fileName);
                }

               
                RefreshData();
            }
        }

        private void SelectConfigBtn_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                TerminalForm form1Instance = Application.OpenForms["TerminalForm"] as TerminalForm;
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string fileName = selectedItem.SubItems[0].Text;
                form1Instance?.SendData("$Config/Filename=" + fileName);
               
            }
            RefreshData();
        }

        private void StorageSelectBtn_Click(object sender, EventArgs e)
        {
            if (StorageSelectBtn.Text == "SD Card")
            {
                StorageSelectBtn.Text = "Local FS";
            }
            else //if (StorageSelectBtn.Text == "Local FS")
            {
                StorageSelectBtn.Text = "SD Card";
            }
            RefreshData();
        }

        private void BackupFilesToSDBtn_Click(object sender, EventArgs e)
        {
            TerminalForm form1Instance = Application.OpenForms["TerminalForm"] as TerminalForm;
            form1Instance?.SendData("$LocalFS/Backup");
        }

        private void RenameBtn_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string fileName = selectedItem.SubItems[0].Text;

                // Zeige das Textfeld und die Schaltflächen an, mit fileName als Defaulttext
                ShowRenameControls(fileName);

                // Entferne alte Ereignisse, falls vorhanden
                OKBtn.Click -= OKBtn_Click;
                CancelBtn.Click -= CancelBtn_Click;

                // Klick-Ereignisse für OK und Abbrechen hinzufügen
                OKBtn.Click += OKBtn_Click;
                CancelBtn.Click += CancelBtn_Click;

                void OKBtn_Click(object sender1, EventArgs e1)
                {
                    HandleRenameOK(fileName);

                    // Entferne das Klick-Ereignis für den OK-Button nach der Benennung
                    OKBtn.Click -= OKBtn_Click;
                }

                // Schalte die Steuerelemente aus
                void CancelBtn_Click(object sender2, EventArgs e2)
                {
                    HideRenameControls();
                    // Entferne das Klick-Ereignis für den OK-Button nach der Benennung
                    OKBtn.Click -= OKBtn_Click;
                }
            }
        }

        private void RunBtn_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string fileName = selectedItem.SubItems[0].Text;

                TerminalForm formInstance = Application.OpenForms["TerminalForm"] as TerminalForm;
                if (formInstance != null)
                {
                    string prefix = (StorageSelectBtn.Text == "SD Card") ? "$LocalFS/Run=" + fileName : "SD/Run=" + fileName;
                    formInstance.SendData($"{prefix}");
                }

            }
        }
        #endregion Buttons
        private void HandleRenameOK(string fileName)
        {
            TerminalForm formInstance = Application.OpenForms["TerminalForm"] as TerminalForm;
            if (formInstance != null)
            {
                string prefix = (StorageSelectBtn.Text == "SD Card") ? "$LocalFS/Rename=" : "$SD/Rename=";
                string newName = RenameBox.Text;

                formInstance.SendData($"{prefix}{fileName}>{newName}");
                RefreshData();
            }
        }

        private void ShowRenameControls(string fileName)
        {
            RenameBox.Text = fileName;
            RenameBox.Visible = true;
            OKBtn.Visible = true;
            CancelBtn.Visible = true;
            AcceptButton = OKBtn;
            CancelButton = CancelBtn;
        }

        private void HideRenameControls()
        {
            RenameBox.Visible = false;
            OKBtn.Visible = false;
            CancelBtn.Visible = false;

            // Entferne die Klick-Ereignisse, um Mehrfachaufrufe zu vermeiden
            OKBtn.Click -= (sender, e) => HandleRenameOK(null);
            CancelBtn.Click -= (sender, e) => HideRenameControls();
        }

        public int TransmitFile(string filePath)
        {
                FileInfo fileInfo = new FileInfo(filePath);
                long fileSize = fileInfo.Length;
                int actualFileSize = 0;

                bool crc = true;
                uint packetNumber = 1;
                int len = 0;
                int retry;

                for (; ; )
                {
                    for (retry = 0; retry < MAXRETRANS; ++retry)
                    {
                        int c;
                        if ((c = MainForm.serialPort.ReadByte()) >= 0)
                        {
                            switch (c)
                            {
                                case 'C':
                                    crc = true;
                                    goto start_trans;
                                case NAK:
                                    crc = false;
                                    goto start_trans;
                                case CAN:
                                    if (MainForm.serialPort.ReadByte() == CAN)
                                    {
                                    Console.WriteLine("CAN abbruch?");
                                        MainForm.serialPort.Write(new byte[] { ACK }, 0, 1);
                                        return -1; /* canceled by remote */
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    MainForm.serialPort.Write(new byte[] { CAN, CAN, CAN }, 0, 3);
                    return -2; /* no sync */

                start_trans:
                    byte[] xbuff;
                    int bufsz;

                    if (packetNumber == 1)
                    {
                        xbuff = new byte[1030]; // 1024 for XModem 1k + 3 head chars + 2 crc + nul
                        xbuff[0] = STX;
                        bufsz = 1024;
                    }
                    else
                    {
                        /*  xbuff = new byte[133]; // 128 for XModem + 3 head chars + 2 crc
                          xbuff[0] = SOH;
                          bufsz = 128;*/
                        xbuff = new byte[1030]; // 1024 for XModem 1k + 3 head chars + 2 crc + nul
                        xbuff[0] = STX;
                        bufsz = 1024;
                    }

                    xbuff[1] = (byte)packetNumber;
                    xbuff[2] = (byte)~packetNumber;

                    using (FileStream fs = new FileStream(filePath, FileMode.Open))
                    {
                        fs.Seek((packetNumber - 1) * bufsz, SeekOrigin.Begin);
                        int bytesRead = fs.Read(xbuff, 3, bufsz);

                        if (bytesRead > 0)
                        {
                            if (bytesRead < bufsz)
                            {
                                for (int i = 3 + bytesRead; i < xbuff.Length; i++)
                                {
                                    xbuff[i] = CTRLZ;
                                }
                            }

                            if (crc)
                            {
                                ushort ccrc = CalculateCRC(xbuff, 3, bufsz);
                                xbuff[bufsz + 3] = (byte)(ccrc >> 8);
                                xbuff[bufsz + 4] = (byte)(ccrc & 0xFF);
                            }
                            else
                            {
                                byte ccks = 0;
                                for (int i = 3; i < bufsz + 3; ++i)
                                {
                                    ccks += xbuff[i];
                                }
                                xbuff[bufsz + 3] = ccks;
                            }

                            bool echoing = false;
                        for (retry = 0; retry < MAXRETRANS;)
                        {
                            if (!echoing)
                            {
                                MainForm.serialPort.Write(xbuff, 0, bufsz + 4 + (crc ? 1 : 0));
                                ++retry;
                            }

                            int response;
                            try
                            {
                                if ((response = MainForm.serialPort.ReadByte()) >= 0)
                                 {
                                switch (response)
                                {
                                    case ACK:
                                        ++packetNumber;
                                        Console.Write(packetNumber + "\r");
                                        actualFileSize += bytesRead;
                                        // Hier könnte der Fortschrittsbalken eingefügt werden
                                        // Berechnung des Fortschritts
                                        double progress = (double)actualFileSize / fileSize;
                                        int progressPercentage = (int)(progress * 100);

                                            // Aktualisierung der ProgressBar
                                        Invoke(new Action(() =>
                                         {
                                            progressBar1.Value = progressPercentage;
                                        }));

                                        goto start_trans;
                                    case CAN:
                                        if (MainForm.serialPort.ReadByte() == CAN)
                                        {
                                            Console.WriteLine("CAN 2 abbruch?");
                                           // MessageBox.Show("Timeout while reading from the serial port.", "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            MainForm.serialPort.Write(new byte[] { ACK }, 0, 1);
                                            return -1; /* canceled by remote */
                                        }
                                        break;
                                    case NAK:
                                        Console.Write(" NAK ");
                                        echoing = false;
                                        break;
                                    default:
                                        Console.Write((char)response);
                                        echoing = true;
                                        break;
                                }
                                }
                                else
                            {
                                Console.Write(" Timeout ");
                                echoing = false;
                            }
                         }
                            catch (TimeoutException ex)
                            {
                               // MessageBox.Show("Timeout while reading from the serial port.", "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            }
                        }
                            MainForm.serialPort.Write(new byte[] { CAN, CAN, CAN }, 0, 3);
                            Console.WriteLine("\nGiving up");
                            len = (int)fs.Position;

                            return -4; /* xmit error */
                        }
                        else
                        {
                            for (retry = 0; retry < 10; ++retry)
                            {
                                MainForm.serialPort.Write(new byte[] { EOT }, 0, 1);
                                if (MainForm.serialPort.ReadByte() == ACK)
                                {
                                    break;
                                }
                            }
                            // Berechnen Sie die tatsächliche empfangene Dateigröße
                            for (int i = 0; i < len; i += bufsz)
                            {
                                actualFileSize += bufsz; // bufsz ist die Größe des Datenpakets
                            }

                            if (actualFileSize == fileSize)
                            {
                                Console.WriteLine($"Dateiübertragung abgeschlossen. Upload:{actualFileSize} Filesize: {fileSize} ");
                            }
                            else
                            {
                                Console.WriteLine($"Fehler: Upload:{actualFileSize} Filesize: {fileSize}");
                            }
                            return (MainForm.serialPort.ReadByte() == ACK) ? len : -5;
                        }
                    }
                }
            
        }

        private ushort CalculateCRC(byte[] data, int offset, int length)
        {
            ushort crc = 0;
            for (int counter = offset; counter < offset + length; counter++)
            {
                crc = (ushort)((crc << 8) ^ crc16tab[(crc >> 8) ^ data[counter]]);
            }
            return crc;
        }

        static readonly ushort[] crc16tab = new ushort[]
        {
               0x0000, 0x1021, 0x2042, 0x3063, 0x4084, 0x50a5, 0x60c6, 0x70e7, 0x8108, 0x9129, 0xa14a, 0xb16b, 0xc18c, 0xd1ad, 0xe1ce, 0xf1ef,
    0x1231, 0x0210, 0x3273, 0x2252, 0x52b5, 0x4294, 0x72f7, 0x62d6, 0x9339, 0x8318, 0xb37b, 0xa35a, 0xd3bd, 0xc39c, 0xf3ff, 0xe3de,
    0x2462, 0x3443, 0x0420, 0x1401, 0x64e6, 0x74c7, 0x44a4, 0x5485, 0xa56a, 0xb54b, 0x8528, 0x9509, 0xe5ee, 0xf5cf, 0xc5ac, 0xd58d,
    0x3653, 0x2672, 0x1611, 0x0630, 0x76d7, 0x66f6, 0x5695, 0x46b4, 0xb75b, 0xa77a, 0x9719, 0x8738, 0xf7df, 0xe7fe, 0xd79d, 0xc7bc,
    0x48c4, 0x58e5, 0x6886, 0x78a7, 0x0840, 0x1861, 0x2802, 0x3823, 0xc9cc, 0xd9ed, 0xe98e, 0xf9af, 0x8948, 0x9969, 0xa90a, 0xb92b,
    0x5af5, 0x4ad4, 0x7ab7, 0x6a96, 0x1a71, 0x0a50, 0x3a33, 0x2a12, 0xdbfd, 0xcbdc, 0xfbbf, 0xeb9e, 0x9b79, 0x8b58, 0xbb3b, 0xab1a,
    0x6ca6, 0x7c87, 0x4ce4, 0x5cc5, 0x2c22, 0x3c03, 0x0c60, 0x1c41, 0xedae, 0xfd8f, 0xcdec, 0xddcd, 0xad2a, 0xbd0b, 0x8d68, 0x9d49,
    0x7e97, 0x6eb6, 0x5ed5, 0x4ef4, 0x3e13, 0x2e32, 0x1e51, 0x0e70, 0xff9f, 0xefbe, 0xdfdd, 0xcffc, 0xbf1b, 0xaf3a, 0x9f59, 0x8f78,
    0x9188, 0x81a9, 0xb1ca, 0xa1eb, 0xd10c, 0xc12d, 0xf14e, 0xe16f, 0x1080, 0x00a1, 0x30c2, 0x20e3, 0x5004, 0x4025, 0x7046, 0x6067,
    0x83b9, 0x9398, 0xa3fb, 0xb3da, 0xc33d, 0xd31c, 0xe37f, 0xf35e, 0x02b1, 0x1290, 0x22f3, 0x32d2, 0x4235, 0x5214, 0x6277, 0x7256,
    0xb5ea, 0xa5cb, 0x95a8, 0x8589, 0xf56e, 0xe54f, 0xd52c, 0xc50d, 0x34e2, 0x24c3, 0x14a0, 0x0481, 0x7466, 0x6447, 0x5424, 0x4405,
    0xa7db, 0xb7fa, 0x8799, 0x97b8, 0xe75f, 0xf77e, 0xc71d, 0xd73c, 0x26d3, 0x36f2, 0x0691, 0x16b0, 0x6657, 0x7676, 0x4615, 0x5634,
    0xd94c, 0xc96d, 0xf90e, 0xe92f, 0x99c8, 0x89e9, 0xb98a, 0xa9ab, 0x5844, 0x4865, 0x7806, 0x6827, 0x18c0, 0x08e1, 0x3882, 0x28a3,
    0xcb7d, 0xdb5c, 0xeb3f, 0xfb1e, 0x8bf9, 0x9bd8, 0xabbb, 0xbb9a, 0x4a75, 0x5a54, 0x6a37, 0x7a16, 0x0af1, 0x1ad0, 0x2ab3, 0x3a92,
    0xfd2e, 0xed0f, 0xdd6c, 0xcd4d, 0xbdaa, 0xad8b, 0x9de8, 0x8dc9, 0x7c26, 0x6c07, 0x5c64, 0x4c45, 0x3ca2, 0x2c83, 0x1ce0, 0x0cc1,
    0xef1f, 0xff3e, 0xcf5d, 0xdf7c, 0xaf9b, 0xbfba, 0x8fd9, 0x9ff8, 0x6e17, 0x7e36, 0x4e55, 0x5e74, 0x2e93, 0x3eb2, 0x0ed1, 0x1ef0
        };

        private void ShowProgressBar()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
        }

        private void HideProgressBar()
        {
            progressBar1.Visible = false;
        }


    }

}

