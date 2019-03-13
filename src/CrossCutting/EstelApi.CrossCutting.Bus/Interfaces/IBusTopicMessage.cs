using EstelApi.CrossCutting.Bus;

public interface IBusTopicMessage : IBusMessage
{
    string TopicName { get; set; }
}