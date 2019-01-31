using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Skietbaan_T2.Models
{
    public class ModelsContext : DbContext
    {
        public ModelsContext(DbContextOptions<ModelsContext> options)
           : base(options)
        { }

        public ModelsContext() : base() { }

        //Tables
        public virtual DbSet<User> Users { get; set; }

        
    }
}
