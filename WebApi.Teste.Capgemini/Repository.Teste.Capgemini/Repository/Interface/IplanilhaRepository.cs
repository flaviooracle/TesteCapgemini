using Domain.Teste.Capgemini.Model;
using Repository.Teste.Capgemini.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Teste.Capgemini.Repository.Interface
{
    public interface IplanilhaRepository
    {
        Task<IEnumerable<ModelTabela1>> Get();
        Task<ModelTabela1> Get(int id);
    }
}
