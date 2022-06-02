using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_DOS.Models
{
    public class CeNovos
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set; }
        public float Valor_Par { get; set; }
        public string V_Parc_Calc { get; set; }
        public float Vcto_Par { get; set; }
        public float Nro_Parcel { get; set; }
        public string Situacao { get; set; }
        public string Sit_Finan { get; set; }
        public float Parcen_Bol { get; set; }
        public float Nro_Tot_Pa { get; set; }
    }
}
