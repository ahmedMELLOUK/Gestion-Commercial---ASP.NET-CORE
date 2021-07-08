using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace WatchioOnlineShop.Models
{
    public class categorie
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Categorie")]

        public String name { set; get; }
        
    }
}
