using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnBoardManagement.Models
{
    public class Project
    {
        [Key]
        public int P_Id { get; set; }
        public string P_Name { get; set; }

        public string P_Technology { get; set; }
        
        public int M_Id { get; set; }
        public ICollection<ProjectAssignment> ProjectAssignments { get; set; }


     public Mentor mentor { get; set; }

    }
}