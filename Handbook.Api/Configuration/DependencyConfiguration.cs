using Handbook.Repository;
using Handbook.Service;
using Handbook.Service.RepositoryInterfaces;
using Handbook.Service.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Handbook.Api.Configuration;

public static class DependencyConfiguration
{
    public static void ConfigureDependency(this WebApplicationBuilder builder)
    {
        if (builder == null) throw new ArgumentNullException(nameof(builder));

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<ICityService, CityService>();
        builder.Services.AddScoped<IContactService, ContactService>();
        builder.Services.AddScoped<IPersonService, PersonService>();
        builder.Services.AddScoped<IPersonLinkService, PersonLinkService>();
        builder.Services.AddDbContext<HandbookDbContext>(options => options.UseSqlServer(connectionString));
    }
}