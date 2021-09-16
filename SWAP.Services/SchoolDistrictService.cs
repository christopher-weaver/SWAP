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
    }
}
