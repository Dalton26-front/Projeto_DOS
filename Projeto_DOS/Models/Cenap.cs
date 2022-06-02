using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_DOS.Models
{
    public class Cenap
    {
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set; }
        public float Valor_Parc { get; set; }
        public string V_Par_calc { get; set; }
        public float Vcto_Par { get; set; }
        public float Nro_Parcel { get; set; }
        public string Situacao { get; set; }
        public float Sit_Finan { get; set; }
        public float Parcen_Bol { get; set; }
        public string Nro_Tot_Pa { get; set; }
    }
}
