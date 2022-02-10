using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
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


namespace Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<NoContent>
    {
        public int Id { get; set; }
      
        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, NoContent>
        {
            IUserRepository _userRepository;
         

            public DeleteUserCommandHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
              
            }

            public async Task<NoContent> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                var userToDelete = await _userRepository.GetAsync(x => x.Id == request.Id);
                if (userToDelete == null)
                    throw new BusinessException("User cannot found");

                
                await _userRepository.DeleteAsync(userToDelete);
              
                return new NoContent();
            }
        }
    }

}
