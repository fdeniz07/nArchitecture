namespace RentACar.Application.Services.Repositories
{
    using Core.Persistence.Repositories;
    using Domain.Entities;

    public interface IModelRepository : IAsyncRepository<Model>, IRepository<Model>
    {

    }
}
