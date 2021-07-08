using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WatchioOnlineShop.Models
{
    public class commande
    {
        public int Id { set; get; }
        [Required]
        public int nbre_article { set; get; }
        [Required]
        public double prix_total { set; get; }
        [Required]

        public virtual List<article> articles { set; get; } //heritage



    }
}
