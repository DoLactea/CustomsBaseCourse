using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomsBase.Models;

namespace CustomsBase.ViewModels.DutiViewModel
{
    public class DutiSortViewModel
    {
        public SortState DutiesIDSort { get; private set; }
        public SortState FirstNameSort { get; private set; }
        public SortState NameSort { get; private set; }
        public SortState Date_receiptSort { get; private set; }
        public SortState Date_of_paymentSort { get; private set; }
        public SortState Date_of_goods_callSort { get; private set; }
        public SortState Current { get; private set; }

        public DutiSortViewModel(SortState sortOrder)
        {
            DutiesIDSort = sortOrder == SortState.DutiesIDAsc ? SortState.DutiesIDDesc : SortState.DutiesIDAsc;
            FirstNameSort = sortOrder == SortState.FirstNameAsc ? SortState.FirstNameDesc : SortState.FirstNameAsc;
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            Date_receiptSort = sortOrder == SortState.Date_receiptAsc ? SortState.Date_receiptDesc : SortState.Date_receiptAsc;
            Date_of_paymentSort = sortOrder == SortState.Date_of_paymentAsc ? SortState.Date_of_paymentDesc : SortState.Date_of_paymentAsc;
            Date_of_goods_callSort = sortOrder == SortState.Date_of_goods_callAsc ? SortState.Date_of_goods_callDesc : SortState.Date_of_goods_callAsc;
            Current = sortOrder;
        }
    }
}
