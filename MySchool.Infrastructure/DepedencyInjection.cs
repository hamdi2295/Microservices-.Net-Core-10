using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MySchool.Application.Interface;
using MySchool.Infrastructure.Presistence.Context;
using MySchool.Infrastructure.Presistence.Repositories;
using MySchool.Application.Students;
using MySchool.Infrastructure.Presistence.UnitOfWork;

namespace MySchool.Infrastructure
{
    public static class DepedencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<MySchoolContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("SchoolDB"),
                    sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(10),
                            errorNumbersToAdd: null);
                    });
            });

            //repositories
            services.AddScoped<IStudentRepository, StudentRepository>();

            //usecase
            services.AddScoped<StudentsUsecase>();

            //unit of works
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
