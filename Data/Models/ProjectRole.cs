using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class ProjectRole
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
    }
}
