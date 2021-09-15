﻿using SWAP.Data;
using SWAP.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.Services.Services
{
    public class ProjectService
    {
        public ProjectService()
        {
        }

        public bool CreateProject(ProjectCreate model)
        {
            var newProject =
                new Project()
                {
                    Category = model.Category,
                    Subcategory = model.Subcategory,
                    SchoolDistrict = model.SchoolDistrict,
                    Consultant = model.Consultant,
                    Status = model.Status
                };

            if (model.DueDate != DateTime.MinValue)
            {
                newProject.DueDate = model.DueDate;
            }

            if (model.Notes != "")
            {
                newProject.Notes = model.Notes;
            }

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Projects.Add(newProject);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
