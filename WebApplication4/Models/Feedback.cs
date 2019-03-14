using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class Feedback
    {
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Ad")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "E-posta")]
        public string Email { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }

        [Display(Name = "Ülke")]
        public Guid? CountryId { get; set; }
        [Display(Name = "Ülke")]
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        [Required]
        [Display(Name = "Şehir")]
        public Guid? CityId { get; set; }
        [ForeignKey("CityId")]
        [Display(Name = "Şehir")]
        public virtual City City { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Mesaj")]
        public string Message { get; set; }
    }
}