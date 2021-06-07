using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace NormalPublisher
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string content = "hello mqtt";
            string topic = "test";
            string host = "127.0.0.1";
            // 实例化Mqtt客户端
            MqttClient client = new MqttClient(host);

            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);

            string strValue = Convert.ToString(content);

            // 发布消息主题 "/home/temperature" ，消息质量 QoS 2 
            client.Publish(topic, Encoding.UTF8.GetBytes(strValue), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
            Console.WriteLine(string.Format("publisher,topic:{0},content:{1}", topic, content));
        }
    }
}
