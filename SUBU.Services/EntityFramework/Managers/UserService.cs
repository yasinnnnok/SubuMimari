using AutoMapper;
using SUBU.Core.Result.Abstract;
using SUBU.Core.Result.Concrete;
using SUBU.DataAccess.EntityFramework.Repositories;
using SUBU.DataAccess.EntityFramework.UnitOfWork;
using SUBU.Entities.EntityFramework.Database1;
using SUBU.Models;
using SUBU.Services.Contans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SUBU.Services.EntityFramework.Managers
{
    public interface IUserService
    {
        //IEnumerable<UserQuery> ListAll();
        IDataResult<IEnumerable<UserQuery>> ListAll();
        IDataResult<IEnumerable<UserQuery>> FindUserName(string userName);
        IResult Create(UserCreate model);
        IResult Delete(int id);

        
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

        public IResult Create(UserCreate model)
        {
            //var user1 = _userRepository.Find(x => x.UserName == model.UserName && x.EnumRole == model.EnumRole).SingleOrDefault();
            //var user2 = _userRepository.GetAll().FirstOrDefault(x => x.UserName == model.UserName && x.EnumRole == model.EnumRole);
            var user = _userRepository.Queryable().Where(x => x.UserName == model.UserName && x.EnumRole == model.EnumRole).FirstOrDefault();
            if (user == null)
            {
                UsersRole modelUser = _userRepository.Add(_mapper.Map<UsersRole>(model));
                _userRepository.Save();
                return new SuccessResult(Usermessages.AddMessages);
            }
            return new ErrorResult(Usermessages.WrongUserAdd);
        }

        public IDataResult<IEnumerable<UserQuery>> ListAll()
        {
            //listelemede select kullanmamızın sebebi bütün kayıtları UserQuery'e dönüştürmemiz.
            return new SuccessDataResult<IEnumerable<UserQuery>>(
                _userRepository.GetAll().ToList()
                .Select(x => _mapper.Map<UserQuery>(x))
                .ToList());
        }

        public IDataResult<IEnumerable<UserQuery>> FindUserName(string userName)
        {
            //listelemede select kullanmamızın sebebi bütün kayıtları UserQuery'e dönüştürmemiz.

            return new SuccessDataResult<IEnumerable<UserQuery>>(
                _userRepository.Queryable().Where(x => x.UserName == userName).ToList()                
                .Select(x => _mapper.Map<UserQuery>(x))
                .ToList());
        }

        //id yi al sil ve  kaydet
        public IResult Delete(int id)
        {
            //var user1 = _userRepository.Queryable().Where(x => x.Id ==id).FirstOrDefault();
            var user = _userRepository.Get(id);
            if (user!=null)
            {
                _userRepository.Remove(id);
                _userRepository.Save();
                return new SuccessResult(Usermessages.DeletedUser);
            }
            return new ErrorResult(Usermessages.WrongNotUser);
            
        
        }




    }
}
