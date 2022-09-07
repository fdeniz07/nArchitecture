using Core.Persistence.Paging;
using RentACar.Application.Features.Brands.Dtos;
using System.Collections.Generic;

namespace RentACar.Application.Features.Brands.Models
{
    public class BrandListModel : BasePageableModel
    {
        public IList<BrandListDto> Items { get; set; }
    }
}
