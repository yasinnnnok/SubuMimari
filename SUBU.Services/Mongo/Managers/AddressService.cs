using SUBU.DataAccess.Mongo.Repositories;
using SUBU.Entities.Mongo;

namespace SUBU.Services.Mongo.Managers
{
    public interface IAddressService
    {
        Address Create(Address Address);
        List<Address> List();
    }

    public class AddressService : IAddressService
    {
        private readonly IMongoAddressRepository _AddressRepository;

        public AddressService(IMongoAddressRepository AddressRepository)
        {
            _AddressRepository = AddressRepository;
        }

        public Address Create(Address Address)
        {
            return _AddressRepository.Insert(Address);
        }

        public List<Address> List()
        {
            return _AddressRepository.List();
        }
    }
}
