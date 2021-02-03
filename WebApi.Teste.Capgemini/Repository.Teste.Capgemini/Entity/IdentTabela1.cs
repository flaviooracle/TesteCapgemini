using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Teste.Capgemini.Entity
{
    public class IdentTabela1
    {
        [Key]
        public int IdentTabela1Id { get; set; }
        public DateTime DataImportacao { get; set; }
        public int NumeroItens { get; set; }
        public DateTime MenorDataEntrega { get; set; }
        public double ValorTotalImport { get; set; }
    }
}
