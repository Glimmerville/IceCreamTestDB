using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IceCream.Models
{
    public class ConeModel
    {
        [Key]
        public string ConeID { get; set; }
        [Display(Name = "Cone or Cup")]
        public string ConeStyleList { get; set; }

        //This property will hold all available cone types for selection
        //public IEnumerable<SelectListItem> Cones { get; set; }
        //it's really hard, I don't know if I can set it up; the tutorial is nuts.
    }
}