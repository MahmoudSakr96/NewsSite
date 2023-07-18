using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table(name: "Roles")]
    public class ApplicationRole : IdentityRole<int>
    {
        public string RoleNameEn { get; set; }
        public string RoleNameAR { get; set; }

        [Column(Order = 300)]
        public string CreatedBy { get; set; }

        [Column(Order = 301)]
        public DateTime CreatedOn { get; set; }
        [Column(Order = 302)]

        public string? UpdatedBy { get; set; }
        [Column(Order = 303)]
        public Nullable<DateTime> UpdatedOn { get; set; }


    }
}