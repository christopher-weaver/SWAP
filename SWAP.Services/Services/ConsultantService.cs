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

        public IEnumerable<ConsultantListItem> GetConsultants()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Consultants
                        .Select(
                            c =>
                                new ConsultantListItem
                                {
                                    Id = c.Id,
                                    Name = c.Name,
                                    Category = c.Category,
                                }
                        );
                return query.ToArray();
            }
        }
    }
}
