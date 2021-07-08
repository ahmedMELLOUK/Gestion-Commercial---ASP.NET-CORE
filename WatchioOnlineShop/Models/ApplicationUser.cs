using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WatchioOnlineShop.Models
{
    public class ApplicationUser:IdentityUser  //L'utilisateur herite du scafolding identity 
    {

        public String prenom { set; get; }

        public String nom { set; get; }

        public String user_type { set; get; }  //admin ou client

    }
}
