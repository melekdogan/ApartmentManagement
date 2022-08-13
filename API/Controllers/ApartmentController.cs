using Business.Abstract;
using Configurations.Filters.Logs;
using DTOs.Apartment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService _apartmentService;

        public ApartmentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }
        [LogFilter]
        [HttpPost("AddApartment")]
        public IActionResult Add(CreateApartmentRequest request)
        {
            var response = _apartmentService.Add(request);
            return Ok(response);
        }

        [HttpPut("UpdateApartment")]
        public IActionResult Update(UpdateApartmentRequest request)
        {
            var response = _apartmentService.Update(request);
            return Ok(response);
        }
        
        [HttpDelete("DeleteApartment")]
        public IActionResult Delete(DeleteApartmentRequest request)
        {
            var response = _apartmentService.Delete(request);
            return Ok(response);
        }

        [HttpGet("ListAllApartments")]
        public IActionResult GetAll()
        {
            var responseData = _apartmentService.GetAll();
            return Ok(responseData);
        }
    }
}
