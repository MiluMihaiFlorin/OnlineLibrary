using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Models.DBEntities;
using OnlineLibrary.Services.Interfaces;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace OnlineLibrary.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdminLoggedInController : Controller
	{
		private readonly ILogger<AdminLoggedInController> _logger;

        ICategoryService _categoryService;
		IAuthorService _authorService;
		IBookService _bookService;

		public AdminLoggedInController(ILogger<AdminLoggedInController> logger, ICategoryService categoryService, IAuthorService authorService, IBookService bookService)
		{
			_logger = logger;
			_categoryService = categoryService;
			_authorService = authorService;
			_bookService = bookService;
		}

		public IActionResult Dashbord()
		{
			ViewData["nrOfListedCategories"] = _categoryService.GetNumberOfListedCategories();
			ViewData["nrOfListedAuthors"] = _authorService.GetNumberOfListedAuthors(); 
			ViewData["nrOfListedBooks"] = _bookService.GetNumberOfListedBooks();
            return View();
		}

    }
}
