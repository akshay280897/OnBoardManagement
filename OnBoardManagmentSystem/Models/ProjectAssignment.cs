using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnBoardManagement.Models
{
    public class ProjectAssignment
    {
        [Key]
        public int PA_Id { get; set; }
        public int P_Id { get; set; }
        public int O_Id { get; set; }
        public string O_RotationNo { get; set; }
        public DateTime StartDate { get; set; }
    }
}