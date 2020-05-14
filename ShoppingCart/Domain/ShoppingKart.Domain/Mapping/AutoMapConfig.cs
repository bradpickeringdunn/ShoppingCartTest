using AutoMapper;
using Entities = ShoppingKart.Repository.Entities;

namespace ShoppingKart.Domain.Mapping
{
    public static class AutoMapConfig
    {
        private static MapperConfiguration GetConfig()
        {
            return new MapperConfiguration(cfg => {
                cfg.CreateMap<Entities.Product, Models.Product>();
                cfg.CreateMap<Entities.Offer, Models.Offer>();
                cfg.CreateMap<Models.Product, Entities.Product>();
                cfg.CreateMap<Models.Offer, Entities.Offer> ();
            });
        }

        public static Mapper Mapper 
        {
            get
            {
                return new Mapper(GetConfig());
            }
        }
    }
}
