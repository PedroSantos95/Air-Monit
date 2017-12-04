using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

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
            string data = Encoding.UTF8.GetString(e.Message);
            Console.WriteLine(data);
        }

    }
}
