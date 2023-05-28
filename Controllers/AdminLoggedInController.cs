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
		IUserService _userService;
		ILoanService _loanService;

		public AdminLoggedInController(ILogger<AdminLoggedInController> logger, ICategoryService categoryService, IAuthorService authorService, IBookService bookService, IUserService userService, ILoanService loanService)
		{
			_logger = logger;
			_categoryService = categoryService;
			_authorService = authorService;
			_bookService = bookService;
			_userService = userService;
			_loanService = loanService;
		}

		public IActionResult Dashbord()
		{
			ViewData["nrOfListedCategories"] = _categoryService.GetNumberOfListedCategories();
			ViewData["nrOfListedAuthors"] = _authorService.GetNumberOfListedAuthors(); 
			ViewData["nrOfListedBooks"] = _bookService.GetNumberOfListedBooks();
			ViewData["nrOfUsers"] = _userService.GetNumberOfUsers();
			ViewData["nrOfLoans"] = _loanService.GetNumberOfLoans();
            return View();
		}

    }
}
