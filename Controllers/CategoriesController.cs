using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Models.DBEntities;
using OnlineLibrary.Services.Interfaces;
using OnlineLibrary.Areas.Identity.Data;
using OnlineLibrary.Data;

namespace OnlineLibrary.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly OnlineLibraryContext _context;

        private ICategoryService _categoryService;

        public CategoriesController(OnlineLibraryContext context, ICategoryService categoryService)
        {
            _context = context;
            _categoryService = categoryService;
        }

        // GET: Categories
        public async Task<IActionResult> Index(string searchString = "",int pg= 1, int pageSize = 5)
        {
            List<Category> data = _categoryService.GetAllCategories();
            if (!String.IsNullOrEmpty(searchString))
            {
                data = _categoryService.GetBySearchCondition(searchString);
            }

            var pager = new Models.DBEntities.Pager(data.Count, pg, pageSize);

            this.ViewBag.Pager = pager;

            data = data.Skip((pg - 1)*pageSize).Take(pageSize).ToList();
            
            return _categoryService.GetAllCategories() != null ? 
                          View(data) :
                          Problem("Entity set 'OnlineLibraryContext.Categories'  is null.");
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var category = _categoryService.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        public IActionResult Create( Category category)
        {
            category.CategoryId = Guid.NewGuid();

            if (!ModelState.IsValid)
            {
                return View(category);
            }
            if(_categoryService.CategoryExists(category.Name))
            {
                ModelState.AddModelError("Name", "There is already a category with this name!");
            }
            _categoryService.CreateCategory(category);
            return RedirectToAction(nameof(Index));
        }

        // GET: Categories/Edit/5
        public IActionResult Edit(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var category = _categoryService.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Update(Guid id, [Bind("CategoryId,Name,IsActive")] Category category)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _categoryService.UpdateCategory(category);
                }
                catch (DbUpdateConcurrencyException)
                {
                        return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public IActionResult Delete(Guid id)
        {
            _categoryService.DeleteCategory(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
