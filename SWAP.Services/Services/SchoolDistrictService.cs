using SWAP.Data;
using SWAP.Data.DataModels;
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

        public IEnumerable<SchoolDistrictItem> GetSchoolDistrict()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .SchoolDistricts
                    .Select(e =>
                    new SchoolDistrictItem
                    {
                        DistrictName = e.DistrictName,
                        DistrictContact = e.DistrictContact,
                        ContactTitle = e.ContactTitle,
                        Telephone = e.Telephone,
                        Projects = e.Projects
                    }
                );
                return query.ToArray();
            }
        }

        public bool UpdateSchoolDistrict(SchoolDistrictEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .SchoolDistricts
                    .Single(e => e.Id == model.Id);

                entity.DistrictName = model.DistrictName;
                entity.DistrictContact = model.DistrictContact;
                entity.ContactTitle = model.ContactTitle;
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
                    .Single(s => s.Id == district.Id);

                ctx.SchoolDistricts.Remove(schoolDistrictDelete);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
