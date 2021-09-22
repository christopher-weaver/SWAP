using SWAP.Data;
using SWAP.Data.DataModels.Enumerations;
using SWAP.Models.SchoolDistrictPOST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.Models.Models
{
    public class ProjectDisplay
    {
        public Guid Id { get; set; }

        public string Category { get; set; }

        public string Subcategory { get; set; }

        public string Status { get; set; }

        public SchoolDistrictItem SchoolDistrict { get; set; }

        public ConsultantListItem Consultant { get; set; }

        public DateTime DueDate { get; set; }

        public string Notes { get; set; }
    }
}
