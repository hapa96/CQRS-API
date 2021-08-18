using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

using MediatR;

using Host.Models;

namespace Host.CQRS.Queries
{
    public class GetTodoQueryHandler : IRequestHandler<GetTodoQuery, TodoItem>
    {

        private readonly TodoContext _context;

        public GetTodoQueryHandler(TodoContext context)
        {
            _context = context;
        }

        public async Task<TodoItem> Handle(GetTodoQuery request, CancellationToken cancellationToken)
        {
            var todoItem = await _context.TodoItems.FindAsync(request.Id);
            return todoItem;

        }
    }
}
