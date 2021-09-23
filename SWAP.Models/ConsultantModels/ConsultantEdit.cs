using SWAP.Data;
using SWAP.Data.DataModels.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.Models.Models
{
    public class ConsultantEdit
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        [Required]
        [Range(0, 3)]
        public Category Category { get; set; }

        public List<Guid> SchoolDistrictIds { get; set; }
    }
}
