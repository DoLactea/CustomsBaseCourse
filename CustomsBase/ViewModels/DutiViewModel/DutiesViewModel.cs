using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomsBase.Models;
using CustomsBase.ViewModels.DutiViewModel;

namespace CustomsBase.ViewModels.DutiViewModel
{
    public class DutiesViewModel
    {
        public IEnumerable<Duti> Duties { get; set; }

        public DutiViewModel DutiViewModel { get; set; }

        public PageViewModel PageViewModel { get; set; }

        public SelectList Customs_AgentsList { get; set; }

        public SelectList Customs_WerehousesList { get; set; }

        public SelectList Type_of_GoodsList { get; set; }

        public DutiSortViewModel SortViewModel { get; set; }

        public DutiesFilterViewModel FilterViewModel { get; set; }
        
    }
}
