using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_DOS.Models
{
    public class MovNota
    {
        public int ID { get; set; }
        public string CodCur { get; set; }
        public string Turma { get; set; }
        public string Lista { get; set; }
        public float Nota { get; set; }
    }
}
