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
    public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoItemCommand, int>
    {

        private readonly TodoContext _context;

        public UpdateTodoCommandHandler(TodoContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
        {

            var todoItem = await _context.TodoItems.FindAsync(request.Id);

            if (todoItem == null)
            {
                return 404;
            }

            todoItem.Name = request.Name;
            todoItem.IsComplete = request.IsComplete;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) 
            {
                return 404;
            }

            return 201;
        }
    }
}
