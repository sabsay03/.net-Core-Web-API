using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TESODEV_BACKEND_CHALLANGE.Configuration.Commands
{
    public class CommandBase : ICommand
    {
        public int Id { get; }

        public CommandBase()
        {
            this.Id = new Int32();
        }

        protected CommandBase(int id)
        {
            this.Id = id;
        }
    }

    public abstract class CommandBase<TResult> : ICommand<TResult>
    {
        public int Id { get; }

        protected CommandBase()
        {
            this.Id = new Int32();
        }

        protected CommandBase(int id)
        {
            this.Id = id;
        }
    }
}
