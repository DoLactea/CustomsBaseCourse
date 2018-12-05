using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomsBase.Models;
using CustomsBase.ViewModels.Customs_werehousesViewModel;

namespace CustomsBase.ViewModels.Customs_werehousesViewModel
{
    public class Customs_werehousesViewModel
    {
        public IEnumerable<Customs_werehouses> Customs_Werehouses { get; set; }

        public Customs_werehouseViewModel Customs_werehouseViewModel { get; set; }

        public PageViewModel PageViewModel { get; set; }

        public SelectList Type_of_GoodsList { get; set; }

        public Customs_werehousesSortViewModel SortViewModel { get; set; }

        public Customs_werehousesFilterViewModel FilterViewModel { get; set; }

    }
}
