using AutoMapper;
using SUBU.API.Helpers;
using SUBU.DataAccess.EntityFramework.Repositories;
using SUBU.DataAccess.EntityFramework.UnitOfWork;
using SUBU.Models;
using SUBU.Services.Contans;

namespace SUBU.Services.EntityFramework.Managers;

public interface IAuthService
{

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

    public AuthService(IDatabase1UnitOfWork2 unitOfWork, IMapper mapper, IUserService userService, ITokenHelper tokenHelper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        //herseferinde GetRepository yazmayalım diye ekliyoruz.
        //return _mapper.Map<T>(_unitOfWork.GetRepository<IAlbumRepository>()
        _repository = _unitOfWork.GetRepository<IAuthRepository>();
        _userService = userService;
        _tokenHelper = tokenHelper;
    }

    public string[] FindRoles(string userName)
    {
        var userdenme = _userService.FindUserName(userName).Data;

        IList<string> rolesIlist = new List<string>();


        foreach (var item in userdenme)
        {
            rolesIlist.Add((item.EnumRole.ToString()));
        }

        string[] roles = rolesIlist.Cast<string>().ToArray();

        return roles;

    }


    public IDataResult<string> Login(LoginModel loginModel)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri("https://apilogin.subu.edu.tr/");


        var response = client.GetAsync($"api/Login?username={loginModel.Username}&password={loginModel.Password}").Result;
        if (response.StatusCode == System.Net.HttpStatusCode.OK && response.Content != null)
        {
            //k.adı ve şifre doğrumu ? Bunu silebiliriz.
            var data = response.Content.ReadAsStringAsync().Result;
            //TODO : servis'e fi
            //var userRole = Find(loginModel.Username);
            string[] userRole = FindRoles(loginModel.Username);

            if (userRole != null)
            {

                //  string token = _tokenHelper.GenerateToken(loginModel.Username, new string[] { userRole });
                string token = _tokenHelper.GenerateToken(loginModel.Username, userRole);

                return new SuccessDataResult<string>(token, "Token gönderildi.");
            }

            return new ErrorDataResult<string>(AuthMessages.Unauthorized);
        }
        return new ErrorDataResult<string>(AuthMessages.WrongPassword);
    }

}
