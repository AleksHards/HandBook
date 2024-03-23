using Handbook.DTO;

namespace Handbook.Service.ServiceInterfaces;

public interface ICityService
{
    Task<City> GetCity(int cityId);
    Task<IQueryable<City>> GetAllCities();
    void AddCity(City city);
    void UpdateCity(City city);
    void DeleteCity(int cityId);
}