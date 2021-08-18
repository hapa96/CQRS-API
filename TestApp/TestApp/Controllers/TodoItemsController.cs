using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Host.CQRS.Commands;
using Host.CQRS.Queries;
using Host.Models;

namespace Host.Controllers
{
    [Route("api/TodoItems")]
    public class TodoItemsController : ApiControllerBase
    {
        private readonly TodoContext _context;

        public TodoItemsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            var todoList = await Mediator.Send(new GetAllTodoItemsQuery());
            return Ok(todoList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(int id)
        {
            var todo =  await Mediator.Send(new GetTodoQuery(id));
            if (todo == null) return NotFound(); 
            return Ok(todo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoItem(int id, TodoItemDTO todoItem)
        {
            var todo = await Mediator.Send(new UpdateTodoItemCommand(id, todoItem.Name, todoItem.IsComplete));
            return StatusCode(todo);
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> CreateTodoItem(TodoItemDTO todoItem)
        {
            var todo = await Mediator.Send(new CreateTodoCommand(todoItem.Name, todoItem.IsComplete));
            return Ok(todo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            var todo = await Mediator.Send(new DeleteTodoCommand(id));
            if (todo) return NoContent();
            return NotFound();
        }
    }
}
