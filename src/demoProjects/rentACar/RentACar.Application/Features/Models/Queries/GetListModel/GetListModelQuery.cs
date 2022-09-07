namespace RentACar.Application.Features.Models.Queries.GetListModel
{
    using Core.Application.Requests;
    using MediatR;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Core.Persistence.Paging;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Services.Repositories;

    public class GetListModelQuery : IRequest<ModelListModel>
    {
        public PageRequest PageRequest { get; set; }


        public class GetListModelQueryHandler : IRequestHandler<GetListModelQuery, ModelListModel>
        {
            private readonly IMapper _mapper;
            private readonly IModelRepository _modelRepository;

            public GetListModelQueryHandler(IMapper mapper, IModelRepository modelRepository)
            {
                _mapper = mapper;
                _modelRepository = modelRepository;
            }

            public async Task<ModelListModel> Handle(GetListModelQuery request, CancellationToken cancellationToken)
            {
                //Car models   
                IPaginate<Model> models = await _modelRepository.GetListAsync(include:
                                                     m => m.Include(c => c.Brand),
                                                     index: request.PageRequest.Page,
                                                     size: request.PageRequest.PageSize
                                                     );
                //dataModel
                ModelListModel mappedModels = _mapper.Map<ModelListModel>(models);
                return mappedModels;
            }
        }
    }
}
