using AutoMapper;
using SUBU.DataAccess.EntityFramework.Repositories;
using SUBU.DataAccess.EntityFramework.UnitOfWork;
using SUBU.Entities.EntityFramework.Database1;
using SUBU.Models;
using SUBU.Services.Contans;
using System.Collections.Generic;

namespace SUBU.Services.EntityFramework.Managers;

public interface IUserService
{
    //IEnumerable<UserQuery> ListAll();
    IDataResult<IEnumerable<UserQuery>> ListAll();
    IDataResult<IEnumerable<UserQuery>> FindUserName(string userName);
    IDataResult<UserQuery> FindById(int id);
    IDataResult<UserQuery> Update(int id, UserUpdate model);
    IDataResult<string> Create(UserCreate model);
    IDataResult<string> Delete(int id);


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

    public IDataResult<string> Create(UserCreate model)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri("https://apilogin.subu.edu.tr/");


        var response = client.GetAsync($"api/CheckPersonelByUserName?UserName={model.UserName}").Result;
        if (response.StatusCode == System.Net.HttpStatusCode.OK && response.Content != null)
        {
            //var user1 = _userRepository.Find(x => x.UserName == model.UserName && x.EnumRole == model.EnumRole).SingleOrDefault();
            //var user2 = _userRepository.GetAll().FirstOrDefault(x => x.UserName == model.UserName && x.EnumRole == model.EnumRole);
            var user = _userRepository.Queryable().Where(x => x.UserName == model.UserName && x.EnumRole == model.EnumRole).FirstOrDefault();
            if (user == null)
            {
                UsersRole modelUser = _userRepository.Add(_mapper.Map<UsersRole>(model));
                _userRepository.Save();
                return new SuccessDataResult<string>(Usermessages.AddMessages);
            }
            return new ErrorDataResult<string>(Usermessages.WrongUserAdd);
        }
        return new ErrorDataResult<string>(Usermessages.WrongNotUserApilogin);

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


    public IDataResult<UserQuery> FindById(int id)
    {
        UsersRole user = _userRepository.Get(id);
        //map i bu şekilde kullanıyoruz. modelii artiste maple. (newlemeden)
        if (user != null)
        {            

            return new SuccessDataResult<UserQuery>(_mapper.Map<UserQuery>(user));
        }

        return new ErrorDataResult<UserQuery>(Usermessages.WrongNotUser);
    }


    //id yi al sil ve  kaydet
    public IDataResult<string> Delete(int id)
    {
        //var user1 = _userRepository.Queryable().Where(x => x.Id ==id).FirstOrDefault();
        var user = _userRepository.Get(id);

        if (user != null)
        {
            _userRepository.Remove(id);
            _userRepository.Save();
            return new SuccessDataResult<string>(Usermessages.DeletedUser);
        }
        return new ErrorDataResult<string>(Usermessages.WrongNotUser);


    }


    //update
    public IDataResult<UserQuery> Update(int id, UserUpdate model)
    {
        //ilk önce user ı bulalım.
        UsersRole user = _userRepository.Get(id);
        //map i bu şekilde kullanıyoruz. modelii artiste maple. (newlemeden)
        if (user != null)
        {
            _userRepository.Update(id, _mapper.Map(model, user));
            _userRepository.Save();

            return new SuccessDataResult<UserQuery>(_mapper.Map<UserQuery>(user), Usermessages.UpdatedUser);
        }

        return new ErrorDataResult<UserQuery>(Usermessages.WrongNotUser);
    }


}
