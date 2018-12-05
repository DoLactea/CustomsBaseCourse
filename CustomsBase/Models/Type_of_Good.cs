using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomsBase.Models
{
    public class Type_of_Good
    {
        [Key]
        [Display(Name = "Goods ID")]
        public int Types_of_goodsID { get; set; }
        [Display(Name = "Goods Name")]
        public string Name { get; set; }
        [Display(Name = "Unit")]
        public string Unit { get; set; }
        [Display(Name = "Amount of duty")]
        public int Amount_of_duty { get; set; }
        public ICollection<Customs_werehouses> Customs_werehouses { get; set; }

    }
}







