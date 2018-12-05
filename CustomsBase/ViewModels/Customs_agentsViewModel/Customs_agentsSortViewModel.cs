using System;
using System.Threading.Tasks;
using CustomsBase.Models;

namespace CustomsBase.ViewModels.Customs_agentsViewModel
{
    public class Customs_agentsSortViewModel
    {
        public SortState Customs_agentIDSort { get; private set; }
        public SortState FirstNameSort { get; private set; }
        public SortState SecondNameSort { get; private set; }
        public SortState ServesSort { get; private set; }
        public SortState Current { get; private set; }

        public Customs_agentsSortViewModel(SortState sortOrder)
        {
            Customs_agentIDSort = sortOrder == SortState.Customs_agentIDAsc ? SortState.Customs_agentIDDesc : SortState.Customs_agentIDAsc;
            FirstNameSort = sortOrder == SortState.FirstNameAsc ? SortState.FirstNameDesc : SortState.FirstNameAsc;
            SecondNameSort = sortOrder == SortState.SecondNameAsc ? SortState.SecondNameDesc : SortState.SecondNameAsc;
            ServesSort = sortOrder == SortState.ServesAsc ? SortState.ServesDesc : SortState.ServesAsc;
            Current = sortOrder;
        }
    }
}
