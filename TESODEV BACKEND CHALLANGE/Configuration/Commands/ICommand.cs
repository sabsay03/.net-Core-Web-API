using System;
using MediatR;

namespace TESODEV_BACKEND_CHALLANGE.Configuration.Commands
{
    public interface ICommand : IRequest
    {
        int Id { get; }
    }

    public interface ICommand<out TResult> : IRequest<TResult>
    {
        int Id { get; }
    }
}
