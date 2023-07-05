using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.PLTechnologies.Queries
{
    public class GetListPLTechnologyDynamicQuery : IRequest<PLTechnologyListModel>
    {
        public PageRequest? PageRequest { get; set; }
        public Dynamic? Dynamic { get; set; }

        public class GetListTechnologyDynamicHandler : IRequestHandler<GetListPLTechnologyDynamicQuery, PLTechnologyListModel>
        {
            private readonly IPLTechnologyRepository _repository;
            private readonly IMapper _mapper;

            public GetListTechnologyDynamicHandler(IPLTechnologyRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<PLTechnologyListModel> Handle(GetListPLTechnologyDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<PLTechnology> paginate = await _repository.GetListByDynamicAsync
                    (
                    size: request.PageRequest.PageSize,
                    index: request.PageRequest.Page,
                    include: p=>p.Include(x=>x.ProgramingLanguage),
                    dynamic:request.Dynamic
                    )
                    ;
                PLTechnologyListModel mappedListModel = _mapper.Map<PLTechnologyListModel>(paginate);
                return mappedListModel;
            }
        }
    }
}
