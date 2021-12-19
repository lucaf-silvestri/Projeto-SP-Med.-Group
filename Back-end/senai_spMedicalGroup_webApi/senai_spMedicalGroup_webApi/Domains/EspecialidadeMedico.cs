using System;
using System.Collections.Generic;

#nullable disable

namespace senai_spMedicalGroup_webApi.Domains
{
    public partial class EspecialidadeMedico
    {
        public EspecialidadeMedico()
        {
            Medicos = new HashSet<Medico>();
        }

        public short IdEspecialidadeMedico { get; set; }
        public string NomeEspecialidade { get; set; }
        public string DescricaoEspecialidade { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
