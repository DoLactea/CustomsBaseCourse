using System;
using System.Collections.Generic;
using System.Linq;
using CustomsBase.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomsBase.ViewModels;
using CustomsBase.ViewModels.Customs_agentsViewModel;
using Microsoft.AspNetCore.Authorization;

namespace CustomsBase.Controllers
{
    public class Customs_agentsController : Controller
    {
        private CustomsContext db;

        public Customs_agentsController(CustomsContext _db)
        {
            db = _db;
        }
        [Authorize(Roles = "admin, user, moder")]
        public IActionResult Index(string firstName, int page = 1, SortState sortOrder = SortState.Customs_agentIDAsc)
        {
            int pageSize = 10;
            IQueryable<Customs_agents> source = db.Customs_agents;
            if(!String.IsNullOrEmpty(firstName))
            {
                source = source.Where(p => p.FirstName.Contains(firstName));
            }
            switch (sortOrder)
            {
                case SortState.Customs_agentIDDesc:
                    source = source.OrderByDescending(s => s.Customs_agentID);
                    break;
                case SortState.FirstNameAsc:
                    source = source.OrderBy(s => s.FirstName);
                    break;
                case SortState.FirstNameDesc:
                    source = source.OrderByDescending(s => s.FirstName);
                    break;
                case SortState.SecondNameAsc:
                    source = source.OrderBy(s => s.SecondName);
                    break;
                case SortState.SecondNameDesc:
                    source = source.OrderByDescending(s => s.SecondName);
                    break;
                case SortState.ServesAsc:
                    source = source.OrderBy(s => s.Serves);
                    break;
                case SortState.ServesDesc:
                    source = source.OrderByDescending(s => s.Serves);
                    break;
            }
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            //Customs_agentsFilterViewModel customs_AgentsFilterViewModel = new Customs_agentsFilterViewModel(firstName);
            Customs_agentsViewModel customsAgents = new Customs_agentsViewModel
            {
                Customs_Agents = items,
                PageViewModel = pageViewModel,
                SortViewModel = new Customs_agentsSortViewModel(sortOrder),
                FilterViewModel = new Customs_agentsFilterViewModel(firstName)
                
            };
           //var customsAgents = db.Customs_agents.ToList();
            return View(customsAgents);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customs_agents customsAgent)
        {
            db.Customs_agents.Add(customsAgent);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Customs_agents customsAgent = db.Customs_agents.Find(id);
            if (customsAgent != null)
            {
                db.Customs_agents.Remove(customsAgent);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Customs_agents customsAgent = db.Customs_agents.Find(id);
            if (customsAgent != null)
            {
                return View(customsAgent);
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Customs_agents customsAgent = db.Customs_agents.Find(id);
            if (customsAgent != null)
            {
                return View(customsAgent);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Customs_agents customsAgent)
        {
            db.Entry(customsAgent).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}