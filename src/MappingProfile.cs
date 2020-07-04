using AutoMapper;
using IndoriZaika.DataService.Models;
using indorizaikaDataService.Models;

namespace IndoriZaika.DataService
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Entities.Recipe, RecipeModel>()
                .ForMember(dest => dest.RecipeType, opts => opts.MapFrom(src => src.RecipeType))
                .ForMember(dest => dest.CuisineType, opts => opts.MapFrom(src => src.CusineType))
                .ReverseMap();

            CreateMap<Models.CuisineTypeModel, Entities.CuisineType>()
                .ForMember(dest => dest.CusineType, opts => opts.MapFrom(src => src.Type))
                .ReverseMap();

            CreateMap<RecipeTypeModel, Entities.RecipeType>()
                .ForMember(dest => dest.Type, opts => opts.MapFrom(src => src.Type))
                .ReverseMap();

            CreateMap<RecipeDetailModel, Entities.RecipeDetail>()
                .ReverseMap();

            CreateMap<ProcedureModel, Entities.Procedure>()
                .ReverseMap();

            CreateMap<IngredientsModel, Entities.Ingredients>()
                .ReverseMap();

            CreateMap<UserCommentsModel, Entities.UserComments>()
                .ReverseMap();
        }
    }
}
