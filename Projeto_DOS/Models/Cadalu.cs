using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_DOS.Models
{
    public class Cadalu
    { 
        public int ID { get; set; }
        [Display(Name = "Nº Ficha:")]
        public string NFicha { get; set; }
        [Display(Name = "CPF:")]
        public string NoCIC { get; set; }
        [Display(Name = "Código do Curso:")]
        public string CodCuR { get; set; }
        [Display(Name ="Turma:")]
        public string Turma { get; set; }
        [Display(Name = "Código do Aluno:")]
        public string CodAlu { get; set; }
        [Display(Name ="Nome:")]
        public string Nome { get; set; }
        [Display(Name ="Apelido:")]
        public string Apelido { get; set; }
        [Display(Name = "Forma de Pagamento:")]
        public string Fpag { get; set; }
        [Display(Name ="Dia:")]
        public string Dia { get; set; }
        [Display(Name = "Currículo:")]
        public string Curri { get; set; }
        [Display(Name = "Certificado:")]
        public string Certi { get; set; }
        [Display(Name = "Histórico:")]
        public string Histo { get; set; }
        [Display(Name ="CIC:")]
        public string CIC { get; set; }
        [Display(Name ="RG:")]
        public string RG { get; set; }
        [Display(Name ="Crea:")]
        public string Crea { get; set; }
        [Display(Name ="Contrato:")]
        public string Contrato { get; set; }
        [Display(Name ="Foto:")]
        public string Foto { get; set; }
        [Display(Name = "Em Dia:")]
        public string EmDia { get; set; }
        [Display(Name ="Situação:")]
        public string Status { get; set; }
        [Display(Name ="Lista:")]
        public string Lista { get; set; }
        [Display(Name ="Carta:")]
        public string Carta { get; set; }
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        [Display(Name = "Data de Inicio:")]
        public string DataInc { get; set; }
        [Display(Name ="Situação-2:")]
        public string Status1 { get; set; }
        //public ICollection<CadastroAlunos_SJC> CadastroAlunos_SJCs { get; set; } = new List<CadastroAlunos_SJC>(); // RECEBE UMA COLEÇÃO DE ALUNOS 
        public Cadalu()
        {
        }
        
    }
}
