using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoBackend.Models;

namespace TodoBackend.Controllers
{
    [Route("api/todo")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private DatabaseContext _context;

        public TodoController(DatabaseContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public List<Todo> GetTodos()
        {
            var list = (from todo in _context.Todos
                        orderby todo.isFinished ascending, todo.Id descending
                        select todo).ToList<Todo>();

            return list;
        }

        [HttpPut]
        public ActionResult UpdateTodo([FromBody] Todo todo)
        {
            try
            {
                _context.Todos.Update(todo);
                _context.SaveChanges();
                return Ok(true);
            }
            catch (Exception e)
            {
                return Ok(false);
            }


        }

        [HttpPost]
        public ActionResult InsertTodo([FromBody] Todo todo)
        {
            try
            {
                _context.Todos.Add(todo);
                _context.SaveChanges();
                return Ok(true);
            }
            catch (Exception e)
            {
                return Ok(false);
            }


        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteTodo(int id)
        {
            try
            {
                Todo t = new Todo();
                t.Id = id;
                _context.Todos.Remove(t);
                _context.SaveChanges();
                return Ok(true);
            }
            catch (Exception e)
            {
                return Ok(false);
            }
        }

    }
}
