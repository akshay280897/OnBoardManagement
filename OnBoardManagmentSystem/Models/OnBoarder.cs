using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnBoardManagement.Models
{
    public class OnBoarder
    {
        [Key]
        public int O_Id { get; set; }
        public string O_Name { get; set; }
        public string O_RotationNo { get; set; }
        public string ReportingManager { get; set; }
        public int M_Id { get; set; }
        public ICollection<ProjectAssignment> ProjectAssignments { get; set; }
    }
}