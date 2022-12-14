using AutoMapper;
using SUBU.API.Helpers;
using SUBU.Core.Result.Abstract;
using SUBU.Core.Result.Concrete;
using SUBU.DataAccess.EntityFramework.Repositories;
using SUBU.DataAccess.EntityFramework.UnitOfWork;
using SUBU.Entities.EntityFramework.Database1;
using SUBU.Entities.EntityFramework.Enums;
using SUBU.Models;
using SUBU.Services.Contans;
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
        IDataResult<string> Login(LoginModel loginModel);

    }
    public class AuthService : IAuthService
    {
        private readonly IDatabase1UnitOfWork2 _unitOfWork;
        private readonly IMapper _mapper;
        //her seferinde GetRepository yazmayalım diye ekliyoruz.        
        private readonly IAuthRepository _repository;
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;

        public AuthService(IDatabase1UnitOfWork2 unitOfWork, IMapper mapper, IUserService userService,ITokenHelper tokenHelper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            //herseferinde GetRepository yazmayalım diye ekliyoruz.
            //return _mapper.Map<T>(_unitOfWork.GetRepository<IAlbumRepository>()
            _repository = _unitOfWork.GetRepository<IAuthRepository>();
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

      

        public string Find(string userName)
        {
           
            var user = _userService.FindUserName(userName).Data.FirstOrDefault();
                        
            if (user != null)
            {
              
                //kayıt varsa rolü vardır.
                return user.EnumRole.ToString();
            }
            return null;
        }

        

        public IDataResult<string> Login(LoginModel loginModel)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://apilogin.subu.edu.tr/");


            var response = client.GetAsync($"api/Login?username={loginModel.Username}&password={loginModel.Password}").Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK && response.Content != null)
            {
                //k.adı ve şifre doğrumu ?
                var data = response.Content.ReadAsStringAsync().Result;
                //TODO : servis'e fi
                var userRole = Find(loginModel.Username);
                if (userRole != null)
                {
                    string token = _tokenHelper.GenerateToken(loginModel.Username, new string[] { userRole });

                    return new SuccessDataResult<string>(token,"Token gönderildi.");
                }
                //if (data!=null)
                //{
                //    string token = _tokenHelper.GenerateToken(loginAuthDto.Username, new string[] { "admin", "manager" });

                //    return Ok(new { Token = token });
                //}

                //return "yetkisiz";
                return new ErrorDataResult<string>(AuthMessages.Unauthorized);
            }
            return new ErrorDataResult<string>(AuthMessages.WrongPassword);
        }
       
    }
}
