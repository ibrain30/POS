using System;
using System.Collections.Generic;

#nullable disable

namespace POS.Models.DB
{
    public partial class Vente
    {
        public Vente()
        {
            DetailsVentes = new HashSet<DetailsVente>();
        }

        public int IdVente { get; set; }
        public string NumVente { get; set; }
        public string NomClient { get; set; }
        public string TelClient { get; set; }
        public string AdrClient { get; set; }
        public DateTime DateVente { get; set; }
        public string MethodPayment { get; set; }
        public double? Total { get; set; }

        public virtual ICollection<DetailsVente> DetailsVentes { get; set; }
    }
}
