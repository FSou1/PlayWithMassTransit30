using System;
using System.Windows.Input;

namespace PlayWithMassTransit30.Contract.Command
{
    public interface ISendSms<T> : ICommand<T>
    {
        Guid CommandId { get; }
        string PhoneNumber { get; }
        string Message { get; }
    }
}