using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<UserDto>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDto>
        {
            IUserRepository _userRepository;
            IMapper _mapper;
            UserBusinessRules _userBusinessRules;

            public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var userToUpdate = await _userRepository.GetAsync(x => x.Id == request.Id);
                if (userToUpdate == null)
                    throw new BusinessException("User cannot found");


                await _userBusinessRules.EmailCanNotBeDublicated(request.Email);
                 _mapper.Map(request, userToUpdate);

                 await _userRepository.UpdateAsync(userToUpdate);

                var updatedUser = _mapper.Map<UserDto>(userToUpdate);

                return updatedUser;
            }
        }
    }

}
