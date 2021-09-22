using SWAP.Data;
using SWAP.Models.Models;
using SWAP.Models.SchoolDistrictPOST;
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
                    Name = model.Name,
                    Phone = model.Phone,
                    Email = model.Email,
                    Category = model.Category
                };

            using (var ctx = new ApplicationDbContext())
            {
                foreach (Guid guid in model.SchoolDistrictIds)
                {
                    var query =
                        ctx
                            .SchoolDistricts
                            .SingleOrDefault(d => d.Id == guid);

                    if (query != null)
                    {
                        newConsultant.SchoolDistricts.Add(query);
                    }
                }

                ctx.Consultants.Add(newConsultant);
                return ctx.SaveChanges() >= 1;
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
                                    Phone = c.Phone,
                                    Email = c.Email,
                                    Category = c.Category.ToString(),
                                    SchoolDistricts = c.SchoolDistricts
                                                       .Select(d =>
                                                                    new SchoolDistrictItem
                                                                    {
                                                                        Id = d.Id,
                                                                        DistrictName = d.DistrictName,
                                                                        DistrictContact = d.DistrictContact,
                                                                        ContactTitle = d.ContactTitle,
                                                                        Email = d.Email,
                                                                        Telephone = d.Telephone
                                                                    }).ToList()
                                }
                        );

                return query.ToList();
            }
        }

        public bool UpdateConsultant(ConsultantEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Consultants
                        .SingleOrDefault(c => c.Id == model.Id);

                entity.Name = model.Name;
                entity.Phone = model.Phone;
                entity.Email = model.Email;
                entity.Category = model.Category;

                for(var distIndex = 0; distIndex < entity.SchoolDistricts.Count; distIndex++)
                {
                    entity.SchoolDistricts.Remove(entity.SchoolDistricts[distIndex]);
                }

                foreach (Guid guid in model.SchoolDistrictIds)
                {
                    var query =
                        ctx
                            .SchoolDistricts
                            .SingleOrDefault(d => d.Id == guid);

                    if (query != null)
                    {
                        entity.SchoolDistricts.Add(query);
                    }
                }

                return ctx.SaveChanges() >= 1;
            }
        }

        public bool DeleteConsultant(ConsultantDelete consultant)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Consultants
                        .SingleOrDefault(c => c.Id == consultant.Id);
                ctx.Consultants.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
