using MediatR;

namespace Host.CQRS.Commands
{
    public record UpdateTodoItemCommand(int Id, string Name, bool IsComplete) : IRequest<int>;
}

