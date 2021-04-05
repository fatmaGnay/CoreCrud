using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Dto
{
    public class ProjectRoleDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
    }
}
