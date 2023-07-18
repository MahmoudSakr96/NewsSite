using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Business.Contracts.Persistence.IRepository
{
    public interface ILoginRepository
    {
        IEnumerable<ApplicationUser> getuser();
        ApplicationUser AuthenticateUser(string username, string passcode);

    }
}
