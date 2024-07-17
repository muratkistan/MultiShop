using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using AutoMapper;
using System.Runtime.CompilerServices;
using MultiShop.Cargo.EntityLayer.Concrete;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;

namespace MultiShop.Cargo.WebApi.Mapper
{
    internal class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<CreateCargoCompanyDto, CargoCompany>().ReverseMap();
            CreateMap<UpdateCargoCompanyDto, CargoCompany>().ReverseMap();
            CreateMap<CreateCargoDetailDto, CargoDetail>().ReverseMap();
            CreateMap<UpdateCargoDetailDto, CargoDetail>().ReverseMap();
            CreateMap<CreateCargoCustomerDto, CargoCustomer>().ReverseMap();
            CreateMap<UpdateCargoCustomerDto, CargoCustomer>().ReverseMap();
            CreateMap<CreateCargoOperationDto, CargoOperation>().ReverseMap();
            CreateMap<UpdateCargoOperationDto, CargoOperation>().ReverseMap();
        }
    }
}