using System;
using System.Collections.Generic;

namespace SonatelRH.Models
{
    public partial class Typerecrutement
    {
        public Typerecrutement()
        {
            Poste = new HashSet<Poste>();
        }

        public int IdTypeRecrutement { get; set; }
        public string LibelleTypeRecrutement { get; set; }

        public virtual ICollection<Poste> Poste { get; set; }
    }
}
