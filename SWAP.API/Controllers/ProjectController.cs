using SWAP.Models.Models;
using SWAP.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SWAP.API.Controllers
{
    public class ProjectController : ApiController
    {
        private ProjectService CreateProjectService()
        {
            var projectService = new ProjectService();
            return projectService;
        }

        [HttpPost]
        public IHttpActionResult Post(ProjectCreate project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projectService = CreateProjectService();

            if (!projectService.CreateProject(project))
            {
                return InternalServerError();
            }

            return Ok($"The following project has been added: {project.Category} {project.Subcategory}");
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            ProjectService projectService = CreateProjectService();
            var projects = projectService.GetAllProjects();
            return Ok(projects);
        }

        [HttpGet]
        [Route("api/Project/{projectId}")]
        public IHttpActionResult Get([FromUri] Guid projectId)
        {
            ProjectService projectService = CreateProjectService();
            var projects = projectService.GetProject(projectId);
            return Ok(projects);
        }

        [HttpPut]
        public IHttpActionResult Put(ProjectEdit project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateProjectService();

            if (!service.UpdateProject(project))
            {
                return InternalServerError();
            }

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(ProjectDelete project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateProjectService();

            if (!service.DeleteProject(project))
            {
                return InternalServerError();
            }

            return Ok();
        }
    }
}
