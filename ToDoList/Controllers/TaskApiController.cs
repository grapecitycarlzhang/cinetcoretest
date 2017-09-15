using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    [Produces("application/json")]
    [Route("api/todo")]
    public class TaskApiController : Controller
    {
        private readonly ToDoContext _context;

        public TaskApiController(ToDoContext context)
        {
            _context = context;
        }

        // GET: api/task
        [HttpGet]
        [Route("items")]
        public async Task<IActionResult> GetTasks([FromQuery] PageRequestModel request)
        {

            var result = new ResultModel()
            {
                Data = await _context.Tasks.Skip(request.FromIndex).Take(request.PageSize).ToListAsync(),
                TotalCount = await _context.Tasks.CountAsync()
            };

            return Ok(result);

        }

        // GET: api/task/5
        [HttpGet]//("{id}")
        public async Task<IActionResult> GetTaskModel([FromQuery] Guid guid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var taskModel = await _context.Tasks.SingleOrDefaultAsync(m => m.Guid == guid);

            if (taskModel == null)
            {
                return NotFound();
            }

            return Ok(ResultModel.GetResult(taskModel));
        }

        // PUT: api/task/5
        [HttpPut]
        public async Task<IActionResult> PutTaskModel([FromBody] TaskModel taskModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(taskModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskModelExists(taskModel.Guid))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(ResultModel.GetResult());
        }

        // POST: api/task
        [HttpPost]
        public async Task<IActionResult> PostTaskModel([FromBody] TaskModel taskModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tasks.Add(taskModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskModel", new { Guid = taskModel.Guid }, ResultModel.GetResult());
        }

        // DELETE: api/task/5
        [HttpDelete]
        public async Task<IActionResult> DeleteTaskModel([FromQuery] Guid guid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var taskModel = await _context.Tasks.SingleOrDefaultAsync(m => m.Guid == guid);
            if (taskModel == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(taskModel);
            await _context.SaveChangesAsync();

            return Ok(ResultModel.GetResult());
        }

        private bool TaskModelExists(Guid guid)
        {
            return _context.Tasks.Any(e => e.Guid == guid);
        }
    }
}