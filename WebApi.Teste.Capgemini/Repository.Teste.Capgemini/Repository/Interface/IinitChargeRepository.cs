using Domain.Teste.Capgemini.Model;
using System.Collections.Generic;

namespace Repository.Teste.Capgemini.Repository.Interface
{
    public interface IinitChargeRepository
    {
        bool DataBaseRegisterChargePlan(List<ModelTabela1> plan);
    }
}
