using Faces.SharedLib.Messaging.InterfacesConstants.Commands;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersApi.Messages.Consumers
{
    public class RegisterOrderCommandConsumer : IConsumer<IRegisterOrderCommand>
    {
        public Task Consume(ConsumeContext<IRegisterOrderCommand> context)
        {
            throw new NotImplementedException();
        }
    }
}
