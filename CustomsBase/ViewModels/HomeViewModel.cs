using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomsBase.Models;
using CustomsBase.ViewModels.DutiViewModel;

namespace CustomsBase.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Customs_agents> Customs_Agents { get; set; }
        public IEnumerable<Customs_werehouses> Customs_Werehouses { get; set; }
        public IEnumerable<Type_of_Good> Type_Of_Goods { get; set; }
        public IEnumerable<Duti> Duties { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public DutiesViewModel DutiesViewModel { get; set; }
    }
}
