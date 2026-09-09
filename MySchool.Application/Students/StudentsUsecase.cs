using MySchool.Application.Interface;
using MySchool.Domain.DTOs.Request.Students;
using MySchool.Domain.DTOs.Response.Students;
using MySchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MySchool.Application.Students
{
    public class StudentsUsecase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWork _unitOfWork;

        
        public StudentsUsecase(
            IStudentRepository studentRepository,
            IUnitOfWork unitOfWork)
        {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<M_StudentResponse?> GetStudentsById(long id)
        {
            try
            {
                var student = await _studentRepository.GetByIdAsync(id);

                if (student == null)
                {
                    return null;
                }

                return new M_StudentResponse
                {
                    StudentId = student.StudentId,
                    StudentNumber = student.StudentNumber,
                    NationalStudentNumber = student.NationalStudentNumber,
                    FullName = student.FullName,
                    Gender = student.Gender,
                    BirthPlace = student.BirthPlace,
                    BirthDate = student.BirthDate,
                    Address = student.Address,
                    PhoneNumber = student.PhoneNumber,
                    Email = student.Email,
                    Class = student.Class,
                    EnrollmentDate = student.EnrollmentDate,
                    Status = student.Status
                };
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        
        public async Task CreateStudent(M_StudentRequest request)
        {
            try
            {
                Domain.Entities.Students students = new Domain.Entities.Students(
                    request.StudentId,
                    request.StudentNumber,
                    request.NationalStudentNumber,
                    request.FullName,
                    request.Gender,
                    request.BirthPlace,
                    request.BirthDate,
                    request.Address,
                    request.PhoneNumber,
                    request.Email,
                    request.Class,
                    request.EnrollmentDate,
                    request.CreatedUser,
                    request.CreatedDate,
                    request.UpdatedUser,
                    request.UpdatedDate,
                    request.DeletedUser,
                    request.DeletedDate,
                    request.Status
                );

                await _studentRepository.CreateAsync(students);
                await _unitOfWork.SaveChangeAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }


        public async Task UpdateStudent(M_StudentRequest request)
        {
            try
            {
                Domain.Entities.Students students = new Domain.Entities.Students(
                    request.StudentId,
                    request.StudentNumber,
                    request.NationalStudentNumber,
                    request.FullName,
                    request.Gender,
                    request.BirthPlace,
                    request.BirthDate,
                    request.Address,
                    request.PhoneNumber,
                    request.Email,
                    request.Class,
                    request.EnrollmentDate,
                    request.CreatedUser,
                    request.CreatedDate,
                    request.UpdatedUser,
                    request.UpdatedDate,
                    request.DeletedUser,
                    request.DeletedDate,
                    request.Status
                );

                await _studentRepository.UpdateAsync(students);
                await _unitOfWork.SaveChangeAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }


        public async Task DeleteStudent(M_StudentRequest request)
        {
            try
            {
                Domain.Entities.Students students = new Domain.Entities.Students(
                    request.StudentId,
                    request.StudentNumber,
                    request.NationalStudentNumber,
                    request.FullName,
                    request.Gender,
                    request.BirthPlace,
                    request.BirthDate,
                    request.Address,
                    request.PhoneNumber,
                    request.Email,
                    request.Class,
                    request.EnrollmentDate,
                    request.CreatedUser,
                    request.CreatedDate,
                    request.UpdatedUser,
                    request.UpdatedDate,
                    request.DeletedUser,
                    request.DeletedDate,
                    request.Status
                );

                await _studentRepository.DeleteAsync(students);
                await _unitOfWork.SaveChangeAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
