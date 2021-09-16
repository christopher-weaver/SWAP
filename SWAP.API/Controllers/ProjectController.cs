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
            var shoppingListService = new ProjectService();
            return shoppingListService;
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

            return Ok($"The following project has been added to {project.SchoolDistrict.DistrictName}: {project.Category} {project.Subcategory}");
        }
    }
}
