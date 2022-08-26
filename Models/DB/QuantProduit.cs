using System;
using System.Collections.Generic;

#nullable disable

namespace POS.Models.DB
{
    public partial class QuantProduit
    {
        public int IdQp { get; set; }
        public int IdProd { get; set; }
        public int Quantite { get; set; }

        public virtual Posproduit IdProdNavigation { get; set; }
    }
}
