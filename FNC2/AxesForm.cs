using System;
using System.IO;

using System.Windows.Forms;
using System.Collections.Generic;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Drawing;



namespace FNC2
{
    public partial class AxesForm : Form
    {
        public AxesForm()
        {
            InitializeComponent();
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.HorizontalScroll.Visible = false;
            flowLayoutPanel1.VerticalScroll.Visible = true;

           

        }

        private void AxesForm_Load(object sender, EventArgs e)
        {
            ApplyCheckedChangedEventToAllCheckBoxes();
            //   buttonParseYAML_Click(null);
            SpindleComboBox.SelectedIndex = 11;

            for (int i = 0; i < checkedListBox1.Items.Count; i++) { checkedListBox1.SetItemChecked(i, true); }
            for (int i = 0; i < checkedListBox2.Items.Count; i++) { checkedListBox2.SetItemChecked(i, true); }

            checkedListBox2.SetItemChecked(2, false);
            checkedListBox2.SetItemChecked(3, false);
            checkedListBox2.SetItemChecked(4, false);
            checkedListBox2.SetItemChecked(5, false);
        }

        private void checkedListBox2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            MainForm form1Instance = Application.OpenForms["MainForm"] as MainForm;
            
            switch (e.Index)
            {
                case 0:
                    form1Instance?.HideButtons("XBtnAxes", !checkedListBox2.GetItemChecked(e.Index));
                    break;
                case 1:
                    form1Instance?.HideButtons("YBtnAxes", !checkedListBox2.GetItemChecked(e.Index));
                    break;
                case 2:
                    form1Instance?.HideButtons("ZBtnAxes", !checkedListBox2.GetItemChecked(e.Index));
                    break;
                case 3:
                    form1Instance?.HideButtons("ABtnAxes", !checkedListBox2.GetItemChecked(e.Index));
                    break;
                case 4:
                    form1Instance?.HideButtons("BBtnAxes", !checkedListBox2.GetItemChecked(e.Index));
                    break;
                case 5:
                    form1Instance?.HideButtons("CBtnAxes", !checkedListBox2.GetItemChecked(e.Index));
                    break;

                default:
                    break;
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            switch (e.Index)
            {
                case 0:
                    ControlInputsBox.Visible = !checkedListBox1.GetItemChecked(e.Index);
                    break;
                case 1:
                    CoolantBox.Visible = !checkedListBox1.GetItemChecked(e.Index);
                    break;
                case 2:
                    I2SOBox.Visible = !checkedListBox1.GetItemChecked(e.Index);
                    break;
                case 3:
                    MacrosBox.Visible = !checkedListBox1.GetItemChecked(e.Index);
                    break;
                case 4:
                    ProbeBox.Visible = !checkedListBox1.GetItemChecked(e.Index);
                    break;
                case 5:
                    SDCardBox.Visible = !checkedListBox1.GetItemChecked(e.Index);
                    break;
                case 6:
                    SPIBox.Visible = !checkedListBox1.GetItemChecked(e.Index);
                    break;
                case 7:
                    SpindleBox.Visible = !checkedListBox1.GetItemChecked(e.Index);
                    break;
                case 8:
                    StartBox.Visible = !checkedListBox1.GetItemChecked(e.Index);
                    break;
                case 9:
                    StatusBox.Visible = !checkedListBox1.GetItemChecked(e.Index);
                    break;
                case 10:
                    TopLevelBox.Visible = !checkedListBox1.GetItemChecked(e.Index);
                    break;
                case 11:
                    UART1Box.Visible = !checkedListBox1.GetItemChecked(e.Index);
                    break;
                case 12:
                    UART2Box.Visible = !checkedListBox1.GetItemChecked(e.Index);
                    break;
                case 13:
                    UserOutputsBox.Visible = !checkedListBox1.GetItemChecked(e.Index);
                    break;

                default:
                    break;
            }
        }

        private void ApplyCheckedChangedEventToAllCheckBoxes()
        {
            foreach (Control control in Controls)
            {
                if (control is CheckBox checkBox)
                {
                    checkBox.CheckedChanged += CheckBox_CheckedChanged;
                    // checkBox.Text = checkBox.Checked ? "\u2714" : "";
                    checkBox.Text = checkBox.Checked ? "true" : "false";
                }
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox checkBox)
            {
                //checkBox.Text = checkBox.Checked ? "\u2714" : "";
                checkBox.Text = checkBox.Checked ? "true" : "false";
            }
        }

        public void buttonParseYAML_Click(string filePath)
        {
            try
            {
               string yamlContent = File.ReadAllText(filePath);
               // string yamlContent = richTextBox1.Text;
                var deserializer = new DeserializerBuilder().Build();
                var yamlObject = deserializer.Deserialize<YamlMappingNode>(yamlContent);

                // Top Level Items
                BoardBox.Text = GetNestedValueFromYaml(yamlObject, "board");
                NameBox.Text = GetNestedValueFromYaml(yamlObject, "name");
                MetaBox.Text = GetNestedValueFromYaml(yamlObject, "meta");
                Arc_toleranceBox.Text = GetNestedValueFromYaml(yamlObject, "arc_tolerance_mm");
                Junction_deviationBox.Text = GetNestedValueFromYaml(yamlObject, "junction_deviation_mm");
                Verbose_errorsCheck.Text = GetNestedValueFromYaml(yamlObject, "verbose_errors");
                Report_inchesCheck.Text = GetNestedValueFromYaml(yamlObject, "report_inches");
                Enable_parkingCheck.Text = GetNestedValueFromYaml(yamlObject, "enable_parking_override_control");
                Use_line_numbersCheck.Text = GetNestedValueFromYaml(yamlObject, "use_line_numbers");
                Planner_Box.Text = GetNestedValueFromYaml(yamlObject, "planner_blocks");

                // start
                Must_homeCheck.Text = GetNestedValueFromYaml(yamlObject, "start", "must_home");
                Deactivate_parkingCheck.Text = GetNestedValueFromYaml(yamlObject, "start", "deactivate_parking");
                Check_limitsCheck.Text = GetNestedValueFromYaml(yamlObject, "start", "check_limits");

                // kinematics
                KinematicsComboBox.Text = GetNestedValueFromYaml(yamlObject, "kinematics");

                // stepping
                EngineComboBox.Text = GetNestedValueFromYaml(yamlObject, "stepping", "engine");
                IdleBox.Text = GetNestedValueFromYaml(yamlObject, "stepping", "idle_ms");
                PulseBox.Text = GetNestedValueFromYaml(yamlObject, "stepping", "pulse_us");
                Dir_delayBox.Text = GetNestedValueFromYaml(yamlObject, "stepping", "dir_delay_us");
                Disable_delayBox.Text = GetNestedValueFromYaml(yamlObject, "stepping", "disable_delay_us");
                SegmentsBox.Text = GetNestedValueFromYaml(yamlObject, "stepping", "segments");

                // i2so
                Bck_PinBox.Text = GetNestedValueFromYaml(yamlObject, "i2so", "bck_pin");
                Data_PinBox.Text = GetNestedValueFromYaml(yamlObject, "i2so", "data_pin");
                Ws_PinBox.Text = GetNestedValueFromYaml(yamlObject, "i2so", "ws_pin");

                // spi
                Miso_pinBox.Text = GetNestedValueFromYaml(yamlObject, "spi", "miso_pin");
                Mosi_PinBox.Text = GetNestedValueFromYaml(yamlObject, "spi", "mosi_pin");
                Sck_PinBox.Text = GetNestedValueFromYaml(yamlObject, "spi", "sck_pin");

                // sdcard
                Cs_PinBox.Text = GetNestedValueFromYaml(yamlObject, "sdcard", "cs_pin");
                Card_detect_PinBox.Text = GetNestedValueFromYaml(yamlObject, "sdcard", "card_detect_pin");
                Frequency_hzBox.Text = GetNestedValueFromYaml(yamlObject, "sdcard", "frequency_hz");

                // coolant
                Flood_pinBox.Text = GetNestedValueFromYaml(yamlObject, "coolant", "flood_pin");
                Mist_pinBox.Text = GetNestedValueFromYaml(yamlObject, "coolant", "mist_pin");
                Delay_coolantBox.Text = GetNestedValueFromYaml(yamlObject, "coolant", "delay_ms");

                // probe
                Probe_pinBox.Text = GetNestedValueFromYaml(yamlObject, "probe", "pin");
                Toolsetter_pinBox.Text = GetNestedValueFromYaml(yamlObject, "probe", "toolsetter_pin");
                Check_mode_startCheck.Text = GetNestedValueFromYaml(yamlObject, "probe", "check_mode_start");

                // status_outputs
                Report_intervalBox.Text = GetNestedValueFromYaml(yamlObject, "status_outputs", "report_interval_ms");
                Idle_pinBox.Text = GetNestedValueFromYaml(yamlObject, "status_outputs", "idle_pin");
                Run_pinBox.Text = GetNestedValueFromYaml(yamlObject, "status_outputs", "run_pin");
                Hold_pinBox.Text = GetNestedValueFromYaml(yamlObject, "status_outputs", "hold_pin");
                Alarm_pinBox.Text = GetNestedValueFromYaml(yamlObject, "status_outputs", "alarm_pin");

                // control
                Safety_door_pinBox.Text = GetNestedValueFromYaml(yamlObject, "control", "safety_door_pin");
                Reset_pinBox.Text = GetNestedValueFromYaml(yamlObject, "control", "reset_pin");
                Feed_hold_pinBox.Text = GetNestedValueFromYaml(yamlObject, "control", "feed_hold_pin");
                Cycle_start_pinBox.Text = GetNestedValueFromYaml(yamlObject, "control", "cycle_start_pin");
                Macro0_pinBox.Text = GetNestedValueFromYaml(yamlObject, "control", "macro0_pin");
                Macro1_pinBox.Text = GetNestedValueFromYaml(yamlObject, "control", "macro1_pin");
                Macro2_pinBox.Text = GetNestedValueFromYaml(yamlObject, "control", "macro2_pin");
                Macro3_pinBox.Text = GetNestedValueFromYaml(yamlObject, "control", "macro3_pin");
                Fault_pinBox.Text = GetNestedValueFromYaml(yamlObject, "control", "fault_pin");
                Estop_pinBox.Text = GetNestedValueFromYaml(yamlObject, "control", "estop_pin");

                // macros
                Startup_line0Box.Text = GetNestedValueFromYaml(yamlObject, "macros", "startup_line0");
                Startup_line1Box.Text = GetNestedValueFromYaml(yamlObject, "macros", "startup_line1");
                Macro0Box.Text = GetNestedValueFromYaml(yamlObject, "macros", "macro0");
                Macro1Box.Text = GetNestedValueFromYaml(yamlObject, "macros", "macro1");
                Macro2Box.Text = GetNestedValueFromYaml(yamlObject, "macros", "macro2");
                Macro3Box.Text = GetNestedValueFromYaml(yamlObject, "macros", "macro3");
                After_homingBox.Text = GetNestedValueFromYaml(yamlObject, "macros", "after_homing");
                After_resetBox.Text = GetNestedValueFromYaml(yamlObject, "macros", "after_reset");
                After_unlockBox.Text = GetNestedValueFromYaml(yamlObject, "macros", "after_unlock");
                M30Box.Text = GetNestedValueFromYaml(yamlObject, "macros", "m30");
                StartupBox.Text = GetNestedValueFromYaml(yamlObject, "macros", "startup");
                ResetBox.Text = GetNestedValueFromYaml(yamlObject, "macros", "reset");
                Post_homing_Box.Text = GetNestedValueFromYaml(yamlObject, "macros", "post_homing");

                // user_outputs
                Analog0_pinBox.Text = GetNestedValueFromYaml(yamlObject, "user_outputs", "analog0_pin");
                Analog1_pinBox.Text = GetNestedValueFromYaml(yamlObject, "user_outputs", "analog1_pin");
                Analog2_pinBox.Text = GetNestedValueFromYaml(yamlObject, "user_outputs", "analog2_pin");
                Analog3_pinBox.Text = GetNestedValueFromYaml(yamlObject, "user_outputs", "analog3_pin");
                Analog0_hzBox.Text = GetNestedValueFromYaml(yamlObject, "user_outputs", "analog0_hz");
                Analog1_hzBox.Text = GetNestedValueFromYaml(yamlObject, "user_outputs", "analog1_hz");
                Analog2_hzBox.Text = GetNestedValueFromYaml(yamlObject, "user_outputs", "analog2_hz");
                Analog3_hzBox.Text = GetNestedValueFromYaml(yamlObject, "user_outputs", "analog3_hz");
                Digital0_pinBox.Text = GetNestedValueFromYaml(yamlObject, "user_outputs", "digital0_pin");
                Digital1_pinBox.Text = GetNestedValueFromYaml(yamlObject, "user_outputs", "digital1_pin");
                Digital2_pinBox.Text = GetNestedValueFromYaml(yamlObject, "user_outputs", "digital2_pin");
                Digital3_pinBox.Text = GetNestedValueFromYaml(yamlObject, "user_outputs", "digital3_pin");
                Digital4_pinBox.Text = GetNestedValueFromYaml(yamlObject, "user_outputs", "digital4_pin");
                Digital5_pinBox.Text = GetNestedValueFromYaml(yamlObject, "user_outputs", "digital5_pin");
                Digital6_pinBox.Text = GetNestedValueFromYaml(yamlObject, "user_outputs", "digital6_pin");
                Digital7_pinBox.Text = GetNestedValueFromYaml(yamlObject, "user_outputs", "digital7_pin");

                // uart1
                txd_pin1.Text = GetNestedValueFromYaml(yamlObject, "uart1", "txd_pin");
                rxd_pin1.Text = GetNestedValueFromYaml(yamlObject, "uart1", "rxd_pin");
                rts_pin1.Text = GetNestedValueFromYaml(yamlObject, "uart1", "rts_pin");
                baud1.Text = GetNestedValueFromYaml(yamlObject, "uart1", "baud");
                mode1.Text = GetNestedValueFromYaml(yamlObject, "uart1", "mode");

                // uart2
                txd_pin2.Text = GetNestedValueFromYaml(yamlObject, "uart2", "txd_pin");
                rxd_pin2.Text = GetNestedValueFromYaml(yamlObject, "uart2", "rxd_pin");
                rts_pin2.Text = GetNestedValueFromYaml(yamlObject, "uart2", "rts_pin");
                baud2.Text = GetNestedValueFromYaml(yamlObject, "uart2", "baud");
                mode2.Text = GetNestedValueFromYaml(yamlObject, "uart2", "mode");

                //Spindle
                SpindleVoid(yamlObject);

                // Axes Pin
                Shared_stepper_disable_pinBox.Text = GetNestedValueFromYaml(yamlObject, "axes", "shared_stepper_disable_pin");
                Shared_stepper_reset_pinBox.Text = GetNestedValueFromYaml(yamlObject, "axes", "shared_stepper_reset_pin");
                Shared_fault_pinBox.Text = GetNestedValueFromYaml(yamlObject, "axes", "shared_fault_pin");
                UpdateAxisFormTextBoxes(MainForm.xaxesForm, "x", yamlObject);
                UpdateAxisFormTextBoxes(MainForm.yaxesForm, "y", yamlObject);
                UpdateAxisFormTextBoxes(MainForm.zaxesForm, "z", yamlObject);
                UpdateAxisFormTextBoxes(MainForm.aaxesForm, "a", yamlObject);
                UpdateAxisFormTextBoxes(MainForm.baxesForm, "b", yamlObject);
                UpdateAxisFormTextBoxes(MainForm.caxesForm, "c", yamlObject);

               

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ein Fehler ist aufgetreten: {ex.Message}");

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

        private void SpindleVoid(YamlMappingNode yamlObject)

        {
            string[] V10 = { "forward_pin", "reverse_pin", "pwm_hz", "output_pin", "enable_pin", "direction_pin", "disable_with_s0", "s0_with_disable", "spinup_ms", "spindown_ms", "tool_num", "off_on_alarm", "speed_map" };
            string[] besc = { "min_pulse_us", "max_pulse_us", "pwm_hz", "output_pin", "enable_pin", "direction_pin", "disable_with_s0", "s0_with_disable", "spinup_ms", "spindown_ms", "tool_num", "off_on_alarm", "speed_map" };
            string[] DAC = { "output_pin", "enable_pin", "direction_pin", "disable_with_s0", "s0_with_disable", "spinup_ms", "spindown_ms", "tool_num", "off_on_alarm", "speed_map" };
            string[] Huanyang = { "uart_num", "modbus_id", "tool_num", "off_on_alarm", "speed_map" };
            string[] YL620 = { "uart_num", "modbus_id", "tool_num", "off_on_alarm", "speed_map" };
            string[] H100 = { "uart_num", "modbus_id", "tool_num", "off_on_alarm", "speed_map" };
            string[] NowForever = { "uart_num", "modbus_id", "tool_num", "off_on_alarm", "speed_map" };
            string[] pwm = { "pwm_hz", "output_pin", "enable_pin", "direction_pin", "disable_with_s0", "s0_with_disable", "spinup_ms", "spindown_ms", "tool_num", "off_on_alarm", "speed_map" };
            string[] HBridge = { "pwm_hz", "enable_pin", "output_ccw_pin", "output_cw_pin", "disable_with_s0", "s0_with_disable", "spinup_ms", "spindown_ms", "tool_num", "off_on_alarm", "speed_map" };
            string[] Laser = { "pwm_hz", "output_pin", "enable_pin", "disable_with_s0", "s0_with_disable", "tool_num", "off_on_alarm", "speed_map" };
            string[] relay = { "output_pin", "enable_pin", "direction_pin", "disable_with_s0", "s0_with_disable", "spinup_ms", "spindown_ms", "tool_num", "off_on_alarm", "speed_map" };
            string[] NoSpindle = { };

            string[] SpindleNames = { "10V", "besc", "DAC", "Huanyang", "YL620", "H100", "NowForever", "pwm", "HBridge", "Laser", "relay", "NoSpindle" };
            string[][] SpindleVar = { V10, besc, DAC, Huanyang, YL620, H100, NowForever, pwm, HBridge, Laser, relay, NoSpindle };

            foreach (var driverType in SpindleNames)
            {
                if (yamlObject.Children.ContainsKey(new YamlScalarNode(driverType)))
                {
                    {
                        SpindleComboBox.SelectedItem = driverType;

                        foreach (var propertyNameArray in SpindleVar)
                        {
                            foreach (var propertyName in propertyNameArray)
                            {
                                // Hier führst du Aktionen für jeden propertyName durch
                                SetControlText(propertyName, GetNestedValueFromYaml(yamlObject, driverType, propertyName));

                            }
                        }
                    }
                }
            }
        }

        private void UpdateAxisFormTextBoxes(AxesFormBase axisForm, string axisName, YamlMappingNode yamlObject)
        {
            if (axisForm == null || yamlObject == null) return;

            string[] stepstick = { "direction_pin", "step_pin", "disable_pin", "ms1_pin", "ms2_pin", "ms3_pin", "reset_pin" };
            string[] tmc_2130 = { "direction_pin", "step_pin", "disable_pin", "r_sense_ohms", "run_amps", "hold_amps", "microsteps", "stallguard", "stallguard_debug", "toff_disable", "toff_stealthchop", "toff_coolstep", "run_mode", "homing_mode", "use_enable", "cs_pin", "spi_index" };
            string[] tmc_2208 = { "direction_pin", "step_pin", "disable_pin", "r_sense_ohms", "run_amps", "hold_amps", "microsteps", "uart_num" };
            string[] tmc_2209 = { "direction_pin", "step_pin", "disable_pin", "r_sense_ohms", "run_amps", "hold_amps", "microsteps", "stallguard", "stallguard_debug", "toff_disable", "toff_stealthchop", "toff_coolstep", "run_mode", "homing_mode", "use_enable", "cs_pin", "addr", "uart_num" };
            string[] tmc_5160 = { "direction_pin", "step_pin", "disable_pin", "r_sense_ohms", "run_amps", "hold_amps", "microsteps", "stallguard", "stallguard_debug", "toff_disable", "toff_stealthchop", "toff_coolstep", "run_mode", "homing_mode", "use_enable", "cs_pin", "tpfd" };
            string[] tmc_5160Pro = { "direction_pin", "step_pin", "disable_pin", "cs_pin", "spi_index", "use_enable", "CHOPCONF", "COOLCONF", "THIGH", "TCOOLTHRS", "GCONF", "PWMCONF", "IHOLD_IRUN" };
            string[] tmc_2160Pro = { "direction_pin", "step_pin", "disable_pin", "cs_pin", "spi_index", "use_enable", "CHOPCONF", "COOLCONF", "THIGH", "TCOOLTHRS", "GCONF", "PWMCONF", "IHOLD_IRUN" };
            string[] driverTypes = { "stepstick", "tmc_2130", "tmc_2208", "tmc_2209", "tmc_5160", "tmc_5160Pro", "tmc_2160Pro" };
            string[][] driverTyp = { stepstick, tmc_2130, tmc_2208, tmc_2209, tmc_5160, tmc_5160Pro, tmc_2160Pro };

            string[] motorPropertyNames = { "limit_pos_pin", "limit_all_pin", "limit_neg_pin", "hard_limits", "pulloff_mm" };
            string[] axisPropertyNames = { "steps_per_mm", "max_rate_mm_per_min", "acceleration_mm_per_sec2", "max_travel_mm", "soft_limits" };
            string[] homingPropertyNames = { "cycle", "positive_direction", "allow_single_axis", "mpos_mm", "feed_mm_per_min", "seek_mm_per_min", "settle_ms", "seek_scaler", "feed_scaler" };

            foreach (var propertyName in axisPropertyNames)
            {
                axisForm.SetControlText(propertyName, GetNestedValueFromYaml(yamlObject, "axes", axisName, propertyName));
            }

            foreach (var propertyName in homingPropertyNames)
            {
                axisForm.SetControlText(propertyName, GetNestedValueFromYaml(yamlObject, "axes", axisName, "homing", propertyName));
            }

            if (yamlObject.Children.TryGetValue(new YamlScalarNode("axes"), out var axesNode) && axesNode is YamlMappingNode axisNode
                && axisNode.Children.TryGetValue(new YamlScalarNode(axisName), out var xNode) && xNode is YamlMappingNode xMappingNode)
            {
                checkedListBox2.SetItemChecked(GetAxisIndex(axisName), true);

                for (int motorIndex = 0; motorIndex <= 1; motorIndex++)
                {
                    string motorKey = $"motor{motorIndex}";

                    if (xMappingNode.Children.TryGetValue(new YamlScalarNode(motorKey), out var motorNode) && motorNode is YamlMappingNode)
                    {
                        axisForm.checkedListBox0.SetItemChecked(motorIndex + 1, true);

                        foreach (var driverType in driverTypes)
                        {
                            if (motorNode is YamlMappingNode motorMappingNode &&
                                motorMappingNode.Children.TryGetValue(new YamlScalarNode(driverType), out _))
                            {
                                axisForm.GetDriverComboBox("Driver_ComboBox" + motorIndex, driverType);

                                foreach (var propertyNameArray in driverTyp)
                                {
                                    foreach (var propertyName in propertyNameArray)
                                    {
                                        // Hier führst du Aktionen für jeden propertyName durch
                                        axisForm.SetTextBoxText(motorIndex, propertyName, GetNestedValueFromYaml(yamlObject, "axes", axisName, motorKey, driverType, propertyName));
                                    }
                                }
                            }
                        }
                        foreach (var propertyName in motorPropertyNames)
                        {
                            axisForm.SetControlText(propertyName + motorIndex, GetNestedValueFromYaml(xMappingNode, motorKey, propertyName));
                        }
                    }
                    else
                    {
                        axisForm.checkedListBox0.SetItemChecked(motorIndex + 1, false);
                    }
                }
            }
        }

        private int GetAxisIndex(string axisName)
        {
            switch (axisName)
            {
                case "x": return 0;
                case "y": return 1;
                case "z": return 2;
                case "a": return 3;
                case "b": return 4;
                case "c": return 5;
                default: return -1;
            }
        }



        private string GetNestedValueFromYaml(YamlMappingNode yamlObject, params string[] keys)
        {
            YamlNode currentNode = yamlObject;

            foreach (string key in keys)
            {
                if (currentNode is not YamlMappingNode mappingNode || !mappingNode.Children.ContainsKey(new YamlScalarNode(key)))
                {
                    return null;  // Eintrag nicht gefunden oder kein verschachtelter Knoten, daher null zurückgeben
                }

                currentNode = mappingNode[new YamlScalarNode(key)];
            }

            return GetValueFromYaml(currentNode);
        }
        private string GetValueFromYaml(YamlNode yamlNode)
        {
            return yamlNode switch
            {
                YamlMappingNode mappingNode => new SerializerBuilder().Build().Serialize(mappingNode).TrimEnd('\n', '\r', ' ', ':'),
                YamlScalarNode scalarNode => scalarNode.ToString(),
                _ => null,
            };
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateDriverGroupBox( SpindleComboBox.SelectedIndex);

        }
       // TableLayoutPanel driverTable = null;
        private void CreateDriverGroupBox( int selectedIndex)
        {
            tableLayoutPanel16.Controls.Clear();
            tableLayoutPanel16.RowStyles.Clear();
            tableLayoutPanel16.RowCount = 0;

            var rowsPerSelection = new Dictionary<int, string[]>
            {
                { 0, new string[] { "forward_pin", "reverse_pin", "pwm_hz", "output_pin", "enable_pin", "direction_pin", "disable_with_s0", "s0_with_disable", "spinup_ms", "spindown_ms", "tool_num", "off_on_alarm", "speed_map" } },
                { 1, new string[] { "min_pulse_us", "max_pulse_us", "pwm_hz", "output_pin", "enable_pin", "direction_pin", "disable_with_s0", "s0_with_disable", "spinup_ms", "spindown_ms", "tool_num", "off_on_alarm", "speed_map"} },
                { 2, new string[] { "output_pin", "enable_pin", "direction_pin", "disable_with_s0", "s0_with_disable", "spinup_ms", "spindown_ms", "tool_num", "off_on_alarm", "speed_map" } },
                { 3, new string[] { "uart_num", "modbus_id", "tool_num", "off_on_alarm", "speed_map" } },
                { 4, new string[] { "uart_num", "modbus_id", "tool_num", "off_on_alarm", "speed_map" } },
                { 5, new string[] { "uart_num", "modbus_id", "tool_num", "off_on_alarm", "speed_map" } },
                { 6, new string[] { "uart_num", "modbus_id", "tool_num", "off_on_alarm", "speed_map" } },
                { 7, new string[] { "pwm_hz", "output_pin", "enable_pin", "direction_pin", "disable_with_s0", "s0_with_disable", "spinup_ms", "spindown_ms", "tool_num", "off_on_alarm", "speed_map"} },
                { 8, new string[] { "pwm_hz", "enable_pin", "output_ccw_pin", "output_cw_pin", "disable_with_s0", "s0_with_disable", "spinup_ms", "spindown_ms", "tool_num", "off_on_alarm", "speed_map" } },
                { 9, new string[] { "pwm_hz", "output_pin", "enable_pin", "disable_with_s0", "s0_with_disable", "tool_num", "off_on_alarm", "speed_map"} },
                { 10,new string[] { "output_pin", "enable_pin", "direction_pin", "disable_with_s0", "s0_with_disable", "spinup_ms", "spindown_ms", "tool_num", "off_on_alarm", "speed_map"} },
                { 11,new string[] { } },

                };

            string[] currentLabels = rowsPerSelection.ContainsKey(selectedIndex) ? rowsPerSelection[selectedIndex] : new string[0];
            for (int i = 0; i < currentLabels.Length; i++)
            {
                tableLayoutPanel16.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                int rowIndex = tableLayoutPanel16.RowCount++;

                Label label = new Label();
                label.Text = currentLabels[i] + ":"; // Setze den Label-Text
                label.AutoSize = true; // Ermöglicht, dass das Label die optimale Breite hat

                TextBox textBox = new TextBox();
                textBox.Size = new Size(142, 26);
                textBox.Name = $"{currentLabels[i]}";

                tableLayoutPanel16.Controls.Add(label, 0, rowIndex);
                tableLayoutPanel16.Controls.Add(textBox, 1, rowIndex);
            }
        }

        public YamlMappingNode BuildYamlStructure()
        {
            var rootNode = new YamlMappingNode
    {
                 { "board", BoardBox.Text },
                 { "name", NameBox.Text },
                 { "meta", MetaBox.Text },

                 { "arc_tolerance_mm", Arc_toleranceBox.Text },
                 { "junction_deviation_mm", Junction_deviationBox.Text },
                 { "verbose_errors", Verbose_errorsCheck.Text },
                 { "report_inches", Report_inchesCheck.Text },
                 { "enable_parking_override_control", Enable_parkingCheck.Text },
                 { "use_line_numbers", Use_line_numbersCheck.Text },
                 { "planner_blocks", Planner_Box.Text },

                  { "kinematics", new YamlMappingNode
                    {
                        { KinematicsComboBox.Text,  null  }
                  } },

                 { "start", new YamlMappingNode
                    {
                        { "must_home", Must_homeCheck.Text },
                        { "deactivate_parking", Deactivate_parkingCheck.Text },
                        { "check_limits",Check_limitsCheck.Text }
                } },

                   { "steping", new YamlMappingNode
                    {
                        { "engine", EngineComboBox.Text },
                        { "idle_ms", IdleBox.Text },
                        { "pulse_us", PulseBox.Text },
                        { "dir_delay_us", Dir_delayBox.Text },
                        { "disable_delay_us", Disable_delayBox.Text },
                        { "segments", SegmentsBox.Text }
                   } },

                    { "i2so", new YamlMappingNode
                    {
                        { "bck_pin", Bck_PinBox.Text },
                        { "data_pin", Data_PinBox.Text },
                        { "ws_pin", Ws_PinBox.Text }
                    } },

                    { "spi", new YamlMappingNode
                    {
                        { "miso_pin", Miso_pinBox.Text },
                        { "mosi_pin", Mosi_PinBox.Text },
                        { "sck_pin", Sck_PinBox.Text }
                    } },

                     { "sdcard", new YamlMappingNode
                    {
                        { "cs_pin", Cs_PinBox.Text },
                        { "card_detect_pin", Card_detect_PinBox.Text },
                        { "frequency_hz", Frequency_hzBox.Text }
                    } },

                      { "coolant", new YamlMappingNode
                    {
                        { "flood_pin", Flood_pinBox.Text },
                        { "mist_pin", Mist_pinBox.Text},
                        { "delay_ms", Delay_coolantBox.Text }
                    } },


                         { "probe", new YamlMappingNode
                    {
                        { "pin", Probe_pinBox.Text},
                        { "toolsetter_pin", Toolsetter_pinBox.Text },
                        { "check_mode_start", Check_mode_startCheck.Text}
                    }},


                        { "status_outputs", new YamlMappingNode
                    {
                        { "report_interval_ms", "I2SO.0:low" },
                        { "idle_pin", "I2SO.0:low" },
                         { "run_pin", "I2SO.0:low" },
                          { "hold_pin", "I2SO.0:low" },
                        { "alarm_pin", "I2SO.0:low" }
                                  } },


     { "control", new YamlMappingNode
                    {
                        { "safety_door_pin", "I2SO.0:low" },
                        { "reset_pin", "I2SO.0:low" },
                        { "feed_hold_pin", "I2SO.0:low" },
                        { "cycle_start_pin", "I2SO.0:low" },
                        { "macro0_pin", "I2SO.0:low" },
                        { "macro1_pin", "I2SO.0:low" },
                        { "macro2_pin", "I2SO.0:low" },
                        { "macro3_pin", "I2SO.0:low" },
                        { "fault_pin", "I2SO.0:low" } ,
                        { "estop_pin", "I2SO.0:low" } }
                    },

          { "macros", new YamlMappingNode
                    {
                        { "startup_line0", "I2SO.0:low" },
                        { "startup_line1", "I2SO.0:low" },
                        { "macro0", "I2SO.0:low" },
                        { "macro1", "I2SO.0:low" },
                        { "macro2", "I2SO.0:low" },
                        { "macro3", "I2SO.0:low" },
                        { "after_homing", "I2SO.0:low" },
                        { "after_reset", "I2SO.0:low" },
                        { "after_unlock", "I2SO.0:low" } ,
                        { "m30", "I2SO.0:low" },
                        { "startup", "I2SO.0:low" },
                        { "reset", "I2SO.0:low" } ,
                        { "post_homing", "I2SO.0:low" }
                    }},


                    { "user_outputs", new YamlMappingNode
                    {
                        { "analog0_pin", "I2SO.0:low" },
                        { "analog1_pin", "I2SO.0:low" },
                        { "analog2_pin", "I2SO.0:low" },
                        { "analog3_pin", "I2SO.0:low" },
                        { "analog0_hz", "I2SO.0:low" },
                        { "analog1_hz", "I2SO.0:low" },
                        { "analog2_hz", "I2SO.0:low" },
                        { "analog3_hz", "I2SO.0:low" },
                        { "digital0_pin", "I2SO.0:low" } ,
                        { "digital1_pin", "I2SO.0:low" },
                        { "digital2_pin", "I2SO.0:low" },
                        { "digital3_pin", "I2SO.0:low" } ,
                        { "digital4_pin", "I2SO.0:low" },
                        { "digital5_pin", "I2SO.0:low" },
                        { "digital6_pin", "I2SO.0:low" },
                        { "digital7_pin", "I2SO.0:low" }
                    }},








            {
                "axes", new YamlMappingNode
                    {
                        { "shared_stepper_disable_pin", "I2SO.0:low" },
                        { "shared_stepper_reset_pin", "I2SO.0:low" },
                        { "shared_fault_pin", "I2SO.0:low" },
                        { "x", new YamlMappingNode
                            {
                                { "steps_per_mm", "157.50" },
                                { "max_rate_mm_per_min", "10000" },
                                { "acceleration_mm_per_sec2", "1300" },
                                { "max_travel_mm", "300" },
                                { "soft_limits", "jk" },
                                { "homing", new YamlMappingNode
                                    {
                                        { "cycle", "kk" },
                                        { "positive_direction", "mk" } }} } } }}





    };

            return rootNode;
        }

        public void SaveYamlFragmentToFile(YamlMappingNode rootNode, string filePath)
        {
            try
            {
                using (var writer = new StreamWriter(filePath))
                {
                    var serializer = new SerializerBuilder().Build();
                    var yaml = serializer.Serialize(rootNode);
                    writer.WriteLine(yaml);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Speichern der YAML-Datei: {ex.Message}");
            }
        }

       
    }
}
