using AutoMapper;
using Domain.Teste.Capgemini.Model;
using Repository.Teste.Capgemini.Repository.Interface;
using Services.Teste.Capgemini.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Teste.Capgemini.Service
{
    public class PlanilhaService : IplanilhaService
    {
        private readonly IplanilhaRepository _planilhaRepository;
        public PlanilhaService(IplanilhaRepository planilhaRepository)
        {
            _planilhaRepository = planilhaRepository;
        }

        public async Task<IEnumerable<ModelTabela1>> Get()
        {
            return await _planilhaRepository.Get();
        }

        public async Task<ModelTabela1> Get(int id)
        {
            return await _planilhaRepository.Get(id);
        }
    }
}
