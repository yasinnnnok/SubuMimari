using AutoMapper;
using MongoDB.Bson;
using SUBU.Core.Extensions;
using SUBU.Entities.EntityFramework.Database1;
using SUBU.Entities.Mongo;
using SUBU.Models;

namespace SUBU.Services
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            AlbumMappings();
            SongMappings();
            CategoryMappings();
            ArtistMappings();
        }

        private void ArtistMappings()
        {
            CreateMap<Artist, ArtistCreate>().ReverseMap();
            CreateMap<Artist, ArtistUpdate>().ReverseMap();
            CreateMap<Artist, ArtistQuery>().ReverseMap();
            CreateMap<Artist, ArtistAliveUpdate>().ReverseMap();
        }

        private void CategoryMappings()
        {
            CreateMap<Category, CategoryQuery>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom((x, y) => x.Id.ToString()));

            CreateMap<CategoryUpdate, Category>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom((x, y) => x.Id.ToObjectId()));
        }

        private void SongMappings()
        {
            CreateMap<SongCreate, Song>().ReverseMap();
            CreateMap<Song, SongQuery>().ReverseMap();
        }

        private void AlbumMappings()
        {
            CreateMap<AlbumCreate, Album>().ReverseMap();
            CreateMap<Album, AlbumQuery>().ReverseMap();
        }
    }
}
