using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IceCream.Models
{
    public class IceCreamContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public IceCreamContext() : base("name=IceCreamContext")
        {
        }

        public System.Data.Entity.DbSet<IceCream.Models.FlavorsModel> FlavorsModels { get; set; }

        public System.Data.Entity.DbSet<IceCream.Models.CustomerModel> CustomerModels { get; set; }

        public System.Data.Entity.DbSet<IceCream.Models.FlavorToCustomerLink> FlavorToCustomerLinks { get; set; }

        public System.Data.Entity.DbSet<IceCream.Models.ConeModel> ConeModels { get; set; }

        public System.Data.Entity.DbSet<IceCream.Models.ClubModel> ClubModels { get; set; }
    }
}
