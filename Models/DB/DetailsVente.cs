using System;
using System.Collections.Generic;

#nullable disable

namespace POS.Models.DB
{
    public partial class DetailsVente
    {
        public int IdDetailVente { get; set; }
        public int IdProd { get; set; }
        public int Quantite { get; set; }
        public double Prix { get; set; }
        public double TotalDetailV { get; set; }
        public int IdVente { get; set; }

        public virtual Posproduit IdProdNavigation { get; set; }
        public virtual Vente IdVenteNavigation { get; set; }
    }
}
