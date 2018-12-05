using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomsBase.Models
{
    public class Duti
    {
        [Key]
        [Display(Name = "Duty ID")]
        public int DutiesID { get; set; }
        [Display(Name = "First Name")]
        public int? Customs_agentID { get; set; }
        [Display(Name = "Goods Name")]
        public int? WerehouseID { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date receipt")]
        public DateTime Date_receipt { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date of payment")]
        public DateTime Date_of_payment { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date of goods call")]
        public DateTime Date_of_goods_call { get; set; }
        public Customs_agents Customs_agents { get; set; }
        public Customs_werehouses Customs_werehouses { get; set; }
       // public Type_of_Good Types_of_goods { get; set; }
    }
}
