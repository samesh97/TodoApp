using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoBackend.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool isFinished { get; set; }
    }
}
