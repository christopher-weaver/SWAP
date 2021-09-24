using SWAP.Data;
using SWAP.Data.DataModels;
using SWAP.Models.Models;
using SWAP.Models.SchoolDistrictPOST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.Services
{
    public class SchoolDistrictService
    {
        public bool CreateSchoolDistrict(SchoolDistrictCreate schoolDistrict)
        {
            var entity = new SchoolDistrict
            {
                DistrictName = schoolDistrict.DistrictName,
                DistrictContact = schoolDistrict.DistrictContact,
                ContactTitle = schoolDistrict.ContactTitle,
                Telephone = schoolDistrict.Telephone,
                Email = schoolDistrict.Email,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.SchoolDistricts.Add(entity);
                return ctx.SaveChanges() >= 1;
            }
        }

        public IEnumerable<SchoolDistrictItem> GetAllSchoolDistricts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .SchoolDistricts
                    .Select(e =>
                    new SchoolDistrictItem
                    {
                        Id = e.Id,
                        DistrictName = e.DistrictName,
                        DistrictContact = e.DistrictContact,
                        ContactTitle = e.ContactTitle,
                        Telephone = e.Telephone,
                        Email = e.Email,
                        Projects = e.Projects
                                    .Select(p =>
                                                new ProjectDisplay_brief
                                                {
                                                    Id = p.Id,
                                                    Category = p.Category.ToString(),
                                                    Subcategory = p.Subcategory.ToString(),
                                                    Consultant = ctx.Consultants
                                                                    .Where(c => c.Id == p.Consultant.Id)
                                                                    .Select(c =>
                                                                                new ConsultantListItem_brief
                                                                                {
                                                                                    Id = c.Id,
                                                                                    Name = c.Name,
                                                                                    Category = c.Category.ToString(),
                                                                                    Phone = c.Phone,
                                                                                    Email = c.Email,
                                                                                }).FirstOrDefault(),
                                                    Status = p.Status.ToString(),
                                                    DueDate = p.DueDate,
                                                    Notes = p.Notes                                                    
                                                }).ToList(),
                        PointOfContact = ctx.Consultants
                                            .Where(c => c.SchoolDistricts.Contains(e))
                                            .Select(c =>
                                                        new ConsultantListItem_brief
                                                        {
                                                            Id = c.Id,
                                                            Name = c.Name,
                                                            Category = c.Category.ToString(),
                                                            Phone = c.Phone,
                                                            Email = c.Email,
                                                        }).FirstOrDefault(),
                    }
                );

                return query.ToArray();
            }
        }

        public IEnumerable<SchoolDistrictItem> GetSchoolDistrict(Guid districtId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .SchoolDistricts
                    .Where(e => e.Id == districtId)
                    .Select(e =>
                    new SchoolDistrictItem
                    {
                        Id = e.Id,
                        DistrictName = e.DistrictName,
                        DistrictContact = e.DistrictContact,
                        ContactTitle = e.ContactTitle,
                        Telephone = e.Telephone,
                        Email = e.Email,
                        Projects = e.Projects
                                    .Select(p =>
                                                new ProjectDisplay_brief
                                                {
                                                    Id = p.Id,
                                                    Category = p.Category.ToString(),
                                                    Subcategory = p.Subcategory.ToString(),
                                                    Consultant = ctx.Consultants
                                                                    .Where(c => c.Id == p.Consultant.Id)
                                                                    .Select(c =>
                                                                                new ConsultantListItem_brief
                                                                                {
                                                                                    Id = c.Id,
                                                                                    Name = c.Name,
                                                                                    Category = c.Category.ToString(),
                                                                                    Phone = c.Phone,
                                                                                    Email = c.Email,
                                                                                }).FirstOrDefault(),
                                                    Status = p.Status.ToString(),
                                                    DueDate = p.DueDate,
                                                    Notes = p.Notes
                                                }).ToList(),
                        PointOfContact = ctx.Consultants
                                            .Where(c => c.SchoolDistricts.Contains(e))
                                            .Select(c =>
                                                        new ConsultantListItem_brief
                                                        {
                                                            Id = c.Id,
                                                            Name = c.Name,
                                                            Category = c.Category.ToString(),
                                                            Phone = c.Phone,
                                                            Email = c.Email,
                                                        }).FirstOrDefault(),
                    }
                );

                return query.ToArray();
            }
        }

        //public SchoolDistrictItem GetSchoolDistrict(Guid guid)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var query =
        //            ctx
        //            .SchoolDistricts
        //            .SingleOrDefault(e => e.Id == guid);
        //        return new SchoolDistrictItem
        //        {
        //            Id = query.Id,
        //            DistrictName = query.DistrictName,
        //            DistrictContact = query.DistrictContact,
        //            ContactTitle = query.ContactTitle,
        //            Telephone = query.Telephone,
        //            Email = query.Email,
        //            Projects = query.Projects
        //        };
        //    }
        //}

        public bool UpdateSchoolDistrict(SchoolDistrictEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .SchoolDistricts
                    .SingleOrDefault(e => e.Id == model.Id);

                entity.DistrictName = model.DistrictName;
                entity.DistrictContact = model.DistrictContact;
                entity.ContactTitle = model.ContactTitle;
                entity.Telephone = model.Telephone;
                entity.Email = model.Email;

                return ctx.SaveChanges() >= 1;
            }
        }

        public bool DeleteSchoolDistrict(SchoolDistrictDelete district)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var schoolDistrictDelete =
                    ctx
                    .SchoolDistricts
                    .SingleOrDefault(s => s.Id == district.Id);

                ctx.SchoolDistricts.Remove(schoolDistrictDelete);

                return ctx.SaveChanges() >= 1;
            }
        }
    }
}
