using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Concrete;
using MultiShop.Cargo.WebApi.Mapper;
using System.Runtime.Serialization;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompaniesController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [HttpGet]
        public IActionResult CargoCompaniesList()
        {
            var cargoCompanies = _cargoCompanyService.TGetAll();
            return Ok(cargoCompanies);
        }

        [HttpGet("{id}")]
        public IActionResult CargoCompanyById(int id)
        {
            var cargoCompany = _cargoCompanyService.TGetById(id);
            return Ok(cargoCompany);
        }

        [HttpPost]
        public IActionResult AddCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            var value = ObjectMapper.Mapper.Map<CargoCompany>(createCargoCompanyDto);
            _cargoCompanyService.TInsert(value);
            return Ok("Kargo sirketi basariyla olsuturuldu");
        }

        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            var value = ObjectMapper.Mapper.Map<CargoCompany>(updateCargoCompanyDto);
            _cargoCompanyService.TUpdate(value);
            return Ok("Kargo sirketi basariyla guncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveCargoCompany(int id)
        {
            _cargoCompanyService.TDelete(id);
            return Ok("Kargo sirketi basariyla silindi");
        }
    }
}