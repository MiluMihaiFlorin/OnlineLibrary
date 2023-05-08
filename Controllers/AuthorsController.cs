using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Models.DBEntities;
using OnlineLibrary.Services;
using OnlineLibrary.Services.Interfaces;

namespace OnlineLibrary.Controllers
{
    public class AuthorsController : Controller
    {        
        private IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {            
            _authorService = authorService;
        }

        // GET: Authors
        public async Task<IActionResult> Index(string searchString = "", int pg = 1, int pageSize = 5)
        {
            List<Author> data = _authorService.GetAllAuthors();
            if (!String.IsNullOrEmpty(searchString))
            {
                data = _authorService.GetBySearchCondition(searchString);
            }

            var pager = new Models.DBEntities.Pager(data.Count, pg, pageSize);
            this.ViewBag.Pager = pager;
            data = data.Skip((pg - 1) * pageSize).Take(pageSize).ToList();

            return _authorService.GetAllAuthors() != null ?
                          View(data) :
                          Problem("Entity set 'OnlineLibraryContext.Authors'  is null.");
        }

        // GET: Authors/Details/5
        public IActionResult Details(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var author =  _authorService.GetAuthor(id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }


        public IActionResult Create( Author author)
        {
            author.AuthorId = Guid.NewGuid();

            if (!ModelState.IsValid)
            {
                return View(author);
            }

            if (_authorService.AuthorExists(author.Name))
            {
                ModelState.AddModelError("Name", "There is already an author with this name!");
                return View(author);    
            }
            _authorService.CreateAuthor(author);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Edit(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var author = _authorService.GetAuthor(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Guid id, [Bind("AuthorId,Name")] Author author)
        {            
            if (ModelState.IsValid)
            {
                try
                {
                  _authorService.UpdateAuthor(author);                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(author);
            }
            
        }

        public IActionResult Delete(Guid id)
        {
            _authorService.DeleteAuthor(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
