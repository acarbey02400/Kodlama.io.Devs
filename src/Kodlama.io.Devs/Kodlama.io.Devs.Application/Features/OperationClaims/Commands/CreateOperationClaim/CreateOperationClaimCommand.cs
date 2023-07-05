using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.OperationClaims.Dtos;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.CreateOperation
{
    public class CreateOperationClaimCommand:IRequest<CreateOperationClaimDto>
    {
        public string? Name { get; set; }

        public class CreateOperationClaimHandler : IRequestHandler<CreateOperationClaimCommand, CreateOperationClaimDto>
        {
            private readonly IOperationClaimRepository _repository;
            private readonly IMapper _mapper;

            public CreateOperationClaimHandler(IOperationClaimRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<CreateOperationClaimDto> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                OperationClaim operationClaim = _mapper.Map<OperationClaim>(request);
                OperationClaim createdOperationClaim = await _repository.AddAsync(operationClaim);
                CreateOperationClaimDto mappedCreateOperationClaimDto = _mapper.Map<CreateOperationClaimDto>(createdOperationClaim);
                return mappedCreateOperationClaimDto;
            }
        }
    }
}
