using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomsBase.Models;

namespace CustomsBase.ViewModels.Type_of_GoodViewModel
{
    public class Type_of_GoodSortViewModel
    {
        public SortState Types_of_goodsIDSort { get; private set; }
        public SortState NameSort { get; private set; }
        public SortState UnitSort { get; private set; }
        public SortState Amount_of_dutySort { get; private set; }
        public SortState Current { get; private set; }

        public Type_of_GoodSortViewModel(SortState sortOrder)
        {
            Types_of_goodsIDSort = sortOrder == SortState.Types_of_goodsIDAsc ? SortState.Types_of_goodsIDDesc : SortState.Types_of_goodsIDAsc;
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            UnitSort = sortOrder == SortState.UnitAsc ? SortState.UnitDesc : SortState.UnitAsc;
            Amount_of_dutySort = sortOrder == SortState.Amount_of_dutiAsc ? SortState.Amount_of_dutiDesc : SortState.Amount_of_dutiAsc;
            Current = sortOrder;
        }
    }
}
