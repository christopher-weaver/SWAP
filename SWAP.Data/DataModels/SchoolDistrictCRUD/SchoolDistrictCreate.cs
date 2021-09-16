using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.Data.DataModels.SchoolDistrictCRUD
{
    public class SchoolDistrictCreate
    {
        [Required]
        public string DistrictName { get; set; }

        public string DistrictContact { get; set; }

        public string ContactTitle { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public List<SchoolDistrict> SchoolDistricts { get; set; } = new List<SchoolDistrict>();
    }
}
