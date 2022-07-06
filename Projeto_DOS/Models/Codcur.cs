using System;
using System.ComponentModel.DataAnnotations;

namespace Projeto_DOS.Models
{
    public class Codcurso
    {
        public int ID { get; set; }
        [Display(Name = "Código do Curso")]
        public string CODCURSO { get; set; }
        public string TURMA { get; set; }
        public string LISTA { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime DATAMOV { get; set; }
        public string DISCIPLINA { get; set; }
        public string SUBDIS { get; set; }
        public string PROFESSOR { get; set; }
        [Display(Name = "Código da Disciplina")]
        public string CODDIS { get; set; }
        public string CODPRO { get; set; }
    }
}
