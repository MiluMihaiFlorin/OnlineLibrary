using Microsoft.AspNetCore.Mvc;

namespace OnlineLibrary.Controllers
{
	public class AdminLoggedInController : Controller
	{
		private readonly ILogger<AdminLoggedInController> _logger;

		public AdminLoggedInController(ILogger<AdminLoggedInController> logger)
		{
			_logger = logger;
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
