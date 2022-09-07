using Microsoft.AspNetCore.Mvc;

namespace RentACar.WebAPI.Controllers
{
    using Application.Features.Models.Models;
    using Application.Features.Models.Queries.GetListModel;
    using Application.Features.Models.Queries.GetListModelByDynamic;
    using Core.Application.Requests;
    using Core.Persistence.Dynamic;

    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListModelQuery getListModelQuery = new GetListModelQuery { PageRequest = pageRequest };
            ModelListModel result = await Mediator.Send(getListModelQuery);

            return Ok(result);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest,[FromBody] Dynamic dynamic)
        {
            GetListModelByDynamicQuery getListModelByDynamicQuery = new GetListModelByDynamicQuery { PageRequest = pageRequest, Dynamic = dynamic};
            ModelListModel result = await Mediator.Send(getListModelByDynamicQuery);

            return Ok(result);

            #region Örnek
            //{
            //    "sort": [
            //    {
            //        "field": "name",
            //        "dir": "asc"
            //    }
            //    ],
            //    "filter": {
            //        "field": "name",
            //        "operator": "eq",
            //        "value": "Series 4",
            //        "logic": "or",
            //        "filters": [
            //        {
            //            "field": "dailyPrice",
            //            "operator": "gte",
            //            "value": "1000"
            //        } 
            //        ]
            //    }
            //}
            #endregion

        }
    }
}
