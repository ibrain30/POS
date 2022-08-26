using System;
using System.Collections.Generic;

#nullable disable

namespace POS.Models.DB
{
    public partial class Categorie
    {
        public Categorie()
        {
            Posproduits = new HashSet<Posproduit>();
        }

        public int IdCateg { get; set; }
        public string NomCateg { get; set; }
        public int? Statu { get; set; }

        public virtual ICollection<Posproduit> Posproduits { get; set; }
    }
}
