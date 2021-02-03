using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Teste.Capgemini.Contracts.Response
{
    public class ChargeXls
    {
        public bool aResult { get; set; }
        public List<Erro> erros { get; set; }
    }

    public class Erro
    {
        public int linha { get; set; }
        public string coluna { get; set; }
        public string ex { get; set; }
    }
}
