namespace RentACar.Application.Features.Models.Models
{
    using Core.Persistence.Paging;
    using Dtos;

    public class ModelListModel : BasePageableModel
    {
        public IList<ModelListDto> Items { get; set; }
    }
}
