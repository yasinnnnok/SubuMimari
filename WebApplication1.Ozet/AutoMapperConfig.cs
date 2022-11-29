using AutoMapper;
using WebApplication1.Ozet.Entities;
using WebApplication1.Ozet.Models;

namespace WebApplication1.Ozet
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<AlbumCreate, Album>().ReverseMap();
        }
    }
}
