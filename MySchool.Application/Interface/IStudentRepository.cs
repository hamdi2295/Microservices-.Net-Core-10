using System;
using System.Collections.Generic;
using System.Text;
using MySchool.Domain.Entities;

namespace MySchool.Application.Interface
{
    public interface IStudentRepository
    {
        Task<Domain.Entities.Students?> GetByIdAsync(long id);
        Task CreateAsync(Domain.Entities.Students student);
        Task UpdateAsync(Domain.Entities.Students student);
        Task DeleteAsync(long id);
    }
}
