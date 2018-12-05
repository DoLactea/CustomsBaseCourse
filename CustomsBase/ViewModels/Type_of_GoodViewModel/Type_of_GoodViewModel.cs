using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomsBase.Models;

namespace CustomsBase.ViewModels.Type_of_GoodViewModel
{
    public class Type_of_GoodViewModel
    {
        public IEnumerable<Type_of_Good> Type_Of_Goods { get; set; }
        public Type_of_Good Type_Of_Good { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public Type_of_GoodSortViewModel SortViewModel { get; set; }
        public Type_of_GoodFilterViewModel FilterViewModel { get; set; }
    }
}
