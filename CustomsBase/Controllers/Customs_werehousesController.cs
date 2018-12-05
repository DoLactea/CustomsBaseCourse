using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CustomsBase.Models;
using CustomsBase.ViewModels;
using CustomsBase.ViewModels.Customs_werehousesViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CustomsBase.Controllers
{
    public class Customs_werehousesController : Controller
    {
        private CustomsContext db;

        public Customs_werehousesController(CustomsContext _db)
        {
            db = _db;
        }
        private Customs_werehouseViewModel _werehouse = new Customs_werehouseViewModel
        {
            Name = ""
        };
        [Authorize(Roles = "admin, user, moder")]
        public IActionResult Index(int? name, int page = 1, SortState sortOrder = SortState.WerehouseIDAsc)
        {
            int pageSize = 10;
            IQueryable<Customs_werehouses> source = db.Customs_werehouses.Include(d => d.Types_of_goods);
            if (name != null && name != 0)
                source = source.Where(p => p.Types_of_goods.Types_of_goodsID == name);
            switch (sortOrder)
            {
                case SortState.WerehouseIDDesc:
                    source = source.OrderByDescending(s => s.WerehouseID);
                    break;
                case SortState.NameAsc:
                    source = source.OrderBy(s => s.Types_of_goods.Name);
                    break;
                case SortState.NameDesc:
                    source = source.OrderByDescending(s => s.Types_of_goods.Name);
                    break;
            }
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            Customs_werehousesViewModel customsWerehouse = new Customs_werehousesViewModel
            {
                Customs_Werehouses = items,
                Customs_werehouseViewModel = _werehouse,
                PageViewModel = pageViewModel,
                SortViewModel = new Customs_werehousesSortViewModel(sortOrder),
                FilterViewModel = new Customs_werehousesFilterViewModel(db.Types_of_goods.ToList(), name)
            };
            return View(customsWerehouse);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var customscontext = db.Customs_werehouses.Include(c => c.Types_of_goods);
            var items = customscontext.Where(d => d.WerehouseID == id).ToList();
            var goods = new SelectList(db.Types_of_goods, "Types_of_goodsID", "Name", items.First().Types_of_goodsID);
            Customs_werehousesViewModel customsWerehouse = new Customs_werehousesViewModel
            {
                Customs_Werehouses = items,
                Customs_werehouseViewModel = _werehouse,
                Type_of_GoodsList = goods
            };
            return View(customsWerehouse);
        }
        [HttpPost]
        public IActionResult Edit(Customs_werehouses werehousis)
        {
            db.Customs_werehouses.Update(werehousis);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            var goods = new SelectList(db.Types_of_goods, "Types_of_goodsID", "Name");
            ViewBag.Types_of_goodsID = goods;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customs_werehouses werehousis)
        {
            db.Customs_werehouses.Add(werehousis);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            var customscontext = db.Customs_werehouses.Include(d => d.Types_of_goods);
            var items = customscontext.Where(d => d.WerehouseID == id).ToList();
            var goods = new SelectList(db.Types_of_goods, "Types_of_goodsID", "Name");
            Customs_werehouseViewModel werehouseView = new Customs_werehouseViewModel
            {
                WerehouseID = items.First().WerehouseID,
                Name = items.First().Types_of_goods.Name
            };
            Customs_werehousesViewModel werehousis = new Customs_werehousesViewModel
            {
                Customs_Werehouses = items,
                Customs_werehouseViewModel = _werehouse,
                Type_of_GoodsList = goods
            };
            if (items == null)
                return View("NotFound");
            else
                return View(werehousis);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var werehousis = db.Customs_werehouses.FirstOrDefault(d => d.WerehouseID == id);
                db.Customs_werehouses.Remove(werehousis);
                db.SaveChanges();
            }
            catch { }
            return RedirectToAction("index");
        }

        public IActionResult Details(int? id)
        {
            var customscontext = db.Customs_werehouses.Include(d => d.Types_of_goods);
            var items = customscontext.Where(d => d.WerehouseID == id).ToList();
            var goods = new SelectList(db.Types_of_goods, "Types_of_goodsID", "Name");

            Customs_werehouseViewModel werehouseView = new Customs_werehouseViewModel
            {
                WerehouseID = items.First().WerehouseID,
                Name = items.First().Types_of_goods.Name
            };
            Customs_werehousesViewModel werehousis = new Customs_werehousesViewModel
            {
                Customs_Werehouses = items,
                Customs_werehouseViewModel = _werehouse,
                Type_of_GoodsList = goods
            };
            if (items == null)
                return View("NotFound");
            else
                return View(werehousis);
        }
    }
}