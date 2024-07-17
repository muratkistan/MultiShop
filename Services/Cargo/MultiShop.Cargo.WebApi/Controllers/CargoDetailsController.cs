using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;
using MultiShop.Cargo.WebApi.Mapper;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public IActionResult CargoDetailsList()
        {
            var cargoCustomers = _cargoDetailService.TGetAll();
            return Ok(cargoCustomers);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var cargoCustomer = _cargoDetailService.TGetById(id);
            return Ok(cargoCustomer);
        }

        [HttpPost]
        public IActionResult AddCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            var value = ObjectMapper.Mapper.Map<CargoDetail>(createCargoDetailDto);
            _cargoDetailService.TInsert(value);
            return Ok("Kargo detaylari basariyla olsuturuldu");
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            var value = ObjectMapper.Mapper.Map<CargoDetail>(updateCargoDetailDto);
            _cargoDetailService.TUpdate(value);
            return Ok("Kargo detaylari basariyla guncellendi");
        }

        [HttpDelete]
        public IActionResult RemoveCargoDetail(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("Kargo detaylari basariyla silindi");
        }
    }
}