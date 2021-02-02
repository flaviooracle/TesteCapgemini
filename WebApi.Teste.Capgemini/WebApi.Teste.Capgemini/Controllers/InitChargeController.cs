using Domain.Teste.Capgemini.Contracts.Response;
using Domain.Teste.Capgemini.Model;
using Domain.Teste.Capgemini.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Teste.Capgemini.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitChargeController : ControllerBase
    {
        private readonly IinitChargeService _iinitChargeService;

        public InitChargeController(IinitChargeService iinitChargeService)
        {
           _iinitChargeService = iinitChargeService; ;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            ChargeXls response = new ChargeXls();
            response = await _iinitChargeService.ChargePlan(file);

            if (response.aResult) { 
                return Ok(); 
            }
            else { 
                return BadRequest(); 
            }
            
        }
    }
}