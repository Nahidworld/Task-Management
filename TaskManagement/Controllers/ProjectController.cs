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
    [RoutePrefix("api/projects")]
    public class ProjectController : ApiController
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllProjects()
        {
            var projects = _projectService.GetAllProjects();
            return Ok(projects);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetProjectById(int id)
        {
            try
            {
                var project = _projectService.GetProjectById(id);
                return Ok(project);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateProject([FromBody] ProjectCreateDto dto)
        {
            try
            {
                _projectService.CreateProject(dto);
                return Ok("Project created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult UpdateProject(int id, [FromBody] ProjectUpdateDto dto)
        {
            try
            {
                _projectService.UpdateProject(id, dto);
                return Ok("Project updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeleteProject(int id)
        {
            try
            {
                _projectService.DeleteProject(id);
                return Ok("Project deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

