using System;
using System.ComponentModel.DataAnnotations;

namespace Projeto_DOS.Models
{
    public class Cadastro_Curso
    {
        public int ID { get; set; }
        [Display(Name = "Código do Curso:")]
        public string CodCur { get; set; }
        [Display(Name = "Descrição:")]
        public string Descricao { get; set; }
        [Display(Name ="Sigla:")]
        public string Sigla { get; set; }
        public string Ano { get; set; }
        [Display(Name = "Início:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime Inicio { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        [Display(Name ="Fim:")]
        public DateTime Fim { get; set; }
        [Display(Name ="Aluno:")]
        public string Aluno { get; set; }
        [Display(Name = "Carga Horária:")]
        public string CargaHor { get; set; }
        [Display(Name ="Apelido:")]
        public string Apelido { get; set; }
        [Display(Name = "Código Prmoção:")]
        public string CodPro { get; set; }
        [Display(Name = "Hora - 1:")]
        public string Hora1 { get; set; }
        [Display(Name = "Hpra - 2:")]
        public string Hora2 { get; set; }
        [Display(Name ="Valor:")]
        public float Valor { get; set; }
        [Display(Name ="Classe:")]
        public string Classe { get; set; }
    }
}
