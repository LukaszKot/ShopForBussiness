using AutoMapper;
using ShopForBussiness.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopForBussiness.Dto
{
    public static class AutoMapperConfig
    {
        public static IMapper Initilize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<Product, ProductDto>();
            })
            .CreateMapper();
    }
}