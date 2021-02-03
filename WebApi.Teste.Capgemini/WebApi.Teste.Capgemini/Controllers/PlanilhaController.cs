using Domain.Teste.Capgemini.Model;
using Microsoft.AspNetCore.Mvc;
using Services.Teste.Capgemini.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Teste.Capgemini.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanilhaController : ControllerBase
    {
        private readonly IplanilhaService _planilhaService;

        public PlanilhaController(IplanilhaService planilhaService)
        {
            _planilhaService = planilhaService; ;
        }
 
        // GET: api/<PlanilhaController>
        [HttpGet]
        public async Task<IEnumerable<ModelTabela1>> Get()
        {
            return await _planilhaService.Get();
        }

        // GET api/<PlanilhaController>/5
        [HttpGet("{id}")]
        public async Task<ModelTabela1> Get(int id)
        {
            return await _planilhaService.Get(id);
        }
    }
}
