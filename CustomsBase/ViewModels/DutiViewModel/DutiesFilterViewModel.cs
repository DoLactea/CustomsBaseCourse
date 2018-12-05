using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using CustomsBase.Models;
using System.Linq;
using System.Threading.Tasks;

namespace CustomsBase.ViewModels.DutiViewModel
{
    public class DutiesFilterViewModel
    {
        public DutiesFilterViewModel(List<Customs_agents> agents, List<Type_of_Good> names, int? agent, int? name)
        {
            agents.Insert(0, new Customs_agents { Customs_agentID = 0, FirstName = "All" });
            names.Insert(0, new Type_of_Good { Types_of_goodsID = 0, Name = "All" });
            Agents = new SelectList(agents, "Customs_agentID", "FirstName", agents);
            Names = new SelectList(names, "Types_of_goodsID", "Name", names);
        }
        public SelectList Agents { get; private set; }
        public SelectList Names { get; private set; }
        public int? SelectedAgent { get; private set; }
        public int? SelectedName { get; private set; }
    }
}
