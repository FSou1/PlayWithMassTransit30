using System;

namespace PlayWithMassTransit30.Contract.Command
{
    public interface ISendEmail
    {
        Guid CommandId { get; }
        string Email { get; }
        string To { get; }
        string Subject { get; }
        string Body { get; }
    }
}