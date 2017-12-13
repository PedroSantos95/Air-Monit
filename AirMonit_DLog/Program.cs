using System;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using AirMonit_DLog.Models;
using System.Text.RegularExpressions;
using RestSharp;

namespace AirMonit_DLog
{
    class Program
    {

        static void Main(string[] args)
        {
            MqttClient mClient = new MqttClient("127.0.0.1");
            string[] topics = { "no2", "co", "o3" };
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
            mClient.Subscribe(topics, qosLevels);
            Console.ReadKey();
            if (mClient.IsConnected)
            {
                mClient.Unsubscribe(topics); //Put this in a button to see notif!
                mClient.Disconnect(); //Free process and process's resources
            }
        }

        private static void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            try
            {
                string data = Encoding.UTF8.GetString(e.Message);
                //Console.WriteLine(data);
                //ServiceReference.Service1Client service = new ServiceReference.Service1Client();
                AirMonit_SERVICE.Controllers.SensorsController service = new AirMonit_SERVICE.Controllers.SensorsController();
                data = Regex.Replace(data, "<.*?>", "#");
                String[] words = data.Split('#');
                Sensor sensor = new Sensor();
                sensor.Id = Int32.Parse(words[2]);
                sensor.Name = words[4];
                sensor.Value = Int32.Parse(words[6]);
                sensor.Date = words[8];
                sensor.City = words[10];
                service.PostSensor(sensor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*protected static void PostSensor(Sensor s)
        {
            var client = new RestClient("http://localhost:56269/");
            var request = new RestRequest("api/sensors/", Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-type", "application/json");

            request.AddJsonBody(s);

            IRestResponse resp = client.Execute(request);

            var content = resp.Content;

        }*/

    }
}
