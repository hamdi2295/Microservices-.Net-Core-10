using System;
using System.Collections.Generic;
using System.Text;

namespace MySchool.Domain.Entities
{
    public class Roles
    {
        public string? RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? DeletedUser { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool? IsDeleted { get; set; }

        private Roles() { }


        public Roles(
            string roleId,
            string roleName,
            string createdUser,
            DateTime? createdDate,
            string? updatedUser,
            DateTime? updatedDate,
            string? deletedUser,
            DateTime? deletedDate,
            bool? isDeleted)
        {
            this.RoleId = roleId;
            this.RoleName = roleName;
            this.CreatedUser = createdUser;
            this.CreatedDate = createdDate;
            this.UpdatedUser = updatedUser;
            this.UpdatedDate = updatedDate;
            this.DeletedUser = deletedUser;
            this.DeletedDate = deletedDate;
            this.IsDeleted = isDeleted;
        }
    }
}
