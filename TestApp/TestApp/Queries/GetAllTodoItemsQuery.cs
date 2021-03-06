using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MediatR;

using Host.Models;

namespace Host.CQRS.Queries
{
    public record GetAllTodoItemsQuery() : IRequest<List<TodoItem>>;
}
