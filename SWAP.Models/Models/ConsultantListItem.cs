using SWAP.Data.DataModels.Enumerations;
using SWAP.Models.SchoolDistrictPOST;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.Models.Models
{
    public class ConsultantListItem
    {
                
        public Guid Id { get; set; }
                
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Category { get; set; }

        public List<SchoolDistrictItem> SchoolDistricts { get; set; }
    }
}
