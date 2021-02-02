using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Teste.Capgemini.Entity
{
    public class Tabela1
    {
        [Key]
        public int Tabela1Id { get; set; }
        [Required]
        public DateTime DataEntrega { get; set; }
        [Required]
        [MaxLength(50)]
        [Column("NomeProduto", TypeName = "nvarchar(50)")]
        public string NomeProduto { get; set; }
        [Required]
        public int Quantidade { get; set; }
        [Required]
        public double ValorUnitario { get; set; }
    }
}
