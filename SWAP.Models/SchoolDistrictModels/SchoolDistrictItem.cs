using SWAP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.Models.SchoolDistrictPOST
{
   public class SchoolDistrictItem
    {
        public Guid Id { get; set; }

        public string DistrictName { get; set; }

        public string DistrictContact { get; set; }

        public string ContactTitle { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public List<Project> Projects { get; set; }
    }
}
