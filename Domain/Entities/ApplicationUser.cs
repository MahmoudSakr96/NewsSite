using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table(name: "Users")]
    public class ApplicationUser : IdentityUser<int>
    {
        public ApplicationUser()
        {

        }
        public ApplicationUser(string userName,
            string email = null)
        {
            //Check.NotNull(userName, nameof(userName));

            UserName = userName.ToLower();
            NormalizedUserName = userName.ToUpperInvariant();
            Email = email?.ToLower();
            NormalizedEmail = email?.ToUpperInvariant();
            SecurityStamp = Guid.NewGuid().ToString();
        }



        [Column(Order = 301)]
        public DateTime CreatedOn { get; set; }
        [Column(Order = 302)]

        public string? UpdatedBy { get; set; }
        [Column(Order = 303)]
        public Nullable<DateTime> UpdatedOn { get; set; }

    }
}
