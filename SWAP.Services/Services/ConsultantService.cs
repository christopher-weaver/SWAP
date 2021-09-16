using SWAP.Data;
using SWAP.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.Services.Services
{
    public class ConsultantService
    {
        public ConsultantService()
            {
            }
        public bool CreateConsultant(ConsultantCreate model)
        {
            var newConsultant =
                new Consultant()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Phone = model.Phone,
                    Email = model.Email,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Consultants.Add(newConsultant);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
