using System;
using SWAP.Models.SchoolDistrictPOST;
using SWAP.Services;
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

        public IHttpActionResult Get()
        {
            SchoolDistrictService schoolDistrictService = CreateSchoolDistrictService();
            var schoolDistrict = schoolDistrictService.GetAllSchoolDistricts();
            return Ok(schoolDistrict);
        }

        [Route("api/SchoolDistrict/{districtId}")]
        public IHttpActionResult Get([FromUri] Guid districtId)
        {
            SchoolDistrictService schoolDistrictService = CreateSchoolDistrictService();
            var schoolDistrict = schoolDistrictService.GetSchoolDistrict(districtId);
            return Ok(schoolDistrict);
        }

        public IHttpActionResult Put(SchoolDistrictEdit schoolDistrict)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSchoolDistrictService();

            if (!service.UpdateSchoolDistrict(schoolDistrict))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(SchoolDistrictDelete id)
        {
            var service = CreateSchoolDistrictService();
            if (!service.DeleteSchoolDistrict(id))
                return InternalServerError();

            return Ok();
        }
    }
}
