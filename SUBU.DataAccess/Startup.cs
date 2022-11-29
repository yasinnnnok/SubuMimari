using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using SUBU.Core;
using SUBU.DataAccess.Base.Mongo.Context;
using SUBU.DataAccess.EntityFramework.Context;
using SUBU.DataAccess.EntityFramework.Repositories;
using SUBU.DataAccess.EntityFramework.UnitOfWork;
using SUBU.DataAccess.Mongo.Context;
using SUBU.DataAccess.Mongo.Repositories;
using SUBU.Entities.Base;

namespace SUBU.DataAccess
{
    // Add-Migration InitialCreate -OutputDir "EntityFramework\Migrations"

    public class Startup : StartupBase
    {
        public Startup(IServiceCollection serviceCollection, IConfiguration configuration) : base(serviceCollection, configuration)
        {
        }

        public override void Configure()
        {
            #region  Entity Framework

            ServiceCollection.AddDbContext<Database1Context>(opts =>
         {
             opts.UseSqlServer(Configuration.GetConnectionString("Database1Connection"));
             opts.UseLazyLoadingProxies();
         });

            ServiceCollection.AddScoped<IDatabase1UnitOfWork, Database1UnitOfWork>();
            ServiceCollection.AddScoped<IDatabase1UnitOfWork2, Database1UnitOfWork2>();

            ServiceCollection.AddScoped<IAlbumRepository, AlbumRepository>();
            ServiceCollection.AddScoped<ISongRepository, SongRepository>();
            ServiceCollection.AddScoped<IArtistRepository, ArtistRepository>();

            #endregion

            #region Mongo

            BsonClassMap.RegisterClassMap<EntityBase<ObjectId>>(cm =>
            {
                cm.AutoMap();
                cm.SetIgnoreExtraElements(true);
                cm.SetIgnoreExtraElementsIsInherited(true);
            });

            ServiceCollection.AddScoped<MongoDBContextBase, MongoDBContext>();
            ServiceCollection.AddScoped<IMongoCategoryRepository, MongoCategoryRepository>();
            ServiceCollection.AddScoped<IMongoAddressRepository, MongoAddressRepository>();
            ServiceCollection.AddScoped<IMongoUserRepository, MongoUserRepository>();

            #endregion
        }
    }
}
