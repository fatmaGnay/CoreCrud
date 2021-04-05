using Data.Context;
using Data.Dto;
using Data.Models;
using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presantation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        MasterContext masterContext = new MasterContext();
        public ProjectController()
        {

        }
        [HttpPost("AddProject")]
        public string AddProject(ProjectDto projectDto)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(masterContext))
            {
                Project project = new Project()
                {
                    Id = projectDto.Id,
                    Name = projectDto.Name
                };
                unitOfWork.GetRepository<Project>().Add(project);
                unitOfWork.SaveChange();
            }
            return "Proje başarı ile kaydedildi";
        }
        [HttpPost("AddProjectRole")]
        public string AddProjectRole(ProjectRoleDto projectRoleDto)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(masterContext))
            {
                ProjectRole projectRole = new ProjectRole()
                {
                    Id = projectRoleDto.Id,
                    UserId = projectRoleDto.UserId,
                    ProjectId = projectRoleDto.ProjectId
                };
                unitOfWork.GetRepository<ProjectRole>().Add(projectRole);
                unitOfWork.SaveChange();
            }
            return "ProjectRole başarı ile kaydedildi";
        }
        [HttpGet("GetProject")]
        public Project GetProject(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(masterContext))
            {
                return unitOfWork.GetRepository<Project>().Get(id);
            }
        }
        [HttpGet("GetProjectRole")]
        public List<ProjectRoleDto> GetProjectRole(int id)
        {
            List<ProjectRoleDto> projectRoleDtos = (from prole in masterContext.projectRoles
                                                    join pro in masterContext.projects on prole.ProjectId equals pro.Id //projectId ve projectroleId eşitse join işlemi yapılır.
                                                    where prole.ProjectId == id
                                                    select new ProjectRoleDto
                                                    {
                                                        Id = prole.Id,
                                                        ProjectId = prole.ProjectId,
                                                        UserId = prole.UserId,
                                                        ProjectName = pro.Name

                                                    }
                                                   ).ToList();
            return projectRoleDtos;
        }
        [HttpPut("SetProject")]
        public string SetProject(ProjectDto projectDto)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(masterContext))
            {
                Project project = unitOfWork.GetRepository<Project>().Get(projectDto.Id);
                {
                    project.Id = projectDto.Id;
                    project.Name = projectDto.Name;
                    unitOfWork.GetRepository<Project>().Update(project);
                    unitOfWork.SaveChange();
                }
                return "Proje güncelleme başarılı";
            }
        }
        [HttpPut("SetProjectRole")]
        public string SetProjectRole(ProjectRoleDto projectRoleDto)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(masterContext))
            {
                ProjectRole projectRole = unitOfWork.GetRepository<ProjectRole>().Get(projectRoleDto.Id);
                projectRole.Id = projectRoleDto.Id;
                projectRole.UserId = projectRoleDto.UserId;
                projectRole.ProjectId = projectRoleDto.ProjectId;
                unitOfWork.GetRepository<ProjectRole>().Update(projectRole);
                unitOfWork.SaveChange();
            }
            return "ProjectRole güncelleme başarılı";
        }
        [HttpDelete("DeleteProject")]
        public string DeleteProject(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(masterContext))
            {
                Project project = unitOfWork.GetRepository<Project>().Get(id);
                unitOfWork.GetRepository<Project>().Delete(project);
                unitOfWork.SaveChange();
            }
            return "Project silme başarılı";
        }
        [HttpDelete("DeleteProjectRole")]
        public string DeleteProjectRole(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(masterContext))
            {
                ProjectRole projectRole = unitOfWork.GetRepository<ProjectRole>().Get(id);
                unitOfWork.GetRepository<ProjectRole>().Delete(projectRole);
                unitOfWork.SaveChange();
            }
            return "ProjectRole silme başarılı";
        }
    }
}
