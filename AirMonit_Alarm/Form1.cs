using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AirMonit_Alarm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            int checkerror = checkAlarms();

            if (checkBox1.Checked && checkerror == 0)
            {
                XMLWriter();
                checkBox1.Text = "Off";
            }
            else{
                if(checkBox1.Text != "On")
                {
                    checkBox1.Text = "On";
                }    
            }
        }

        private int checkAlarms()
        {
            int parsedValue;
            int error = 0;
            if (checkBox2.Checked)
            {
                if (textBox1.Text != "")
                {
                    if (!int.TryParse(textBox1.Text, out parsedValue))
                    {
                        MessageBox.Show("Please enter a numeric value!\n");
                        error++;
                    }
                }
                if (textBox2.Text != "")
                {
                    if (!int.TryParse(textBox2.Text, out parsedValue))
                    {
                        MessageBox.Show("Please enter a numeric value!\n");
                        error++;
                    }
                }
                if (textBox3.Text != "")
                {
                    if (!int.TryParse(textBox3.Text, out parsedValue))
                    {
                        MessageBox.Show("Please enter a numeric value!\n");
                        error++;
                    }
                }
                if (textBox4.Text != "" && textBox5.Text != "")
                {
                    if ((!int.TryParse(textBox4.Text, out parsedValue)) || (!int.TryParse(textBox5.Text, out parsedValue)))
                    {
                        MessageBox.Show("Please enter a numeric value!\n");
                        error++;
                    }
                    else
                    {
                        int minval = Int32.Parse(textBox4.Text);
                        int maxval = Int32.Parse(textBox5.Text);

                        if (minval >= maxval)
                        {
                            MessageBox.Show("Error on between values, please check min/max\n");
                            error++;
                        }
                    }
                }
                else
                {
                    if (textBox4.Text != "" || textBox5.Text != "")
                    {
                        MessageBox.Show("Please fill both values!\n");
                        error++;
                    }
                }
            }

            if (checkBox3.Checked)
            {
                if (textBox10.Text != "")
                {
                    if (!int.TryParse(textBox10.Text, out parsedValue))
                    {
                        MessageBox.Show("Please enter a numeric value!\n");
                        error++;
                    }
                }
                if (textBox9.Text != "")
                {
                    if (!int.TryParse(textBox9.Text, out parsedValue))
                    {
                        MessageBox.Show("Please enter a numeric value!\n");
                        error++;
                    }
                }
                if (textBox8.Text != "")
                {
                    if (!int.TryParse(textBox8.Text, out parsedValue))
                    {
                        MessageBox.Show("Please enter a numeric value!\n");
                        error++;
                    }
                }
                if (textBox7.Text != "" && textBox6.Text != "")
                {
                    if ((!int.TryParse(textBox7.Text, out parsedValue)) || (!int.TryParse(textBox6.Text, out parsedValue)))
                    {
                        MessageBox.Show("Please enter a numeric value!\n");
                        error++;
                    }
                    else
                    {
                        int minval = Int32.Parse(textBox7.Text);
                        int maxval = Int32.Parse(textBox6.Text);

                        if (minval >= maxval)
                        {
                            MessageBox.Show("Error on between values, please check min/max\n");
                            error++;
                        }
                    }
                }
                else
                {
                    if (textBox7.Text != "" || textBox6.Text != "")
                    {
                        MessageBox.Show("Please fill both values!\n");
                        error++;
                    }
                }
            }

            if (checkBox4.Checked)
            {
                if (textBox15.Text != "")
                {
                    if (!int.TryParse(textBox15.Text, out parsedValue))
                    {
                        MessageBox.Show("Please enter a numeric value!\n");
                        error++;
                    }
                }
                if (textBox14.Text != "")
                {
                    if (!int.TryParse(textBox14.Text, out parsedValue))
                    {
                        MessageBox.Show("Please enter a numeric value!\n");
                        error++;
                    }
                }
                if (textBox13.Text != "")
                {
                    if (!int.TryParse(textBox13.Text, out parsedValue))
                    {
                        MessageBox.Show("Please enter a numeric value!\n");
                        error++;
                    }
                }
                if (textBox12.Text != "" && textBox11.Text != "")
                {
                    if ((!int.TryParse(textBox12.Text, out parsedValue)) || (!int.TryParse(textBox11.Text, out parsedValue)))
                    {
                        MessageBox.Show("Please enter a numeric value!\n");
                        error++;
                    }
                    else
                    {
                        int minval = Int32.Parse(textBox12.Text);
                        int maxval = Int32.Parse(textBox11.Text);

                        if (minval >= maxval)
                        {
                            MessageBox.Show("Error on between values, please check min/max\n");
                            error++;
                        }
                    }
                }
                else
                {
                    if (textBox12.Text != "" || textBox11.Text != "")
                    {
                        MessageBox.Show("Please fill both values!\n");
                        error++;
                    }
                }
            }

            return error;
        }

        private void XMLWriter()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("trigger-rules.xml");

            if (checkBox2.Checked)
            {
                XmlNodeList lstNO2 = doc.SelectNodes("/alarms/NO2");
                
                foreach(XmlNode n in lstNO2)
                {
                    XmlNode minNO2 = n.SelectSingleNode("Min");
                    minNO2.InnerText = textBox1.Text;

                    XmlNode maxNO2 = n.SelectSingleNode("Max");
                    maxNO2.InnerText = textBox2.Text;

                    XmlNode eqNO2 = n.SelectSingleNode("Equal");
                    eqNO2.InnerText = textBox3.Text;

                    XmlNode minBetNO2 = n.SelectSingleNode("Between").SelectSingleNode("min");
                    minBetNO2.InnerText = textBox4.Text;
                    XmlNode maxBetNO2 = n.SelectSingleNode("Between").SelectSingleNode("max");
                    maxBetNO2.InnerText = textBox5.Text;
                }
            }

            if (checkBox3.Checked)
            {
                XmlNodeList lstCO = doc.SelectNodes("/alarms/CO");

                foreach (XmlNode n in lstCO)
                {
                    XmlNode minCO = n.SelectSingleNode("Min");
                    minCO.InnerText = textBox10.Text;

                    XmlNode maxCO = n.SelectSingleNode("Max");
                    maxCO.InnerText = textBox9.Text;

                    XmlNode eqCO = n.SelectSingleNode("Equal");
                    eqCO.InnerText = textBox8.Text;

                    XmlNode minBetCO = n.SelectSingleNode("Between").SelectSingleNode("min");
                    minBetCO.InnerText = textBox7.Text;
                    XmlNode maxBetCO = n.SelectSingleNode("Between").SelectSingleNode("max");
                    maxBetCO.InnerText = textBox6.Text;
                }
            }

            if (checkBox4.Checked)
            {
                XmlNodeList lstO3 = doc.SelectNodes("/alarms/O3");

                foreach (XmlNode n in lstO3)
                {
                    XmlNode minO3 = n.SelectSingleNode("Min");
                    minO3.InnerText = textBox15.Text;

                    XmlNode maxO3 = n.SelectSingleNode("Max");
                    maxO3.InnerText = textBox14.Text;

                    XmlNode eqO3 = n.SelectSingleNode("Equal");
                    eqO3.InnerText = textBox13.Text;

                    XmlNode minBetO3 = n.SelectSingleNode("Between").SelectSingleNode("min");
                    minBetO3.InnerText = textBox12.Text;
                    XmlNode maxBetO3 = n.SelectSingleNode("Between").SelectSingleNode("max");
                    maxBetO3.InnerText = textBox11.Text;
                }
            }

            doc.Save("trigger-rules.xml");
        }

        private void triggerAlarm()
        {

        }
    }
}
