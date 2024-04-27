using Handbook.DTO;
using Handbook.Model;
using Handbook.Service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Handbook.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService CityService)
        {
            _cityService = CityService;
        }

        [HttpGet("{id:int}")]
        public Task<City> GetCity(int id)
        {
            return _cityService.GetCity(id) ?? throw new ArgumentNullException(nameof(id));
        }

        [HttpGet]
        public Task<IQueryable<City>> GetCitys()
        {
            return _cityService.GetAllCities() ?? throw new ArgumentNullException($"City {nameof(City)} can not be loaded.");
        }

        [HttpPost]
        public Task CreateCity(CityModel CityModel)
        {
            _cityService.AddCity(new City()
            {
                CityName = CityModel.CityName,
                CityCode = CityModel.CityCode,
            });
            return Task.CompletedTask;
        }

        [HttpPut]
        public Task UpdateCity(City City)
        {
            if (City == null) throw new ArgumentNullException(nameof(City));
            _cityService.UpdateCity(City);
            return Task.CompletedTask;
        }

        [HttpDelete]
        public Task DeleteCity(int id)
        {
            _cityService.DeleteCity(id);
            return Task.CompletedTask;
        }
    }
}
