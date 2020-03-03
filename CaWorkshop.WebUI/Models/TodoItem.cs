using System;
using System.ComponentModel.DataAnnotations;

namespace CaWorkshop.WebUI.Models
{
    public class TodoItem
    {
        public long Id { get; set; }

        public int ListId { get; set; }

        [Required]
        [StringLength(280)]
        public string Title { get; set; }

        [StringLength(4000)]
        public string Note { get; set; }

        public bool Done { get; set; }

        public DateTime? Reminder { get; set; }

        public PriorityLevel Priority { get; set; }

        public TodoList List { get; set; }
    }
}