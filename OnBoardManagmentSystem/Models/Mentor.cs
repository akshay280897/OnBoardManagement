using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnBoardManagement.Models
{
    public class Mentor
    {
        [Key]
        public int M_Id { get; set; }
        public string M_Name { get; set; }
        public ICollection<OnBoarder> OnBoarders { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}