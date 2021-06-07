using System;
using System.Text;
using uPLibrary.Networking.M2Mqtt;

using uPLibrary.Networking.M2Mqtt.Messages;


namespace mqdemo
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");NormalPublisher
            string topic = "test";
            string host = "127.0.0.1";

            MqttClient mqttClient = new MqttClient(host);


            mqttClient.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            string clientId = Guid.NewGuid().ToString();
            mqttClient.Connect(clientId);

            // 订阅主题 "/home/temperature"， 订阅质量 QoS 2 
            mqttClient.Subscribe(new string[] { topic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });



        }


        static void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            // 打印订阅的发布端消息
            Console.WriteLine(string.Format("subscriber,topic:{0},content:{1}",
                e.Topic, Encoding.UTF8.GetString(e.Message)));
        }
    }

}
