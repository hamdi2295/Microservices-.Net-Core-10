using System;
using System.Collections.Generic;
using System.Text;

namespace MySchool.Domain.DTOs.Request.Students
{
    public class M_StudentRequest
    {
        public long StudentId { get; set; }
        public string StudentNumber { get; set; } = null!;
        public string NationalStudentNumber { get; set; }
        public string FullName { get; set; } = null!;
        public string Gender { get; set; }
        public string BirthPlace { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public long? Class { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public string? CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? DeletedUser { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool? Status { get; set; }
    }
}
