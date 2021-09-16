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
    [Authorize]
    public class ConsultantController : ApiController
    {
        private ConsultantService CreateConsultantService()
        {
            var consultantService = new ConsultantService();
            return consultantService;
        }
        
        
        
        public IHttpActionResult Post(ConsultantCreate consultant)
        {
            if (ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateConsultantService();

            if (!service.CreateConsultant(consultant))
                return InternalServerError();
            
            return Ok();
                
        }
    }
}
