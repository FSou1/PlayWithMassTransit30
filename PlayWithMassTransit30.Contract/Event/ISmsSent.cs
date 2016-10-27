using System;

namespace PlayWithMassTransit30.Contract.Event
{
    public interface ISmsSent
    {
        Guid EventId { get; }
        DateTime SentAtUtc { get; }
    }
}