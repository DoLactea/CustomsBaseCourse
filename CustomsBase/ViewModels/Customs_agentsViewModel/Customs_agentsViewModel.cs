using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomsBase.Models;
using CustomsBase.ViewModels.Customs_agentsViewModel;

namespace CustomsBase.ViewModels.Customs_agentsViewModel
{
    public class Customs_agentsViewModel
    {
        public IEnumerable<Customs_agents> Customs_Agents { get; set; }
        public Customs_agents Customs_agents { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public Customs_agentsSortViewModel SortViewModel { get; set; }
        public Customs_agentsFilterViewModel FilterViewModel { get; set; }
    }
}
