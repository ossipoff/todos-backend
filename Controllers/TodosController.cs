using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodosBackend.Models;

namespace TodosBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly EntityFramework.TodosContext todosContext;

        public TodosController(EntityFramework.TodosContext todosContext)
        {
            this.todosContext = todosContext;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Todo>> Get()
        {
            var todos = todosContext.Todos.Select(t => new Todo()
            {
                Id = t.Id,
                Text = t.Text
            }).ToList();

            return new ObjectResult(todos);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Todo> Get(int id)
        {
            var todo = todosContext.Todos.Find(id);

            return new ObjectResult(todo);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Todo todo)
        {
            var efTodo = new EntityFramework.Models.Todo()
            {
                Text = todo.Text
            };

            todosContext.Todos.Add(efTodo);

            todosContext.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Todo todo)
        {
            var efTodo = todosContext.Todos.Find(id);

            if (efTodo != null)
            {
                efTodo.Text = todo.Text;

                todosContext.SaveChanges();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var efTodo = todosContext.Todos.Find(id);

            if (efTodo != null)
            {
                todosContext.Todos.Remove(efTodo);

                todosContext.SaveChanges();
            }
        }
    }
}
