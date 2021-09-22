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
    public class Consultant
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        [Required]
        public Category Category { get; set; }

        public virtual List<SchoolDistrict> SchoolDistricts { get; set; } = new List<SchoolDistrict>();

        public Consultant()
        {
            Id = Guid.NewGuid();
        }
    }
}
