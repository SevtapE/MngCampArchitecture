using Application.Features.Brands.Rules;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Mailing;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<User>
    {
     
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
        {
            IUserRepository _userRepository;
            IMapper _mapper;
            UserBusinessRules _userBusinessRules;
      

            public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
             
            }

            public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                await _userBusinessRules.EmailCanNotBeDublicated(request.Email);
                var mappedUser = _mapper.Map<User>(request);
                var createdUser = await _userRepository.AddAsync(mappedUser);
         
                return createdUser;
            }
        }
            }

}
