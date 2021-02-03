using AutoMapper;
using Domain.Teste.Capgemini.Model;
using Repository.Teste.Capgemini.Entity;


namespace Repository.Teste.Capgemini.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {

            CreateMap<Tabela1, ModelTabela1>().ReverseMap();

        }
    }
}
