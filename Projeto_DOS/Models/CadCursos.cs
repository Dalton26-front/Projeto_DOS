using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_DOS.Models
{
    public class CadCursos
    {
        public int ID { get; set; }
        public int CodCur { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public string Ano { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public string Aluno { get; set; }
        public string CargaHor { get; set; }
        public string Apelido { get; set; }
        public string CodPro { get; set; }
        public string Hora1 { get; set; }
        public string Hora2 { get; set; }
        public float Valor { get; set; }
        public string Classe { get; set; }
    }
}
