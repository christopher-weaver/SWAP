using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.Data
{
    public class Project
    {
        [Required]
        public Guid Id { get; set; }

        // build enums
        [Required]
        public string Category { get; set; }

        [Required]
        public string Subcategory { get; set; }

        [Required]
        public string Status { get; set; }
        //

        [ForeignKey(nameof(SchoolDistrict))]
        public int DistrictID { get; set; }
        public virtual SchoolDistrict SchoolDistrict { get; set; }

        [ForeignKey(nameof(Consultant))]
        public int ConsultantId { get; set; }
        public virtual Consultant Consultant { get; set; }

        public DateTime DueDate { get; set; }

        public string Notes { get; set; }
    }
}
