using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;
using MultiShop.Cargo.WebApi.Mapper;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationsController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }

        [HttpGet]
        public IActionResult CargoOperationsList()
        {
            var cargoCustomers = _cargoOperationService.TGetAll();
            return Ok(cargoCustomers);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoOperationById(int id)
        {
            var cargoCustomer = _cargoOperationService.TGetById(id);
            return Ok(cargoCustomer);
        }

        [HttpPost]
        public IActionResult AddCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            var value = ObjectMapper.Mapper.Map<CargoOperation>(createCargoOperationDto);
            _cargoOperationService.TInsert(value);
            return Ok("Kargo operasyonlari basariyla olsuturuldu");
        }

        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            var value = ObjectMapper.Mapper.Map<CargoOperation>(updateCargoOperationDto);
            _cargoOperationService.TUpdate(value);
            return Ok("Kargo operasyonlari basariyla guncellendi");
        }

        [HttpDelete]
        public IActionResult RemoveCargoOperation(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok("Kargo operasyonlari basariyla silindi");
        }
    }
}