using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_DOS.Models
{
    public class Caddata
    {
        public int CodCur { get; set; }
        public string Turma { get; set; }
        public DateTime DataMov { get; set; }
        public string Motivo { get; set; }
        public string Mesano { get; set; }
        public float HoraRel { get; set; }
        public string Ativi { get; set; }
        public string Aula { get; set; }
        public string CodDis { get; set; }
        public string CodSub { get; set; }
        public string CodPro { get; set; }
    }
}
