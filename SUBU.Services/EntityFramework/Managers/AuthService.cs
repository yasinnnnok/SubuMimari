using AutoMapper;
using SUBU.DataAccess.EntityFramework.Repositories;
using SUBU.DataAccess.EntityFramework.UnitOfWork;
using SUBU.Entities.EntityFramework.Database1;
using SUBU.Entities.EntityFramework.Enums;
using SUBU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUBU.Services.EntityFramework.Managers
{
    public interface IAuthService
    {
        string Find(string userName);

    }
    public class AuthService : IAuthService
    {
        private readonly IDatabase1UnitOfWork2 _unitOfWork;
        private readonly IMapper _mapper;
        //her seferinde GetRepository yazmayalım diye ekliyoruz.        
        private readonly IAuthRepository _repository;
        private readonly IUserService _userService;

        public AuthService(IDatabase1UnitOfWork2 unitOfWork, IMapper mapper, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            //herseferinde GetRepository yazmayalım diye ekliyoruz.
            //return _mapper.Map<T>(_unitOfWork.GetRepository<IAlbumRepository>()
            _repository = _unitOfWork.GetRepository<IAuthRepository>();
            _userService = userService;
        }

      

        public string Find(string userName)
        {
            var user = _userService.ListAll().FirstOrDefault(x=>x.UserName== userName);
        
            if (user != null)
            {
              
                //kayıt varsa rolü vardır.
                return user.EnumRole.ToString();
            }
            return null;
        }

       
    }
}
