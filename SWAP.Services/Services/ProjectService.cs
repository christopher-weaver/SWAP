using SWAP.Data;
using SWAP.Models.Models;
using SWAP.Models.SchoolDistrictPOST;
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
                var distQuery =
                        ctx
                            .SchoolDistricts
                            .SingleOrDefault(d => d.Id == model.SchoolDistrictId);

                if (distQuery != null)
                {
                    newProject.SchoolDistrict = distQuery;
                }

                var consQuery =
                        ctx
                            .Consultants
                            .SingleOrDefault(d => d.Id == model.ConsultantId);

                if (consQuery != null)
                {
                    newProject.Consultant = consQuery;
                }

                ctx.Projects.Add(newProject);
                return ctx.SaveChanges() >= 1;
            }
        }

        public IEnumerable<ProjectDisplay> GetAllProjects()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Projects
                        .Select(
                            p => new ProjectDisplay
                            {
                                Id = p.Id,
                                Category = p.Category.ToString(),
                                Subcategory = p.Subcategory.ToString(),
                                Status = p.Status.ToString(),
                                DueDate = p.DueDate,
                                Notes = p.Notes,
                                SchoolDistrict = ctx.SchoolDistricts
                                                    .Where(d => d.Id == p.SchoolDistrict.Id)
                                                    .Select(d =>
                                                                new SchoolDistrictItem
                                                                {
                                                                    Id = d.Id,
                                                                    DistrictName = d.DistrictName,
                                                                    DistrictContact = d.DistrictContact,
                                                                    ContactTitle = d.ContactTitle,
                                                                    Email = d.Email,
                                                                    Telephone = d.Telephone
                                                                }).FirstOrDefault(),
                                Consultant = ctx.Consultants
                                                    .Where(c => c.Id == p.Consultant.Id)
                                                    .Select(c =>
                                                                new ConsultantListItem
                                                                {
                                                                    Id = c.Id,
                                                                    Name = c.Name,
                                                                    Category = c.Category.ToString(),
                                                                    Phone = c.Phone,
                                                                    Email = c.Email,
                                                                    SchoolDistricts = c.SchoolDistricts
                                                                                       .Select(d =>
                                                                                                    new SchoolDistrictItem
                                                                                                    {
                                                                                                        Id = d.Id,
                                                                                                        DistrictName = d.DistrictName,
                                                                                                        DistrictContact = d.DistrictContact,
                                                                                                        ContactTitle = d.ContactTitle,
                                                                                                        Email = d.Email,
                                                                                                        Telephone = d.Telephone
                                                                                                    }).ToList()
                                                                }).FirstOrDefault()
                            });

                return query.ToArray();
            }
        }

        public IEnumerable<ProjectDisplay> GetProject(Guid projectId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Projects
                        .Where(p => p.Id == projectId)
                        .Select(
                            p => new ProjectDisplay
                            {
                                Id = p.Id,
                                Category = p.Category.ToString(),
                                Subcategory = p.Subcategory.ToString(),
                                Status = p.Status.ToString(),
                                DueDate = p.DueDate,
                                Notes = p.Notes,
                                SchoolDistrict = ctx.SchoolDistricts
                                                    .Where(d => d.Id == p.SchoolDistrict.Id)
                                                    .Select(d =>
                                                                new SchoolDistrictItem
                                                                {
                                                                    Id = d.Id,
                                                                    DistrictName = d.DistrictName,
                                                                    DistrictContact = d.DistrictContact,
                                                                    ContactTitle = d.ContactTitle,
                                                                    Email = d.Email,
                                                                    Telephone = d.Telephone
                                                                }).FirstOrDefault(),
                                Consultant = ctx.Consultants
                                                    .Where(c => c.Id == p.Consultant.Id)
                                                    .Select(c =>
                                                                new ConsultantListItem
                                                                {
                                                                    Id = c.Id,
                                                                    Name = c.Name,
                                                                    Category = c.Category.ToString(),
                                                                    Phone = c.Phone,
                                                                    Email = c.Email,
                                                                    SchoolDistricts = c.SchoolDistricts
                                                                                       .Select(d =>
                                                                                                    new SchoolDistrictItem
                                                                                                    {
                                                                                                        Id = d.Id,
                                                                                                        DistrictName = d.DistrictName,
                                                                                                        DistrictContact = d.DistrictContact,
                                                                                                        ContactTitle = d.ContactTitle,
                                                                                                        Email = d.Email,
                                                                                                        Telephone = d.Telephone
                                                                                                    }).ToList()
                                                                }).FirstOrDefault()
                            });

                return query.ToArray();
            }
        }

        public bool UpdateProject(ProjectEdit editedProject)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var projectToEdit =
                    ctx
                        .Projects
                        .SingleOrDefault(p => p.Id == editedProject.Id);

                projectToEdit.Category = editedProject.Category;
                projectToEdit.Subcategory = editedProject.Subcategory;
                projectToEdit.Status = editedProject.Status;

                var query =
                        ctx
                            .Consultants
                            .SingleOrDefault(c => c.Id == editedProject.ConsultantId);

                if (query != null)
                {
                    projectToEdit.Consultant = query;
                }

                if (editedProject.DueDate != DateTime.MinValue)
                {
                    projectToEdit.DueDate = editedProject.DueDate;
                }

                if (editedProject.Notes != "")
                {
                    projectToEdit.Notes = editedProject.Notes;
                }

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteProject(ProjectDelete project)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var projectToDelete =
                    ctx
                        .Projects
                        .SingleOrDefault(p => p.Id == project.Id);

                ctx.Projects.Remove(projectToDelete);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
