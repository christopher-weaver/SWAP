using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.Data.DataModels
{
    public class SchoolDistrictGet
    {
        public string DistrictName { get; set; }

        public string DistrictContact { get; set; }

        public List<Project> Projects { get; set; } = new List<Project>();

    }
}
