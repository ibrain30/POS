using System;
using System.Collections.Generic;

#nullable disable

namespace POS.Models.DB
{
    public partial class Utilisateur
    {
        public int IdUtil { get; set; }
        public string Identifiant { get; set; }
        public string MotDePasse { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
    }
}
