using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FNC2;

namespace FNC2
{
    public partial class AxesFormBase : Form
    {

        protected int AxeIndex;

        protected GroupBox[] motorDriverBoxes = { new GroupBox(), new GroupBox() };
        protected TableLayoutPanel[] motorTables = { new TableLayoutPanel(), new TableLayoutPanel() };

        public AxesFormBase(int axeIndex)
        {
            InitializeComponent();
            AxeIndex = axeIndex;

            InitializeCheckBoxes();
          //  WireEvents();
        }

        private void AxesFormBase_Load(object sender, EventArgs e)
        {

        }

        private void InitializeCheckBoxes()
        {
            for (int i = 0; i < checkedListBox0.Items.Count; i++) { checkedListBox0.SetItemChecked(i, true); }
            // checkedListBox0.SetItemChecked(1, false);
            checkedListBox0.SetItemChecked(2, false);
           // Driver_ComboBox0.SelectedIndex = 0;
        }

      

        private void WireEvents()
        {
            checkedListBox0.ItemCheck += CheckedListBox_ItemCheck;
        }

        protected void CheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            switch (e.Index)
            {
                case 0:
                    HomingBox.Visible = !checkedListBox0.GetItemChecked(e.Index);
                    break;
                case 1:
                    MotorBox0.Visible = !checkedListBox0.GetItemChecked(e.Index);
                    motorDriverBoxes[0].Visible = !checkedListBox0.GetItemChecked(e.Index);
                    break;
                case 2:
                    MotorBox1.Visible = !checkedListBox0.GetItemChecked(e.Index);
                    motorDriverBoxes[1].Visible = !checkedListBox0.GetItemChecked(e.Index);
                    break;
                  default:
                break;
            }
        }


        protected void Driver_ComboBox0_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateDriverGroupBox(0, Driver_ComboBox0.SelectedIndex);

        }
        protected void Driver_ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateDriverGroupBox(1, Driver_ComboBox1.SelectedIndex);

        }

        protected void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox checkBox)
            {
                //checkBox.Text = checkBox.Checked ? "\u2714" : "";
                checkBox.Text = checkBox.Checked ? "true" : "false";
            }
        }

   

        protected void CreateDriverGroupBox(int motor, int selectedIndex)
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
                label.Text = currentLabels[i] + ":"; // Setze den Label-Text
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

        public void GetDriverComboBox( string name, string drivertype)
        {
            Control[] matches = Controls.Find(name, true);
            if (matches.Length > 0 && matches[0] is ComboBox combobox)
            {
                combobox.SelectedItem = drivertype;
            }
        }

        public void SetTextBoxText(int motor, string name, string text)
        {
            Control[] matches = motorTables[motor].Controls.Find($"{name}_{motor}", true);
            if (matches.Length > 0 && matches[0] is TextBox textBox)
            {
                textBox.Text = text;
            }
        }

        public void SetControlText(string propertyName, string text)
        {
            // Suche global in den Controls
            Control[] globalMatches = Controls.Find(propertyName, true);
            if (globalMatches.Length > 0)
            {
                // Überprüfe den Typ des gefundenen Steuerelements und setze den Text
                if (globalMatches[0] is TextBox globalTextBox)
                {
                    globalTextBox.Text = text;
                }
                else if (globalMatches[0] is CheckBox globalCheckBox)
                {
                    globalCheckBox.Text = text;
                }
            }
        }




    }

    public partial class XAxesForm : AxesFormBase
    {
        public XAxesForm() : base(0)
        {
            //InitializeComponent();
            AxesGroupBox.Text = "Axes X";
        }
    }

    public partial class YAxesForm : AxesFormBase
    {
        public YAxesForm() : base(1)
        {
            //  InitializeComponent();
            AxesGroupBox.Text = "Axes Y";
        }
    }

    public partial class ZAxesForm : AxesFormBase
    {
        public ZAxesForm() : base(1)
        {
            //  InitializeComponent();
            AxesGroupBox.Text = "Axes Z";
        }
    }

    public partial class AAxesForm : AxesFormBase
    {
        public AAxesForm() : base(1)
        {
            //  InitializeComponent();
            AxesGroupBox.Text = "Axes A";
        }
    }

    public partial class BAxesForm : AxesFormBase
    {
        public BAxesForm() : base(1)
        {
            //  InitializeComponent();
            AxesGroupBox.Text = "Axes B";
        }
    }

    public partial class CAxesForm : AxesFormBase
    {
        public CAxesForm() : base(1)
        {
            //  InitializeComponent();
            AxesGroupBox.Text = "Axes C";
        }
    }

}


