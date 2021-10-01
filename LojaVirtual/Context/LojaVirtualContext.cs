﻿using LojaVirtual.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Database
{
    public class LojaVirtualContext : DbContext 
    {
        public LojaVirtualContext(DbContextOptions<LojaVirtualContext> options) : base(options)
        {

        }

        public DbSet<User> Clientes { get; set; }

        public DbSet<NewslertterEmail> NewslertterEmails { get; set; }
        public DbSet<Collaborator> Collaborators { get; set; }
    }
}
