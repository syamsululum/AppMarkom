using AppMarkom.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace AppMarkom.Data
{
    public class MarkomContext : IdentityDbContext
    {
        public MarkomContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<m_company> m_companies { get; set; }
        public virtual DbSet<m_employee> m_employees { get; set; }
        public virtual DbSet<m_role> m_roles { get; set; }
    }
}
