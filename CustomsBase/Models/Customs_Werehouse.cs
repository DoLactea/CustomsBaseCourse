using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomsBase.Models
{
    public class Customs_werehouses
    {
        [Key]
        [Display(Name = "Warehouse ID")]
        public int WerehouseID { get; set; }
        [Display(Name = "Goods Name")]
        public int? Types_of_goodsID { get; set; }
        public Type_of_Good Types_of_goods { get; set; }
        public ICollection<Duti> Duties { get; set; }
    }
}


















