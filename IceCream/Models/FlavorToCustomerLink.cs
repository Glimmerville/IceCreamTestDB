using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IceCream.Models
{
    public class FlavorToCustomerLink
    {
        [Key]
        public int FlavorToCustomerLinkID { get; set; }

        //Foreign key from Customer
        public int CustomerID { get; set; }
        public CustomerModel CustomerLink { get; set; }

        //Foreign key from Flavors
        public int FlavorID { get; set; }
        public FlavorsModel FlavorLink {get; set;}

        //Special order info, since I guess this is an order!
        //add a model for Cone Style: waffle cone or sugar cone or cake cone or bowl

        public bool Sprinkles { get; set; }
        public bool ToGo { get; set; }

        //Foreign Key for cone styles
        public int ConeID { get; set; }
        public ConeModel ConeStyleLink { get; set; }
    }

}