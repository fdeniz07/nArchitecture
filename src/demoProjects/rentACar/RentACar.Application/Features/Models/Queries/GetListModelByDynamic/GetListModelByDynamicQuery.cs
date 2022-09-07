namespace RentACar.Application.Features.Models.Queries.GetListModelByDynamic
{
    using AutoMapper;
    using Core.Application.Requests;
    using Core.Persistence.Dynamic;
    using MediatR;
    using Models;
    using Services.Repositories;
    using System.Threading;
    using System.Threading.Tasks;
    using Core.Persistence.Paging;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public class GetListModelByDynamicQuery : IRequest<ModelListModel>
    {
        public Dynamic Dynamic { get; set; }

        public PageRequest PageRequest { get; set; }

        public class GetListModelByDynamicQueryHandler : IRequestHandler<GetListModelByDynamicQuery, ModelListModel>
        {
            private readonly IMapper _mapper;
            private readonly IModelRepository _modelRepository;

            public GetListModelByDynamicQueryHandler(IMapper mapper, IModelRepository modelRepository)
            {
                _mapper = mapper;
                _modelRepository = modelRepository;
            }

            public async Task<ModelListModel> Handle(GetListModelByDynamicQuery request, CancellationToken cancellationToken)
            {
                //Car models   
                IPaginate<Model> models = await _modelRepository.GetListByDynamicAsync(request.Dynamic, include:
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
