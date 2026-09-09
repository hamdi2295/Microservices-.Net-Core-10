using System;
using System.Collections.Generic;
using System.Text;

namespace MySchool.Domain.Entities
{
    public class Students
    {
        public long? StudentId { get; set; }
        public string? StudentNumber { get; set; } = null!;
        public string? NationalStudentNumber { get; set; }
        public string? FullName { get; set; } = null!;
        public string? Gender { get; set; }
        public string? BirthPlace { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public long? Class { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public string? CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? DeletedUser { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool? Status { get; set; }

        private Students()
        {

        }

        public Students(
            long? studentId,  
            string? studentNumber, 
            string? nationalStudentNumber,
            string? fullName,
            string? gender,
            string? birthPlace,
            DateTime? birthDate,
            string? address,
            string? phoneNumber,
            string? email,
            long? classes,
            DateTime? enrollmentDate,
            string? createdUser,
            DateTime? createdDate,
            string? updatedUser,
            DateTime? updatedDate,
            string? deletedUser,
            DateTime? deletedDate,
            bool? status
        )
        {
            this.StudentId = studentId;
            this.StudentNumber = studentNumber;
            this.NationalStudentNumber = nationalStudentNumber;
            this.FullName = fullName;
            this.Gender = gender;
            this.BirthPlace = birthPlace;
            this.BirthDate = birthDate;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Class = classes;
            this.EnrollmentDate = enrollmentDate;
            this.CreatedUser = createdUser;
            this.CreatedDate = createdDate;
            this.UpdatedUser = updatedUser;
            this.UpdatedDate = updatedDate;
            this.DeletedUser = deletedUser;
            this.DeletedDate = deletedDate;
            this.Status = status;
        }

    }
}
