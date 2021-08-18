using MediatR;

using Host.Models;

namespace Host.CQRS.Commands
{
    // Create an Entity with               <Name, IsComplete> specified and return a TodoItem
    public record CreateTodoCommand(string Name, bool IsComplete) : IRequest<TodoItem>;
}
