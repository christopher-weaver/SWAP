using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.Models.Models
{
    public class ConsultantDelete
    {
        [Required]
        public Guid Id { get; set; }
    }
}
