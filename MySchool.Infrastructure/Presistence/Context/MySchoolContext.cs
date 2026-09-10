using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MySchool.Infrastructure.Presistence.Database.Students;
using MySchool.Infrastructure.Presistence.Database.Auth;

namespace MySchool.Infrastructure.Presistence.Context
{
    public class MySchoolContext : DbContext
    {

        public MySchoolContext(
            DbContextOptions<MySchoolContext> options)
            : base(options)
        {
        }

        //students
        public DbSet<M_Students> M_Students => Set<M_Students>();

        //auth
        public DbSet<M_Roles> M_Roles => Set<M_Roles>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(MySchoolContext).Assembly);
        }
    }
}
