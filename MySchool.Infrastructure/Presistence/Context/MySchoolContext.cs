using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MySchool.Infrastructure.Presistence.Database.Students;

namespace MySchool.Infrastructure.Presistence.Context
{
    public class MySchoolContext : DbContext
    {

        public MySchoolContext(
            DbContextOptions<MySchoolContext> options)
            : base(options)
        {
        }

        public DbSet<M_Students> M_Students => Set<M_Students>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(MySchoolContext).Assembly);
        }
    }
}
