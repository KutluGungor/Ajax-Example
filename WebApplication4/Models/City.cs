using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class City
    {
        public City()
        {
            Feedbacks = new HashSet<Feedback>();
        }
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Şehir Adı")]
        public string Name { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}