using Domain.Teste.Capgemini.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Teste.Capgemini.Service.Interface
{
    public interface IplanilhaService
    {
        Task<IEnumerable<ModelTabela1>> Get();
        Task<ModelTabela1> Get(int id);
    }
}
