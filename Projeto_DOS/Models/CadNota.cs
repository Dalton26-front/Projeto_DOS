using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_DOS.Models
{
    public class CadNota
    {
        [Key]
        public int CODCURSO { get; set; }
        public string TURMA { get; set; }
        public string LISTA { get; set; }
        public DateTime DATAMOV { get; set; }
        public string DISCIPLINA { get; set; }
        public string SUBDIS { get; set; }
        public string PROFESSOR { get; set; }
        public string CODDIS { get; set; }
        public string CODPRO { get; set; }
    }
}
