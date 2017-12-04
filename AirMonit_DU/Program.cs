using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using uPLibrary.Networking.M2Mqtt;

namespace AirMonit_DU
{
    static class Program
    {
        static MqttClient mClient = null;
        static string[] topics = { "no2", "co", "o3" };

        static void Main(string[] args)
        {
            mClient = new MqttClient("127.0.0.1");
            mClient.Connect(Guid.NewGuid().ToString());
            if (!mClient.IsConnected)
            {
                //MessageBox.Show("Error connecting to message broker...");
                Console.WriteLine("Error connecting to message broker...");
                return;
            }
            else
            {
                AirSensorNodeDll.AirSensorNodeDll dll = new AirSensorNodeDll.AirSensorNodeDll();
                dll.Initialize(GenerataSensorData, 2500);

            }
        }

        private static void GenerataSensorData(string message)
        {
            String[] str_parts = message.Split(';');
            XmlDocument doc = new XmlDocument();

            XmlNode root = doc.CreateElement("sensor");

            XmlElement id = doc.CreateElement("sensor_id");
            id.InnerText = str_parts[0];

            XmlElement name = doc.CreateElement("sensor_name");
            name.InnerText = str_parts[1];

            XmlElement value = doc.CreateElement("sensor_value");
            value.InnerText = str_parts[2];

            XmlElement date = doc.CreateElement("sensor_date");
            date.InnerText = str_parts[3];

            XmlElement city = doc.CreateElement("sensor_city");
            city.InnerText = str_parts[4];

            root.AppendChild(id);
            root.AppendChild(name);
            root.AppendChild(value);
            root.AppendChild(date);
            root.AppendChild(city);
            doc.AppendChild(root);
            String data = doc.OuterXml;
            Console.WriteLine(data);
            //doc.Save(@"example.xml");

            if (str_parts[1].Equals("NO2"))
            {
                Console.WriteLine("Publishing in NO2 CHANNEL..");
                mClient.Publish(topics[0], Encoding.UTF8.GetBytes(data));

            }
            else if (str_parts[1].Equals("CO"))
            {
                Console.WriteLine("Publishing in CO CHANNEL..");
                mClient.Publish(topics[1], Encoding.UTF8.GetBytes(data));
            }
            else
            {
                Console.WriteLine("Publishing in O3 CHANNEL..");
                mClient.Publish(topics[2], Encoding.UTF8.GetBytes(data));
            }
        }
    }
}
