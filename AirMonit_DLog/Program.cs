using System;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using AirMonit_DLog.Models;
using System.Text.RegularExpressions;
using RestSharp;
using System.Collections.Generic;

namespace AirMonit_DLog
{
    class Program
    {
        //private static List<String> topics = new List<String>();
        static string[] topics = { "no2", "co", "o3" };
        static void Main(string[] args)
        {
            MqttClient mClient = new MqttClient("127.0.0.1");
            //string[] topics = { "alarm", "no2", "co", "o3" };

            mClient.Connect(Guid.NewGuid().ToString());
            if (!mClient.IsConnected)
            {
                Console.WriteLine("Error connecting to message broker...");
                return;
            }

            //Connect to database

            mClient.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            //Subscribe to topics

            byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE ,
            MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE};
            byte[] qos = { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE };
            mClient.Subscribe(topics, qosLevels);
            mClient.Subscribe(new String[] { "alarm" }, qos);
            Console.ReadKey();
            if (mClient.IsConnected)
            {
                mClient.Unsubscribe(topics); //Put this in a button to see notif!
                mClient.Disconnect(); //Free process and process's resources
            }
        }

        private static void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            // try
            //{
            string data = Encoding.UTF8.GetString(e.Message);
            AirMonit_SERVICE.Controllers.SensorsController service = new AirMonit_SERVICE.Controllers.SensorsController();

            if (e.Topic == "alarm")
            {
                data = Regex.Replace(data, "<.*?>", "#");
                String[] wordsA = data.Split('#');
                Sensor sensorAlarm = new Sensor();
                sensorAlarm.Id = Int32.Parse(wordsA[4]);
                sensorAlarm.Name = wordsA[6];
                sensorAlarm.Date = wordsA[8];
                sensorAlarm.City = wordsA[10];
                sensorAlarm.Value = Int32.Parse(wordsA[12]);
                sensorAlarm.Trigger_rule = wordsA[14];
                sensorAlarm.Trigger_value = Int32.Parse(wordsA[16]);
                service.PostAlarm(sensorAlarm);
                Console.WriteLine("Escrever na tabela Alarms!");

            }
            else
            {
                data = Regex.Replace(data, "<.*?>", "#");
                String[] words = data.Split('#');
                Sensor sensor = new Sensor();

                sensor.Id = Int32.Parse(words[2]);
                sensor.Name = words[4];
                sensor.Value = Int32.Parse(words[6]);
                sensor.Date = words[8];
                sensor.City = words[10];
                service.PostSensor(sensor);
                Console.WriteLine("Escrever na tabela Sensors!");
            }
        }
        //catch (Exception ex)
        //{
        //   throw ex;
        //}
    }
}





