using Domain.Teste.Capgemini.Model;
using Repository.Teste.Capgemini.Entity;
using Repository.Teste.Capgemini.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Teste.Capgemini.Service
{
    public class ChargeRepository : IinitChargeRepository
    {
        private readonly IinitChargeRepository _initChargeRepository;
        public ChargeRepository(IinitChargeRepository initChargeRepository)
        {
            _initChargeRepository = initChargeRepository;
        }
        public bool DataBaseRegisterChargePlan(List<ModelTabela1> plan)
        {
            return DataBaseRegisterChargePlan(plan);
        }
    }
}
