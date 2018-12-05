using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CustomsBase.Models;
using Microsoft.EntityFrameworkCore;
using CustomsBase.ViewModels;
using CustomsBase.ViewModels.Type_of_GoodViewModel;
using Microsoft.AspNetCore.Authorization;

namespace CustomsBase.Controllers
{
    public class Type_of_GoodController : Controller
    {
        private CustomsContext db;

        public Type_of_GoodController(CustomsContext _db)
        {
            db = _db;
        }
        [Authorize(Roles = "admin, user, moder")]
        public IActionResult Index(string Name, int page = 1, SortState sortOrder = SortState.Types_of_goodsIDAsc)
        {
            int pageSize = 10;
            IQueryable<Type_of_Good> source = db.Types_of_goods;
            if(!String.IsNullOrEmpty(Name))
            {
                source = source.Where(p => p.Name.Contains(Name));
            }
            switch (sortOrder)
            {
                case SortState.Types_of_goodsIDDesc:
                    source = source.OrderByDescending(s => s.Types_of_goodsID);
                    break;
                case SortState.NameAsc:
                    source = source.OrderBy(s => s.Name);
                    break;
                case SortState.NameDesc:
                    source = source.OrderByDescending(s => s.Name);
                    break;
                case SortState.UnitAsc:
                    source = source.OrderBy(s => s.Unit);
                    break;
                case SortState.UnitDesc:
                    source = source.OrderByDescending(s => s.Unit);
                    break;
                case SortState.Amount_of_dutiAsc:
                    source = source.OrderBy(s => s.Amount_of_duty);
                    break;
                case SortState.Amount_of_dutiDesc:
                    source = source.OrderByDescending(s => s.Amount_of_duty);
                    break;
            }
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            Type_of_GoodViewModel ToGS = new Type_of_GoodViewModel
            {
                Type_Of_Goods = items,
                PageViewModel = pageViewModel,
                SortViewModel = new Type_of_GoodSortViewModel(sortOrder),
                FilterViewModel = new Type_of_GoodFilterViewModel(Name)
            };
            return View(ToGS);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Type_of_Good tog)
        {
            db.Types_of_goods.Add(tog);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Type_of_Good tog = db.Types_of_goods.Find(id);
            if (tog != null)
            {
                db.Types_of_goods.Remove(tog);
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
            Type_of_Good tog = db.Types_of_goods.Find(id);
            if (tog != null)
            {
                return View(tog);
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
            Type_of_Good tog = db.Types_of_goods.Find(id);
            if (tog != null)
            {
                return View(tog);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Type_of_Good tog)
        {
            db.Entry(tog).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}