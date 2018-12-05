using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CustomsBase.Models;
using CustomsBase.ViewModels;
using CustomsBase.ViewModels.DutiViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CustomsBase.Controllers
{
    public class DutiController : Controller
    {
        private CustomsContext db;

        public DutiController(CustomsContext _db)
        {
            db = _db;
        }
        private DutiViewModel _duti = new DutiViewModel
        {
            FirstName = "",
            Name = ""
        };
        [Authorize(Roles = "admin, user, moder")]
        public IActionResult Index(int? agent, int? name, int page = 1, SortState sortOrder = SortState.DutiesIDAsc)
        {
            int pageSize = 10;
            IQueryable<Duti> source = db.Duties.Include(d => d.Customs_agents)
                .Include(d => d.Customs_werehouses.Types_of_goods);
            if (agent != null && agent != 0)
                source = source.Where(p => p.Customs_agentID == agent);
            if (name != null && name != 0)
                source = source.Where(p => p.Customs_werehouses.Types_of_goods.Types_of_goodsID == name);
            switch (sortOrder)
            {
                case SortState.DutiesIDDesc:
                    source = source.OrderByDescending(s => s.DutiesID);
                    break;
                case SortState.FirstNameAsc:
                    source = source.OrderBy(s => s.Customs_agents.FirstName);
                    break;
                case SortState.FirstNameDesc:
                    source = source.OrderByDescending(s => s.Customs_agents.FirstName);
                    break;
                case SortState.NameAsc:
                    source = source.OrderBy(s => s.Customs_werehouses.Types_of_goods.Name);
                    break;
                case SortState.NameDesc:
                    source = source.OrderByDescending(s => s.Customs_werehouses.Types_of_goods.Name);
                    break;
                case SortState.Date_receiptAsc:
                    source = source.OrderBy(s => s.Date_receipt);
                    break;
                case SortState.Date_receiptDesc:
                    source = source.OrderByDescending(s => s.Date_receipt);
                    break;
                case SortState.Date_of_paymentAsc:
                    source = source.OrderBy(s => s.Date_of_payment);
                    break;
                case SortState.Date_of_paymentDesc:
                    source = source.OrderByDescending(s => s.Date_of_payment);
                    break;
                case SortState.Date_of_goods_callAsc:
                    source = source.OrderBy(s => s.Date_of_goods_call);
                    break;
                case SortState.Date_of_goods_callDesc:
                    source = source.OrderByDescending(s => s.Date_of_goods_call);
                    break;
            }
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            DutiesViewModel duti = new DutiesViewModel
            {
                Duties = items,
                DutiViewModel = _duti,
                PageViewModel = pageViewModel,
                SortViewModel = new DutiSortViewModel(sortOrder),
                FilterViewModel = new DutiesFilterViewModel(db.Customs_agents.ToList(), db.Types_of_goods.ToList(), agent, name)
            };
            return View(duti);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var customscontext = db.Duties.Include(c => c.Customs_agents).Include(d => d.Customs_werehouses.Types_of_goods);
            var items = customscontext.Where(d => d.DutiesID == id).ToList();
            var agents = new SelectList(db.Customs_agents, "Customs_agentID", "FirstName", items.First().Customs_agentID);
            var goods = new SelectList(db.Types_of_goods, "Types_of_goodsID", "Name", items.First().Customs_werehouses.Types_of_goodsID);
            DutiesViewModel duti = new DutiesViewModel
            {
                Duties = items,
                DutiViewModel = _duti,
                Customs_AgentsList = agents,
                Type_of_GoodsList = goods
            };
            return View(duti);
        }
        [HttpPost]
        public IActionResult Edit(Duti dutis)
        {
            db.Duties.Update(dutis);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            var agents = new SelectList(db.Customs_agents, "Customs_agentID", "FirstName");
            var goods = new SelectList(db.Types_of_goods, "Types_of_goodsID", "Name");
            ViewBag.Customs_agentID = agents;
            ViewBag.Types_of_goodsID = goods;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Duti dutis)
        {
            db.Duties.Add(dutis);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            var customscontext = db.Duties.Include(c => c.Customs_agents).Include(d => d.Customs_werehouses.Types_of_goods);
            var items = customscontext.Where(d => d.DutiesID == id).ToList();
            var agents = new SelectList(db.Customs_agents, "Customs_agentID", "FirstName");
            var goods = new SelectList(db.Types_of_goods, "Types_of_goodsID", "Name");
            DutiViewModel dutiView = new DutiViewModel
            {
                DutiesID = items.First().DutiesID,
                FirstName = items.First().Customs_agents.FirstName,
                Name = items.First().Customs_werehouses.Types_of_goods.Name,
                Date_receipt = items.First().Date_receipt,
                Date_of_payment = items.First().Date_of_payment,
                Date_of_goods_call = items.First().Date_of_goods_call
            };
            DutiesViewModel dutis = new DutiesViewModel
            {
                Duties = items,
                DutiViewModel = _duti,
                Customs_AgentsList = agents,
                Type_of_GoodsList = goods
            };
            if (items == null)
                return View("NotFound");
            else
                return View(dutis);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var dutis = db.Duties.FirstOrDefault(d => d.DutiesID == id);
                db.Duties.Remove(dutis);
                db.SaveChanges();
            }
            catch { }
            return RedirectToAction("index");
        }

        public IActionResult Details(int? id)
        {
            var customscontext = db.Duties.Include(c => c.Customs_agents).Include(d => d.Customs_werehouses.Types_of_goods);
            var items = customscontext.Where(d => d.DutiesID == id).ToList();
            var agents = new SelectList(db.Customs_agents, "Customs_agentID", "FirstName");
            var goods = new SelectList(db.Types_of_goods, "Types_of_goodsID", "Name");

            DutiViewModel dutiView = new DutiViewModel
            {
                DutiesID = items.First().DutiesID,                          
                FirstName = items.First().Customs_agents.FirstName,
                Name = items.First().Customs_werehouses.Types_of_goods.Name,
                Date_receipt = items.First().Date_receipt,
                Date_of_payment = items.First().Date_of_payment,
                Date_of_goods_call = items.First().Date_of_goods_call
            };
            DutiesViewModel dutis = new DutiesViewModel                      
            {
                Duties = items,
                DutiViewModel = _duti,
                Customs_AgentsList = agents,
                Type_of_GoodsList = goods
            };
            if (items == null)
                return View("NotFound");
            else
                return View(dutis);
        }
    }
}