using AutoMapper;
using SUBU.DataAccess.EntityFramework.Repositories;
using SUBU.DataAccess.EntityFramework.UnitOfWork;
using SUBU.Entities.EntityFramework.Database1;
using SUBU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUBU.Services.EntityFramework.Managers
{
    public interface IUserService
    {
        IEnumerable<UserQuery> ListAll();
        UserQuery Create(UserCreate model);
    }

    public class UserService : IUserService
    {
        private readonly IDatabase1UnitOfWork2 _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IDatabase1UnitOfWork2 unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            //burada yukarıdaki Repository'i çağırmadan injectionnunu unitofWork üzerinden yapıyoruz.
            _userRepository = _unitOfWork.GetRepository<IUserRepository>();
        }

        public UserQuery Create(UserCreate model)
        {
            UsersRole user = _userRepository.Add(_mapper.Map<UsersRole>(model));
            _userRepository.Save();
            return _mapper.Map<UserQuery>(user);
        }

        public IEnumerable<UserQuery> ListAll()
        {
            //listelemede select kullanmamızın sebebi bütün kayıtları UserQuery'e dönüştürmemiz.
            return _userRepository.GetAll().ToList()
                .Select(x => _mapper.Map<UserQuery>(x))
                .ToList();
        }
    }
}
