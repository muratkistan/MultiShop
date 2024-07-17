using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;
using MultiShop.Cargo.WebApi.Mapper;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomersController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }

        [HttpGet]
        public IActionResult CargoCustomersList()
        {
            var cargoCustomers = _cargoCustomerService.TGetAll();
            return Ok(cargoCustomers);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id)
        {
            var cargoCustomer = _cargoCustomerService.TGetById(id);
            return Ok(cargoCustomer);
        }

        [HttpPost]
        public IActionResult AddCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            var value = ObjectMapper.Mapper.Map<CargoCustomer>(createCargoCustomerDto);
            _cargoCustomerService.TInsert(value);
            return Ok("Kargo musteri basariyla olsuturuldu");
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            var value = ObjectMapper.Mapper.Map<CargoCustomer>(updateCargoCustomerDto);
            _cargoCustomerService.TUpdate(value);
            return Ok("Kargo musteri basariyla guncellendi");
        }

        [HttpDelete]
        public IActionResult RemoveCargoCustomer(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok("Kargo musteri basariyla silindi");
        }
    }
}