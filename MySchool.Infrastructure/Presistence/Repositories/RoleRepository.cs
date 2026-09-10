using Microsoft.EntityFrameworkCore;
using MySchool.Domain.Entities;
using MySchool.Infrastructure.Presistence.Context;
using MySchool.Infrastructure.Presistence.Database.Auth;
using MySchool.Infrastructure.Presistence.Database.Students;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySchool.Infrastructure.Presistence.Repositories
{
    public class RoleRepository
    {
        private readonly MySchoolContext _context;

        public RoleRepository(MySchoolContext context)
        {
            _context = context;
        }


        public async Task<List<Roles>> GetAll()
        {
            var data = await _context.M_Roles.ToListAsync();

            if (data == null || data.Count <= 0)
            {
                return null;
            }

            List<Roles> roles = new List<Roles>();

            foreach(var item in data)
            {
                Roles role = new Roles(
                    item.RoleId,
                    item.RoleName,
                    item.CreatedUser,
                    item.CreatedDate,
                    item.UpdatedUser,
                    item.UpdatedDate,
                    item.DeletedUser,
                    item.DeletedDate,
                    item.IsDeleted
                 );

                roles.Add( role );
            }            

            return roles;
        }


        public async Task<Roles> GetByIdAsync(string id)
        {
            var data = await _context.M_Roles.FirstOrDefaultAsync(x => x.RoleId == id);

            if (data == null)
            {
                return null;
            }

            Roles student = new Roles(
                data.RoleId,
                data.RoleName,
                data.CreatedUser,
                data.CreatedDate,
                data.UpdatedUser,
                data.UpdatedDate,
                data.DeletedUser,
                data.DeletedDate,
                data.IsDeleted
             );

            return student;
        }


        public async Task CreateAsync(Roles role)
        {
            M_Roles data = new M_Roles();

            data.RoleId = role.RoleId;
            data.RoleName = role.RoleName;
            data.CreatedUser = role.CreatedUser;
            data.CreatedDate = (DateTime)role.CreatedDate;
            data.IsDeleted = false;

            await _context.M_Roles.AddAsync(data);
        }


        public async Task UpdateAsync(Roles role)
        {
            var data = await _context.M_Roles.FirstOrDefaultAsync(x => x.RoleId == role.RoleId);

            data.RoleName = role.RoleName;
            data.UpdatedUser = role.UpdatedUser;
            data.UpdatedDate = (DateTime)role.UpdatedDate;
        }


        public async Task DeleteAsync(Roles role)
        {

            var data = await _context.M_Roles.FirstOrDefaultAsync(x => x.RoleId == role.RoleId);

            data.DeletedUser = role.DeletedUser;
            data.DeletedDate = DateTime.UtcNow.ToLocalTime();
            data.IsDeleted = true;
        }
    }
}
