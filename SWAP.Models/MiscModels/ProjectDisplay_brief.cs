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
    public class ProjectDisplay_brief
    {
        public Guid Id { get; set; }

        public string Category { get; set; }

        public string Subcategory { get; set; }

        public string Status { get; set; }

        public ConsultantListItem_brief Consultant { get; set; }

        public DateTime DueDate { get; set; }

        public string Notes { get; set; }
    }
}
