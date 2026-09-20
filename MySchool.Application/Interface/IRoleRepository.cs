using System;
using System.Collections.Generic;
using System.Text;

namespace MySchool.Application.Interface
{
    public interface IRoleRepository
    {
        Task<List<Domain.Entities.Roles>> GetAllAsync();
        Task<Domain.Entities.Roles> GetByIdAsync(string id);
        Task CreateAsync(Domain.Entities.Roles role);
        Task UpdateAsync(Domain.Entities.Roles role);
        Task DeleteAsync(Domain.Entities.Roles role);
    }
}
