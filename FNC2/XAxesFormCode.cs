using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FNC2
{
    public partial class XAxesFormCode : Form
    {
        public XAxesFormCode()
        {
            InitializeComponent();
            for (int i = 0; i < checkedListBox0.Items.Count; i++) { checkedListBox0.SetItemChecked(i, true); }
           // checkedListBox0.SetItemChecked(1, false);
            checkedListBox0.SetItemChecked(2, false);
        }

        private void XAxesForm_Load(object sender, EventArgs e)
        {
            
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox checkBox)
            {
                //checkBox.Text = checkBox.Checked ? "\u2714" : "";
                checkBox.Text = checkBox.Checked ? "true" : "false";
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            switch (e.Index)
            {
                case 0:
                    HomingBox.Visible = !checkedListBox0.GetItemChecked(e.Index);
                    break;
                case 1:
                    Motor_0Box.Visible = !checkedListBox0.GetItemChecked(e.Index);
                    motorDriverBoxes[0].Visible = !checkedListBox0.GetItemChecked(e.Index);
                    break;
                case 2:
                    Motor_1Box.Visible = !checkedListBox0.GetItemChecked(e.Index);
                    motorDriverBoxes[1].Visible= !checkedListBox0.GetItemChecked(e.Index);
                    break;
            

                default:
                    break;
            }
        }


        public GroupBox[] motorDriverBoxes = { new GroupBox(), new GroupBox() };
        private TableLayoutPanel[] motorTables = { new TableLayoutPanel(), new TableLayoutPanel() };
        private void Driver0_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Driver_SelectedIndex(0, Driver_ComboBox0.SelectedIndex);
        }

        private void Driver1_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Driver_SelectedIndex(1, Driver_ComboBox1.SelectedIndex);
        }

        public void Driver_SelectedIndex(int motor, int selectedIndex)
        {
            GroupBox driverBox = motorDriverBoxes[motor];
            TableLayoutPanel driverTable = motorTables[motor];


            if (driverBox == null)
            {
                driverBox = new GroupBox();
            }
            else
            {
                driverBox.Controls.Clear();
            }


            if (driverTable == null)
            {
                driverTable = new TableLayoutPanel();
                motorTables[motor] = driverTable;
                driverTable.Dock = DockStyle.Fill;
                driverTable.ColumnCount = 2;
            }
            else
            {
                driverTable.Controls.Clear();
                driverTable.RowStyles.Clear();
                driverTable.RowCount = 0;
            }

            driverBox.Controls.Add(driverTable);
            driverTable.Dock = DockStyle.Fill;
            driverTable.ColumnCount = 2;
            

            driverBox.Controls.Add(driverTable);
            flowLayoutPanel2.Controls.Add(driverBox);

            var rowsPerSelection = new Dictionary<int, string[]>
            {
                { 0, new string[] { "direction_pin", "step_pin", "disable_pin", "ms1_pin", "ms2_pin", "ms3_pin", "reset_pin" } },
                { 1, new string[] { "direction_pin", "step_pin", "disable_pin", "r_sense_ohms", "run_amps", "hold_amps", "microsteps", "uart_num" } },
                { 2, new string[] { "direction_pin", "step_pin", "disable_pin", "r_sense_ohms", "run_amps", "hold_amps", "microsteps", "stallguard", "stallguard_debug", "toff_disable", "toff_stealthchop", "toff_coolstep", "run_mode", "homing_mode", "use_enable", "cs_pin", "spi_index" } },
                { 3, new string[] { "direction_pin", "step_pin", "disable_pin", "r_sense_ohms", "run_amps", "hold_amps", "microsteps", "stallguard", "stallguard_debug", "toff_disable", "toff_stealthchop", "toff_coolstep", "run_mode", "homing_mode", "use_enable", "cs_pin", "addr", "uart_num" } },
                { 4, new string[] { "direction_pin", "step_pin", "disable_pin", "r_sense_ohms", "run_amps", "hold_amps", "microsteps", "stallguard", "stallguard_debug", "toff_disable", "toff_stealthchop", "toff_coolstep", "run_mode", "homing_mode", "use_enable", "cs_pin", "tpfd" } },
                { 5, new string[] { "direction_pin", "step_pin", "disable_pin", "cs_pin", "spi_index", "use_enable", "CHOPCONF", "COOLCONF", "THIGH", "TCOOLTHRS", "GCONF", "PWMCONF", "IHOLD_IRUN" } },
                { 6, new string[] { "direction_pin", "step_pin", "disable_pin", "cs_pin", "spi_index", "use_enable", "CHOPCONF", "COOLCONF", "THIGH", "TCOOLTHRS", "GCONF", "PWMCONF", "IHOLD_IRUN"} },

                };

            string[] currentLabels = rowsPerSelection.ContainsKey(selectedIndex) ? rowsPerSelection[selectedIndex] : new string[0];
            for (int i = 0; i < currentLabels.Length; i++)
            {
                driverTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                int rowIndex = driverTable.RowCount++;

                Label label = new Label();
                label.Text = currentLabels[i]+":"; // Setze den Label-Text
                label.AutoSize = true; // Ermöglicht, dass das Label die optimale Breite hat

                TextBox textBox = new TextBox();
                textBox.Size = new Size(142, 26);
                textBox.Name = $"{currentLabels[i]}_{motor}";
               
                //currentLabels[i]_motor.Text = "moin";
                driverTable.Controls.Add(label, 0, rowIndex);
                driverTable.Controls.Add(textBox, 1, rowIndex);
            }
            driverBox.Text = $"Motor {motor} Driver";
            driverBox.ForeColor = Color.Silver;
            driverBox.AutoSize = true;
            driverTable.AutoSize = true;

          
        }

        public void SetTextBoxText(string name, int motor, string text)
        {
            Control[] matches = motorTables[motor].Controls.Find($"{name}_{motor}", true);
            if (matches.Length > 0 && matches[0] is TextBox textBox)
            {
                textBox.Text = text;
            }
        }


    }
}
