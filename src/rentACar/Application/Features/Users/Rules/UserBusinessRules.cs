using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task EmailCanNotBeDublicated(string email)
        {
            var result = await _userRepository.GetListAsync(b => b.Email == email);
            if (result.Items.Any())
            {
                throw new BusinessException("Email is already exists");
            }
        }
    }
}
