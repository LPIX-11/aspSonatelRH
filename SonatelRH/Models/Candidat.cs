﻿using System;
using System.Collections.Generic;

namespace SonatelRH.Models
{
    public partial class Candidat
    {
        public int IdCandidat { get; set; }
        public string NomCandidat { get; set; }
        public string PrenomCandidat { get; set; }
        public DateTime DateNaissance { get; set; }
        public string LieuNaissance { get; set; }
        public DateTime? DatePriseFonction { get; set; }
        public int IdPoste { get; set; }

        public virtual Poste IdPosteNavigation { get; set; }
    }
}
