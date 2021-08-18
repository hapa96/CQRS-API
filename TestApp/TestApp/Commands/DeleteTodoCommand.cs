using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MediatR;

namespace Host.CQRS.Commands
{
    public record DeleteTodoCommand(int Id) : IRequest<bool>;
}
