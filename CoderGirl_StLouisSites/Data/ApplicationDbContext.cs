﻿using System;
using System.Collections.Generic;
using System.Text;
using CoderGirl_StLouisSites.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoderGirl_StLouisSites.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Location> Locations { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
