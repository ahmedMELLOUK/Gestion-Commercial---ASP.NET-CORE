using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace WatchioOnlineShop.Models
{
    public class article
    {
        //-------ATTRIBUTS DES ARTICLES-------------//
        public int Id { set; get; }
        [Required]
        public String name { set; get; }  //nom d'article
        [Required]
        public bool disponible { set; get; }  //disponibilite d'article
        public String image { set; get; }
        [Required]
        public int quantite { set; get; }  //quantite d'articles
        [Required]
        public double prix { set; get; }  //prix

        //-------------FOREIGN KEYS----------------//

        public int id_categorie { set; get; }
        [ForeignKey("id_categorie")]

        public categorie categorie { set; get; }



        
    }
}
