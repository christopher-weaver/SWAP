using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.Data
{
    public class Consultant
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        // build enum
        public string Category { get; set; }
    }
}
