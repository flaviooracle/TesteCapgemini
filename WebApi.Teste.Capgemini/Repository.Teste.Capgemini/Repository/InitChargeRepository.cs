using Repository.Teste.Capgemini.DbContextCapgemini;
using Repository.Teste.Capgemini.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Teste.Capgemini.Model;
using AutoMapper;
using Repository.Teste.Capgemini.Entity;

namespace Repository.Teste.Capgemini.Repository
{
    public class InitChargeRepository : IinitChargeRepository
    {
        private readonly CapgeminiContext _dB;
        public InitChargeRepository(CapgeminiContext dB)
        {
            _dB = dB;
        }

        public bool DataBaseRegisterChargePlan(List<ModelTabela1> plan)
        {
            Tabela1 novoItem = new Tabela1();
            try
            {
                foreach(ModelTabela1 item in plan)
                {
                    Tabela1 novo = new Tabela1();
                    novo = Mapper.Map<Tabela1>(item);
                    _dB.Tabela1.Add(novo);
                    _dB.SaveChanges();
                };

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }       
            
        }
    }
}
