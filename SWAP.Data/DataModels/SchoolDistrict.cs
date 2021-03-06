using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.Data
{
    public class SchoolDistrict
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string DistrictName { get; set; }

        public string DistrictContact { get; set; }

        public string ContactTitle { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public List<Project> Projects { get; set; }

        public SchoolDistrict()
        {
            Id = Guid.NewGuid();
        }
    }
}
