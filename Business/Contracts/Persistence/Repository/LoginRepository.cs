using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure;
using Business.Contracts.Persistence.IRepository;

namespace Business.Contracts.Persistence.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly GlobalAppdbContext _context;

        public LoginRepository(GlobalAppdbContext context)
        {
            _context = context;
        }
        public ApplicationUser AuthenticateUser(string username, string passcode)
        {
            var succeeded = _context.ApplicationUsers.FirstOrDefault(authUser => authUser.Email == username && authUser.PasswordHash == passcode);
            return succeeded;
        }

        public IEnumerable<ApplicationUser> getuser()
        {
            return _context.ApplicationUsers.ToList();
        }
    }
}
