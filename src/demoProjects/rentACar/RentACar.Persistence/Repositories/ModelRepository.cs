namespace RentACar.Persistence.Repositories;

using Application.Services.Repositories;
using Contexts;
using Core.Persistence.Repositories;
using Domain.Entities;

public class ModelRepository : EfRepositoryBase<Model, BaseDbContext>, IModelRepository
{
    public ModelRepository(BaseDbContext context) : base(context)
    {
    }
}