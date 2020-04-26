using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using probnyKol.DTOs.Requests;
using probnyKol.DTOs.Responses;
using probnyKol.Models;
using probnyKol.Services;

namespace probnyKol.Controllers
{
    [ApiController]
    [Route("api/badanko")]
    public class BadankoController : ControllerBase
    {
        
  private IAnimalDbService _service;

        public BadankoController(IAnimalDbService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult BadankoAnimal(BadankoAnimalReguest request)
        {

            _service.BadankoAnimal(request);
            var response = new BadankoAnimalResponse();
            //response.Name = an.Name;
            //...

            return Ok(response);
        }
       
    }
}