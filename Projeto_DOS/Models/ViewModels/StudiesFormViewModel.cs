using System.Collections.Generic;

namespace Projeto_DOS.Models.ViewModels
{
    public class StudiesFormViewModel
    {
        public Cadalu Cadalu { get; set; }
        public ICollection<Cadalu> Aluno { get; set; }
    }
}
