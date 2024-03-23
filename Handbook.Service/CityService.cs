using Handbook.DTO;
using Handbook.Service.RepositoryInterfaces;
using Handbook.Service.ServiceInterfaces;

namespace Handbook.Service;

public class CityService : ICityService
{
    private readonly IUnitOfWork _unitofWork;

    public CityService(IUnitOfWork unitofWork)
    {
        _unitofWork = unitofWork;
    }

    public Task<City> GetCity(int cityId)
    {
        City city = _unitofWork.CityRepository.Get(cityId) ?? throw new InvalidDataException("City not found.");
        if (city == null)
        {
            throw new InvalidDataException();
        }
        else
        {
            return Task.FromResult(city);
        }
    }

    public Task<IQueryable<City>> GetAllCities()
    {
        var city = _unitofWork.CityRepository.Set();
        if (city == null)
        {
            throw new InvalidDataException("Cities not found.");
        }
        else
        {
            return Task.FromResult(city);
        }
    }

    public void AddCity(City city)
    {
        if (city == null) throw new ArgumentNullException("No name of city provided");
        _unitofWork.CityRepository.Insert(city);
        _unitofWork.SaveChanges();
    }

    public void UpdateCity(City city)
    {
        if (city == null) throw new ArgumentNullException("No name of city provided");
        _unitofWork.CityRepository.Update(city);
        _unitofWork.SaveChanges();
    }

    public void DeleteCity(int cityId)
    {
        City city = _unitofWork.CityRepository.Get(cityId) ?? throw new InvalidDataException("City not found");
        city.IsDeleted = true;
        _unitofWork.CityRepository.Update(city);
        _unitofWork.SaveChanges();
    }
}