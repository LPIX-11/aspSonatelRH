using System;
using System.Collections.Generic;

namespace SonatelRH.Models
{
    public partial class Direction
    {
        public Direction()
        {
            Poste = new HashSet<Poste>();
        }

        public int IdDirection { get; set; }
        public string CodeDirection { get; set; }
        public string LibelleDirection { get; set; }

        public virtual ICollection<Poste> Poste { get; set; }
    }
}
