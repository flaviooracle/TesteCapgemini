using AutoMapper;
using Domain.Teste.Capgemini.Model;
using Repository.Teste.Capgemini.DbContextCapgemini;
using Repository.Teste.Capgemini.Entity;
using Repository.Teste.Capgemini.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Teste.Capgemini.Repository
{
    public class PlanilhaRepository: IplanilhaRepository
    {
        private readonly CapgeminiContext _dB;
        public PlanilhaRepository(CapgeminiContext dB)
        {
            _dB = dB;
        }
        public async Task<IEnumerable<ModelTabela1>> Get()
        {
            return _dB.Tabela1.Select(p => Mapper.Map<ModelTabela1>(p));
        }

        public async Task<ModelTabela1> Get(int id)
        {
            return  Mapper.Map<ModelTabela1>(_dB.Tabela1
                .Where(row => row.Tabela1Id == id)
                .FirstOrDefault());
        }
    }
}
