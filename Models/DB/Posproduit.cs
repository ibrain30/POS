using System;
using System.Collections.Generic;

#nullable disable

namespace POS.Models.DB
{
    public partial class Posproduit
    {
        public Posproduit()
        {
            DetailsVentes = new HashSet<DetailsVente>();
            QuantProduits = new HashSet<QuantProduit>();
        }

        public int IdProd { get; set; }
        public string Designation { get; set; }
        public int IdCateg { get; set; }

        public virtual Categorie IdCategNavigation { get; set; }
        public virtual ICollection<DetailsVente> DetailsVentes { get; set; }
        public virtual ICollection<QuantProduit> QuantProduits { get; set; }
    }
}
