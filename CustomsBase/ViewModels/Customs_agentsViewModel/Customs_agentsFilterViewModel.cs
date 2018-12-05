using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomsBase.ViewModels.Customs_agentsViewModel
{
    public class Customs_agentsFilterViewModel
    {
        public Customs_agentsFilterViewModel(string firstName)
        {
            SelectedfirstName = firstName;
        }
        public string SelectedfirstName { get; private set; }

    }
}
