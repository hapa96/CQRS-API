using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Host.Models;

namespace Host.CQRS.Commands
{
    public class DeleteTodoCommandHandler:IRequestHandler<DeleteTodoCommand,bool>
    {
        private readonly TodoContext _context;

        public DeleteTodoCommandHandler(TodoContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            var todoItem = await _context.TodoItems.FindAsync(request.Id);

            if (todoItem == null)
            {
                return false;
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
