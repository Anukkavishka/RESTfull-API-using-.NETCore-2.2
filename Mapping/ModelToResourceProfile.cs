using AutoMapper;
using SuperMarket.Domain.Models;
using SuperMarket.Resources;

namespace SuperMarket.Mapping
{
    public class ModelToResourceProfile : Profile // we need to extend this class because AutoMapper uses to check what to map by checking an instance of this class
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();
            CreateMap<SaveCategoryResource, Category>();
            // this is how define what should be mapped to what resource.
            //actually we are mapping the domain model here but behind the scence that is what services will emitt,
        }
    }
}

