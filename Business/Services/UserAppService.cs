using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Domain.Entities;
using Business.Contracts.Persistence.IRepository;
using Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class UserAppService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly DataProtectorTokenProvider<ApplicationUser> _dataProtectorTokenProvider;
        private readonly PhoneNumberTokenProvider<ApplicationUser> _phoneNumberTokenProvider;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper mapper;
        private readonly ILoginRepository _loginRepository;
        public UserAppService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            DataProtectorTokenProvider<ApplicationUser> dataProtectorTokenProvider,
            PhoneNumberTokenProvider<ApplicationUser> phoneNumberTokenProvider,
            RoleManager<ApplicationRole> roleManager,
            ILoginRepository loginRepository,
            IMapper _mapper
            )
        {
            _userManager = userManager;
            _dataProtectorTokenProvider = dataProtectorTokenProvider;
            _phoneNumberTokenProvider = phoneNumberTokenProvider;
            _roleManager = roleManager;
            _signInManager = signInManager;
            mapper = _mapper;
            _loginRepository = loginRepository;
        }

        public async Task<UserDto> GetAsync(Guid id)
        {
            var result = await _userManager.FindByIdAsync(id.ToString());
            return mapper.Map<UserDto>(result);
        }
        public async Task<ApplicationUser> GetUserAsync(Guid id)
        {
            var result = await _userManager.FindByIdAsync(id.ToString());
            return result;
        }

        public async Task<bool> ChangePassword(Guid userId, string password)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return false;
            }
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, password);
            var result = await _userManager.UpdateAsync(user);

            return result.Succeeded;
        }

        public async Task<UserDto> FindByIdAsync(Guid? id)
        {
            var result = await _userManager.FindByIdAsync(id.ToString());
            return mapper.Map<UserDto>(result);
        }
        public async Task RemoveUserInRole(Guid userId, Guid roleId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var role = _roleManager.FindByIdAsync(roleId.ToString());
            await _userManager.RemoveFromRoleAsync(user, role.Result.Name);
        }

        public async Task<UserDto> FindByUsernameAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return mapper.Map<UserDto>(user);
        }
        public async Task<ApplicationUser> FindByUsername(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            return user;
        }
        public async Task<UserDto> FindByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return mapper.Map<UserDto>(user);
        }

        public async Task<List<UserDto>> FindAllByRoleIdAsync(Guid roleId, bool activeOnly = false)
        {
            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            var users = await _userManager.GetUsersInRoleAsync(role.Name);
            var userList = activeOnly ? users
                .ToList() : users.ToList();
            return mapper.Map<List<UserDto>>(users);
        }

        public bool ValidateToken(Guid id, string token)
        {
            var user = _userManager.FindByIdAsync(id.ToString()).Result;
            var isValid = _phoneNumberTokenProvider.ValidateAsync("Reset_Password", token, _userManager, user);
            return isValid.Result;
        }

        public async Task<bool> Logout()
        {
            await _signInManager.SignOutAsync();
            return true ;

        }
      
        public async Task<UserDto> Login(LoginDto model)
        {
            try
            {
                var user = _loginRepository.AuthenticateUser(model.UserName, model.Password);
                if (user != null)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    var currentUser = mapper.Map<UserDto>(user);
                    return currentUser;
                }
                return new UserDto() { CreatedOn = DateTime.Now };
            }
            catch (Exception ex)
            {
                return new UserDto() { CreatedOn = DateTime.Now };
            }
        }

        public async Task<bool> IsUserInRoleAsync(Guid userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            return await _userManager.IsInRoleAsync(user, roleName);
        }
    }
}
