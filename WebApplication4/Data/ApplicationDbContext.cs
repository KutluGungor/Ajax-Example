using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext() : base("name=DefaultConnection") { }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<City> Cities { get; set; }

    }
}