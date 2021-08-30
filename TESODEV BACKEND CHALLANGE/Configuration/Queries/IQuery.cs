using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TESODEV_BACKEND_CHALLANGE.Configuration.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {

    }
}

