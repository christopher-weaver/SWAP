using SWAP.Data;
using SWAP.Data.DataModels.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.Models.Models
{
    public class ProjectDisplay
    {
        public Category Category { get; set; }

        public Subcategory Subcategory { get; set; }

        public Status Status { get; set; }

        public SchoolDistrict SchoolDistrict { get; set; }

        public Consultant Consultant { get; set; }

        public DateTime DueDate { get; set; }

        public string Notes { get; set; }
    }
}
