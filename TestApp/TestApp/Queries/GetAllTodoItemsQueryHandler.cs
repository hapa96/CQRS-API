using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Microsoft.EntityFrameworkCore;

using Host.Models;

namespace Host.CQRS.Queries
{
    public class GetAllTodoItemsQueryHandler: IRequestHandler<GetAllTodoItemsQuery, List<TodoItem>>
    {

    private readonly TodoContext _context;

    public GetAllTodoItemsQueryHandler(TodoContext context)
    {
        _context = context;
    }



    public async Task<List<TodoItem>> Handle(GetAllTodoItemsQuery request, CancellationToken cancellationToken)
    {
        var todoItem = await _context.TodoItems.ToListAsync();
        return todoItem;
        }
    }

}
