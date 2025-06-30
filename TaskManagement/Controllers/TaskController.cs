using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManagement.BLL.Dtos;
using TaskManagement.BLL.Interfaces;

namespace TaskManagement.WebAPI.Controllers
{
    [RoutePrefix("api/tasks")]
    public class TaskController : ApiController
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllTasks()
        {
            var tasks = _taskService.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetTaskById(int id)
        {
            try
            {
                var task = _taskService.GetTaskById(id);
                return Ok(task);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateTask([FromBody] TaskCreateDto dto)
        {
            try
            {
                _taskService.CreateTask(dto);
                return Ok("Task created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult UpdateTask(int id, [FromBody] TaskUpdateDto dto)
        {
            try
            {
                _taskService.UpdateTask(id, dto);
                return Ok("Task updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeleteTask(int id)
        {
            try
            {
                _taskService.DeleteTask(id);
                return Ok("Task deleted.");
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}
