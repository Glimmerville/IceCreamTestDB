using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IceCream.Models
{
    public class FlavorsModel
    {
        [Key]
        public int FlavorID { get; set; }

        public string Flavor { get; set; }

        [Display(Name = "Description")]
        public string FlavorDesc { get; set; }
        [Display(Name = "Limited Ed.")]
        public bool LimtedEd { get; set; }
        [Display(Name = "In Season")]
        public bool CurrentlyAvail { get; set; }
        [Display(Name ="Best Seller")]
        public bool BestSeller { get; set; }
        [Display(Name ="Contains Nuts")]
        public bool ContainsNuts { get; set; }

    }
}