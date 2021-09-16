
using SWAP.Models.SchoolDistrictPOST;
using SWAP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SWAP.API.Controllers
{
    public class SchoolDistrictController : ApiController
    {
        private SchoolDistrictService CreateSchoolDistrictService()
        {
            var schoolDistrictService = new SchoolDistrictService();
            return schoolDistrictService;
        }

        public IHttpActionResult Post(SchoolDistrictCreate schoolDistrict)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSchoolDistrictService();

            if (!service.CreateSchoolDistrict(schoolDistrict))
                return InternalServerError();

            return Ok();

        }
    }
}
