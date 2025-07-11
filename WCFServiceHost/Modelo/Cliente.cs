using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;


    [DataContract]
    public class Cliente
    {
        [Key]
        [DataMember]
        [StringLength(14)]
        public string CPF { get; set; }

        [Required]
        [DataMember]
        [StringLength(100)]
        public string Nome { get; set; }

        [DataMember] public string RG { get; set; }
        [DataMember] public DateTime? DataExpedicao { get; set; }
        [DataMember] public string OrgaoExpedicao { get; set; }
        [DataMember] public string UF_Expedicao { get; set; }
        [DataMember] public DateTime? DataNascimento { get; set; }
        [DataMember] public string Sexo { get; set; }
        [DataMember] public string EstadoCivil { get; set; }
        [DataMember] public string CEP { get; set; }
        [DataMember] public string Logradouro { get; set; }
        [DataMember] public string Numero { get; set; }
        [DataMember] public string Complemento { get; set; }
        [DataMember] public string Bairro { get; set; }
        [DataMember] public string Cidade { get; set; }
        [DataMember] public string UF { get; set; }
    }

