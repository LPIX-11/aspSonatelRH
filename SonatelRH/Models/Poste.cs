using System;
using System.Collections.Generic;

namespace SonatelRH.Models
{
    public partial class Poste
    {
        public Poste()
        {
            Candidat = new HashSet<Candidat>();
        }

        public int IdPoste { get; set; }
        public string IntitulePoste { get; set; }
        public string SitePoste { get; set; }
        public string CompetenceRequise { get; set; }
        public DateTime PremierCommission { get; set; }
        public DateTime DeuxiemeCommission { get; set; }
        public int IdDirection { get; set; }
        public int IdTypeRecrutement { get; set; }

        public virtual Direction IdDirectionNavigation { get; set; }
        public virtual Typerecrutement IdTypeRecrutementNavigation { get; set; }
        public virtual ICollection<Candidat> Candidat { get; set; }
    }
}
