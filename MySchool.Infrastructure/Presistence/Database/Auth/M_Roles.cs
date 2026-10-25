using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MySchool.Infrastructure.Presistence.Database.Auth
{
    public class M_Roles
    {
      [Key]
      public string RoleId { get; set; }
      public string RoleName { get; set; }
      public string CreatedUser { get; set; }
      public DateTime CreatedDate { get; set; }
      public string? UpdatedUser { get; set; }
      public DateTime? UpdatedDate { get; set; }
      public string? DeletedUser { get; set; }
      public DateTime? DeletedDate { get; set; }
      public bool IsDeleted { get; set; }
    }
}
