using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Models.DBEntities;
using OnlineLibrary.Services.Interfaces;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace OnlineLibrary.Controllers
{
	public class AdminLoggedInController : Controller
	{
		private readonly ILogger<AdminLoggedInController> _logger;

        ICategoryService _categoryService;

		public AdminLoggedInController(ILogger<AdminLoggedInController> logger, ICategoryService categoryService)
		{
			_logger = logger;
			_categoryService = categoryService;
		}

		public IActionResult Dashbord()
		{
			return View();
		}

        public IActionResult Categories()
        {
            return View();
        }
        public IActionResult AddCategory()
        {
            return View();
        }

        public IActionResult Authors()
        {
            return View();
        }
        public IActionResult Books()
        {
            return View();
        }
        public IActionResult IssueBooks()
        {
            return View();
        }
        public IActionResult RegisterStudents()
        {
            return View();
        }

    }
}
