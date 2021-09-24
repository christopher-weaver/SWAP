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
    public class ProjectCreate
    {
        [Required]
        public Category Category { get; set; }

        [Required]
        public Subcategory Subcategory { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public Guid SchoolDistrictId { get; set; }

        [Required]
        public Guid ConsultantId { get; set; }

        public DateTime DueDate { get; set; }

        public string Notes { get; set; }
    }
}
