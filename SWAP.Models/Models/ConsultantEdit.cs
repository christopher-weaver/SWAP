using SWAP.Data.DataModels.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.Models.Models
{
    public class ConsultantEdit
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

       public Category Category { get; set; }
    }
}
