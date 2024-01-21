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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;



namespace FNC2
    {

    public partial class MainForm : Form
    {

        // Deklariere die Objekte, initialisiere sie jedoch nicht bei der Deklaration
        private TerminalForm terminalForm;
        private WifiForm wifiForm;
        private FilesForm filesForm;
        private UpdateForm updateForm;
        private AxesForm axesForm;

        public static XAxesForm xaxesForm;
        public static YAxesForm yaxesForm;
        public static ZAxesForm zaxesForm;
        public static AAxesForm aaxesForm;
        public static BAxesForm baxesForm;
        public static CAxesForm caxesForm;



        public static SerialPort serialPort;
        string receivedDataBuffer = "";

        private static Timer statusCheckTimer = new Timer();
        public static bool IsSerialPortOpen { get; private set; }
        bool isPortOpen = IsSerialPortOpen;

        public MainForm()
        {
            InitializeComponent();
            terminalForm = new TerminalForm();
            wifiForm = new WifiForm();
            filesForm = new FilesForm();
            updateForm = new UpdateForm();
            axesForm = new AxesForm();

            xaxesForm = new XAxesForm();
            yaxesForm = new YAxesForm(); 
            zaxesForm = new ZAxesForm();
            aaxesForm = new AAxesForm(); 
            baxesForm = new BAxesForm();
            caxesForm = new CAxesForm();
            BaudrateBox.Text = "115200";


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ComPortBox_DropDown(null, EventArgs.Empty);
            AxesSubPanel.Visible = false;
            StartStatusCheck(); // Starte den Status-Check

            OpenFormAndSetSubPanel(terminalForm);
        }

        #region Serial

        public  void StartStatusCheck()
        {
            statusCheckTimer.Interval = 1000; // 1 Sekunde
            statusCheckTimer.Tick += new EventHandler(StatusCheckTimer_Tick);
            statusCheckTimer.Start();
        }

        private  void StatusCheckTimer_Tick(object sender, EventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                IsSerialPortOpen = true;
                connectBtn.Text = "close";
                ComPortBox.Enabled = false;
                BaudrateBox.Enabled = false;
            }
            else
            {
                connectBtn.Text = "connect";
                IsSerialPortOpen = false;
                ComPortBox.Enabled = true;
                BaudrateBox.Enabled = true;
            }

            if (ComPortBox.Text == "")
            {
                connectBtn.Text = "<-select Port";
              
            }
           

        }

        private void ComPortBox_DropDown(object sender, EventArgs e)
        {
            ComPortBox.Items.Clear(); // Lösche die vorhandenen Elemente in der ComboBox
            string[] ports = SerialPort.GetPortNames(); // Suche nach verfügbaren COM-Ports
            if (ports.Length > 0)
            {
                ComPortBox.Items.AddRange(ports);   // Füge die verfügbaren Ports zur ComboBox hinzu
                ComPortBox.SelectedIndex = 0; // Wähle den ersten Port aus (optional)
            }
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {

            if (connectBtn.Text == "close")
            {
                serialPort.Close();
                return;
            }
            if (ComPortBox.Text != "")
            {
                string selectedPort = ComPortBox.SelectedItem.ToString();
                int selectedBaudRate = Convert.ToInt32(BaudrateBox.SelectedItem.ToString());
                serialPort = new SerialPort(selectedPort, selectedBaudRate, Parity.None, 8, StopBits.One);
           
            try
            {
                serialPort.Open();
                if (serialPort.IsOpen)
                {
                   
                    Console.WriteLine($"Verbindung hergestellt. Port: {serialPort.PortName} Baudrate: {serialPort.BaudRate}");
                    serialPort.DataReceived += SerialPort_DataReceived;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Verbindungsaufbau: " + ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Schließen der seriellen Verbindung, wenn sie geöffnet ist
               // if (serialPort.IsOpen)
                //    serialPort.Close();
            }
            }
            //Console.ReadLine(); // Hält das Konsolenfenster geöffnet, damit du das Ergebnis sehen kannst

        }
        
        // Eventhandler für eingehende Daten (falls benötigt)
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
           // string receivedData = serialPort.ReadExisting();
           // terminalForm.DisplayReceivedData(receivedData);
            // Verwende die Instanz von TerminalForm, um die Methode aufzurufen
            // Beachte: terminalForm müsste ebenfalls statisch sein, wenn diese Methode statisch bleibt
            receivedDataBuffer += serialPort.ReadExisting();
            while (receivedDataBuffer.Contains("\r\n"))
            {
                int endIndex = receivedDataBuffer.IndexOf("\r\n");
                if (endIndex >= 0)
                {
                    string completeMessage = receivedDataBuffer.Substring(0, endIndex)+ "\r\n";
                    Invoke(new Action(() =>
                    {
                        terminalForm.DisplayReceivedData(completeMessage);
                    }));
                    filesForm.ParseFS(completeMessage);

                    receivedDataBuffer = receivedDataBuffer.Remove(0, endIndex + 2); // +2 für \r\n
                }
                else
                {
                    // Wenn kein Zeilenende gefunden wurde, breche die Schleife ab
                    break;
                }
            }
        }


        #endregion Serial



        #region GUI
      
      
        public void HideButtons(string name, bool state )
        {
           Button button= Controls.Find(name, true).FirstOrDefault() as Button;
           button.Visible = state;
        }


        private void AxesBtn_Click(object sender, EventArgs e) => OpenFormAndSetSubPanel(axesForm, true);
        private void TerminalBtn_Click(object sender, EventArgs e) => OpenFormAndSetSubPanel(terminalForm);
        private void WifiBtn_Click(object sender, EventArgs e) => OpenFormAndSetSubPanel(wifiForm);
        private void LocalFilesBtn_Click(object sender, EventArgs e) => OpenFormAndSetSubPanel(filesForm);
        private void XBtnAxes_Click(object sender, EventArgs e) => OpenFormAndSetSubPanel(xaxesForm, true);
        private void YBtnAxes_Click(object sender, EventArgs e) => OpenFormAndSetSubPanel(yaxesForm, true);
        private void ZBtnAxes_Click(object sender, EventArgs e) => OpenFormAndSetSubPanel(zaxesForm, true);
        private void ABtnAxes_Click(object sender, EventArgs e) => OpenFormAndSetSubPanel(aaxesForm, true);
        private void BBtnAxes_Click(object sender, EventArgs e) => OpenFormAndSetSubPanel(baxesForm, true);
        private void CBtnAxes_Click(object sender, EventArgs e) => OpenFormAndSetSubPanel(caxesForm, true);
        private void UpdateFirmwareBtn_Click(object sender, EventArgs e) => OpenFormAndSetSubPanel(updateForm);

        private void OpenFormAndSetSubPanel(Form form, bool showAxesSubPanel = false)
        {
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            if (!RightPanel.Controls.Contains(form))
            {
                RightPanel.Controls.Add(form); // Füge die TerminalForm zum Panel hinzu
            }

            if (!form.Visible) // Überprüfe, ob die Form bereits sichtbar ist
            {
                form.Show();
                form.BringToFront(); // Bring die Form nach vorne, wenn sie bereits sichtbar ist
            }
            else
            {
                form.BringToFront();// Bring die Form nach vorne, wenn sie bereits sichtbar ist
            }
            AxesSubPanel.Visible = showAxesSubPanel;
        }


        private void OpenConfigFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "FNC config|*.yaml|All files|*.*"; 
            fileDialog.Title = "Select a config File";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                OpenFormAndSetSubPanel(axesForm, true);
                for (int i = 0; i <axesForm.checkedListBox2.Items.Count; i++) { axesForm.checkedListBox2.SetItemChecked(i, false); }

                axesForm.buttonParseYAML_Click(fileDialog.FileName);
               
            }
        }

        private void SaveConfigFileBtn_Click(object sender, EventArgs e)
        {
            string filePath = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())), "test.yaml");

            var rootNode = axesForm.BuildYamlStructure();
            axesForm.SaveYamlFragmentToFile(rootNode, filePath);
        }

        private void SendToBoardBtn_Click(object sender, EventArgs e)
        {

        }

        private void ReadFromBoardBtn_Click(object sender, EventArgs e)
        {
            
        }


        #endregion GUI

    }
}
