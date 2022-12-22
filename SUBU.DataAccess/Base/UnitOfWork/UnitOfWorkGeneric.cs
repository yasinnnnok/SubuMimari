using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SUBU.DataAccess.Base.UnitOfWork;

public interface IUnitOfWorkGeneric : IUnitOfWork
{
    TRepository GetRepository<TRepository>();
}

//Gelen context ile newleyip çalışşın.
//Dictionary(Key,value) : Repositorylerin listesi olacak ve varmı diye bakacak.Aynısından 2 tane olmaması için dictionary kullanıyoruz. List kullanırsak aynısı eklenebilir.
//2 kolanlı listemiz (tip(IAlbumReposirty),nesne). Metodumuz olsun , AlbumReposritory varmı baksın. Yoksa newlesin, listeye atsın.
public class UnitOfWorkGeneric<TContext> : IUnitOfWorkGeneric
    where TContext : DbContext
{
    private readonly TContext _context;
    //2 kolunlu listemizi oluşturalım.Genericte property yerine Dictionary miz var. Standırdı AlbumRepository propertylerini yazmıştık ayrı ayrı.keymizi TYPe verelim.Nesne Obje
    private readonly Dictionary<Type, object> _repositories;
    //APı Program.cs de Servis.builderdan erişiyoruz.AddScpoed denildiğinde IServiceProvider nesnesine ekleniyor.
    //By katmana IServiceProvider bağımlılığını ekleyerek erişim alıyoruz. .net kendisi ınjekte ediyor..
    private readonly IServiceProvider _serviceProvider;

    public UnitOfWorkGeneric(TContext context, IServiceProvider serviceProvider)
    {
        _context = context;
        _repositories = new Dictionary<Type, object>();
        _serviceProvider = serviceProvider;
    }

    //Save işlemi
    public int Commit()
    {
        return _context.SaveChanges();
    }

    //Dictionary de kontrol eden metodumuz.Gelen listede varmı bakacak.
    public TRepository GetRepository<TRepository>()
    {
        //Key kolonunda arama yapıyor.Key imiz -> type
        if (_repositories.ContainsKey(typeof(TRepository)) == false)
        {
            //Injektionu consrcutor da yapmak yerine INjectionu metod seviyesinde yapalım
            //ServiProvider üzerinde GetRequiredService kullanarak git TRepostiry ney ise onu bize NEW lever diyoruz.
            TRepository repository = _serviceProvider.GetRequiredService<TRepository>();
            //Dictionary'e Type ile Repositoryi ekle.
            _repositories.Add(typeof(TRepository), repository);
        }
        //Dictionary'de keyi vererek nesneyi alabiliriz.
        return (TRepository)_repositories[typeof(TRepository)];
    }
}
