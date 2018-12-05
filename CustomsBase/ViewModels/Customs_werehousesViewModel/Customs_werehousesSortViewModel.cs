using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomsBase.Models;

namespace CustomsBase.ViewModels.Customs_werehousesViewModel
{
    public class Customs_werehousesSortViewModel
    {
        public SortState WerehouseIDSort { get; private set; }
        public SortState NameSort { get; private set; }
        public SortState Current { get; private set; }

        public Customs_werehousesSortViewModel(SortState sortOrder)
        {
            WerehouseIDSort = sortOrder == SortState.WerehouseIDAsc ? SortState.WerehouseIDDesc : SortState.WerehouseIDAsc;
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            Current = sortOrder;
        }
    }
}
