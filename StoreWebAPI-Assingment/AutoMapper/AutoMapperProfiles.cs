using AutoMapper;
using StoreWebAPI_Assingment.Models.Category;
using StoreWebAPI_Assingment.Models.Order;
using StoreWebAPI_Assingment.Models.Product;
using StoreWebAPI_Assingment.Models.User;

namespace StoreWebAPI_Assingment.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserEntity, UserModel>().ReverseMap();
            CreateMap<UserRequest, UserEntity>();

            CreateMap<ProductEntity, ProductModel>().ReverseMap();
            CreateMap<ProductRequest, ProductEntity>();

            CreateMap<CategoryEntity, CategoryModel>().ReverseMap();
            CreateMap<CategoryRequest, CategoryEntity>();

            CreateMap<OrderEntity, Order>().ReverseMap();


        }
    }
}
