using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_DOS.Models
{
    public class CadastroAlunos_SJC
    {
        public int ID { get; set; }
        [Display(Name = "CPF")]
        public string NOCIC { get; set; }
        public string NOME { get; set; }
        public string SEXO { get; set; }
        [Display(Name = "ENDEREÇO")]
        public string ENDERECO { get; set; }
        public string CIDADE { get; set; }
        public string BAIRRO { get; set; }
        public string ESTADO { get; set; }
        public string CEP { get; set; }
        public string FONE { get; set; }
        public string PAI { get; set; }
        [Display(Name = "MÃE")]
        public string MAE { get; set; }
        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "DATA DE NASCIMENTO")]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime NASCIMENTO { get; set; }
        [Display(Name = "LOCAL DE NASCIMENTO")]
        public string LOCALNASC { get; set; }
        [Display(Name = "UF DE NASCIMENTO")]
        public string UFNASC { get; set; }
        public string RG { get; set; }
        [Display(Name = "ORGÃO")]
        public string ORGAO { get; set; }
        [Display(Name ="ESTADO DE EMISSÃO")]
        public string UFEMIS { get; set; }
        [Display(Name = "ESTADO CIVIL")]
        public string ESTADOCIVI { get; set; }
        [Display(Name = "PROFISSÃO")]
        public string PROFISSAO { get; set; }
        public string EMPRESA { get; set; }
        [Display(Name = "DEPARTAMENTO")]
        public float DEPTO { get; set; }
        public float CARGO { get; set; }
        public string RESPRH { get; set; }
        public string CURSOG { get; set; }
        public string FACULDADE { get; set; }
        public string ANO { get; set; }
        public float CIDG { get; set; }
        public string UFG { get; set; }
        public string FONEC { get; set; }
        public string RAMAL { get; set; }
        public float CELULAR { get; set; }
        public float FONE1 { get; set; }
        public float EMAIL { get; set; }
        [Display(Name = "NÚMERO DO CREA")]
        public float NROCREA { get; set; }
        public Cadalu Cadalu { get; set; }        
    }
}
