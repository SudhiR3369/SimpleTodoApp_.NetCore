using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryData
{
    public class TodoTask
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Task { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }        
        public bool IsComplete { get; set; } = false;        
        public DateTime TaskDate { get; set; }
    }
}
