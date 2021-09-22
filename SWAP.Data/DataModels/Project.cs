using SWAP.Data.DataModels.Enumerations;
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
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public Subcategory Subcategory { get; set; }

        [Required]
        public Status Status { get; set; }

        [ForeignKey(nameof(SchoolDistrict))]
        public Guid DistrictID { get; set; }
        public virtual SchoolDistrict SchoolDistrict { get; set; }

        [ForeignKey(nameof(Consultant))]
        public Guid ConsultantId { get; set; }
        public virtual Consultant Consultant { get; set; }

        public DateTime DueDate { get; set; }

        public string Notes { get; set; }

        public Project()
        {
            Id = Guid.NewGuid();
        }
    }
}
