using Microsoft.EntityFrameworkCore;
using MySchool.Application.Interface;
using MySchool.Domain;
using MySchool.Domain.Entities;
using MySchool.Infrastructure.Presistence.Context;
using MySchool.Infrastructure.Presistence.Database.Students;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;

namespace MySchool.Infrastructure.Presistence.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly MySchoolContext _context;

        public StudentRepository(MySchoolContext context)
        {
            _context = context;
        }

        public async Task<Students?> GetByIdAsync(long id)
        {
            var data = await _context.M_Students.FirstOrDefaultAsync(x => x.StudentId == id);

            if(data == null)
            {
                return null;
            }

            Students student = new Students(
                data.StudentId,
                data.StudentNumber,
                data.NationalStudentNumber,
                data.FullName,
                data.Gender,
                data.BirthPlace,
                data.BirthDate,
                data.Address,
                data.PhoneNumber,
                data.Email,
                data.Class,
                data.EnrollmentDate,
                data.CreatedUser,
                data.CreatedDate,
                data.UpdatedUser,
                data.UpdatedDate,
                data.DeletedUser,
                data.DeletedDate,
                data.Status
             );

            return student;
        }


        public async Task CreateAsync(Students student)
        {
            M_Students data = new M_Students();

            data.StudentNumber = student.StudentNumber;
            data.NationalStudentNumber = student.NationalStudentNumber;
            data.FullName = student.FullName;
            data.Gender = student.Gender;
            data.BirthPlace = student.BirthPlace;
            data.BirthDate = student.BirthDate;
            data.Address = student.Address;
            data.PhoneNumber = student.PhoneNumber;
            data.Email = student.Email;
            data.Class = student.Class;
            data.EnrollmentDate = student.EnrollmentDate;
            data.CreatedUser = student.CreatedUser;
            data.CreatedDate = DateTime.UtcNow.ToLocalTime();
            data.Status = true;

            await _context.M_Students.AddAsync(data);
        }


        public async Task UpdateAsync(Students student)
        {
            var data = await _context.M_Students.FirstOrDefaultAsync(x => x.StudentId == student.StudentId);

            data.StudentNumber = student.StudentNumber;
            data.NationalStudentNumber = student.NationalStudentNumber;
            data.FullName = student.FullName;
            data.Gender = student.Gender;
            data.BirthPlace = student.BirthPlace;
            data.BirthDate = student.BirthDate;
            data.Address = student.Address;
            data.PhoneNumber = student.PhoneNumber;
            data.Email = student.Email;
            data.Class = student.Class;
            data.EnrollmentDate = student.EnrollmentDate;
            data.UpdatedUser = student.UpdatedUser;
            data.UpdatedDate = DateTime.UtcNow.ToLocalTime();
            data.Status = true;
        }


        public async Task DeleteAsync(long id)
        {

            var data = await _context.M_Students.FirstOrDefaultAsync(x => x.StudentId == id);

            _context.M_Students.Remove(data);
        }
    }
}
