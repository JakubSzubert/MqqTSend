using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Frends.MQTT.Send.Definitions;

namespace Frends.MQTT.Send
{

    public static class MqttTask
    {
        public static async Task<Result> SendMessageAsync([PropertyTab] Input input, CancellationToken cancellationToken)
        {
            try
            {
                var mqttSender = new MqttSender();
                await mqttSender.SendMqttMessageAsync(input.BrokerAddress, input.BrokerPort, input.Topic, input.Message, cancellationToken);
                return new Result(true, "Message sent successfully");
            }
            catch (Exception ex)
            {
                return new Result(false, $"Error: {ex.Message}");
            }
        }
    }
}
