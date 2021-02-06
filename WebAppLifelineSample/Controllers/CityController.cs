using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppLifeline.DAL.Models;
using WebAppLifeline.Service;

namespace WebAppLifeline.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _svc;
        public CityController(ICityService cityService)
        {
            this._svc = cityService;
        }

        [HttpGet]
        public async Task<IEnumerable<City>> Get()
        {
            return await this._svc.getCityList();
        }

    }
}
