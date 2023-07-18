using Microsoft.AspNetCore.Identity;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dto
{
    public class UserDto:ApplicationUser
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public virtual string NormalizedUserName { get; set; }
        public virtual string Email { get; set; }
        public virtual string NormalizedEmail { get; set; }
        public virtual bool EmailConfirmed { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string PhoneNumber { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public Nullable<DateTime> UpdatedOn { get; set; }



    }
}
