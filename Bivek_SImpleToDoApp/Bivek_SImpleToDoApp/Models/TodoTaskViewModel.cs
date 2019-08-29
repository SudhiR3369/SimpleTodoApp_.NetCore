using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bivek_SImpleToDoApp.Models
{
    public class TodoTaskViewModel
    {
        public int? Id { get; set; }        
        [Required]
        public string Task { get; set; }       
        [Required]
        public string TaskDate { get; set; }
        [Required]
        public string Description { get; set; }
        public bool? IsComplete { get; set; } = false;
    }
    //public class TodoTaskPostViewModel
    //{
    //    public string Task { get; set; }
    //    [Required]
    //    public string TaskDate { get; set; }
    //    [Required]
    //    public string Description { get; set; }
    //}
}
