using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_DOS.Models
{
    public class CadCurso
    {
        public int ID { get; set; }
        public string CodCur { get; set; }
        public float Turma { get; set; }
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public string Ano { get; set; }
        public string CodPro { get; set; }
        public string Repres { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public DateTime FimReal { get; set; }
        public string Valor { get; set; }
        public float AbonoD { get; set; }
        public float AbonoJ { get; set; }
        public string QtadeDis { get; set; }
        public string Faval { get; set; }
        public string Fechado { get; set; }
        public string CodAlu { get; set; }
        public float Madia { get; set; }
    }
}
