using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Cliente
    {
        [Key]
        [StringLength(14)]
        public string CPF { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        public string RG { get; set; }
        public DateTime? DataExpedicao { get; set; }
        public string OrgaoExpedicao { get; set; }
        public string UF_Expedicao { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

    }
}