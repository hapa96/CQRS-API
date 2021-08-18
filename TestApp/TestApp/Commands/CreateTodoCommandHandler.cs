using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Microsoft.EntityFrameworkCore;

using Host.Models;

namespace Host.CQRS.Commands
{
    // "Register" Handler for CreateTodoCommand and return TodoItem
    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, TodoItem>
    {
        private readonly TodoContext _context;

        public CreateTodoCommandHandler(TodoContext context)
        {
            _context = context;
        }

        public async Task<TodoItem> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var todoItem = new TodoItem
            {
                IsComplete = request.IsComplete,
                Name = request.Name
            };

            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();

            return todoItem;
        }
    }
}
