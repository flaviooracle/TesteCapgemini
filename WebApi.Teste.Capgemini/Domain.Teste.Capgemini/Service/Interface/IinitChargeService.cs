using Domain.Teste.Capgemini.Contracts.Response;
using Domain.Teste.Capgemini.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Teste.Capgemini.Service.Interface
{
    public interface IinitChargeService
    {
        bool VerifyPlan(List<Tabela1> plan);
        Task<ChargeXls> ChargePlan(IFormFile file);
    }
}
