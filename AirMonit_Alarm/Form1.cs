using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace AirMonit_Alarm
{
    public partial class Form1 : Form
    {
        private static Sensor sensor;
        private static MqttClient m_cClient = new MqttClient("127.0.0.1");
        private static List<String> topics = new List<String>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Se ficheiro xml for válido então pode começar a receber dados
            XMLHandler xmlHandler = new XMLHandler("trigger-rules.xml", "trigger-rules.xsd");
            if (xmlHandler.ValidadeXml())
            {
                Thread thread = new Thread(receiveSensorData);
                thread.Start();
            }
            else
            {
                MessageBox.Show("XML Invalid file!");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            int checkerror = checkAlarms();

            if (checkBox1.Checked && checkerror == 0)
            {
                XMLWriter();
                subscribeTopics();
                checkBox1.Text = "Off";
            }
            else
            {
                if (checkBox1.Text != "On")
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

                foreach (XmlNode n in lstNO2)
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

            if (!checkBox2.Checked)
            {
                XmlNodeList lstNO2 = doc.SelectNodes("/alarms/NO2");

                foreach (XmlNode n in lstNO2)
                {
                    XmlNode minNO2 = n.SelectSingleNode("Min");
                    minNO2.InnerText = "";

                    XmlNode maxNO2 = n.SelectSingleNode("Max");
                    maxNO2.InnerText = "";

                    XmlNode eqNO2 = n.SelectSingleNode("Equal");
                    eqNO2.InnerText = "";

                    XmlNode minBetNO2 = n.SelectSingleNode("Between").SelectSingleNode("min");
                    minBetNO2.InnerText = "";
                    XmlNode maxBetNO2 = n.SelectSingleNode("Between").SelectSingleNode("max");
                    maxBetNO2.InnerText = "";
                }
            }

            if (!checkBox3.Checked)
            {
                XmlNodeList lstCO = doc.SelectNodes("/alarms/CO");

                foreach (XmlNode n in lstCO)
                {
                    XmlNode minCO = n.SelectSingleNode("Min");
                    minCO.InnerText = "";

                    XmlNode maxCO = n.SelectSingleNode("Max");
                    maxCO.InnerText = "";

                    XmlNode eqCO = n.SelectSingleNode("Equal");
                    eqCO.InnerText = "";

                    XmlNode minBetCO = n.SelectSingleNode("Between").SelectSingleNode("min");
                    minBetCO.InnerText = "";
                    XmlNode maxBetCO = n.SelectSingleNode("Between").SelectSingleNode("max");
                    maxBetCO.InnerText = "";
                }
            }

            if (!checkBox4.Checked)
            {
                XmlNodeList lstO3 = doc.SelectNodes("/alarms/O3");

                foreach (XmlNode n in lstO3)
                {
                    XmlNode minO3 = n.SelectSingleNode("Min");
                    minO3.InnerText = "";

                    XmlNode maxO3 = n.SelectSingleNode("Max");
                    maxO3.InnerText = "";

                    XmlNode eqO3 = n.SelectSingleNode("Equal");
                    eqO3.InnerText = "";

                    XmlNode minBetO3 = n.SelectSingleNode("Between").SelectSingleNode("min");
                    minBetO3.InnerText = "";
                    XmlNode maxBetO3 = n.SelectSingleNode("Between").SelectSingleNode("max");
                    maxBetO3.InnerText = "";
                }
            }

            doc.Save("trigger-rules.xml");
        }

        private static void XMLReader(Sensor sensor)
        {
            string alarmMessage = "";

            XmlTextReader xmlReader = new XmlTextReader("trigger-rules.xml");
            while (xmlReader.Read())
            {
                alarmMessage += sensor.Value;

            }
            xmlReader.Close();

            m_cClient.Publish(alarmMessage, Encoding.UTF8.GetBytes(sensor.Serialize()));
        }

        private void subscribeTopics()
        {
            topics.Add("alarm");

            if (checkBox2.Checked)
            {
                topics.Add("no2");
                m_cClient.Subscribe(new String[] { "no2" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            }
            else
            {
                if (topics.Contains("no2"))
                {
                    topics.Remove("no2");
                    m_cClient.Unsubscribe(new String[] { "no2" });
                }
            }

            if (checkBox3.Checked)
            {
                topics.Add("co");
                m_cClient.Subscribe(new String[] { "co" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            }
            else
            {
                if (topics.Contains("co"))
                {
                    topics.Remove("co");
                    m_cClient.Unsubscribe(new String[] { "co" });
                }
            }

            if (checkBox4.Checked)
            {
                topics.Add("o3");
                m_cClient.Subscribe(new String[] { "o3" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            }
            else
            {
                if (topics.Contains("o3"))
                {
                    topics.Remove("o3");
                    m_cClient.Unsubscribe(new String[] { "o3" });
                }
            }
        }

        private void receiveSensorData()
        {
            try
            {
                m_cClient = new MqttClient("127.0.0.1");
                m_cClient.Connect(Guid.NewGuid().ToString());
                if (!m_cClient.IsConnected)
                {
                    Console.WriteLine("Error connecting to message broker...");
                    return;
                }

                m_cClient.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        static void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            try
            {
                String xmlString = Encoding.UTF8.GetString(e.Message);

                StringReader stringReader = new StringReader(xmlString);
                XmlSerializer serializer = new XmlSerializer(typeof(Sensor), new XmlRootAttribute("sensor"));

                sensor = (Sensor)serializer.Deserialize(stringReader);

                XMLReader(sensor);
                XmlDocument rules = new XmlDocument();
                rules.Load("trigger-rules.xml");

                XmlDocument doc = new XmlDocument();
                XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", null, null);
                doc.AppendChild(dec);
                XmlNode root = doc.CreateElement("alarms");
                doc.AppendChild(root);

                XmlNodeList nodeListNO2 = rules.SelectNodes("/alarms/NO2");
                XmlNodeList nodeListCO = rules.SelectNodes("/alarms/CO");
                XmlNodeList nodeListO3 = rules.SelectNodes("/alarms/O3");

                checkMinRules(nodeListNO2, doc, rules, root);
                checkMinRules(nodeListCO, doc, rules, root);
                checkMinRules(nodeListO3, doc, rules, root);

                checkMaxRules(nodeListNO2, doc, rules, root);
                checkMaxRules(nodeListCO, doc, rules, root);
                checkMaxRules(nodeListO3, doc, rules, root);

                checkEqualRules(nodeListNO2, doc, rules, root);
                checkEqualRules(nodeListCO, doc, rules, root);
                checkEqualRules(nodeListO3, doc, rules, root);

                checkBetweenRules(nodeListNO2, doc, rules, root);
                checkBetweenRules(nodeListCO, doc, rules, root);
                checkBetweenRules(nodeListO3, doc, rules, root);

                String data = doc.OuterXml;
                m_cClient.Publish(topics[0], Encoding.UTF8.GetBytes(data));
                Console.WriteLine(data);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        private static void checkMinRules(XmlNodeList list, XmlDocument doc, XmlDocument rules, XmlNode root)
        {
            foreach (XmlNode node in list)
            {
                foreach (XmlNode nodeC in node)
                {
                    if (nodeC.InnerText != "")
                    {
                        if (nodeC.Name == "Min")
                        {
                            if (sensor.Value < Int32.Parse(nodeC.InnerText))
                            {

                                XmlElement alarm = doc.CreateElement("alarm");

                                XmlElement id = doc.CreateElement("sensor_id");
                                id.InnerText = sensor.SensorID.ToString();

                                XmlElement name = doc.CreateElement("sensor_name");
                                name.InnerText = sensor.SensorName.ToString();

                                XmlElement date = doc.CreateElement("sensor_date");
                                date.InnerText = sensor.DateTime.ToString();

                                XmlElement city = doc.CreateElement("sensor_city");
                                city.InnerText = sensor.SensorCity.ToString();

                                XmlElement value = doc.CreateElement("sensor_value");
                                value.InnerText = sensor.Value.ToString();

                                XmlElement trigger_value = doc.CreateElement("trigger_value");
                                trigger_value.InnerText = nodeC.InnerText;

                                XmlElement trigger_rule = doc.CreateElement("trigger_rule");
                                trigger_rule.InnerText = "Min";

                                alarm.AppendChild(id);
                                alarm.AppendChild(name);
                                alarm.AppendChild(date);
                                alarm.AppendChild(city);
                                alarm.AppendChild(value);
                                alarm.AppendChild(trigger_rule);
                                alarm.AppendChild(trigger_value);
                                root.AppendChild(alarm);
                            }
                        }
                    }
                }

            }
        }

        private static void checkMaxRules(XmlNodeList list, XmlDocument doc, XmlDocument rules, XmlNode root)
        {
            foreach (XmlNode node in list)
            {
                foreach (XmlNode nodeC in node)
                {
                    if (nodeC.InnerText != "")
                    {
                        if (nodeC.Name == "Max")
                        {
                            if (sensor.Value > Int32.Parse(nodeC.InnerText))
                            {

                                XmlElement alarm = doc.CreateElement("alarm");

                                XmlElement id = doc.CreateElement("sensor_id");
                                id.InnerText = sensor.SensorID.ToString();

                                XmlElement name = doc.CreateElement("sensor_name");
                                name.InnerText = sensor.SensorName.ToString();

                                XmlElement date = doc.CreateElement("sensor_date");
                                date.InnerText = sensor.DateTime.ToString();

                                XmlElement city = doc.CreateElement("sensor_city");
                                city.InnerText = sensor.SensorCity.ToString();

                                XmlElement value = doc.CreateElement("sensor_value");
                                value.InnerText = sensor.Value.ToString();

                                XmlElement trigger_value = doc.CreateElement("trigger_value");
                                trigger_value.InnerText = nodeC.InnerText;

                                XmlElement trigger_rule = doc.CreateElement("trigger_rule");
                                trigger_rule.InnerText = "Max";

                                alarm.AppendChild(id);
                                alarm.AppendChild(name);
                                alarm.AppendChild(date);
                                alarm.AppendChild(city);
                                alarm.AppendChild(value);
                                alarm.AppendChild(trigger_rule);
                                alarm.AppendChild(trigger_value);
                                root.AppendChild(alarm);
                            }
                        }
                    }
                }

            }
        }

        private static void checkEqualRules(XmlNodeList list, XmlDocument doc, XmlDocument rules, XmlNode root)
        {
            foreach (XmlNode node in list)
            {
                foreach (XmlNode nodeC in node)
                {
                    if (nodeC.InnerText != "")
                    {
                        if (nodeC.Name == "Equal")
                        {
                            if (sensor.Value == Int32.Parse(nodeC.InnerText))
                            {

                                XmlElement alarm = doc.CreateElement("alarm");

                                XmlElement id = doc.CreateElement("sensor_id");
                                id.InnerText = sensor.SensorID.ToString();

                                XmlElement name = doc.CreateElement("sensor_name");
                                name.InnerText = sensor.SensorName.ToString();

                                XmlElement date = doc.CreateElement("sensor_date");
                                date.InnerText = sensor.DateTime.ToString();

                                XmlElement city = doc.CreateElement("sensor_city");
                                city.InnerText = sensor.SensorCity.ToString();

                                XmlElement value = doc.CreateElement("sensor_value");
                                value.InnerText = sensor.Value.ToString();

                                XmlElement trigger_value = doc.CreateElement("trigger_value");
                                trigger_value.InnerText = nodeC.InnerText;

                                XmlElement trigger_rule = doc.CreateElement("trigger_rule");
                                trigger_rule.InnerText = "Equals";

                                alarm.AppendChild(id);
                                alarm.AppendChild(name);
                                alarm.AppendChild(date);
                                alarm.AppendChild(city);
                                alarm.AppendChild(value);
                                alarm.AppendChild(trigger_rule);
                                alarm.AppendChild(trigger_value);
                                root.AppendChild(alarm);
                            }
                        }
                    }
                }

            }
        }

        private static void checkBetweenRules(XmlNodeList list, XmlDocument doc, XmlDocument rules, XmlNode root)
        {
            int min = 0;
            int max = 0;

            foreach (XmlNode node in list)
            {
                foreach (XmlNode nodeC in node)
                {
                    if (nodeC.InnerText != "")
                    {
                        if (nodeC.Name == "Between")
                        {
                            XmlNodeList minLst = node.SelectSingleNode("Between").SelectNodes("min");
                            XmlNodeList maxLst = node.SelectSingleNode("Between").SelectNodes("max");

                            foreach (XmlNode x in minLst)
                            {
                                min = Int32.Parse(x.InnerText);
                            }
                            foreach (XmlNode y in maxLst)
                            {
                                max = Int32.Parse(y.InnerText);
                            }

                            if (sensor.Value < max && sensor.Value > min)
                            {
                                XmlElement alarm = doc.CreateElement("alarm");

                                XmlElement id = doc.CreateElement("sensor_id");
                                id.InnerText = sensor.SensorID.ToString();

                                XmlElement name = doc.CreateElement("sensor_name");
                                name.InnerText = sensor.SensorName.ToString();

                                XmlElement date = doc.CreateElement("sensor_date");
                                date.InnerText = sensor.DateTime.ToString();

                                XmlElement city = doc.CreateElement("sensor_city");
                                city.InnerText = sensor.SensorCity.ToString();

                                XmlElement value = doc.CreateElement("sensor_value");
                                value.InnerText = sensor.Value.ToString();

                                XmlElement trigger_value = doc.CreateElement("trigger_value");
                                trigger_value.InnerText = nodeC.InnerText;

                                XmlElement trigger_rule = doc.CreateElement("trigger_rule");
                                trigger_rule.InnerText = "Between";

                                alarm.AppendChild(id);
                                alarm.AppendChild(name);
                                alarm.AppendChild(date);
                                alarm.AppendChild(city);
                                alarm.AppendChild(value);
                                alarm.AppendChild(trigger_rule);
                                alarm.AppendChild(trigger_value);
                                root.AppendChild(alarm);
                            }

                        }
                    }

                }
            }
        }

    }
}