using System;
using System.Globalization;
using AutoMapper;
using CarRent.Resources;

namespace CarRent.Mapping
{
    public class MappingProfile: Profile
    {
        string pattern = "yyyy-MM-dd";
        public  MappingProfile()
        {
            //From Domain to Resources
            CreateMap<User, UserResource>();
            CreateMap<Car, CarResource>();
            CreateMap<Order, OrderResource>();

            //From Resources to Domain
            CreateMap<SaveOrderResource, Order>();
        }
    }
}