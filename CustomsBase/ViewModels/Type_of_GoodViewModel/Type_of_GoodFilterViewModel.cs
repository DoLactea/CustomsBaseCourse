using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomsBase.ViewModels.Type_of_GoodViewModel
{
    public class Type_of_GoodFilterViewModel
    {
        public Type_of_GoodFilterViewModel(string Name)
        {
            SelectedName = Name;
        }
        public string SelectedName { get; private set; }
    }
}
