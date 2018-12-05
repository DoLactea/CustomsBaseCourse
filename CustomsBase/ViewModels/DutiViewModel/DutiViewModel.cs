using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace CustomsBase.ViewModels.DutiViewModel
{
    public class DutiViewModel
    {
        [Display(Name = "Duty ID")]
        public int DutiesID { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Goods Name")]
        public string Name { get; set; }
        [Display(Name = "Date receipt")]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "1/1/1996", "1/1/2020")]
        public System.DateTime Date_receipt { get; set; }
        [Display(Name = "Date of payment")]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "1/1/1996", "1/1/2020")]
        public System.DateTime Date_of_payment { get; set; }
        [Display(Name = "Date of goods call")]
        [DataType(DataType.Date)]
        public System.DateTime Date_of_goods_call { get; set; }
    }
}
