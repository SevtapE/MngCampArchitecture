using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Mailing;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommand:IRequest<Brand>
    {
        public string Name { get; set; }
        public class CreateBrandCommandHandler:IRequestHandler<CreateBrandCommand,Brand>
        {
            IBrandRepository _brandRepository;
            IMapper _mapper;
            BrandBusinessRules _brandBusinessRules;
            IMailService _mailService;

            public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules, IMailService mailService)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _brandBusinessRules = brandBusinessRules;
                _mailService = mailService;
            }

            public async Task<Brand> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                await _brandBusinessRules.BrandNameCanNotBeDuplicatedWhenInsertedAndUpdated(request.Name);
                var mappedBrand=_mapper.Map<Brand>(request);
                var createdBrand = await _brandRepository.AddAsync(mappedBrand);
                Mail mail = new Mail 
                { 
                    ToFullName="system admins",
                    ToEmail="admins@mngkargo.com.tr",
                    Subject="New brand added",
                    HtmlBody="Hey, check the system"
                };
                _mailService.SendMail(mail);
                return createdBrand;
            }
        }
            }

}
