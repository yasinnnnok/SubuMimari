using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SUBU.Core;
using SUBU.Services.EntityFramework.Managers;
using SUBU.Services.Mongo.Managers;
using SUBU.Services.NoContext;

namespace SUBU.Services
{
    public class Startup : StartupBase
    {
        public Startup(IServiceCollection serviceCollection, IConfiguration configuration) : base(serviceCollection, configuration)
        {
        }

        public override void Configure()
        {
            ServiceCollection.AddAutoMapper(System.Reflection.Assembly.GetExecutingAssembly());

            #region Entity Framework

            // Injections2
            ServiceCollection.AddScoped<IAlbumService, AlbumService>();
            ServiceCollection.AddScoped<IAlbumServiceBase, AlbumServiceBase>();
            ServiceCollection.AddScoped<IAlbumServiceQuick, AlbumServiceQuick>();
            ServiceCollection.AddScoped<IAlbumServiceUow, AlbumServiceUow>();
            ServiceCollection.AddScoped<IAlbumServiceUow2, AlbumServiceUow2>();
            ServiceCollection.AddScoped<ISongService, SongService>();
            ServiceCollection.AddScoped<IArtistService, ArtistService>();

            #endregion

            #region Mongo

            ServiceCollection.AddScoped<ICategoryService, CategoryService>();
            ServiceCollection.AddScoped<IAddressService, AddressService>();
            ServiceCollection.AddScoped<IUserService, UserService>();

            #endregion

            //injection-> interface i çağırdığımda servisi getir.
            ServiceCollection.AddScoped<IProductService, ProductService>();
            ServiceCollection.AddScoped<ILocationService, LocationService>();

            //gelen 2 nesneyi DataAaccess newleyio aktarıyor.
            DataAccess.Startup dataAccessStartup =
                new SUBU.DataAccess.Startup(ServiceCollection, Configuration);

            dataAccessStartup.Configure();
        }
    }
}
