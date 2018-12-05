using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomsBase.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CustomsBase.ViewModels.Customs_werehousesViewModel
{
    public class Customs_werehousesFilterViewModel
    {
        public Customs_werehousesFilterViewModel(List<Type_of_Good> names, int? name)
        {
            names.Insert(0, new Type_of_Good { Types_of_goodsID = 0, Name = "All" });
            Names = new SelectList(names, "Types_of_goodsID", "Name", names);
        }
        
        public SelectList Names { get; private set; }
        public int? SelectedName { get; private set; }
    }
}
