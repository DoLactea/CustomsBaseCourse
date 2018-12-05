using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;
using CustomsBase.Models;

namespace CustomsBase.ViewModels.Customs_werehousesViewModel
{
    public class Customs_werehouseViewModel
    {
        [Display(Name = "Warehouse ID")]
        public int WerehouseID { get; set; }
        [Display(Name = "Goods Name")]
        public string Name { get; set; }
       
    }
}
