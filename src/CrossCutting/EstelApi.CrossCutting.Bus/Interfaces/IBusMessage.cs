namespace EstelApi.CrossCutting.Bus
{
    using System;

    public interface IBusMessage
    {
        DateTime? ScheduledEnqueueTimeUtc { get; set; }
    }
}